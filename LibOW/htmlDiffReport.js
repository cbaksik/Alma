// 1. HELPER FUNCTIONS

// Translates messy MARC JSON into standard, readable MARC strings
function formatMarcField(field) {
  var tag = field.tag || (field["$"] && field["$"].tag);
  if (!tag) return null;

  // alter 880 so they will sort with pair, accounting for different syntax in alma and oclc
  // also drop 880 if it's for 758
  if (tag === "880" && (field.subfield[0].code === "6" || field.subfield[0]["$"].code === "6")) {
	var pairField= field.subfield[0]._.substring(0,3);
	if (pairField === '758') return null;	
	tag = field.subfield[0]._.substring(0,3) ;
  }

  if (tag === "LDR" || tag.startsWith("00")) {
    var val = field["_"] || "";
    if (tag === "008" && val.length > 37) {
		val = 
			"DtSt: " + val.substring(6,7) + 
               "	Dates: " + val.substring(7,15) + 
               "		Pub: " + val.substring(15,18) + 
               "	Lang: " + val.substring(35,38)  
		;
    }
    return { tag, text: `${tag}    ${val}` };
  }

  const ind1 = field.ind1 || (field["$"] && field["$"].ind1) || " ";
  const ind2 = field.ind2 || (field["$"] && field["$"].ind2) || " ";
  
const subfields = (
  Array.isArray(field.subfield)
    ? field.subfield
    : (field.subfield ? [field.subfield] : [])
).filter(sf => {
  const code = sf.code || (sf["$"] && sf["$"].code);
  // Drop subfields whose code is 0, 1
  return !["0", "1", "6", 0, 1, 6].includes(code);
});

  const sfText = subfields.map(sf => {
    const code = sf.code || (sf["$"] && sf["$"].code);
    var val = sf["_"] || "";
    if (code === "a") {
 	val = val.replace(/\.$/,"");
    }
    return `‡${code} ${val}`;
  }).join(" ");

   // replace period at end of value with nothing
  return { tag, text: `${tag} ${ind1}${ind2} ${sfText.replace(/\.$/,"")}` };
}

// Escapes HTML so angle brackets don't break the table
function escapeHtml(str) {
  return str.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
}

// Decompose precomposed Unicode in Alma fields, except tag 880
function decomposeAlmaUnicode(alma) {
  const decompose = (s) => (typeof s === "string" ? s.normalize("NFD") : s);  

  // Datafields
  (alma.datafield || []).forEach(f => {
    const tag = f.tag || (f["$"] && f["$"].tag);
    if (!tag || tag === "880") return;

    const subfields = Array.isArray(f.subfield)
      ? f.subfield
      : (f.subfield ? [f.subfield] : []);

    subfields.forEach(sf => {
      if (sf && typeof sf._ === "string") {
        sf._ = decompose(sf._);
      }
    });
  });

}

// INLINE DIFF ALGORITHM
function getInlineDiff(oldStr, newStr) {
  if (!oldStr) return { aHtml: "", oHtml: `<span color: #3f413f; padding: 1px 3px; border-radius: 3px;">${escapeHtml(newStr)}</span>` };
  if (!newStr) return { aHtml: `<span style="background-color: #ffcdd2; color: #3f413f; font-weight: bold; padding: 1px 3px; border-radius: 3px;">${escapeHtml(oldStr)}</span>`, oHtml: "" };
  if (oldStr === newStr) return { aHtml: escapeHtml(oldStr), oHtml: escapeHtml(newStr) };

  let start = 0;
  while (start < oldStr.length && start < newStr.length && oldStr[start] === newStr[start]) start++;

  let endOld = oldStr.length - 1;
  let endNew = newStr.length - 1;
  while (endOld >= start && endNew >= start && oldStr[endOld] === newStr[endNew]) {
    endOld--;
    endNew--;
  }

  const prefix = escapeHtml(oldStr.substring(0, start));
  const suffix = escapeHtml(oldStr.substring(endOld + 1));

  const oldDiff = escapeHtml(oldStr.substring(start, endOld + 1));
  const newDiff = escapeHtml(newStr.substring(start, endNew + 1));

  const aHtml = prefix + (oldDiff ? `<span style="background-color: #ffcdd2; color: #3f413f; font-weight: bold; padding: 1px 3px; border-radius: 3px;">${oldDiff}</span>` : "") + suffix;
  const oHtml = prefix + (newDiff ? `<span style="background-color: #bbf5ce; color: #3f413f; font-weight: bold; padding: 1px 3px; border-radius: 3px;">${newDiff}</span>` : "") + suffix;

  return { aHtml, oHtml };
}

// 2. START BUILDING THE HTML DOCUMENT

const allItems = $input.all();

// Build a timestamp like yyyy-MM-dd-HHMM
function pad(n) {
  return String(n).padStart(2, '0');
}
const now = new Date();
const ts = [
  now.getFullYear(),
  pad(now.getMonth() + 1),
  pad(now.getDate())
].join('-') + '-' + pad(now.getHours()) + pad(now.getMinutes());

const setId = allItems[0].json.set_id;  // adjust if set_id is elsewhere


let html = `<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title>MARC Compare ${allItems[0].json.set_name}</title>
</head>
<body style="font-family: sans-serif; font-size: 14px; padding: 20px; background: #f6f8fa; color: #333;">
  <div style="max-width: 1400px; margin: 0 auto; background: #fff; padding: 30px; border-radius: 6px; box-shadow: 0 1px 3px rgba(0,0,0,0.1);">
  <h1 >Batch comparison for set ${setId}. Set name: ${allItems[0].json.set_name.substring(0,50)}</h1>
  <h4 style="border-bottom: 2px solid #ccc; padding-bottom: 10px; margin-top: 0;">${allItems[0].json.set_count} records. Set creator: ${allItems[0].json.set_creator}. Report produced: ${ts}</h4>`;


// 3. PROCESS EVERY RECORD
for (let i = 0; i < allItems.length; i++) {
  const item = allItems[i];
   
  let oclc = item.json.oclc;
  let alma = item.json.alma;

   // Decompose Unicode in Alma (except tag 880)
  decomposeAlmaUnicode(alma);
  
  const oclcFields = [...(oclc.controlfield || []), ...(oclc.datafield || [])];
 // if (oclc.leader && oclc.leader[0]) oclcFields.unshift({ tag: "LDR", "_": oclc.leader[0] });
  if (oclc.leader && oclc.leader[0] && oclc.fixed) oclcFields.unshift({ tag: "LDR", "_":  "Type(06) Bib Level(07): " + oclc.fixed.typeLevel});
  const almaFields = [...(alma.controlfield || []), ...(alma.datafield || [])];
  //if (alma.leader && alma.leader[0]) almaFields.unshift({ tag: "LDR", "_": alma.leader[0] });
  if (alma.leader && alma.leader[0] && alma.fixed) almaFields.unshift({ tag: "LDR", "_":  "Type(06) Bib Level(07): " + alma.fixed.typeLevel});

  const oclcParsed = oclcFields.map(formatMarcField).filter(Boolean);
  const almaParsed = almaFields.map(formatMarcField).filter(Boolean);

  // BUILD THE SEPARATOR AND HEADER FOR THIS RECORD{}
  if (i > 0) {
    html += `<hr style="margin: 50px 0 30px 0; border: 0; border-top: 5px solid #d0d7de;">`;
  }
  let bibInstance = i + 1;
  html += `<h2 style="color: #0969da; margin-bottom: 15px;">${bibInstance + '.  ' + escapeHtml(item.json.title)}</h2>`;

  if (oclcParsed.length === 0 && almaParsed.length === 0) {
     html += `<div style="color: red;"><strong>⚠️ ERROR:</strong> Could not locate MARC data for this record.</div>`;
     continue; // Skip table building for this one
  }

  // COMPARE AND ALIGN THE TWO RECORDS
  const comparisonRows = [];
  const allTags = [...new Set([...almaParsed.map(f=>f.tag), ...oclcParsed.map(f=>f.tag)])];
  
  allTags.sort((a, b) => {
    if (a === "LDR") return -1; 
    if (b === "LDR") return 1;
    return a.localeCompare(b);
  });

  allTags.forEach(tag => {
    const aList = almaParsed.filter(f => f.tag === tag).map(f => f.text);
    const oList = oclcParsed.filter(f => f.tag === tag).map(f => f.text);

    for (let j = aList.length - 1; j >= 0; j--) {
      const aStr = aList[j];
      const oIdx = oList.indexOf(aStr);
      if (oIdx > -1) {
        comparisonRows.push({ type: 'match', alma: aStr, oclc: aStr });
        aList.splice(j, 1);
        oList.splice(oIdx, 1);
      }
    }

    const maxLen = Math.max(aList.length, oList.length);
    for (let j = 0; j < maxLen; j++) {
      comparisonRows.push({ type: 'diff', alma: aList[j] || "", oclc: oList[j] || "" });
    }
  });

  // ADD THE TABLE FOR THIS SPECIFIC RECORD
  html += `<table style="width: 100%; border-collapse: collapse; font-family: monospace; font-size: 13px; white-space: pre-wrap; word-break: break-word; outline: 1px solid #ccc;">`;
  html += `<thead style="background-color: #f6f8fa;">
            <tr>
              <th style="width:50%; text-align:left; border-bottom: 1px solid #ccc; padding: 10px; font-size: 14px;">Alma record ${item.json.mms_id}</th>
              <th style="width:50%; text-align:left; border-bottom: 1px solid #ccc; padding: 10px; font-size: 14px; border-left: 1px solid #ccc;">OCLC record ${item.json.ocn}</th>
            </tr>
           </thead>`;
  html += `<tbody>`;

  comparisonRows.forEach(row => {
    let almaStyle = "padding: 8px 10px; border-bottom: 1px solid #eee; vertical-align: top;";
    let oclcStyle = "padding: 8px 10px; border-bottom: 1px solid #eee; vertical-align: top; border-left: 1px solid #ccc;";

    let aHtml = "";
    let oHtml = "";

    if (row.type === 'match') {
      almaStyle += " color: #57606a;";
      oclcStyle += " color: #57606a;";
      aHtml = escapeHtml(row.alma);
      oHtml = escapeHtml(row.oclc);
    } else {
      const diffs = getInlineDiff(row.alma, row.oclc);
      aHtml = diffs.aHtml;
      oHtml = diffs.oHtml;
    } if (aHtml.indexOf("ffcdd2") > 0 && aHtml.indexOf(">752") > 0) {
		aHtml = aHtml + " (PROTECTED)";
    }

    html += `<tr>`;
    html += `<td style="${almaStyle}">${aHtml || '&nbsp;'}</td>`;
    html += `<td style="${oclcStyle}">${oHtml || '&nbsp;'}</td>`;
    html += `</tr>`;
  });

  html += `</tbody></table>`;
}
// end of for loop of step 3

// 4. CLOSE THE MASTER HTML DOCUMENT
html += `</div></body></html>`;

// 5. RETURN A SINGLE ITEM WITH THE BINARY ATTACHMENT

return [
  {
    json: {
      message: 'Batch report successfully generated.',
      records_processed: allItems.length,
    },
    binary: {
      report_file: {
        data: Buffer.from(html, 'utf8').toString('base64'),
        mimeType: 'text/html',
        fileName: `compare-${setId.substring(2,12)}-${allItems[0].json.set_name.replace(/\s/g,'-')}-${ts}.html`,
      },
    },
  },
];