rule "Primo VE Marc - Lsr26"
	when
		MARC "596" has any "a,b" AND
		MARC."596".ind"2"  equals "9"
	then
		set TEMP"1" to MARC "596" sub without sort "a,b"
		create pnx."search"."lsr26" with TEMP"1"
end



