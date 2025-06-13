// code from AI

// Get the input items
const items = $input.all();
const newItems = [];

for (const item of items) {
  // Get the Barcode string from the specified path
  const barcodeString = $('920-web-form').first().json.Barcode;
  // Assuming '920-web-form' is the direct input node

  // If you need to refer to a node not directly connected, use:
  // const barcodeString = $('920-web-form').item.json.Barcode;

  if (typeof barcodeString === 'string' && barcodeString.trim() !== '') {
    const lines = barcodeString
      .split(/\r?\n/) // Splits by newline (handles Windows \r\n and Unix \n)
      .filter(line => line.trim() !== ''); // Remove any empty lines

    // Create a new field in the current item to hold the array of lines
    // This array will be used by the "Split In Batches" node later
    item.json.barcodeLinesArray = lines;
    newItems.push(item); // Keep the original item, but now with the array
  } else {
    // If barcodeString is empty or not a string, you might want to just pass it through
    // or handle it as an error. Here, we'll just pass it.
    item.json.barcodeLinesArray = []; // Ensure the field exists even if empty
    newItems.push(item);
  }
}

return newItems;