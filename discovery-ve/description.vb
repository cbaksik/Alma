rule "Primo VE - Description 520"
	when
        MARC is "520" AND 
		(MARC."520".ind"1" equals "8" OR 
		MARC."520".ind"1" equals "0" OR
		MARC."520".ind"1" equals " ")
	then
        create pnx."display"."description" with MARC."520" sub without sort "3,a-c" 
end

rule "Primo VE - Description 520 1st 1"
	when
        MARC is "520" AND 
		MARC."520".ind"1" equals "1"
	then
		set TEMP"1" to MARC."520" sub without sort "3,a-c" 
		add prefix (TEMP"1","Review: ")
		create pnx."display"."description" with TEMP"1"
end

rule "Primo VE - Description 520 1st 2"
	when
        MARC is "520" AND 
		MARC."520".ind"1" equals "2"
	then
		set TEMP"1" to MARC."520" sub without sort "3,a-c" 
		add prefix (TEMP"1","Scope and content: ")
		create pnx."display"."description" with TEMP"1"
end

rule "Primo VE - Description 520 1st 3"
	when
        MARC is "520" AND 
		MARC."520".ind"1" equals "3"
	then
		set TEMP"1" to MARC."520" sub without sort "3,a-c" 
		add prefix (TEMP"1","Abstract: ")
		create pnx."display"."description" with TEMP"1"
end

rule "Primo VE - Description 520 1st 4"
	when
        MARC is "520" AND 
		MARC."520".ind"1" equals "4"
	then
		set TEMP"1" to MARC."520" sub without sort "3,a-c" 
		add prefix (TEMP"1","Content advice: ")
		create pnx."display"."description" with TEMP"1"
end

rule "Primo VE - Description 880-520"
	when
        MARC is "880" AND
        MARC."880"."6" match "520-.*"
	then
        create pnx."display"."description" with MARC."880" sub without sort "3,a-c" 
end
