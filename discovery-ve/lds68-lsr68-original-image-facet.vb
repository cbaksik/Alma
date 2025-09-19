rule "Primo VE Marc - Lsr68"	
	when
		MARC."590" has any "c" AND
		MARC."590".ind"2"  equals "9" AND
		MARC."590"."c" match "true"
	then
		set TEMP"1" to MARC."590" sub without sort "c"
		add prefix (TEMP"1","$$T")
		add suffix (TEMP"1","$$")
		create pnx."search"."lsr68" with "hvd-img-orig-true"
end


