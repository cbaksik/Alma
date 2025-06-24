rule "Primo VE Marc - Lsr61"
	when
		MARC is "245"."k"
	then
		create pnx."search"."lsr61" with MARC "245"."k"
end

rule "Primo VE Marc - Lsr61 222"
	when
		MARC is "222"."a"
	then
		create pnx."search"."lsr61" with MARC "222"."a"
end


