rule "Primo VE Marc - Lsr22"
	when
		MARC."592" has any "a" AND
		MARC."592".ind"2"  equals "9"
	then
		create pnx."search"."lsr22" with MARC "592" subfields "a"
end

rule "Primo VE Marc - Lsr22 components"	
	when
		MARC."599" has any "m" AND
		MARC."599".ind"2"  equals "9"
	then
		create pnx."search"."lsr22" with MARC."599" sub without sort "m" 
end


