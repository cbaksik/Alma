rule "Primo VE - Lds72"
	when
		MARC is "385"
	then
		set TEMP"1" to MARC."385" sub without sort "3,a,m" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","m","",": ")
		replace wrapping delimiters (TEMP"1","a","","")
		create pnx."display"."lds72" with TEMP"1"
end

rule "Primo VE - Lds72 - 521"
	when
		MARC is "521"
	then
		set TEMP"1" to MARC."521" sub without sort "3,a,b" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b"," -- ","")
		create pnx."display"."lds72" with TEMP"1"
end

rule "Primo VE - Lds72 - 521-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "521.*" 
	then
		set TEMP"1" to MARC."880" sub without sort "3,a,b" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b"," -- ","")
		create pnx."display"."lds72" with TEMP"1"
end