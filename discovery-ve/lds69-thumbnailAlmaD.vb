rule "Primo VE - Lds69"
	when
		MARC "919" has any "a,b" AND
		MARC."919"."a" match "thumbnail" 
	then
		set TEMP"1" to MARC."919" sub without sort "b"
		create pnx."display"."lds69" with TEMP"1"
end


