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

rule "Primo VE Marc - Lds72 special - fixed"
	when
		MARC is "041"."q" OR
		MARC is "341"."d" OR
		(MARC.control."LDR"(6-7) matches "a|t|p|c|d|m|i|j" AND MARC.control."008"(23-24) equals "f") OR
		(MARC.control."LDR"(6-7) matches "e|f|g" AND MARC.control."008"(29-30) equals "f")
	then
		create pnx."display"."lds72" with "People with visual disabilities"
end

rule "Primo VE Marc - Lds72 special - 650 maps"
	when
		MARC.control."LDR"(6-7) matches "e|f" AND
		MARC is "650" AND 
		MARC."650"."a" match "Maps for the blind"
	then
		create pnx."display"."lds72" with "People with visual disabilities"
end

rule "Primo VE Marc - Lds72 special - 650 scores"
	when
		MARC.control."LDR"(6-7) matches "c|d" AND
		MARC is "650" AND 
		(MARC."650"."a" match "Braille music notation" OR MARC."650"."a" match "Music for the blind")
	then
		create pnx."display"."lds72" with "People with visual disabilities"
end

rule "Primo VE Marc - Lds72 special - 655 lcsh"
	when
		MARC is "655" AND 
		MARC."655".ind"2"  equals "0" AND
		(MARC."655"."a" match "Braille music notation" OR 
		MARC."655"."a" match "Music for the blind" OR
		MARC."655"."a" match "Large type books" OR
		MARC."655"."a" match "Maps for the blind" OR
		MARC."655"."a" match "Large print books")
	then
		create pnx."display"."lds72" with "People with visual disabilities"
end

rule "Primo VE Marc - Lds72 special - 655 2nd ind 7"
	when
		MARC is "655" AND 
		MARC."655".ind"2"  equals "7" AND
		(MARC."655"."a" match "Talking books" OR 
		MARC."655"."a" match "Braille books" OR 
		MARC."655"."a" match "Braille periodicals" OR 
		MARC."655"."a" match "Cartographic materials for people with visual disabilities" OR 
		MARC."655"."a" match "Television programs for people with visual disabilities" OR 
		MARC."655"."a" match "Video recordings for people with visual disabilities" OR 
		MARC."655"."a" match "Films for people with visual disabilities" OR 
		MARC."655"."a" match "Large print books")
	then
		create pnx."display"."lds72" with "People with visual disabilities"
end

