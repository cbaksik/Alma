rule "Primo VE - Lds64"
	when
		MARC."598" has any "a-z"  AND
		MARC."598".ind"2"  equals "9"
	then
		set TEMP"1" to MARC."598" sub without sort "t"
		add prefix (TEMP"1","Title: ")		
		set TEMP"2" to MARC."598" sub without sort "g"
		add prefix (TEMP"2","Type: ")
		concatenate with delimiter (TEMP"1",TEMP"2","<br>")
		set TEMP"3" to MARC."598" sub without sort "a"
		add prefix (TEMP"3","Creator: ")
		concatenate with delimiter (TEMP"1",TEMP"3","<br>")
		set TEMP"4" to MARC."598" sub without sort "c"
		add prefix (TEMP"4","Copyright: ")
		concatenate with delimiter (TEMP"1",TEMP"4","<br>")
		set TEMP"5" to MARC."598" sub without sort "h"
		add prefix (TEMP"5","Classification: ")
		concatenate with delimiter (TEMP"1",TEMP"5","<br>")
		set TEMP"6" to MARC."598" sub without sort "z"
		add prefix (TEMP"6","Note: ")
		concatenate with delimiter (TEMP"1",TEMP"6","<br>")
		set TEMP"7" to MARC."598" sub without sort "n"
		add prefix (TEMP"7","Associated name: ")
		concatenate with delimiter (TEMP"1",TEMP"7","<br>")
		set TEMP"8" to MARC."598" sub without sort "s"
		add prefix (TEMP"8","Subject: ")
		concatenate with delimiter (TEMP"1",TEMP"8","<br>")		
		set TEMP"9" to MARC."598" sub without sort "w"
		add prefix (TEMP"9","ID: ")
		concatenate with delimiter (TEMP"1",TEMP"9","<br>")		
		set TEMP"10" to MARC."598" sub without sort "r"
		add prefix (TEMP"10","Repository: ")
		concatenate with delimiter (TEMP"1",TEMP"10","<br>")	
		create pnx."display"."lds64" with TEMP"1"
end
