rule "Primo VE Marc - Lsr30"
	when
		MARC."655" has any "a-z" AND
		MARC."655".ind"2" equals "0"
	then
		set TEMP"1" to MARC."655" sub without sort "a"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 600"
	when
		MARC."600" has any "v" AND
		MARC."600".ind"2" equals "0"
	then
		set TEMP"1" to MARC."600" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 610"
	when
		MARC."610" has any "v" AND
		MARC."610".ind"2" equals "0"
	then
		set TEMP"1" to MARC."610" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 611"
	when
		MARC."611" has any "v" AND
		MARC."611".ind"2" equals "0"
	then
		set TEMP"1" to MARC."611" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 630"
	when
		MARC."630" has any "v" AND
		MARC."630".ind"2" equals "0"
	then
		set TEMP"1" to MARC."630" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 648"
	when
		MARC."648" has any "v" AND
		MARC."648".ind"2" equals "0"
	then
		set TEMP"1" to MARC."648" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 650"
	when
		MARC."650" has any "v" AND
		MARC."650".ind"2" equals "0"
	then
		set TEMP"1" to MARC."650" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 651"
	when
		MARC."651" has any "v" AND
		MARC."651".ind"2" equals "0"
	then
		set TEMP"1" to MARC."651" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 654"
	when
		MARC."654" has any "v" AND
		MARC."654".ind"2" equals "0"
	then
		set TEMP"1" to MARC."654" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 656"
	when
		MARC."656" has any "v" AND
		MARC."656".ind"2" equals "0"
	then
		set TEMP"1" to MARC."656" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE Marc - Lsr30 657"
	when
		MARC."657" has any "v" AND
		MARC."657".ind"2" equals "0"
	then
		set TEMP"1" to MARC."657" sub without sort "v"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE - lsr30 655 sf 7"
	when
		MARC."655" has any "a-z" AND
		MARC."655".ind"2" equals "7" AND NOT
		(MARC."655"."2" match "barngf" OR
		MARC."655"."2" match "bellobv" OR
		MARC."655"."2" match "buscxf" OR
		MARC."655"."2" match "gatbeg" OR
		MARC."655"."2" match "gnd.*" OR
		MARC."655"."2" match "idref" OR
		MARC."655"."2" match "mts" OR
		MARC."655"."2" match "muzeukv" OR
		MARC."655"."2" match "nbdbgf" OR
		MARC."655"."2" match "ncr.*" OR
		MARC."655"."2" match "ndlgft" OR
		MARC."655"."2" match "nskzs" OR
		MARC."655"."2" match "ntsf" OR
		MARC."655"."2" match "rvmgf" OR
		MARC."655"."2" match "saogf" OR
		MARC."655"."2" match "sgp" OR
		MARC."655"."2" match "slm" OR
		MARC."655"."2" match "tgfbne" OR
		MARC."655"."2" match "tgfc" OR
		MARC."655"."2" match "tpro")
	then
		set TEMP"1" to MARC."655" sub without sort  "a" 
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		lower case (TEMP"1")
		create pnx."search"."lsr30" with TEMP"1"
end

rule "Primo VE - lsr30 880-655"
	when
		MARC is "880" AND
		MARC."880"."6" match "655-.*"
	then
		set TEMP"1" to MARC."880" sub without sort  "a-z" 
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr30" with TEMP"1"
end

