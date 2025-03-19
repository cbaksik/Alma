rule "Primo VE - Dissertation"
	when
		MARC is "502"
	then
		create pnx."display"."dissertation" with MARC "502" sub without sorting "a-z" delimited by ", "
end

// BEGIN 880

rule "Primo VE - dissertation 880-502"
	when
		MARC."880" has any "a" AND
		MARC."880"."6" match "502-.*" 
	then
		create pnx."display"."dissertation" with MARC "880" sub without sorting "a-z" delimited by ", "
end
