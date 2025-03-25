rule "Primo VE - publisher 260"
	when
		MARC."260" has any "3,a-g" 
	then
		create pnx."display"."publisher" with MARC "260" sub without sort "3,a-g"
end

rule "Primo VE - publisher 264 2nd ind 1"
	when
		MARC."264" has any "3,a-g" AND
		MARC."264".ind"2"  equals "1"
	then
		create pnx."display"."publisher" with MARC "264" sub without sort "3,a-c"
end

rule "Primo VE - publisher 264 2nd ind null"
	when
		MARC."264" has any "3,a-g" AND
		MARC."264".ind"2"  equals " "
	then
		create pnx."display"."publisher" with MARC "264" sub without sort "3,a-c"
end

rule "Primo VE - publisher 362"
	when
		MARC is "362"."a" 
	then
		create pnx."display"."publisher" with MARC "362" sub without sort "a,z"
end

// BEGIN 880

rule "Primo VE - publisher 260-880"
	when
		MARC."880" has any "3,a-g" AND
		MARC."880"."6" match "260-.*"
	then
		create pnx."display"."publisher" with MARC "880" sub without sort "3,a-g"
end

rule "Primo VE - publisher 264-880"
	when
		MARC."880" has any "3,a-g" AND
		MARC."880"."6" match "264-.*" AND
		(MARC."880".ind"2"  equals "1" OR
		MARC."880".ind"2"  equals " ")
	then
		create pnx."display"."publisher" with MARC "880" sub without sort "3,a-g"
end

rule "Primo VE - publisher 362-880"
	when
		MARC."880" has any "a" AND
		MARC."880"."6" match "362-0.*" 
	then
		create pnx."display"."publisher" with MARC "880" sub without sort "3,a-g"
end
