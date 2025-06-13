rule "Primo VE Marc - Lsr70"
	when
		MARC."382" has any "3,a-v" 
	thenlds
		create pnx."search"."lsr70" with MARC."382" sub without sort "3,a-v" 
end


// begin 880

rule "Primo VE - Lsr70 - 880"
	when
		MARC."880" has any "3,a-v" AND
		MARC."880"."6" match "382-.*"  
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-v" 
		create pnx."search"."lsr70" with TEMP"1"
end

