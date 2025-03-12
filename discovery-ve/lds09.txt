rule "Primo VE - Lds09"
	when
		MARC."555" has any "3,a-d" AND NOT 
		MARC."555"."u" match ".*"
	then
		create pnx."display"."lds09" with MARC "555" sub without sort "3,a-d"
end

rule "Primo VE - Lds09 555 with link"
	when
		MARC."555" has any "u"
	then
		set TEMP"1" to MARC."555" sub without sort "3,a-d"
		set TEMP"2" to MARC."555" sub without sort "u"
		set TEMP"3" to MARC."555" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">")
		concatenate with delimiter  (TEMP"2",TEMP"3","")
		add suffix (TEMP"2","</a>")
		concatenate with delimiter  (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds09" with TEMP"1"
end

// begin 880

rule "Primo VE - Lds09 - 555-880"
	when
		MARC."880" has any "3,a-d,u" AND
		MARC."880"."6" match "555-.*"  
	then
		create pnx."display"."lds09" with MARC "880" sub without sort "3,a-d,u"
end