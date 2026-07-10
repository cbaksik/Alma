// n8n Code node (JavaScript)

// ------------------------------------
// 1. CONFIGURE YOUR TAG / SUBFIELD FILTERS HERE
// ------------------------------------

// Tags you do NOT want (any matching datafield or controlfield will be removed)
// Supports "*" wildcards:
//   "9**"  =>  900–999
//   "90*"  =>  900–909
//   "035"  =>  exactly 035
const EXCLUDE_TAGS = [
  '001',
  '003',
  '005',
  '010',
  '014',
  '015',
  '024',
  '028',
  '029',
  '035',
  '037',
  '040',
  '042',
  '050',
  '060',
  '066',
  '072',
  '080',
  '082',
  '090',
  '098',
  '336',
  '337',
  '338',
  '690',
  '691',
  '693',
  '695',
  '758',
  '776',
  '85*',
  '86*',
  '9**',   // remove all 9xx tags
];

// Exclude any datafield that has a subfield with code "5"
const EXCLUDE_IF_SUBFIELD_5_EXISTS = true;

// Exclude any datafield that has subfield $2 with one of these values
// (comparison is case-sensitive; change to lower-case compare if needed)
const EXCLUDE_CODE2_VALUES = ['fast','gnd', 'cash', 'rvm','swd','jhpk'];

// (Optional) If you instead want to define tags to KEEP and drop everything else,
// uncomment and use this, and set USE_INCLUDE_MODE = true.
// const INCLUDE_TAGS = ['100', '245', '260', '300'];

// If true, we keep only INCLUDE_TAGS and drop others.
// If false, we drop only EXCLUDE_TAGS and keep others.
const USE_INCLUDE_MODE = false;


// ------------------------------------
// 2. HELPERS: wildcard match "9**", "90*"
// ------------------------------------
function wildcardMatch(pattern, tag) {
  // Escape regex metacharacters except *
  const escaped = pattern.replace(/[-/\\^$+?.()|[\]{}]/g, '\\$&');
  const regexStr = '^' + escaped.replace(/\*/g, '.*') + '$';
  const regex = new RegExp(regexStr);
  return regex.test(tag);
}

function tagIsExcluded(tag) {
  return EXCLUDE_TAGS.some(pat => wildcardMatch(pat, tag));
}

// If you use include mode instead:
function tagIsIncluded(tag, includePatterns) {
  return includePatterns.some(pat => wildcardMatch(pat, tag));
}

// ---------- NEW: subfield helpers ----------

// Normalize alma subfields to an array (handles both array and single object)
function getSubfields(df) {
  if (!df || df.subfield == null) return [];
  return Array.isArray(df.subfield) ? df.subfield : [df.subfield];
}

// Does this field have a subfield with a given code?
function hasSubfieldCode(df, code) {
  const sfs = getSubfields(df);
  return sfs.some(sf => sf.$?.code === code);
}

// Does this field have subfield $2 with value in EXCLUDE_CODE2_VALUES?
function hasExcludedCode2Value(df) {
  if (!EXCLUDE_CODE2_VALUES || EXCLUDE_CODE2_VALUES.length === 0) return false;
  const sfs = getSubfields(df);
  return sfs.some(sf => {
    if (sf.$?.code !== '2' || typeof sf._ !== 'string') return false;
    return EXCLUDE_CODE2_VALUES.includes(sf._);
  });
}

// Combined subfield-based exclusion
function shouldExcludeBySubfields(df) {
  if (EXCLUDE_IF_SUBFIELD_5_EXISTS && hasSubfieldCode(df, '5')) {
    return true;
  }
  if (hasExcludedCode2Value(df)) {
    return true;
  }
  return false;
}

// Combined tag indicator based exclusion
// if this returns true than that df is not included in final array
function shouldExcludeByTagIndicators(df) {
  var topic = df.$?.tag;
  var topic = topic.substring(0,1);
  if ( topic === '6' && ((df.$?.ind2 === '1') || (df.$?.ind2 === '3') || (df.$?.ind2 === '4') || (df.$?.ind2 === '5') || (df.$?.ind2 === '6'))) {
    return true;
  }
  return false;
}

// ------------------------------------
// 3. PROCESS ITEMS
//    STEP 1: EDIT VALUES
//    STEP 2: APPLY EXCLUDE / INCLUDE + SUBFIELD RULES
// ------------------------------------
const newItems = items.map(item => {
  const data = item.json;

  if (!data.alma) {
    return item; // nothing to do
  }

  // Make shallow copies so we don't mutate original array references
  let fields = data.alma.datafield.map(df => ({ ...df }));
  let cfields = data.alma.controlfield.map(cf => ({ ...cf }));

  // ------------------------------------
  // STEP 1: EDIT VALUES FIRST
  //  - tag = 300 -> replace "p." with "pages" in subfield a
  // ------------------------------------
  for (const df of fields) {
    if (df.$?.tag === '300' && Array.isArray(df.subfield)) {
      for (const sf of df.subfield) {
        if (sf.$?.code === 'a' && typeof sf._ === 'string') {
          // Replace all occurrences of "p." with "pages"
          sf._ = sf._.replace(/p\./g, 'pages');
        }
      }
	 for (const sf of df.subfield) {
        if (sf.$?.code === 'b' && typeof sf._ === 'string') {
          sf._ = sf._.replace(/ill\./g, 'illustrations');
        }
      }
    }

    // Add more edit rules here if needed, e.g.:
    // if (df.$?.tag === '245') { ... }
  }


  // ------------------------------------
  // STEP 2: FILTER FIELDS (EXCLUDE / INCLUDE + SUBFIELD RULES)
  // ------------------------------------
  const filteredFields = fields.filter(df => {
    const tag = df.$?.tag;
    if (!tag) return true; // keep if no tag for safety

    // First apply tag-based include/exclude logic
    let keep;
    if (USE_INCLUDE_MODE) {
      // keep only tags that match INCLUDE_TAGS (uncomment INCLUDE_TAGS above)
      keep = tagIsIncluded(tag, INCLUDE_TAGS);
    } else {
      // drop tags that match EXCLUDE_TAGS
      keep = !tagIsExcluded(tag);
    }
    if (!keep) return false;

    // Then apply subfield-based exclusions
    if (shouldExcludeBySubfields(df)) {
      return false;
    }
    // Then apply tag and ind based exclusions
    if (shouldExcludeByTagIndicators(df)) {
      return false;
    }

    return true;
  });

  const filteredControl = cfields.filter(cf => {
    const tag = cf.$?.tag;
    if (!tag) return true; // keep if no tag for safety
    // Only tag-based rules apply to controlfields
    return !tagIsExcluded(tag);
  });


  // Write back the modified + filtered arrays
  data.alma.datafield = filteredFields;
  data.alma.controlfield = filteredControl;

  return { json: data };
});

return newItems;