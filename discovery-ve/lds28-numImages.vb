rule "Primo VE - Lds28"
	when
		MARC."590" has any "b" AND
		MARC."590".ind"2"  equals "9" AND NOT 
		MARC."590"."b" match "0" AND NOT 
		MARC."590"."b" match "1"
	then
		set TEMP"1" to MARC."590" sub without sort "b"
		add prefix (TEMP"1","[")
		add suffix (TEMP"1"," images]")
		create pnx."display"."lds28" with TEMP"1"
end
