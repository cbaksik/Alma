this is not same as rule in UI

rule "Primo VE - Lds69"
	when
		MARC "919" has any "a,b" AND
		MARC."919"."a" match "thumbnail" AND
		MARC."919"."b" match "12*"
	then
		set TEMP"1" to MARC."919" sub without sort "b"
		create pnx."display"."lds69" with TEMP"1"
end