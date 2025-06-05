rule "Primo VE Marc - Lsr86"
	when
		MARC is "028"."a"
	then
		create pnx."search"."lsr86" with MARC "028" sub without sort "a,b,q"
end
