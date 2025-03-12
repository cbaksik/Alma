rule "Primo VE - Lds16"
	when
		MARC."545" has any "a,b" 
	then
		create pnx."display"."lds16" with MARC "545" sub without sort "a,b"
end


// begin 880

rule "Primo VE - Lds16 - 880"
	when
		MARC."880" has any "a,b" AND
		MARC."880"."6" match "545-.*"  
	then
		create pnx."display"."lds16" with MARC "880" sub without sort "a,b"
end
