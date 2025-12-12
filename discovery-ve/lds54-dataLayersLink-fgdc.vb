rule "Primo VE - Lds54"
	when
		MARC is "591"."a" AND
		MARC."591".ind"2"  equals "9"
	then
		set TEMP"1" to MARC."591" sub without sort "a"
		set TEMP"2" to MARC."591" sub without sort "b"
		concatenate with delimiter (TEMP"1",TEMP"2","$$Q")
		create pnx."display"."lds54" with TEMP"1"
end


