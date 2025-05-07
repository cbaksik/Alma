rule "Primo VE - Lds67"
	when
		MARC."590" has any "h" AND
		MARC."590".ind"2"  equals "9"
	then
		create pnx."display"."lds67" with MARC "590" subfields "h"
end
