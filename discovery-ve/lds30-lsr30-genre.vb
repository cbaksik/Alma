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

// 880

rule "Primo VE - lsr30 880-655"
	when
		MARC is "880" AND
		MARC."880"."6" match "655-.*"
	then
		set TEMP"1" to MARC."880" sub without sort  "a-z" 
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr30" with TEMP"1"
end

// mapping from 008 values only when ldr06and7 are am

rule "Primo VE - lsr30 008 mapping a"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "a" OR 
		MARC.control."008"(19-20) equals "a" OR
		MARC.control."008"(20-21) equals "a" OR
		MARC.control."008"(21-22) equals "a")
	then
		create pnx."search"."lsr30" with "illustrations"
end

rule "Primo VE - lsr30 008 mapping b"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "b" OR 
		MARC.control."008"(19-20) equals "b" OR
		MARC.control."008"(20-21) equals "b" OR
		MARC.control."008"(21-22) equals "b")
	then
		create pnx."search"."lsr30" with "maps"
end

rule "Primo VE - lsr30 008 mapping c"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "c" OR 
		MARC.control."008"(19-20) equals "c" OR
		MARC.control."008"(20-21) equals "c" OR
		MARC.control."008"(21-22) equals "c")
	then
		create pnx."search"."lsr30" with "portraits"
end

rule "Primo VE - lsr30 008 mapping d"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "d" OR 
		MARC.control."008"(19-20) equals "d" OR
		MARC.control."008"(20-21) equals "d" OR
		MARC.control."008"(21-22) equals "d")
	then
		create pnx."search"."lsr30" with "charts"
end

rule "Primo VE - lsr30 008 mapping e"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "e" OR 
		MARC.control."008"(19-20) equals "e" OR
		MARC.control."008"(20-21) equals "e" OR
		MARC.control."008"(21-22) equals "e")
	then
		create pnx."search"."lsr30" with "plans"
end

rule "Primo VE - lsr30 008 mapping f"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "f" OR 
		MARC.control."008"(19-20) equals "f" OR
		MARC.control."008"(20-21) equals "f" OR
		MARC.control."008"(21-22) equals "f")
	then
		create pnx."search"."lsr30" with "plates"
end

rule "Primo VE - lsr30 008 mapping g"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "g" OR 
		MARC.control."008"(19-20) equals "g" OR
		MARC.control."008"(20-21) equals "g" OR
		MARC.control."008"(21-22) equals "g")
	then
		create pnx."search"."lsr30" with "music"
end

rule "Primo VE - lsr30 008 mapping h"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "h" OR 
		MARC.control."008"(19-20) equals "h" OR
		MARC.control."008"(20-21) equals "h" OR
		MARC.control."008"(21-22) equals "h")
	then
		create pnx."search"."lsr30" with "facsimiles"
end

rule "Primo VE - lsr30 008 mapping i"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "i" OR 
		MARC.control."008"(19-20) equals "i" OR
		MARC.control."008"(20-21) equals "i" OR
		MARC.control."008"(21-22) equals "i")
	then
		create pnx."search"."lsr30" with "coats of arms"
end

rule "Primo VE - lsr30 008 mapping j"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "j" OR 
		MARC.control."008"(19-20) equals "j" OR
		MARC.control."008"(20-21) equals "j" OR
		MARC.control."008"(21-22) equals "j")
	then
		create pnx."search"."lsr30" with "genealogical tables"
end

rule "Primo VE - lsr30 008 mapping k"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "k" OR 
		MARC.control."008"(19-20) equals "k" OR
		MARC.control."008"(20-21) equals "k" OR
		MARC.control."008"(21-22) equals "k")
	then
		create pnx."search"."lsr30" with "forms"
end

rule "Primo VE - lsr30 008 mapping l"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "l" OR 
		MARC.control."008"(19-20) equals "l" OR
		MARC.control."008"(20-21) equals "l" OR
		MARC.control."008"(21-22) equals "l")
	then
		create pnx."search"."lsr30" with "samples"
end

rule "Primo VE - lsr30 008 mapping m"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "m" OR 
		MARC.control."008"(19-20) equals "m" OR
		MARC.control."008"(20-21) equals "m" OR
		MARC.control."008"(21-22) equals "m")
	then
		create pnx."search"."lsr30" with "phonodisc phonowire"
end

rule "Primo VE - lsr30 008 mapping o"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "o" OR 
		MARC.control."008"(19-20) equals "o" OR
		MARC.control."008"(20-21) equals "o" OR
		MARC.control."008"(21-22) equals "o")
	then
		create pnx."search"."lsr30" with "photographs"
end

rule "Primo VE - lsr30 008 mapping p"
	when
		MARC.control."LDR"(6-8) equals "am" AND
		(MARC.control."008"(18-19) equals "p" OR 
		MARC.control."008"(19-20) equals "p" OR
		MARC.control."008"(20-21) equals "p" OR
		MARC.control."008"(21-22) equals "p")
	then
		create pnx."search"."lsr30" with "illuminations"
end
