rule "Primo VE Marc - Lsr01"
	when
		MARC.control is "001"
	then
		set TEMP"1" to MARC.control."001"
		create pnx."search"."lsr01" with TEMP"1"
end
