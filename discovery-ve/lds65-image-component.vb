rule "Primo VE - Lds65"
	when
		MARC."599" has any "a-z"
	then
		set TEMP"1" to MARC."599" sub without sort "0-9,a-z" wrap subfields
		replace wrapping delimiters (TEMP"1","0","==0","")
		replace wrapping delimiters (TEMP"1","1","==1","")
		replace wrapping delimiters (TEMP"1","2","==2","")
		replace wrapping delimiters (TEMP"1","3","==3","")
		replace wrapping delimiters (TEMP"1","4","==4","")
		replace wrapping delimiters (TEMP"1","5","==5","")
		replace wrapping delimiters (TEMP"1","6","==6","")
		replace wrapping delimiters (TEMP"1","7","==7","")
		replace wrapping delimiters (TEMP"1","8","==8","")
		replace wrapping delimiters (TEMP"1","9","==9","")
		replace wrapping delimiters (TEMP"1","a","==A","")
		replace wrapping delimiters (TEMP"1","b","==B","")
		replace wrapping delimiters (TEMP"1","c","==C","")
		replace wrapping delimiters (TEMP"1","d","==D","")
		replace wrapping delimiters (TEMP"1","f","==F","")
		replace wrapping delimiters (TEMP"1","g","==G","")
		replace wrapping delimiters (TEMP"1","h","==H","")
		replace wrapping delimiters (TEMP"1","i","==I","")
		replace wrapping delimiters (TEMP"1","j","==J","")
		replace wrapping delimiters (TEMP"1","k","==K","")
		replace wrapping delimiters (TEMP"1","m","==M","")
		replace wrapping delimiters (TEMP"1","n","==N","")
		replace wrapping delimiters (TEMP"1","r","==R","")
		replace wrapping delimiters (TEMP"1","s","==S","")
		replace wrapping delimiters (TEMP"1","t","==T","")
		replace wrapping delimiters (TEMP"1","u","==U","")
		replace wrapping delimiters (TEMP"1","w","==W","")
		replace wrapping delimiters (TEMP"1","x","==X","")
		replace wrapping delimiters (TEMP"1","y","==Y","")
		replace wrapping delimiters (TEMP"1","z","==Z","")
		create pnx."display"."lds65" with TEMP"1"
end

