rule "Primo VE - frequency"
	when
		MARC is "310"
	then
		create pnx."display"."frequency" with MARC "310" excluding num subfields without sort
end

rule "Primo VE - frequency 321"
	when
		MARC is "321"
	then
		set TEMP"1" to MARC."321" excluding num subfields without sort
		add prefix (TEMP"1","Formerly: ")
		create pnx."display"."frequency" with TEMP"1"
end

// BEGIN 880

rule "Primo VE - frequency 880-310"
	when
		MARC."880" has any "a" AND
		MARC."880"."6" match "310-.*" 
	then
		create pnx."display"."frequency" with MARC "880" excluding num subfields without sort
end

rule "Primo VE - frequency 880-321"
	when
		MARC."880" has any "a" AND
		MARC."880"."6" match "321-.*" 
	then
		create pnx."display"."frequency" with MARC "880" excluding num subfields without sort
end
