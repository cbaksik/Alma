rule "Primo VE - Lds33"
	when
		MARC is "730"
	then
		set TEMP"1" to MARC."730" sub without sort "3,i,a,d,f,g,h,k,l,m,n,o,p,r,s,t,x"
		set TEMP"2" to MARC."730" sub without sort "a,d,f,g,k,l,m,n,o,p,r,s,t"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"2","")
		create pnx."display"."lds33" with TEMP"1"
end

// begin 880

rule "Primo VE - Lds33 880-730"
	when
		MARC is "880" AND
		MARC."880"."6" match "730.*" 
	then
		set TEMP"1" to MARC."880" sub without sort "3,i,a,d,f,g,h,k,l,m,n,o,p,r,s,t,x"
		set TEMP"2" to MARC."880" sub without sort "a,d,f,g,k,l,m,n,o,p,r,s,t"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"2","")
		create pnx."display"."lds33" with TEMP"1"
end