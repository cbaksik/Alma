rule "Primo VE Marc - Lsr04"
	when
		 MARC."100" has any "a-d"
	then
		set TEMP"1" to MARC."100" sub without sort "a,b,c,q,d,j"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr04" with TEMP"1"
end

rule "Primo VE Marc - Lsr04 - 700"
	when
		 MARC."700" has any "a-d"
	then
		set TEMP"1" to MARC."700" sub without sort "a,b,c,q,d,j"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr04" with TEMP"1"
end

rule "Primo VE - Lsr04 - 110"
	when
		 MARC."110" has any "a-b"
	then
		set TEMP"1" to MARC."110" sub without sort "a,b"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr04" with TEMP"1"
end

rule "Primo VE - Lsr04 - 710"
	when
		 MARC."710" has any "a-b"
	then
		set TEMP"1" to MARC."710" sub without sort "a,b"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr04" with TEMP"1"
end

rule "Primo VE - Lsr04 - 111"
	when
		 MARC."111" has any "a"
	then
		set TEMP"1" to MARC."111" sub without sort "a,e"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr04" with TEMP"1"
end

rule "Primo VE - Lsr04 - 711"
	when
		 MARC."711" has any "a"
	then
		set TEMP"1" to MARC."711" sub without sort "a,e"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		create pnx."search"."lsr04" with TEMP"1"
end


// 880 

rule "Primo VE - Lsr04 - 880-100"
	when
        MARC is "880" AND
        MARC."880"."6" match "100-.*"
	then
        create pnx."search"."lsr04" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE - Lsr04 - 880-110"
	when
        MARC is "880" AND
        MARC."880"."6" match "110-.*"
	then
        create pnx."search"."lsr04" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE - Lsr04 - 880-111"
	when
        MARC is "880" AND
        MARC."880"."6" match "111-.*"
	then
        create pnx."search"."lsr04" with MARC."880" sub without sort "a-z" 
end



rule "Primo VE - Lsr04 - 880-700"
	when
        MARC is "880" AND
        MARC."880"."6" match "700-.*"
	then
        create pnx."search"."lsr04" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE - Lsr04 - 880-710"
	when
        MARC is "880" AND
        MARC."880"."6" match "710-.*"
	then
        create pnx."search"."lsr04" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE - Lsr04 - 880-711"
	when
        MARC is "880" AND
        MARC."880"."6" match "711-.*"
	then
        create pnx."search"."lsr04" with MARC."880" sub without sort "a-z" 
end