rule "Primo VE - Lds15"
	when
		MARC."540" has any "3,a-q"
	then
		set TEMP"1" to MARC "540" sub without sort "3,a-q" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b",""," ")
		replace wrapping delimiters (TEMP"1","c","Authorization: "," ")
		replace wrapping delimiters (TEMP"1","d","Authorized users: "," ")
		replace wrapping delimiters (TEMP"1","f",""," ")
		set TEMP"2" to MARC."540" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">Terms</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds15" with TEMP"1"
end


rule "Primo VE - Relation 880-540"
	when
		MARC is "880" AND
		MARC."880"."6" match "540.*" 
	then
		set TEMP"1" to MARC "880" sub without sort "3,a-q" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a",""," ")
		replace wrapping delimiters (TEMP"1","b",""," ")
		replace wrapping delimiters (TEMP"1","c","Authorization: "," ")
		replace wrapping delimiters (TEMP"1","d","Authorized users: "," ")
		replace wrapping delimiters (TEMP"1","f",""," ")
		set TEMP"2" to MARC."880" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">Terms</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds15" with TEMP"1"
end