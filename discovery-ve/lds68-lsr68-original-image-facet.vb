rule "Primo VE Marc - Lsr68"	
	when
		MARC."590" has any "c" AND
		MARC."590".ind"2"  equals "9" AND
		MARC."590"."c" match "true"
	then
		set TEMP"1" to MARC."590" sub without sort "b"
		add prefix (TEMP"1","[")
		add suffix (TEMP"1"," images]")
		create pnx."search"."lsr68" with "Yes"
end


