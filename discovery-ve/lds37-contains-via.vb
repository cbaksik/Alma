rule "Primo VE - Lds37"
	when
		MARC is "597"."c"  AND
		MARC."597".ind"2"  equals "9"
	then
		set TEMP"1" to MARC."597" sub without sort "c"
		set TEMP"2" to MARC."597" sub without sort "d"
		concatenate with delimiter (TEMP"1",TEMP"2","$$Q")
		create pnx."display"."lds37" with TEMP"1"
end


