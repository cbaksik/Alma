// n8n Code node (JavaScript)

// ===============================
// 1. CONFIGURATION
// ===============================

// --- 1a. Leader modification ---
// Supply a function that takes the old leader string and returns the new one.
function modifyLeader(oldLeader) {
  if (typeof oldLeader !== 'string') return oldLeader;

  // EXAMPLE: force position 17 to ' ' (just an example tweak).
  // Adjust to whatever MARC leader rule you need.
  const chars = oldLeader.split('');
  if (chars.length > 17) {
    chars[17] = ' ';
  }
  return chars.join('');
}


// --- 1b. Exclude rules by tag + indicators ---
// Any rule that matches a field will cause that field to be excluded.
//
// - tag: exact tag string (e.g. "650")
// - ind1 / ind2: indicator value, or null/undefined to ignore that indicator
//
// Examples below:
//  - Remove any 650 with 2nd indicator = "7"
//  - Remove any 758 field regardless of indicators
const EXCLUDE_BY_TAG_AND_INDICATORS = [
  { tag: '650', ind1: null, ind2: '6' },
  { tag: '758', ind1: null, ind2: null },
  { tag: '029', ind1: null, ind2: null },
  { tag: '040', ind1: null, ind2: null },
  { tag: '050', ind1: null, ind2: null },
  { tag: '060', ind1: null, ind2: null },
  { tag: '336', ind1: null, ind2: null },
  { tag: '337', ind1: null, ind2: null },
  { tag: '338', ind1: null, ind2: null },
  { tag: '082', ind1: null, ind2: null },
  { tag: '090', ind1: null, ind2: null },
];


// --- 1c. Exclude rules by subfield content ---
// Any rule that matches a field will cause that field to be excluded.
//
// - tagPattern: string or regex for the field tag (e.g., "650" or /^65\d$/)
// - code: subfield code to check (e.g. "2", "1", "0")
// - valuePattern: string or regex checked against subfield._
//
// Examples below:
//  - Any field with subfield: code=2 and value containing "fast"
//  - Any field with subfield: code=1 and value starting with "https://id.oclc.org"
const EXCLUDE_BY_SUBFIELD = [
  { tagPattern: /.*/, code: '2', valuePattern: /fast/ },
  { tagPattern: /.*/, code: '1', valuePattern: /^https:\/\/id\.oclc\.org/ },
];


// ===============================
// 2. HELPER FUNCTIONS
// ===============================

function matchesTagIndicatorRule(df, rule) {
  if (!df || !df.tag) return false;
  if (df.tag !== rule.tag) return false;
  if (rule.ind1 != null && df.ind1 !== rule.ind1) return false;
  if (rule.ind2 != null && df.ind2 !== rule.ind2) return false;
  return true;
}

function matchesSubfieldRule(df, rule) {
  if (!df || !df.tag) return false;

  // Match tag pattern
  const tagPattern = rule.tagPattern;
  const tagMatches =
    typeof tagPattern === 'string'
      ? df.tag === tagPattern
      : tagPattern instanceof RegExp
        ? tagPattern.test(df.tag)
        : true;

  if (!tagMatches) return false;

  // Normalize subfield(s) to array
  const sfs = Array.isArray(df.subfield)
    ? df.subfield
    : df.subfield
      ? [df.subfield]
      : [];

  return sfs.some(sf => {
    if (!sf || sf.code !== rule.code || typeof sf._ !== 'string') return false;

    const vp = rule.valuePattern;
    if (typeof vp === 'string') {
      return sf._ === vp;
    } else if (vp instanceof RegExp) {
      return vp.test(sf._);
    }
    return false;
  });
}

function fieldShouldBeExcluded(df) {
  // Rule set 1: Tag + indicator rules
  if (EXCLUDE_BY_TAG_AND_INDICATORS.some(rule => matchesTagIndicatorRule(df, rule))) {
    return true;
  }

  // Rule set 2: Subfield content rules
  if (EXCLUDE_BY_SUBFIELD.some(rule => matchesSubfieldRule(df, rule))) {
    return true;
  }

  return false;
}


// ===============================
// 3. PROCESS ITEMS
// ===============================

const newItems = items.map(item => {
  const data = item.json;

  if (!data.oclc) return item;

  const oclc = { ...data.oclc };

  // --- Remove namespace ---
  if (oclc.xmlns) {
    delete oclc.xmlns;
  }

  // --- Modify leader ---
  if (oclc.leader) {
    oclc.leader = modifyLeader(oclc.leader);
  }

  // --- Filter datafield(s) ---
  if (Array.isArray(oclc.datafield)) {
    oclc.datafield = oclc.datafield.filter(df => !fieldShouldBeExcluded(df));
  }

  // (Optionally also filter controlfield by similar rules; right now we keep all)

  return {
    json: {
      ...data,
      oclc,
    },
  };
});

return newItems;