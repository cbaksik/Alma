rule "Primo VE - Lds39"
      when
		MARC."916" has any "a"
      then
		set TEMP"1" to MARC."916" sub without sort "a"
		add prefix (TEMP"1","$$T")
		add suffix (TEMP"1","$$")
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		create pnx."display"."lds39" with TEMP"1"
end

