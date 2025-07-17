rule "Primo VE - Date Of Publication 008"
	priority 30
	when
		MARC is "260"."c" AND
		MARC."260".ind"1"  equals "3"
	then
		set TEMP"1" to MARC."260"."c"
		remove substring using regex (TEMP"1","(\\.)+$")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date Of Publication 264/3/1"
	priority 40
	when
		MARC is "264"."c" AND
		MARC."264".ind"1"  equals "3" AND
		MARC."264".ind"2"  equals "1"
	then
		set TEMP"1" to MARC."264"."c"
		remove substring using regex (TEMP"1","(\\.)+$")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date Of Publication 260"
	priority 50
	when
		MARC is "260"."c"
	then
		set TEMP"1" to MARC."260"."c"
		remove substring using regex (TEMP"1","(\\.)+$")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date Of Publication 264"
	priority 60
	when
		MARC is "264"."c"
	then
		set TEMP"1" to MARC."264"."c"
		remove substring using regex (TEMP"1","(\\.)+$")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date of Publication 008 real one"
	priority 70
	when
		MARC.control."008"(06-07) equals "b" OR
		MARC.control."008"(06-07) equals "e" OR
		MARC.control."008"(06-07) equals "n" OR
		MARC.control."008"(06-07) equals "p" OR
		MARC.control."008"(06-07) equals "q" OR
		MARC.control."008"(06-07) equals "r" OR
		MARC.control."008"(06-07) equals "s" OR
		MARC.control."008"(06-07) equals "t" OR
		MARC.control."008"(06-07) equals "|" OR
		MARC.control."008"(06-07) equals " " OR
		MARC.control."008"(06-07) equals "^"
	then
		set TEMP"1" to MARC.control."008".Date1
		replace string by string (TEMP"1","u{4}","?")
		replace string by string (TEMP"1","9{4}","?")
		replace string by string (TEMP"1","u","?")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date of Publication 008 contins"
	priority 80
	when
		MARC.control."008"(06-07) equals "c" OR
		MARC.control."008"(06-07) equals "i" OR
		MARC.control."008"(06-07) equals "k" OR
		MARC.control."008"(06-07) equals "m" OR
		MARC.control."008"(06-07) equals "u"
	then
		set TEMP"1" to MARC.control."008".Date1
		set TEMP"2" to MARC.control."008".Date2		
		replace string by string (TEMP"1","u","?")
		replace string by string (TEMP"1","9","?")
		replace string by string (TEMP"1","????","?")
		replace string by string (TEMP"2","uuuu"," ")
		replace string by string (TEMP"2","9999"," ")
		replace string by string (TEMP"2","u","?")
		concatenate with delimiter (TEMP"1",TEMP"2","-")
		set pnx."display"."creationdate" to TEMP"1"
end

rule "Primo VE - Date of Publication 008 ceased"
	priority 90
	when
		MARC.control."008"(06-07) equals "d"
	then
		set TEMP"1" to MARC.control."008".Date1
		set TEMP"2" to MARC.control."008".Date2		
		replace string by string (TEMP"1","u{4}","?")
		replace string by string (TEMP"1","9{4}","?")
		replace string by string (TEMP"1","u","?")
		replace string by string (TEMP"2","u{4}",".")
		replace string by string (TEMP"2","9{4}",".")
		replace string by string (TEMP"2","u","?")
		concatenate with delimiter (TEMP"1",TEMP"2","-")
		set pnx."display"."creationdate" to TEMP"1"
end

