rule "Primo VE - Lds01"
priority 90
	when
		MARC.control is "001" AND NOT
		MARC.control is "003"
	then
		set TEMP"1" to MARC.control."001"
		replace string by string (TEMP"1","^99([0-9]*)3941$","alma$1harvardAlma")
		replace string by string (TEMP"1","^99.*","")
		replace string by string (TEMP"1","^alma","99")
		replace string by string (TEMP"1","harvardAlma$","3941")
		// now we're left with Alma hvd only as well as any VE ext sources with 001 fields
		// for some reason can't use set below, maybe doesn't work for lds only otb? 
		create pnx."display"."lds01" with TEMP"1"
end

rule "Primo VE - Lds01 - VE external data -- show VIA but not recap"
priority 80
	when
		MARC.control is "001" AND
		MARC.control is "003" AND NOT
		MARC is "852"
	then
		set TEMP"1" to MARC.control."001"
		//set TEMP"2" to MARC.control."003"
		//replace string by string (TEMP"2","jstorHvdImg","keep")
		// don't want recap scsb for hollis number
		//concatenate with delimiter (TEMP"2",TEMP"1","")		
		create pnx."display"."lds01" with TEMP"1"
end

