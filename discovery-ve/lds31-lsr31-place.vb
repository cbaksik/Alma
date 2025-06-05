rule "Primo VE Marc - Lsr31"
	when
		MARC is "752"
	then
		set TEMP"1" to MARC."752" sub without sort "a-d"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 751"
	when
		MARC is "751"
	then
		set TEMP"1" to MARC."751" sub without sort "a,g,e"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 651"
	when
		MARC is "651"  AND
		MARC."651".ind"2" equals "0"
	then
		set TEMP"1" to MARC."651" sub without sort "a,z"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 600"
	when
		MARC is "600"  AND
		MARC."600".ind"2" equals "0"
	then
		set TEMP"1" to MARC."600" sub without sort "z"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 610"
	when
		MARC is "610"  AND
		MARC."610".ind"2" equals "0"
	then
		set TEMP"1" to MARC."610" sub without sort "z"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 611"
	when
		MARC is "611"  AND
		MARC."611".ind"2" equals "0"
	then
		set TEMP"1" to MARC."611" sub without sort "z"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 630"
	when
		MARC is "630"  AND
		MARC."630".ind"2" equals "0"
	then
		set TEMP"1" to MARC."630" sub without sort "z"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 650"
	when
		MARC is "650"  AND
		MARC."650".ind"2" equals "0"
	then
		set TEMP"1" to MARC."650" sub without sort "z"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 662"
	when
		MARC is "662"
	then
		set TEMP"1" to MARC."662" sub without sort "a-d,f-h"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

rule "Primo VE Marc - Lsr31 370"
	when
		MARC is "370"
	then
		set TEMP"1" to MARC."370" sub without sort "c,f,g"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr31" with TEMP"1"
end

