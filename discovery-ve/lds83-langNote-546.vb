rule "Primo VE - Lds83"
	when
		MARC."546" has any "3,a-b" 
	then
		set TEMP"1" to MARC."546" sub without sort "3,a-b" 
		create pnx."display"."lds83" with TEMP"1"
end

// begin 880

rule "Primo VE - Lds83 546-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "546.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-b" 
		create pnx."display"."lds83" with TEMP"1"
end
