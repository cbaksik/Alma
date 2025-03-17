rule "Primo VE - Lds04"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals " "
	then
		create pnx."display"."lds04" with MARC."246" sub without sort "a-p"
end

rule "Primo VE - Lds04 - 1st ind 0"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "0"
	then
		create pnx."display"."lds04" with MARC."246" sub without sort "a-p"
end

rule "Primo VE - Lds04 - 1st ind 3"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "3"
	then
		create pnx."display"."lds04" with MARC."246" sub without sort "a-p"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 3"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "3"
	then
		create pnx."display"."lds04" with MARC."246" sub without sort "a-p"
end

rule "Primo VE - Lds04 - 1st 1, 2nd null"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals " "
	then
		create pnx."display"."lds04" with MARC."246" sub without sort "a-p"
end
// begin section with prefixes

rule "Primo VE - Lds04 - 1st 1, 2nd 0"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "0"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Portion of title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 1"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "1"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Parallel title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 2"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "2"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Distinctive title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 4"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "4"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Cover title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 5"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "5"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Added title page title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 6"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "6"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Caption title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 7"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "7"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Running title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 1st 1, 2nd 8"
	when
		MARC."246" has any "a-p" AND 
		MARC."246".ind"1" equals "1" AND 
		MARC."246".ind"2" equals "8"
	then
		set TEMP"1" to MARC."246" sub without sort "a-p"
		add prefix (TEMP"1","Spine title: ")
		create pnx."display"."lds04" with TEMP"1"
end

rule "Primo VE - Lds04 - 247"
	when
		MARC."247" has any "a-p"
	then
		create pnx."display"."lds04" with MARC."247" sub without sort "a-p"
end

// begin 880

rule "Primo VE - Lds04 - 246-880"
	when
		MARC."880" has any "a-p" AND
		MARC."880"."6" match "246-.*"  
	then
		create pnx."display"."lds04" with MARC "880" sub without sort "a-p"
end

rule "Primo VE - Lds04 - 247-880"
	when
		MARC."880" has any "a-p" AND
		MARC."880"."6" match "247-.*"  
	then
		create pnx."display"."lds04" with MARC "880" sub without sort "a-p"
end