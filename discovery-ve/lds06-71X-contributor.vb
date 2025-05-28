rule "Primo VE - Lds06"
	when
		 MARC."710" has any "a-d"
	then
		set TEMP"1" to MARC."710" sub without sort "3,i,a,b,t,c,d,g,k,n,p"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."710" sub without sort "e"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."710" sub without sort "f,h,l,m,o,r,s,u,x"
		concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		set TEMP"4" to MARC."710" sub without sort "a,b,t,c,d,g,k,n,p"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds06" with TEMP"1"
end

rule "Primo VE - Lds06 - 711"
	when
		 MARC."711" has any "a-g"
	then
		set TEMP"1" to MARC."711" sub without sort "a-g,k,l,n,p,q,s,t,u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."711" sub without sort "h,i,j"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"4" to MARC."711" sub without sort "a,c,d,e,n,p,q,t"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds06" with TEMP"1"
end

rule "Primo VE - Lds06 - 880-710"
	when
        MARC is "880" AND
        MARC."880"."6" match "710-.*"
	then
        create pnx."display"."lds06" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Lds06 - 880-711"
	when
        MARC is "880" AND
        MARC."880"."6" match "711-.*"
	then
        create pnx."display"."lds06" with MARC."880" sub without sort "3,a-z" 
end