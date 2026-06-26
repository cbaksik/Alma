// 1. HELPER FUNCTIONS

// Translates messy MARC JSON into standard, readable MARC strings
function formatMarcField(field) {
  const tag = field.tag || (field["$"] && field["$"].tag);
  if (!tag) return null;

  if (tag === "LDR" || tag.startsWith("00")) {
    const val = field["_"] || "";
    return { tag, text: `${tag}    ${val}` };
  }

  const ind1 = field.ind1 || (field["$"] && field["$"].ind1) || " ";
  const ind2 = field.ind2 || (field["$"] && field["$"].ind2) || " ";
  
  const subfields = Array.isArray(field.subfield) 
    ? field.subfield 
    : (field.subfield ? [field.subfield] : []);

  const sfText = subfields.map(sf => {
    const code = sf.code || (sf["$"] && sf["$"].code);
    const val = sf["_"] || "";
    return `‡${code} ${val}`;
  }).join(" ");

  return { tag, text: `${tag} ${ind1}${ind2} ${sfText}` };
}

// Escapes HTML so angle brackets don't break the table
function escapeHtml(str) {
  return str.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
}

// INLINE DIFF ALGORITHM
function getInlineDiff(oldStr, newStr) {
  if (!oldStr) return { aHtml: "", oHtml: `<span style="background-color: #bbf5ce; color: #1a7f37; font-weight: bold; padding: 1px 3px; border-radius: 3px;">${escapeHtml(newStr)}</span>` };
  if (!newStr) return { aHtml: `<span style="background-color: #ffcdd2; color: #b30000; font-weight: bold; text-decoration: line-through; padding: 1px 3px; border-radius: 3px;">${escapeHtml(oldStr)}</span>`, oHtml: "" };
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

  const aHtml = prefix + (oldDiff ? `<span style="background-color: #ffcdd2; color: #b30000; font-weight: bold; text-decoration: line-through; padding: 1px 3px; border-radius: 3px;">${oldDiff}</span>` : "") + suffix;
  const oHtml = prefix + (newDiff ? `<span style="background-color: #bbf5ce; color: #1a7f37; font-weight: bold; padding: 1px 3px; border-radius: 3px;">${newDiff}</span>` : "") + suffix;

  return { aHtml, oHtml };
}

// 2. START BUILDING THE MASTER HTML DOCUMENT
let html = `<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title>Batch MARC Comparison</title>
</head>
<body style="font-family: sans-serif; font-size: 14px; padding: 20px; background: #f6f8fa; color: #333;">
  <div style="max-width: 1400px; margin: 0 auto; background: #fff; padding: 30px; border-radius: 6px; box-shadow: 0 1px 3px rgba(0,0,0,0.1);">
  <h1 style="border-bottom: 2px solid #ccc; padding-bottom: 10px; margin-top: 0;">Batch MARC Record Comparison</h1>`;

const allItems = $input.all();

// 3. PROCESS EVERY RECORD
for (let i = 0; i < allItems.length; i++) {
  const item = allItems[i];
  
  // --- AGGRESSIVE DATA HUNTING ---
  let oclc = item.json.oclc || (item.json.bothrecords && item.json.bothrecords.oclc);
  let alma = item.json.alma || (item.json.bothrecords && item.json.bothrecords.alma);
  
  if (Array.isArray(item.json.bothrecords)) {
    const oclcObj = item.json.bothrecords.find(r => r.oclc);
    const almaObj = item.json.bothrecords.find(r => r.alma);
    if (oclcObj) oclc = oclcObj.oclc;
    if (almaObj) alma = almaObj.alma;
  }
  
  oclc = oclc || {};
  alma = alma || {};
  // -------------------------------

  const oclcFields = [...(oclc.controlfield || []), ...(oclc.datafield || [])];
  if (oclc.leader && oclc.leader[0]) oclcFields.unshift({ tag: "LDR", "_": oclc.leader[0] });

  const almaFields = [...(alma.controlfield || []), ...(alma.datafield || [])];
  if (alma.leader && alma.leader[0]) almaFields.unshift({ tag: "LDR", "_": alma.leader[0] });

  const oclcParsed = oclcFields.map(formatMarcField).filter(Boolean);
  const almaParsed = almaFields.map(formatMarcField).filter(Boolean);

  // EXTRACT TITLE (Find the 245 tag and strip the "245 10 " off the front)
  let recordTitle = `Record ${i + 1} (Title Unknown)`;
  const titleField = oclcParsed.find(f => f.tag === "245") || almaParsed.find(f => f.tag === "245");
  if (titleField) {
    recordTitle = titleField.text.replace(/^245\s+..\s+/, '');
  }

  // BUILD THE SEPARATOR AND HEADER FOR THIS RECORD
  if (i > 0) {
    html += `<hr style="margin: 50px 0 30px 0; border: 0; border-top: 3px solid #d0d7de;">`;
  }
  html += `<h2 style="color: #0969da; margin-bottom: 15px;">📄 ${escapeHtml(recordTitle)}</h2>`;

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
              <th style="width:50%; text-align:left; border-bottom: 1px solid #ccc; padding: 10px; font-size: 14px;">Alma Record (Current)</th>
              <th style="width:50%; text-align:left; border-bottom: 1px solid #ccc; padding: 10px; font-size: 14px; border-left: 1px solid #ccc;">OCLC Record (New)</th>
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
    }

    html += `<tr>`;
    html += `<td style="${almaStyle}">${aHtml || '&nbsp;'}</td>`;
    html += `<td style="${oclcStyle}">${oHtml || '&nbsp;'}</td>`;
    html += `</tr>`;
  });

  html += `</tbody></table>`;
}

// 4. CLOSE THE MASTER HTML DOCUMENT
html += `</div></body></html>`;

// 5. RETURN A SINGLE ITEM WITH THE BINARY ATTACHMENT
return [{
  json: {
    message: "Batch report successfully generated.",
    records_processed: allItems.length
  },
  binary: {
    report_file: {
      data: Buffer.from(html, 'utf8').toString('base64'),
      mimeType: 'text/html',
      fileName: 'MARC_Batch_Comparison_Report.html'
    }
  }
}];