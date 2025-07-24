rule "Primo VE - Lds24"
	when
		MARC "594" has any "a,e" AND
		MARC."594".ind"2"  equals "9"
	then
		set TEMP"1" to MARC "594" sub without sort "a,e"
		create pnx."display"."lds24" with TEMP"1"
end

