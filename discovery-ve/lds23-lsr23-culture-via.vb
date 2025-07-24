rule "Primo VE Marc - Lsr23"
	when
		MARC."593" has any "a" AND
		MARC."593".ind"2"  equals "9"
	then
		create pnx."search"."lsr23" with MARC "593" subfields "a"
end

