rule "Primo VE - Lds77"
	when
		MARC."245" has any "z"
	then
		set TEMP"1" to MARC."245" sub without sort "z"
		create pnx."display"."lds77" with TEMP"1"
end

