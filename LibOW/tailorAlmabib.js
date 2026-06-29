// n8n Code node (JavaScript)

// ------------------------------------
// 1. CONFIGURE YOUR TAG FILTERS HERE
// ------------------------------------

// Tags you do NOT want (any matching datafield will be removed)
// Supports "*" wildcards:
//   "9**"  =>  900–999
//   "90*"  =>  900–909
//   "035"  =>  exactly 035
const EXCLUDE_TAGS = [
  '9**',   // remove all 9xx tags
  '035',
  '005',
  '003',
  '040',
  '050',
  '060',
  '082',
  // '035', // example: remove 035 as well
];

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


// ------------------------------------
// 3. PROCESS ITEMS
//    STEP 1: EDIT VALUES
//    STEP 2: APPLY EXCLUDE / INCLUDE
// ------------------------------------
const newItems = items.map(item => {
  const data = item.json;

  if (!data.alma || !Array.isArray(data.alma.datafield)) {
    return item; // nothing to do
  }

  // Make a shallow copy of datafield so we don't mutate the original array reference
  let fields = data.alma.datafield.map(df => ({ ...df }));

  // ------------------------------------
  // STEP 1: EDIT VALUES FIRST
  //  - tag = 300 -> replace "p." with "pages" in subfield a
  //  (Adjust this block for any other transformations you need)
  // ------------------------------------
  for (const df of fields) {
    if (df.$?.tag === '300' && Array.isArray(df.subfield)) {
      for (const sf of df.subfield) {
        if (sf.$?.code === 'a' && typeof sf._ === 'string') {
          // Replace all occurrences of "p." with "pages"
          sf._ = sf._.replace(/p\./g, 'pages');
        }
      }
    }

    // Add more edit rules here if needed, e.g.:
    // if (df.$?.tag === '245') { ... }
  }

  // ------------------------------------
  // STEP 2: FILTER FIELDS (EXCLUDE / INCLUDE)
  // ------------------------------------
  const filteredFields = fields.filter(df => {
    const tag = df.$?.tag;
    if (!tag) return true; // keep if no tag for safety

    if (USE_INCLUDE_MODE) {
      // keep only tags that match INCLUDE_TAGS (uncomment INCLUDE_TAGS above)
      return tagIsIncluded(tag, INCLUDE_TAGS);
    } else {
      // drop tags that match EXCLUDE_TAGS
      return !tagIsExcluded(tag);
    }
  });

  // Write back the modified + filtered datafield array
  data.alma.datafield = filteredFields;

  return { json: data };
});

return newItems;