rule "Primo VE Marc - Lsr01"
	when
		MARC.control is "001"
	then
		set TEMP"1" to MARC.control."001"
		create pnx."search"."lsr01" with TEMP"1"
end

rule "Primo VE Marc - 900"
	when
		MARC."900" has any "a"
	then
		set TEMP"1" to MARC."900" sub without sort "a"
		set TEMP"2" to MARC."900" sub without sort "a"
		remove substring using regex (TEMP"2","^0+")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."search"."lsr01" with TEMP"1"
end

rule "Primo VE Marc - 901"
	when
		MARC."901" has any "a"
	then
		set TEMP"1" to MARC."901" sub without sort "a"
		create pnx."search"."lsr01" with TEMP"1"
end




