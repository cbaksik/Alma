rule "Primo VE - Lds15"
	when
		MARC."540" has any "3,a-p"
	then
		set TEMP"1" to MARC "540" sub without sort "3,a-p" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","",". ")
		replace wrapping delimiters (TEMP"1","b",""," ")
		replace wrapping delimiters (TEMP"1","c","Authorization: "," ")
		replace wrapping delimiters (TEMP"1","d","Authorized users: "," ")
		replace wrapping delimiters (TEMP"1","f","",". ")
		set TEMP"2" to MARC."540" sub without sort "0"
		add prefix (TEMP"2","<a target=\"_blank\" href=\"")
		add suffix (TEMP"2","\">Terms</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds15" with TEMP"1"
end

