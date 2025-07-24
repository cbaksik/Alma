rule "Primo VE - Lds22"
	when
		MARC."592" has any "a" AND
		MARC."592".ind"2"  equals "9"
	then
		set TEMP"1" to MARC."592" sub without sort "a"
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		create pnx."display"."lds22" with TEMP"1"
end

