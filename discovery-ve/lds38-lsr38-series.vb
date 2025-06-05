rule "Primo VE Marc - Lsr38"
	when
		MARC is "830"
	then
		set TEMP"1" to MARC."830" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 800"
	when
		MARC is "800"
	then
		set TEMP"1" to MARC."800" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 810"
	when
		MARC is "810"
	then
		set TEMP"1" to MARC."810" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 811"
	when
		MARC is "811"
	then
		set TEMP"1" to MARC."811" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 490 first ind 0"
	when
		MARC."490" has any "a" AND
		MARC."490".ind"1"  equals "0"
	then
		set TEMP"1" to MARC."490" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

// special rule for titles of mono series

rule "Primo VE Marc - Lsr38 mono series 245"
	when
		MARC.control."LDR"(7-8) equals "s" AND
		MARC.control."008"(21-22) equals "m" AND
		MARC."245" has any "a"
	then
		set TEMP"1" to MARC."245" sub without sort "a,n,p"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 mono series 222"
	when
		MARC.control."LDR"(7-8) equals "s" AND
		MARC.control."008"(21-22) equals "m" AND
		MARC."222" has any "a"
	then
		set TEMP"1" to MARC."222" sub without sort "a"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

// 880s

rule "Primo VE Marc - Lsr38 880-830"
	when
        MARC is "880" AND
        MARC."880"."6" match "830-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 880-800"
	when
        MARC is "880" AND
        MARC."880"."6" match "800-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 880-810"
	when
        MARC is "880" AND
        MARC."880"."6" match "810-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 880-811"
	when
        MARC is "880" AND
        MARC."880"."6" match "811-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end

rule "Primo VE Marc - Lsr38 880-490"
	when
        MARC is "880" AND
        MARC."880"."6" match "490-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr38" with TEMP"1"
end