rule "Primo VE Marc - Lsr66"
	when
		MARC."590" has any "f" AND
		MARC."590".ind"2"  equals "9"
	then
		set TEMP"1" to MARC "590" sub without sort "f"
		add prefix (TEMP"1","$$T")
		add suffix (TEMP"1","$$")
		create pnx."search"."lsr66" with  TEMP"1"
end

