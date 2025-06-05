rule "Primo VE Marc - Lsr42"
	when
		MARC."044" has any "a"
	then
		set TEMP"1" to MARC."044" sub without sort "a"
		create pnx."search"."lsr42" with TEMP"1"
end

rule "Primo VE Marc - Lsr42 008"
	when
		MARC.control is "008"
	then
		set TEMP"1" to position("008",15-18)
		create pnx."search"."lsr42" with TEMP"1"
end


