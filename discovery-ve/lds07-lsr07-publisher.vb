rule "Primo VE Marc - Lsr07"
	when
		MARC is "264"."b"
	then
		create pnx."search"."lsr07" with MARC "264"."b"
end

rule "Primo VE Marc - Lsr07-260"
	when
		MARC."260" has any "b,f"
	then
		create pnx."search"."lsr07" with MARC "260" sub without sort "b,f"
end

rule "Primo VE Marc - Lsr07-028b"
	when
		MARC is "028"."b"
	then
		create pnx."search"."lsr07" with MARC "028"."b"
end

// begin 880

rule "Primo VE - Lsr07-880-264"
	when
		MARC."880" has any "b" AND
		MARC."880"."6" match "264-.*" 
	then
		create pnx."search"."lsr07" with MARC "880" sub without sort "b"
end

rule "Primo VE - Lsr07 880-260"
	when
		MARC."880" has any "b,f" AND
		MARC."880"."6" match "260-.*" 
	then
		create pnx."search"."lsr07" with MARC "880" sub without sort "b,f"
end

rule "Primo VE - Lsr07 880-028"
	when
		MARC."880" has any "b" AND
		MARC."880"."6" match "028-.*" 
	then
		create pnx."search"."lsr07" with MARC "880" sub without sort "b"
end

