rule "Primo VE Marc - Lsr40"
	when
		MARC.control is "008"
	then
		set TEMP"1" to MARC.control."008".Language
		create pnx."search"."lsr40" with TEMP"1"
end

rule "Primo VE Marc - Lsr40 041"
	when
		MARC is "041"."a"
	then
		set TEMP"2" to MARC."041"."a"
		lower case (TEMP"2")
		return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
		create pnx."search"."lsr40" with list TEMP"1"
end

rule "Primo VE Marc - Lsr40 041 additional"
	when
		MARC."041" has any "b,d,e,g"
	then
		set TEMP"1" to MARC."041" sub without sort "b,d,e,g" 
		create pnx."search"."lsr40" with TEMP"1"
end

rule "Primo VE Marc - Lsr40 377 "
	when
		MARC is "377"
	then
		create pnx."search"."lsr40" with MARC "377" sub without sort "a" 
end
