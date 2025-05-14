// get encoding level 
let bibEncLevel = $('get EncLevel').first().json.encodingLevel;

// handle type of cataloging
let typeCataloging = $('920-web-form').first().json['Type of cataloging'][0]
typeCataloging = typeCataloging[0]

let catSubfield = $('validateInput').first().json.catCode;
let deptSubfield = $('validateInput').first().json.deptCode;
let catNote = $('validateInput').first().json.catNote;



// Create a new Date object for the current date
const date = new Date();

// Extract year, month, and day
const year = date.getFullYear();
const month = ('0' + (date.getMonth() + 1)).slice(-2); // Months are zero-based, so add 1
const day = ('0' + date.getDate()).slice(-2);

// Concatenate year, month, and day into the desired format
const currentDateFormatted = `${year}${month}${day}`;


$input.first().json.record.datafield.push({
    $: { tag: "920", ind1: "1", ind2: "1" },
    subfield: [
        { $: { code: "a" }, _: typeCataloging },
        { $: { code: "d" }, _: currentDateFormatted},
        { $: { code: "e" }, _: deptSubfield },
        { $: { code: "f" }, _: catSubfield },
        { $: { code: "g" }, _: bibEncLevel },
        { $: { code: "x" }, _: catNote }
    ]
});
return $input.all();