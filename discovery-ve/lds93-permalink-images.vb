rule "Primo VE - Lds93"
	when
		MARC.control is "001" AND
		MARC.control is "003" AND NOT
		MARC is "852"
	then
		set TEMP"1" to MARC.control."001"
		set TEMP"2" to MARC.control."001"
		add prefix (TEMP"1","<a aria-label=\"Permanent link to item\" href=\"https://id.lib.harvard.edu/images/")
		add suffix (TEMP"1","/catalog\">https://id.lib.harvard.edu/images/")
		concatenate with delimiter  (TEMP"1",TEMP"2","")
		add suffix (TEMP"1","/catalog</a>")
		create pnx."display"."lds93" with TEMP"1"
end




// <a href="https://id.lib.harvard.edu/images/viaID/catalog">Permanent link to HOLLIS record</a>


