rule "Primo VE Display - Creator 100"
	when
		 MARC."100" has any "a-d"
	then
		set TEMP"1" to MARC."100" sub without sort "3,i,a,b,c,q,d,j"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."100" sub without sort "e"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."100" sub without sort "f,g,h,k,l,m,n,o,p,r,s,t,u"
		concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		set TEMP"4" to MARC."100" sub without sort "a,b,c,q,d,j"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."creator" with TEMP"1"
end

rule "Primo VE - creator - 110"
	when
		 MARC."110" has any "a-d"
	then
		set TEMP"1" to MARC."110" sub without sort "3,i,a,b,t,c,d,g,k,n,p"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."110" sub without sort "e"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."110" sub without sort "f,h,l,m,o,r,s,u,x"
		concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		set TEMP"4" to MARC."110" sub without sort "i,a,b,t,c,d,g,k,n,p"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."creator" with TEMP"1"
end

rule "Primo VE - creator - 111"
	when
		 MARC."111" has any "a-g"
	then
		set TEMP"1" to MARC."111" sub without sort "a-g,k,l,n,p,q,s,t,u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."111" sub without sort "h,i,j"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"4" to MARC."111" sub without sort "a-f,k,l,n,p,q,s,t,u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."creator" with TEMP"1"
end

rule "Primo VE - creator - 880-100"
	when
        MARC is "880" AND
        MARC."880"."6" match "100-.*"
	then
        create pnx."display"."creator" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - creator - 880-110"
	when
        MARC is "880" AND
        MARC."880"."6" match "110-.*"
	then
        create pnx."display"."creator" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - creator - 880-111"
	when
        MARC is "880" AND
        MARC."880"."6" match "111-.*"
	then
        create pnx."display"."creator" with MARC."880" sub without sort "3,a-z" 
end