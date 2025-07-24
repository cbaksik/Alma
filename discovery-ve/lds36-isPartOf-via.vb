rule "Primo VE - Lds36"
	when
		MARC is "597"."a" AND
		MARC."597".ind"2"  equals "9"
	then
		set TEMP"1" to MARC."597" sub without sort "a"
		set TEMP"2" to MARC."597" sub without sort "b"
		concatenate with delimiter (TEMP"1",TEMP"2","$$Q")
		create pnx."display"."lds36" with TEMP"1"
end


