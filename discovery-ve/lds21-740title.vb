rule "Primo VE - Lds21"
	when
		MARC is "740"
	then
		create pnx."display"."lds21" with MARC."740" sub without sort "a,h,n,p" 
end

// begin 880

rule "Primo VE - Lds21 880-740"
	when
		MARC is "880" AND
		MARC."880"."6" match "740.*" 
	then
		create pnx."display"."lds21" with MARC."880" sub without sort "a,h,n,p" 
end