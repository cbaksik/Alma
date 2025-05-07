rule "Primo VE - Lds20"
	when
		MARC."590" has any "b" AND
		MARC."590".ind"2"  equals "9"
	then
		create pnx."display"."lds20" with MARC "590" subfields "b"
end
