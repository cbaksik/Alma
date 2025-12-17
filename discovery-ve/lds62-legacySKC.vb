rule "Primo VE - Lds62"
	when
		MARC "956" has any "u" AND
		MARC."956"."a" match "legacyKeyContent" 
	then
		set TEMP"1" to MARC."956" sub without sort "a"
		create pnx."display"."lds62" with TEMP"1"
end

