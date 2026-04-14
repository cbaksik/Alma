const captions = {
  "eng": {
    "name": "English",
    "01": "Jan.", "02": "Feb.", "03": "Mar.", "04": "Apr.",
    "05": "May", "06": "June", "07": "July", "08": "Aug.",
    "09": "Sept.", "10": "Oct.", "11": "Nov.", "12": "Dec.",
    "21": "Spring", "22": "Summer", "23": "Fall", "24": "Winter"
  },
  "bel": {
    "name": "Belorusian",
    "01": "studz.", "02": "liut.", "03": "sak./mar.", "04": "kras.",
    "05": "trav.", "06": "cherv.", "07": "lip.", "08": "zhniven'",
    "09": "veras.", "10": "kastr.", "11": "list.", "12": "snezh.",
    "21": "Viasna", "22": "Leta", "23": "Vosen'", "24": "Zima"
  }
};

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

// Now that the loop is totally finished, check 'b' exactly ONCE
  if (prefixMap['b'] && !prefixMap['b'].endsWith('.')) {
    prefixMap['b'] += ' ';
  }
  
  // --- ENUMERATION FORMATTING ---
  const enums = [];
  if (data.enum_a) enums.push((prefixMap['a'] || "") + data.enum_a);
  if (data.enum_b) enums.push((prefixMap['b'] || "") + data.enum_b);
  if (data.enum_c) enums.push((prefixMap['c'] || "") + data.enum_c);
  if (data.enum_d) enums.push((prefixMap['d'] || "") + data.enum_d);
  
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