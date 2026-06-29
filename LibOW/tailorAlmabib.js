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
  '001',
  '003',
  '005',
  '035',
  '040',
  '050',
  '060',
  '082',
  '090',
  '85*',
  '86*',
  '9**',   // remove all 9xx tags
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

function modifyLeader(oldLeader) {

  var ldr = oldLeader;
  
  if (ldr.length > 17) {
    ldr = ldr.replace(/^.{6}/, "______");
    ldr = ldr.replace(/^(.{8}).{9}/, "$1________");
    ldr = ldr.replace(/^(.{16}) /, "$1^");
    ldr = ldr.replace(/^(.{17}).{6}/, "$1______");

   }
  return ldr;
}


// ------------------------------------
// 3. PROCESS ITEMS
//    STEP 1: EDIT VALUES
//    STEP 2: APPLY EXCLUDE / INCLUDE
// ------------------------------------
const newItems = items.map(item => {
  const data = item.json;

  if (!data.alma) {
    return item; // nothing to do
  }

  // Make a shallow copy of datafield so we don't mutate the original array reference
  let fields = data.alma.datafield.map(df => ({ ...df }));

  let cfields = data.alma.controlfield.map(cf => ({ ...cf }));

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

  for (const cf of cfields) {
    if (cf.$?.tag === '008') {
        if (cf._.length > 37) {
          cf._ = cf._.replace(/^.{6}/, "______");
          cf._ = cf._.replace(/^(.{19}).{16}/, "$1________________");
          cf._ = cf._.replace(/^(.{38}).{2}/, "$1__");
      }
    }
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

  const filteredControl = cfields.filter(cf => {
    const tag = cf.$?.tag;
    if (!tag) return true; // keep if no tag for safety
    return !tagIsExcluded(tag);
    
  });

  // HANDLE CONTROL FIELDS
  if (data.alma.leader[0]) {
     data.alma.leader[0] = modifyLeader(data.alma.leader[0]);
 }
 

  // Write back the modified + filtered datafield array
  data.alma.datafield = filteredFields;
  data.alma.controlfield = filteredControl;

  return { json: data };
});

return newItems;