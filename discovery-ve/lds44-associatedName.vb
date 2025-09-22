rule "Primo VE - Lds44"
	when
		MARC is "720"."a"
	then
		create pnx."display"."lds44" with MARC "720" sub without sort "a,d,e"
end

rule "Primo VE - Lds06 - 880-720"
	when
        MARC is "880" AND
        MARC."880"."6" match "720-.*"
	then
        create pnx."display"."lds44" with MARC."880" sub without sort "a,d,e"
end