rule "Primo VE - Rights"
	when
		MARC is "542" AND 
		(MARC."542".ind"1" equals "1" OR
		MARC."542".ind"1" equals " ")
	then
		set TEMP"1" to MARC "542" sub without sort "3,a-s" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","Personal creator: "," -- ")
		replace wrapping delimiters (TEMP"1","b","Deceased "," -- ")
		replace wrapping delimiters (TEMP"1","c","Corporate creator: "," -- ")
		replace wrapping delimiters (TEMP"1","d","Copyright holder: "," -- ")
		replace wrapping delimiters (TEMP"1","e","Copyright holder contact: "," -- ")
		replace wrapping delimiters (TEMP"1","f",""," -- ")
		replace wrapping delimiters (TEMP"1","g","Initial year of copyright: "," -- ")
		replace wrapping delimiters (TEMP"1","h","Renewal date: "," -- ")
		replace wrapping delimiters (TEMP"1","i","Publication date: "," -- ")
		replace wrapping delimiters (TEMP"1","j","Creation date of unpublished resource: "," -- ")
		replace wrapping delimiters (TEMP"1","k","Publisher: "," -- ")
		replace wrapping delimiters (TEMP"1","l","Rights status: "," -- ")
		replace wrapping delimiters (TEMP"1","m","Publication status: "," -- ")
		replace wrapping delimiters (TEMP"1","n","Note: "," -- ")
		replace wrapping delimiters (TEMP"1","o","Research date: "," -- ")
		replace wrapping delimiters (TEMP"1","p","Country of publication or creation: "," -- ")
		replace wrapping delimiters (TEMP"1","q","Information supplied by: "," -- ")
		replace wrapping delimiters (TEMP"1","r","Jurisdiction: "," -- ")
		replace wrapping delimiters (TEMP"1","s","Source: "," -- ")
        replace string by string (TEMP"1"," -- $",".")
        replace string by string (TEMP"1",":.$",".")
		set TEMP"2" to MARC."542" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">Rights details</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."rights" with TEMP"1" 
end

rule "Primo VE - Rights 880"
	when
		MARC."880" has any "3,a-s,u" AND 
		(MARC."880"."6" match "542-1.*" OR
		MARC."880"."6" match "542- .*")
	then
		create pnx."display"."rights" with MARC "880" sub without sort "3,a-s,u"
end