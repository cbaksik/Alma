rule "Primo VE - Lds51"
	when
		MARC "916" has any "a" AND NOT
		MARC."916"."b" match "best"
	then
		set TEMP"1" to MARC."916" sub without sort "a"
		add prefix (TEMP"1","$$T")
		add suffix (TEMP"1","$$")
		create pnx."display"."lds51" with TEMP"1"
end

