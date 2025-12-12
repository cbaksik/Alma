rule "Primo VE - Lds53"
	when
		MARC is "552"."a" 
	then
		set TEMP"1" to MARC."552"."a"
		create pnx."display"."lds53" with TEMP"1"
end

