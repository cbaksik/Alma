rule "Primo VE - Lds25"
	when
		MARC "595" has any "a,u" AND
		MARC."595".ind"2"  equals "9"
	then
		set TEMP"1" to MARC "595" sub without sort "a"
		set TEMP"2" to MARC."595" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">")
		concatenate with delimiter  (TEMP"2",TEMP"1","")
		add suffix (TEMP"2","</a>")
		create pnx."display"."lds25" with TEMP"2"
end


