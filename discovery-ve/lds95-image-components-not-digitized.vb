rule "Primo VE - Lds95"
	when
		MARC."599" has any "w"  AND
		MARC."599".ind"2"  equals "9" AND NOT
		MARC."590" has any "u" 
	then
		set TEMP"1" to MARC."599" sub without sort "t,l"
		add prefix (TEMP"1","Title: ")
		set TEMP"2" to MARC."599" sub without sort "h,i"
		add prefix (TEMP"2","Classification: ")
		set TEMP"3" to MARC."599" sub without sort "f,g"
		add prefix (TEMP"3","Work type: ")
		set TEMP"4" to MARC."599" sub without sort "d,4"
		add prefix (TEMP"4","Date: ")
		set TEMP"5" to MARC."599" sub without sort "r,8"
		add prefix (TEMP"5","Repository: ")
		set TEMP"6" to MARC."599" sub without sort "0,2,3,b,a,n,o,p,s"
		add prefix (TEMP"6",":Topics: ")
		set TEMP"7" to MARC."599" sub without sort "6,7"
		add prefix (TEMP"7","Related: ")
		set TEMP"8" to MARC."599" sub without sort "m,5,9,1,c,e,j,k,q,z"
		add prefix (TEMP"8","Other information: ")
		set TEMP"9" to MARC."599" sub without sort "w"
		add prefix (TEMP"9","Component ID: ")
		concatenate with delimiter  (TEMP"1",TEMP"2",". ")
		concatenate with delimiter  (TEMP"1",TEMP"3",". ")
		concatenate with delimiter  (TEMP"1",TEMP"4",". ")
		concatenate with delimiter  (TEMP"1",TEMP"5",". ")
		concatenate with delimiter  (TEMP"1",TEMP"6",". ")
		concatenate with delimiter  (TEMP"1",TEMP"7",". ")
		concatenate with delimiter  (TEMP"1",TEMP"8",". ")
		concatenate with delimiter  (TEMP"1",TEMP"9",". ")
		create pnx."display"."lds95" with TEMP"1"

end

