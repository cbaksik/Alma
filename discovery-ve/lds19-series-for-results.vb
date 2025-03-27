rule "Primo VE - Lds19"
	when
		MARC is "830" AND NOT
		MARC."830"."5" match ".*" AND NOT
		MARC."830"."6" match "880-.*"
	then
		set TEMP"1" to MARC."830" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."830" sub without sort "v"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		add prefix (TEMP"1","(")	
		add suffix (TEMP"1",")")	
		set pnx."display"."lds19" to TEMP"1"
end


// begin 880

rule "Primo VE - Lds19 880-830"
	when
		MARC is "880" AND
		MARC."880"."6" match "830-.*" AND NOT
		MARC."880"."5" match ".*"
	then
		set TEMP"1" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		add prefix (TEMP"1","(")	
		add suffix (TEMP"1",")")	
		set pnx."display"."lds19" to TEMP"1"
end
