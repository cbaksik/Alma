rule "Primo VE - Lds17"
	when
		MARC is "490" 
	then
		set TEMP"1" to MARC."490" sub without sort "3,a,l"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."490" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."490" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		create pnx."display"."lds17" with TEMP"1"
end

rule "Primo VE - Lds17 880-490"
	when
        MARC is "880" AND
        MARC."880"."6" match "490-.*"
	then
        create pnx."display"."lds17" with MARC."880" sub without sort "3,a,l,v,x" 
end
