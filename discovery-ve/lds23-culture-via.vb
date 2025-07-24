rule "Primo VE - Lds23"
	when
		MARC."593" has any "a" AND
		MARC."593".ind"2"  equals "9"
	then
		set TEMP"1" to MARC."593" sub without sort "a"
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		create pnx."display"."lds23" with TEMP"1"
end

