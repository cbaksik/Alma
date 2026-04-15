// keep this variable in sync with source file: captions_latin_script.json
// originally populated with data from https://web.library.yale.edu/cataloging/months
// and also https://static-prod.lib.princeton.edu/cams/katmandu/reference/seasons.html
const captions = {
	"eng": {
		"name": "English",
		"01": "Jan.",
		"02": "Feb.",
		"03": "Mar.",
		"04": "Apr.",
		"05": "May",
		"06": "June",
		"07": "July",
		"08": "Aug.",
		"09": "Sept.",
		"10": "Oct.",
		"11": "Nov.",
		"12": "Dec.",
		"21": "Spring",
		"22": "Summer",
		"23": "Fall",
		"24": "Winter",
		"ordinal": {
			"default": "th",
			"1": "st",
			"2": "nd",
			"3": "rd"
		}
	},
	"ara": {
		"name": "Arabic",
		"01": "Yan.",
		"02": "Fibr.",
		"03": "Mār.",
		"04": "Ibr.",
		"05": "Māyū",
		"06": "Yūn.",
		"07": "Yūl.",
		"08": "Agh.",
		"09": "Sibt.",
		"10": "Ukt.",
		"11": "Nūf.",
		"12": "Dīs.",
		"21": "rabīʻ",
		"22": "ṣayf",
		"23": "kharīf",
		"24": "shitāʼ",
		"ordinal": {
			"default": "."
		}
	},
	"arm": {
		"name": "Armenian",
		"01": "Hunu.",
		"02": "Pʻetr.",
		"03": "Mart",
		"04": "April",
		"05": "Mayis",
		"06": "Hunis",
		"07": "Hulis",
		"08": "Ōg'",
		"09": "Sept.",
		"10": "Hokt.",
		"11": "Noy.",
		"12": "Dekt.",
		"21": "garun",
		"22": "amaṛ",
		"23": "ashun",
		"24": "dzmeṛ",
		"ordinal": {
			"default": "."
		}
	},
	"bel": {
		"name": "Belorusian",
		"01": "studz.",
		"02": "liut.",
		"03": "sak./mar.",
		"04": "kras.",
		"05": "trav.",
		"06": "cherv.",
		"07": "lip.",
		"08": "zhniven'",
		"09": "veras.",
		"10": "kastr.",
		"11": "list.",
		"12": "snezh.",
		"21": "viasna",
		"22": "leto",
		"23": "vosen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"bos": {
		"name": "Bosnian",
		"01": "jan.",
		"02": "feb.",
		"03": "mart",
		"04": "april",
		"05": "maj",
		"06": "juni",
		"07": "juli",
		"08": "aug.",
		"09": "sept.",
		"10": "okt.",
		"11": "nov.",
		"12": "dec.",
		"21": "proljeće",
		"22": "ljeto",
		"23": "jesen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"bul": {
		"name": "Bulgarian",
		"01": "ian.",
		"02": "fevr.",
		"03": "mart",
		"04": "april",
		"05": "mai",
		"06": "iuni",
		"07": "iuli",
		"08": "avg.",
		"09": "sept.",
		"10": "okt.",
		"11": "noem.",
		"12": "dek.",
		"21": "prolet",
		"22": "liato",
		"23": "esen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"hrv": {
		"name": "Croatian",
		"01": "sijec.",
		"02": "velj.",
		"03": "ozuj.",
		"04": "trav.",
		"05": "svib.",
		"06": "lip.",
		"07": "srp.",
		"08": "kol.",
		"09": "ruj.",
		"10": "list.",
		"11": "stud.",
		"12": "pros.",
		"21": "prolece",
		"22": "ljeto",
		"23": "jesen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"cze": {
		"name": "Czech",
		"01": "led.",
		"02": "ún.",
		"03": "břez.",
		"04": "dub.",
		"05": "květ.",
		"06": "červ.",
		"07": "červen.",
		"08": "srp.",
		"09": "září",
		"10": "říj.",
		"11": "list.",
		"12": "pros.",
		"21": "jaro",
		"22": "léto",
		"23": "podzim",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"dan": {
		"name": "Danish",
		"01": "jan.",
		"02": "febr.",
		"03": "marts",
		"04": "april",
		"05": "maj",
		"06": "juni",
		"07": "juli",
		"08": "aug.",
		"09": "sept.",
		"10": "okt.",
		"11": "nov.",
		"12": "dec.",
		"21": "forår",
		"22": "sommer",
		"23": "efterår",
		"24": "vinter",
		"ordinal": {
			"default": "."
		}
	},
	"dut": {
		"name": "Dutch",
		"01": "jan.",
		"02": "feb.",
		"03": "maart",
		"04": "apr.",
		"05": "mei",
		"06": "juni",
		"07": "juli",
		"08": "aug.",
		"09": "sept.",
		"10": "oct./okt.",
		"11": "nov.",
		"12": "dec.",
		"21": "lente",
		"22": "zomer",
		"23": "herfst",
		"24": "winter",
		"ordinal": {
			"default": "e",
			"1": "ste",
			"8": "ste"
		}
	},
	"est": {
		"name": "Estonian",
		"01": "jaan.",
		"02": "veebr.",
		"03": "märts",
		"04": "apr.",
		"05": "mai",
		"06": "juuni",
		"07": "juuli",
		"08": "aug.",
		"09": "sept.",
		"10": "okt.",
		"11": "nov.",
		"12": "dets.",
		"21": "kevad",
		"22": "suvi",
		"23": "sügis",
		"24": "talv",
		"ordinal": {
			"default": "."
		}
	},
	"fre": {
		"name": "French",
		"01": "janv.",
		"02": "févr.",
		"03": "mars",
		"04": "avril",
		"05": "mai",
		"06": "juin",
		"07": "juil.",
		"08": "août",
		"09": "sept.",
		"10": "oct.",
		"11": "nov.",
		"12": "déc.",
		"21": "printemps",
		"22": "été",
		"23": "automne",
		"24": "hiver",
		"ordinal": {
			"default": "e",
			"1": "re"
		}
	},
	"ger": {
		"name": "German",
		"01": "Jan./Jän.",
		"02": "Feb.",
		"03": "März",
		"04": "Apr.",
		"05": "Mai",
		"06": "Juni",
		"07": "Juli",
		"08": "Aug.",
		"09": "Sept.",
		"10": "Okt.",
		"11": "Nov.",
		"12": "Dez.",
		"21": "Frühling",
		"22": "Sommer",
		"23": "Herbst",
		"24": "Winter",
		"ordinal": {
			"default": "."
		}
	},
	"gre": {
		"name": "Greek, Modern",
		"01": "Ian.",
		"02": "Phevr.",
		"03": "Mart.",
		"04": "Apr.",
		"05": "Maios",
		"06": "Ioun.",
		"07": "Ioul.",
		"08": "Aug.",
		"09": "Sept.",
		"10": "Okt.",
		"11": "Noem.",
		"12": "Dek.",
		"21": "anoixis",
		"22": "theros",
		"23": "phthinoporon",
		"24": "cheimon",
		"ordinal": {
			"default": "."
		}
	},
	"hun": {
		"name": "Hungarian",
		"01": "jan.",
		"02": "feb.",
		"03": "márc.",
		"04": "ápr.",
		"05": "máj.",
		"06": "jun.",
		"07": "jul.",
		"08": "aug.",
		"09": "szept.",
		"10": "okt.",
		"11": "nov.",
		"12": "dec.",
		"21": "tavasz",
		"22": "nyár",
		"23": "osz",
		"24": "tél",
		"ordinal": {
			"default": "."
		}
	},
	"ind": {
		"name": "Indonesian",
		"01": "Jan./Djan.",
		"02": "Peb.",
		"03": "Mrt.",
		"04": "Apr.",
		"05": "Mei/Mai",
		"06": "Juni/Djuni",
		"07": "Juli/Djuli",
		"08": "Ag.",
		"09": "Sept.",
		"10": "Okt.",
		"11": "Nop.",
		"12": "Des.",
		"21": "musim semi",
		"22": "musim panas",
		"23": "musim gugur",
		"24": "musim dingin",
		"ordinal": {
			"default": ""
		}
	},
	"ita": {
		"name": "Italian",
		"01": "genn.",
		"02": "febbr.",
		"03": "mar.",
		"04": "apr.",
		"05": "magg.",
		"06": "giugno",
		"07": "luglio",
		"08": "ag.",
		"09": "sett.",
		"10": "ott.",
		"11": "nov.",
		"12": "dic.",
		"21": "primavera",
		"22": "estate",
		"23": "autunno",
		"24": "inverno",
		"ordinal": {
			"default": "º"
		}
	},
	"lat": {
		"name": "Latin",
		"01": "Ian.",
		"02": "Febr.",
		"03": "Mart.",
		"04": "Apr",
		"05": "Mai.",
		"06": "Iun.",
		"07": "Iul.",
		"08": "Aug.",
		"09": "Sept.",
		"10": "Oct.",
		"11": "Nov.",
		"12": "Dec.",
		"21": "ver",
		"22": "aestas",
		"23": "autumnus",
		"24": "hiems",
		"ordinal": {
			"default": "."
		}
	},
	"lav": {
		"name": "Latvian",
		"01": "jan.",
		"02": "feb.",
		"03": "marts",
		"04": "apr.",
		"05": "maijs",
		"06": "junijs",
		"07": "julijs",
		"08": "aug.",
		"09": "sept.",
		"10": "okt.",
		"11": "nov.",
		"12": "dec.",
		"21": "pavasaris",
		"22": "vasara",
		"23": "rudens",
		"24": "zìema",
		"ordinal": {
			"default": "."
		}
	},
	"lit": {
		"name": "Lithuanian",
		"01": "Saus.",
		"02": "vas.",
		"03": "kovas",
		"04": "bal.",
		"05": "geg.",
		"06": "birz",
		"07": "liepa",
		"08": "rugp.",
		"09": "rugs.",
		"10": "spalis",
		"11": "lapkr.",
		"12": "gr.",
		"21": "pavasaris",
		"22": "vasara",
		"23": "ruduo",
		"24": "ziema",
		"ordinal": {
			"default": "."
		}
	},
	"may": {
		"name": "Malaysian",
		"01": "Jan.",
		"02": "Feb.",
		"03": "Mac",
		"04": "Apr.",
		"05": "Mei",
		"06": "Jun",
		"07": "Julai",
		"08": "Og",
		"09": "Sept.",
		"10": "Okt.",
		"11": "Nov.",
		"12": "Dis.",
		"21": "musim bunga",
		"22": "musim panas",
		"23": "musim luruh",
		"24": "musim sejuk",
		"ordinal": {
			"default": ""
		}
	},
	"nor": {
		"name": "Norwegian",
		"01": "jan.",
		"02": "febr.",
		"03": "mars",
		"04": "april",
		"05": "mai",
		"06": "juni",
		"07": "juli",
		"08": "aug.",
		"09": "sept.",
		"10": "okt.",
		"11": "nov.",
		"12": "des.",
		"ordinal": {
			"default": "."
		}
	},
	"pol": {
		"name": "Polish",
		"01": "stycz.",
		"02": "luty",
		"03": "mar.",
		"04": "kwiec.",
		"05": "maj",
		"06": "czerw.",
		"07": "lip.",
		"08": "sierp.",
		"09": "wrzes.",
		"10": "pazdz.",
		"11": "listop.",
		"12": "grudz.",
		"21": "wiosna",
		"22": "lato",
		"23": "jesien",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"por": {
		"name": "Portuguese",
		"01": "jan.",
		"02": "fev.",
		"03": "março",
		"04": "abril",
		"05": "maio",
		"06": "junho",
		"07": "julho",
		"08": "agosto",
		"09": "set.",
		"10": "out.",
		"11": "nov.",
		"12": "dez.",
		"21": "primavera",
		"22": "verão",
		"23": "outono",
		"24": "inverno",
		"ordinal": {
			"default": "º"
		}
	},
	"rum": {
		"name": "Romanian",
		"01": "Ian.",
		"02": "Feb.",
		"03": "Mar.",
		"04": "Apr.",
		"05": "Mai",
		"06": "Iunie",
		"07": "Iulie",
		"08": "Aug.",
		"09": "Sept.",
		"10": "Oct.",
		"11": "Noiem.",
		"12": "Dec.",
		"21": "primavera",
		"22": "vara",
		"23": "toamna",
		"24": "iarno",
		"ordinal": {
			"default": "."
		}
	},
	"rus": {
		"name": "Russian",
		"01": "ianv.",
		"02": "fevr.",
		"03": "mart",
		"04": "apr.",
		"05": "mai",
		"06": "iiun'",
		"07": "iiul'",
		"08": "avg.",
		"09": "sent.",
		"10": "okt.",
		"11": "noiabr'",
		"12": "dek.",
		"21": "vesna",
		"22": "leto",
		"23": "osen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"srp": {
		"name": "Serbian",
		"01": "jan.",
		"02": "febr.",
		"03": "mart",
		"04": "april",
		"05": "maj",
		"06": "juni",
		"07": "juli",
		"08": "avg.",
		"09": "sept.",
		"10": "okt.",
		"11": "nov.",
		"12": "dec.",
		"21": "prolece",
		"22": "leto",
		"23": "osen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"slo": {
		"name": "Slovak",
		"01": "l'ad./jan.",
		"02": "ún./feb.",
		"03": "brez./mar.",
		"04": "dub./apr.",
		"05": "kvet/máj",
		"06": "cerv./jún",
		"07": "cerven./júl",
		"08": "srp./aug.",
		"09": "zári./sept.",
		"10": "ruj./okt.",
		"11": "list./nov.",
		"12": "pros./dec.",
		"21": "jaro",
		"22": "leto",
		"23": "jasen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"slv": {
		"name": "Slovenian",
		"01": "jan./pros.",
		"02": "feb./svec.",
		"03": "mar./sus.",
		"04": "apr./mali traven",
		"05": "maj./veliki traven",
		"06": "jun./roz.",
		"07": "jul./mali srpan",
		"08": "avg./veliki srpan",
		"09": "sept./kim.",
		"10": "okt./vino.",
		"11": "nov./list.",
		"12": "dec./gr.",
		"21": "pomlad",
		"22": "poletje",
		"23": "jesen",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"spa": {
		"name": "Spanish",
		"01": "enero",
		"02": "feb.",
		"03": "marzo",
		"04": "abr.",
		"05": "mayo",
		"06": "jun.",
		"07": "jul.",
		"08": "agosto",
		"09": "sept./set.",
		"10": "oct.",
		"11": "nov.",
		"12": "dic.",
		"21": "primavera",
		"22": "verano",
		"23": "otoño",
		"24": "invierno",
		"ordinal": {
			"default": "o"
		}
	},
	"swe": {
		"name": "Swedish",
		"01": "jan.",
		"02": "febr.",
		"03": "mars",
		"04": "april",
		"05": "maj",
		"06": "juni",
		"07": "juli",
		"08": "aug.",
		"09": "sept.",
		"10": "okt.",
		"11": "nov.",
		"12": "dec.",
		"21": "vår",
		"22": "sommar",
		"23": "höst",
		"24": "vinter",
		"ordinal": {
			"default": ":e",
			"1": ":a",
			"2": ":a"
		}
	},
	"tur": {
		"name": "Turkish",
		"01": "Ocak",
		"02": "Subat",
		"03": "mart",
		"04": "Nisan",
		"05": "Mayis",
		"06": "Haziran",
		"07": "Temmuz",
		"08": "Agustos",
		"09": "Eylul",
		"10": "Ekim",
		"11": "Kasim",
		"12": "Aralik",
		"21": "ilkbahar",
		"22": "yaz",
		"23": "sonbahar",
		"24": "kis",
		"ordinal": {
			"default": "."
		}
	},
	"ukr": {
		"name": "Ukranian",
		"01": "sich.",
		"02": "liut.",
		"03": "ber.",
		"04": "kvit.",
		"05": "trav.",
		"06": "cher.",
		"07": "lyp.",
		"08": "serp.",
		"09": "ver.",
		"10": "zhovt.",
		"11": "lyst.",
		"12": "hrud.",
		"21": "vesna",
		"22": "lito",
		"23": "osin",
		"24": "zima",
		"ordinal": {
			"default": "."
		}
	},
	"wel": {
		"name": "Welsh",
		"01": "Ion.",
		"02": "Chwef.",
		"03": "Maw.",
		"04": "Ebr.",
		"05": "Mai",
		"06": "Meh.",
		"07": "Gorff.",
		"08": "Awst",
		"09": "Medi",
		"10": "Hyd.",
		"11": "Tach.",
		"12": "Rhag.",
		"21": "gwanwyn",
		"22": "haf",
		"23": "hydref",
		"24": "gaeaf",
		"ordinal": {
			"default": "fed",
			"1": "af",
			"2": "il",
			"3": "ydd",
			"4": "ydd",
			"5": "ed",
			"6": "ed"
		}
	}
}
;

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