rule "Primo VE - Lds07"
	when
		MARC."264" has any "3,a-c" AND
		MARC."264".ind"2"  equals "0"
	then
		set TEMP"1" to MARC."264" sub without sort "3,a-c"
		add prefix (TEMP"1","Produced: ")
		create pnx."display"."lds07" with TEMP"1"
end

rule "Primo VE - 264 2nd ind 2"
	when
		MARC."264" has any "3,a-c" AND
		MARC."264".ind"2"  equals "2"
	then
		set TEMP"1" to MARC."264" sub without sort "3,a-c"
		add prefix (TEMP"1","Distributed: ")
		create pnx."display"."lds07" with TEMP"1"
end

rule "Primo VE - 264 2nd ind 3"
	when
		MARC."264" has any "3,a-c" AND
		MARC."264".ind"2"  equals "3"
	then
		set TEMP"1" to MARC."264" sub without sort "3,a-c"
		add prefix (TEMP"1","Manufactured: ")
		create pnx."display"."lds07" with TEMP"1"
end

rule "Primo VE - 264 2nd ind 4"
	when
		MARC."264" has any "3,a-c" AND
		MARC."264".ind"2"  equals "4"
	then
		set TEMP"1" to MARC."264" sub without sort "3,a-c"
		add prefix (TEMP"1","Copyright notice: ")
		create pnx."display"."lds07" with TEMP"1"
end

rule "Primo VE - 257"
	when
		MARC is "257"
	then
		set TEMP"1" to MARC."257" sub without sort "a"
		add prefix (TEMP"1","Country of producer: ")
		create pnx."display"."lds07" with TEMP"1"
end
// begin 880


rule "Primo VE - Lds07 880 264"
	when
		MARC."880" has any "3,a-d,u" AND
		MARC."880"."6" match "264-.*"  
	then
		create pnx."display"."lds07" with MARC "880" sub without sort "3,a-d,u"
end


rule "Primo VE - Lds07 880 257"
	when
		MARC."880" has any "a" AND
		MARC."880"."6" match "257-.*"  
	then
		create pnx."display"."lds07" with MARC "880" sub without sort "a"
end
