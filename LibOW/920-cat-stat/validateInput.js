

const catCode = $('920-web-form').first().json['Cataloger code'].trim();

const deptCode = $('920-web-form').first().json['Department code'].toUpperCase().trim();

const catNote = $('920-web-form').first().json['Note'].substring(0, 250).trim();

function onlyLettersAndNumbers(str) {
  return /^[A-Za-z0-9]*$/.test(str);
}

if (!onlyLettersAndNumbers(catCode))  {
        throw new Error("Codes may not contain special characters.");
}
if (!onlyLettersAndNumbers(deptCode))  {
        throw new Error("Codes may not contain special characters.");
}

if ((catCode.length > 12) || (catCode.length <3))  {
        throw new Error("Codes are generally between 3 and 12 characters long.");
}
if ((deptCode.length > 3) || (deptCode.length <2))  {
        throw new Error("Codes are generally between 3 and 12 characters long.");
}

return [
  {
    json: {
      catCode: catCode,
      deptCode: deptCode,
      catNote: catNote
    }
  }
];
