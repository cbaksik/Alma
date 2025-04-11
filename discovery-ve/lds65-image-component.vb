rule "Primo VE - Lds65"
	when
		MARC."974" has any "a-z"
	then
		set TEMP"1" to MARC."974" sub without sort "a-z" wrap subfields
		replace wrapping delimiters (TEMP"1","w","==W","")
		replace wrapping delimiters (TEMP"1","x","==X","")
		replace wrapping delimiters (TEMP"1","h","==H","")
		replace wrapping delimiters (TEMP"1","u","==U","")
		replace wrapping delimiters (TEMP"1","t","==T","")
		replace wrapping delimiters (TEMP"1","f","==F","")
		replace wrapping delimiters (TEMP"1","a","==A","")
		replace wrapping delimiters (TEMP"1","d","==D","")
		replace wrapping delimiters (TEMP"1","b","==B","")
		replace wrapping delimiters (TEMP"1","s","==S","")
		replace wrapping delimiters (TEMP"1","m","==M","")
		replace wrapping delimiters (TEMP"1","n","==N","")
		replace wrapping delimiters (TEMP"1","c","==C","")
		replace wrapping delimiters (TEMP"1","r","==R","")
		create pnx."display"."lds65" with TEMP"1"
end

