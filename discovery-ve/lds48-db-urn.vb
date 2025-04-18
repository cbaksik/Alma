rule "Primo VE - Lds48"
	when
		MARC is "918"."a"
	then
		set TEMP"1" to MARC."918" sub without sort "a"
		set TEMP"2" to MARC."918" sub without sort "a"
		set TEMP"3" to MARC."918" sub without sort "z"
		add prefix (TEMP"1","<a href=\"")
		add suffix (TEMP"1","\">")
		concatenate with delimiter (TEMP"1",TEMP"2","")
		add suffix (TEMP"1","</a>")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		create pnx."display"."lds48" with TEMP"1"
end
