rule "Primo VE - Lds08"
	when
		MARC."555" has any "u"
	then
		set TEMP"1" to MARC."555" sub without sort "u"
		create pnx."display"."lds08" with TEMP"1"
end


