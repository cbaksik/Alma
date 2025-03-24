rule "Primo VE - Lds29"
	when
		MARC is "580"."a"
	then
		create pnx."display"."lds29" with MARC "580"."a"
end

rule "Primo VE - Lds29 880-580"
	when
		MARC is "880" AND
		MARC."880"."6" match "580-.*"
	then
		create pnx."display"."lds29" with MARC "880" sub without sort "a"
end