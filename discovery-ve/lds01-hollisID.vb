rule "Primo VE - Lds01"
	when
		MARC.control is "001"
	then
		set TEMP"1" to MARC.control."001"
		create pnx."display"."lds01" with TEMP"1"
end
