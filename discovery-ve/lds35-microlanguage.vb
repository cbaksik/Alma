rule "Primo VE - Lds35"
	when
        MARC.control is "008"
	then
		set TEMP"2" to MARC.control."008".Language
		return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
        add prefix to list (TEMP"1","lang.")
        create pnx."display"."lds35" with list TEMP"1"
end

rule "Primo VE- Language 041 Lds35"
	when
		MARC."041" has any "a,d,e" 
	then
		set TEMP"2" to MARC."041" sub without sort "a,d,e"
        lower case (TEMP"2")
        return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
        add prefix to list (TEMP"1","lang.")
        create pnx."display"."lds35" with list TEMP"1"
end

