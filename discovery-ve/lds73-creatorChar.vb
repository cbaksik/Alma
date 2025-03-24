rule "Primo VE - Lds73"
	when
		MARC is "386"
	then
		set TEMP"1" to MARC."386" sub without sort "3,i,a,m" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","i","",": ")
		replace wrapping delimiters (TEMP"1","m","",": ")
		replace wrapping delimiters (TEMP"1","a","","")
		create pnx."display"."lds73" with TEMP"1"
end