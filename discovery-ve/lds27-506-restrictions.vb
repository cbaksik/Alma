rule "Primo VE - Lds27"
	when
		MARC."506" has any "a,f"
	then
		set TEMP"1" to MARC "506" sub without sort "3,a-q" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b",""," ")
		replace wrapping delimiters (TEMP"1","c",""," ")
		replace wrapping delimiters (TEMP"1","d","Authorized users: "," ")
		replace wrapping delimiters (TEMP"1","e","Authorization: "," ")
		replace wrapping delimiters (TEMP"1","f",""," ")
		set TEMP"2" to MARC."506" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">Terms</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds27" with TEMP"1"
end

rule "Primo VE - Relation 880-506"
	when
		MARC is "880" AND
		MARC."880"."6" match "506.*" 
	then
		set TEMP"1" to MARC "880" sub without sort "3,a-q" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b",""," ")
		replace wrapping delimiters (TEMP"1","c",""," ")
		replace wrapping delimiters (TEMP"1","d","Authorized users: "," ")
		replace wrapping delimiters (TEMP"1","e","Authorization: "," ")
		replace wrapping delimiters (TEMP"1","f",""," ")
		set TEMP"2" to MARC."880" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">Terms</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds27" with TEMP"1"
end