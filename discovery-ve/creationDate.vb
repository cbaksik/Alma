rule "Primo VE - Date Of Publication 008"
	when
		MARC is "260"."c"
	then
		set TEMP"1" to MARC."260"."c"
		remove substring using regex (TEMP"1","(\\.)+$")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date Of Publication 264"
	when
		MARC is "264"."c"
	then
		set TEMP"1" to MARC."264"."c"
		remove substring using regex (TEMP"1","(\\.)+$")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date Of Publication 008 - real one"
	when
		MARC.control is "008" AND NOT 
		(MARC is "264"."c" OR 
		MARC is "260"."c")
	then
		set TEMP"1" to MARC.control."008".Date1
		set TEMP"2" to MARC.control."008".Date2
		replace string by string (TEMP"1","u{4}","\\[\\?\\]")
		replace string by string (TEMP"1","9{4}","\\[\\?\\]")
		replace string by string (TEMP"1","[^0-9]","\\?")
		replace string by string (TEMP"2","u{4}","\\[\\?\\]")
		replace string by string (TEMP"2","[^0-9]","\\?")
		replace string by string (TEMP"2","9{4}"," ")
		concatenate with delimiter (TEMP"1",TEMP"2","-")
		set pnx."display"."creationdate" to TEMP"1"
end