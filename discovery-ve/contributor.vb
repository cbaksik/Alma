rule "Primo VE Display - contributor 700"
	when
		 MARC."700" has any "a-d" AND NOT
		MARC."700"."e" match "former owner"
	then
		set TEMP"1" to MARC."700" sub without sort "3,i,a,b,c,q,d,j"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."700" sub without sort "e"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."700" sub without sort "f,g,h,k,l,m,n,o,p,r,s,t,u"
		concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		set TEMP"4" to MARC."700" sub without sort "a,b,c,q,d,j"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."contributor" with TEMP"1"
end

rule "Primo VE Display - contributor 700 former owner"
	when
		 MARC."700" has any "a-d" AND
		MARC."700"."e" match "former owner"
	then
		set TEMP"1" to MARC."700" sub without sort "3,i,a,b,c,q,d,j"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."700" sub without sort "e"
		remove substring using regex (TEMP"2","(;|,|\\.)+$")
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."700" sub without sort "f,g,h,k,l,m,n,o,p,r,s,t,u"
		concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		set TEMP"4" to MARC."700" sub without sort "a,b,c,q,d,j,e"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."contributor" with TEMP"1"
end

rule "Primo VE - Lds06 - 880-700 rev"
	when
        MARC is "880" AND
        MARC."880"."6" match "700-.*"
	then
        create pnx."display"."contributor" with MARC."880" sub without sort "3,a-z" 
end