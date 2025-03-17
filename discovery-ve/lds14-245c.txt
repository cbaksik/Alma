rule "Primo VE - Lds14"
	when
		MARC."245" has any "c" 
	then
		create pnx."display"."lds14" with MARC "245" sub without sort "c"
end


// begin 880

rule "Primo VE - Lds14 - 880"
	when
		MARC."880" has any "c" AND
		MARC."880"."6" match "245-.*"  
	then
		create pnx."display"."lds14" with MARC "880" sub without sort "c"
end
