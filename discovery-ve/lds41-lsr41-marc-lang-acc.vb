rule "Primo VE Marc - Lsr41"
	when
		MARC."041" has any "j,p,q,r,t"
	then
		set TEMP"1" to MARC."041" sub without sort "j,p,q,r,t"
		create pnx."search"."lsr41" with TEMP"1"
end

