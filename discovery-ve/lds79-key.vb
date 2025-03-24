rule "Primo VE - Lds79"
	when
		MARC is "384" AND
		MARC."384".ind"1" equals " "
	then
		set TEMP"1" to MARC."384" sub without sort "3,a" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","","")
		create pnx."display"."lds79" with TEMP"1"
end

rule "Primo VE - Lds79 384/0"
	when
		MARC is "384" AND
		MARC."384".ind"1" equals "0"
	then
		set TEMP"1" to MARC."384" sub without sort "3,a" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","","")
		add prefix (TEMP"1","Original: ")
		create pnx."display"."lds79" with TEMP"1"
end

rule "Primo VE - Lds79 384/1"
	when
		MARC is "384" AND
		MARC."384".ind"1" equals "1"
	then
		set TEMP"1" to MARC."384" sub without sort "3,a" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","","")
		add prefix (TEMP"1","Transposed: ")
		create pnx."display"."lds79" with TEMP"1"
end
rule "Primo VE - Lds79 384/2"
	when
		MARC is "384" AND
		MARC."384".ind"1" equals "2"
	then
		set TEMP"1" to MARC."384" sub without sort "3,a" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","","")
		add prefix (TEMP"1","Representative expression: ")
		create pnx."display"."lds79" with TEMP"1"
end