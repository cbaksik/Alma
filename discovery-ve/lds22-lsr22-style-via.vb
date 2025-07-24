rule "Primo VE Marc - Lsr22"
	when
		MARC."592" has any "a" AND
		MARC."592".ind"2"  equals "9"
	then
		create pnx."search"."lsr22" with MARC "592" subfields "a"
end

