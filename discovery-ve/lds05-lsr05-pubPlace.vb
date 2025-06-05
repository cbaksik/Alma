rule "Primo VE Marc - Lsr05"
	when
		MARC is "264"."a"
	then
		create pnx."search"."Lsr05" with MARC "264"."a"
end

rule "Primo VE Marc - Lsr05-260"
	when
		MARC."260" has any "a,e"
	then
		create pnx."search"."Lsr05" with MARC "260" sub without sort "a,e"
end

rule "Primo VE Marc - Lsr05-752"
	when
		MARC."752" has any "a-d"
	then
		create pnx."search"."Lsr05" with MARC "752" sub without sort "a-d"
end

// rule has no display equivalent

// begin 880

rule "Primo VE - Lsr05-880-264"
	when
		MARC."880" has any "a" AND
		MARC."880"."6" match "264-.*" 
	then
		create pnx."search"."Lsr05" with MARC "880" sub without sort "a"
end

rule "Primo VE - Lsr05 880-260"
	when
		MARC."880" has any "a,e" AND
		MARC."880"."6" match "260-.*" 
	then
		create pnx."search"."Lsr05" with MARC "880" sub without sort "a,e"
end

rule "Primo VE - Lsr05 880-752"
	when
		MARC."880" has any "a-d" AND
		MARC."880"."6" match "752-.*" 
	then
		create pnx."search"."Lsr05" with MARC "880" sub without sort "a-d"
end

