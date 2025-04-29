// Access the JSON element at the specified path
const catDropdown = $input.first().json.Cataloger;

// testing getting user id of submitter
const almaID = $input.first().json.__$auth.username;

const mappingAlmaID = {
    '00266345': { initials: '463', code: 'CA' },
    '00282694': { initials: '246', code: 'CA' },
    '00310617': { initials: '196', code: 'CA' },
    '00315018': { initials: '436', code: 'DO' },
    '00335630': { initials: '850', code: 'MA' },
    '00041044': { initials: 'VernonE', code: 'JD' },
    'ID645279': { initials: 'SamuelsV', code: 'JD' },
    'IDA58804': { initials: '907', code: 'MA' },
    'ID543140': { initials: 'Corinna', code: 'LTS' },
    'ID818404': { initials: '129', code: 'DO' } ,
    'IDAA000152331': { initials: '962', code: 'MA' } ,
    'IDAA000177870': { initials: '189', code: 'CA' } 
};

let result = mappingAlmaID[almaID];

    // If the input string isn't found, return a default or error object
    if (!result) {
        throw new Error("Your user ID has not been included in the Cat Stats Registry. Please contact Minna to have your user ID added.");
    }

    // Return the JSON object with the associated values
return [
  {
    json: {
      catCode: result.initials,
      deptCode: result.code,
    }
  }
];
