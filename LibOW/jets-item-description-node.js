// 1. Pull the captions dictionary out of the first item from the previous node
const captions = $('Captions array').first().json.global_captions;

const results = [];

// 2. Process every incoming item in the unified workflow
for (const item of $input.all()) {
  const inputJSON = item.json;
  
  // Clone the cleanData so we can safely attach new fields to it
  const data = JSON.parse(JSON.stringify(inputJSON.cleanData));
  
  // Get language for this specific row (fallback to English if missing)
  const langCode = inputJSON.language || "eng";
  const langDict = captions[langCode] || captions["eng"];
  
  // Parse the prefixes from this specific row's serial_caption
  const prefixMap = {};
  if (inputJSON.serial_caption && inputJSON.serial_caption.subfield) {
	for (const sf of inputJSON.serial_caption.subfield) {
		let code = sf["$"].code;
		let prefix = String(sf["_"]).trimEnd(); // Trims trailing spaces right here!
		
		// Rule: If enclosed in parentheses, ignore the prefix
		if (prefix.startsWith("(") && prefix.endsWith(")")) {
		prefix = "";
		}
		prefixMap[code] = prefix;
		
	} 
  }

// Now that the loop is totally finished, check specific codes exactly ONCE
// if caption ends in period, don't add space, whereas if it's an entire word we want a space before the number
['a', 'b', 'c', 'd'].forEach(key => {
  if (prefixMap[key] && !prefixMap[key].endsWith('.')) {
    prefixMap[key] += ' ';
  }
});
 // --- ENUMERATION FORMATTING ---
  
  // Helper function to process standard prefixes and '+' ordinals
  const formatEnum = (val, prefix) => {
    if (!val) return null;
    prefix = prefix || "";
    
    // Check if the prefix is flagged for an ordinal
    if (prefix.startsWith('+')) {
      let cleanPrefix = prefix.substring(1); // Strip the '+' sign
      let suffix = "";
      
      // If the language dictionary has an ordinal section, calculate the suffix
      if (langDict.ordinal) {
        suffix = langDict.ordinal[val] || langDict.ordinal.default || "";
      }
      
      // Note: By default this outputs "Prefix + Number + Suffix" (e.g. "ser. 1st")
      // If your standard requires the number FIRST (e.g. "1st ser."), 
      // you can swap the return to: return val + suffix + cleanPrefix;
      return val + suffix + cleanPrefix;
    }
    
    // If no '+', just return the standard prefix and value
    return prefix + val;
  };

  const enums = [];
  if (data.enum_a) enums.push(formatEnum(data.enum_a, prefixMap['a']));
  if (data.enum_b) enums.push(formatEnum(data.enum_b, prefixMap['b']));
  if (data.enum_c) enums.push(formatEnum(data.enum_c, prefixMap['c']));
  if (data.enum_d) enums.push(formatEnum(data.enum_d, prefixMap['d']));
  
  const enumString = enums.join(":");
  
  // --- CHRONOLOGY FORMATTING ---
  const chrons = [];
  
  if (data.chron_i) {
    chrons.push((prefixMap['i'] || "") + data.chron_i);
  }
  
if (data.chron_j) {
    let jVal = String(data.chron_j);
    let yVal = prefixMap['y'] || "";
    
    // Check if subfield 'y' starts with 'pm' or 'ps', and chron_j contains a slash
    if ((yVal.startsWith("pm") || yVal.startsWith("ps")) && jVal.includes("/")) {
      // Split the values (e.g. "04/05"), translate each one independently, and rejoin them with the slash
      jVal = jVal.split("/").map(part => langDict[part] || part).join("/");
    } else if (langDict[jVal]) {
      // Standard translation for single values
      jVal = langDict[jVal];
    }
    
    chrons.push((prefixMap['j'] || "") + jVal);
  }
  
  let chronString = chrons.join(":");
  
  if (data.chron_k) {
    chronString += (chronString ? " " : "") + (prefixMap['k'] || "") + data.chron_k;
  }
  
  // --- COMBINE INTO FINAL DESCRIPTION FIELD ---
  let description = enumString;
  if (chronString) {
    description += `(${chronString})`;
  }

  // Check if description_override exists and is not empty
  if (data.description_override && String(data.description_override).trim() !== "") {
    data.description_field = data.description_override;
  } else {
    data.description_field = description;
  }
  
  // --- ATTACH EXTRAS TO THE OUTPUT ---
  data.prefixMap = prefixMap;
    
  // Push the enriched cleanData object into our results array
  results.push({ json: data });
}

// 3. Return the newly built results list
return results;