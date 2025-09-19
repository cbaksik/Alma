rule "Primo VE Marc - Lsr26"
	when
		MARC "596" has any "a,b" AND
		MARC."596".ind"2"  equals "9"
	then
		set TEMP"1" to MARC "596" sub without sort "a,b"
		create pnx."search"."lsr26" with TEMP"1"
end

rule "Primo VE Marc - Lsr26 surrogate"
	when
		MARC "598" has any "r" AND
		MARC."598".ind"2"  equals "9"
	then
		set TEMP"1" to MARC "598" sub without sort "r"
		create pnx."search"."lsr26" with TEMP"1"
end

rule "Primo VE Marc - Lsr26 component"
	when
		MARC "599" has any "8,r" AND
		MARC."599".ind"2"  equals "9"
	then
		set TEMP"1" to MARC "599" sub without sort "8,r"
		create pnx."search"."lsr26" with TEMP"1"
end


