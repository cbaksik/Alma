rule "Primo VE - Lds63"
	when
		(MARC."590" has any "r" AND
		MARC."590"."r" match "true") OR
		(MARC."599" has any "x" AND
		MARC."599"."x" match "true")
	then
		create pnx."display"."lds63" with "restricted"
end

