rule "Primo VE Marc - Lsr23"
	when
		MARC."593" has any "a" AND
		MARC."593".ind"2"  equals "9"
	then
		create pnx."search"."lsr23" with MARC "593" subfields "a"
end

rule "Primo VE Marc - Lsr23 components"	
	when
		MARC."599" has any "3" AND
		MARC."599".ind"2"  equals "9"
	then
		create pnx."search"."lsr23" with MARC."599" sub without sort "3" 
end


