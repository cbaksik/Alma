// Access the JSON data from the previous node
const inputData = items[0].json;

// Access the JSON element at the specified path
let leaderElement = inputData.record.leader[0];

// Ensure the element is a string
if (typeof leaderElement !== 'string') {
    leaderElement = String(leaderElement);
}


// Extract the 17th character if the string is long enough
let seventeenthChar = null;
if (leaderElement.length >= 17) {
    seventeenthChar = leaderElement[17]; // Index 16 is the 17th character
}

seventeenthChar = seventeenthChar.replace(/ /g, '#');

return [
  {
    json: {
      encodingLevel: seventeenthChar
    }
  }
];