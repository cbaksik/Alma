rule "Primo VE - Lds03"
	when
		MARC.control is "001" AND NOT
		MARC.control is "003"
	then
		set TEMP"1" to MARC.control."001"
		replace string by string (TEMP"1","^99([0-9]*)3941$","alma$1harvardAlma")
		replace string by string (TEMP"1","^99.*","")
		replace string by string (TEMP"1","^alma","99")
		replace string by string (TEMP"1","harvardAlma$","3941")
		add prefix (TEMP"1","<a href=\"https://id.lib.harvard.edu/alma/")
		add suffix (TEMP"1","/catalog\">Permanent link to HOLLIS record</a>")
		create pnx."display"."lds03" with TEMP"1"
end


// <a href="https://id.lib.harvard.edu/alma/990025484440203941/catalog">Permanent link to HOLLIS record</a>


