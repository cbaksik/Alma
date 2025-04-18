rule "Primo VE - Lds70"
	when
		MARC."382" has any "3,a-v" 
	then
		set TEMP"1" to MARC."382" sub without sort "3,a-v" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b",""," ")
		replace wrapping delimiters (TEMP"1","d",""," ")
		replace wrapping delimiters (TEMP"1","n","(","). ")
		replace wrapping delimiters (TEMP"1","e","(","). ")
		replace wrapping delimiters (TEMP"1","p"," Or "," ")
		replace wrapping delimiters (TEMP"1","r"," Total individuals: ",".")
		replace wrapping delimiters (TEMP"1","s"," Total performers: ",".")
		replace wrapping delimiters (TEMP"1","t"," Total ensembles: ",".")
		replace wrapping delimiters (TEMP"1","v"," Note: ",".")
		create pnx."display"."lds70" with TEMP"1"
end


// begin 880

rule "Primo VE - Lds70 - 880"
	when
		MARC."880" has any "3,a-v" AND
		MARC."880"."6" match "382-.*"  
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-v" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b",""," ")
		replace wrapping delimiters (TEMP"1","d",""," ")
		replace wrapping delimiters (TEMP"1","n","(","). ")
		replace wrapping delimiters (TEMP"1","e","(","). ")
		replace wrapping delimiters (TEMP"1","p"," Or "," ")
		replace wrapping delimiters (TEMP"1","r"," Total individuals: ",".")
		replace wrapping delimiters (TEMP"1","s"," Total performers: ",".")
		replace wrapping delimiters (TEMP"1","t"," Total ensembles: ",".")
		replace wrapping delimiters (TEMP"1","v"," Note: ",".")
		create pnx."display"."lds70" with TEMP"1"
end

