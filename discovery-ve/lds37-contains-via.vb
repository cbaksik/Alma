rule "Primo VE - Lds37"
	when
		MARC is "597"."c"  AND
		MARC."597".ind"2"  equals "9" AND
		MARC.control is "001" AND
		MARC.control is "003" AND NOT
		MARC is "852"
	then
		set TEMP"1" to MARC.control."001"
		add prefix (TEMP"1","SEE ALL IMAGES IN THIS GROUP$$Q")	
		create pnx."display"."lds37" with TEMP"1"
end


