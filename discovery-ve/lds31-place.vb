rule "Primo VE - Lds31"
	when
		MARC is "752"
	then
		set TEMP"1" to MARC."752" sub without sorting "a-d,f-h" delimited by " -- "
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		add prefix (TEMP"1","Hierarchical: ")
		set TEMP"2" to MARC."752" sub without sort "e"
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2","")
		add suffix (TEMP"1","$$Q")
		set TEMP"3" to MARC."752" sub without sort "a-d,f-h"
		concatenate with delimiter (TEMP"1",TEMP"3","")
 		create pnx."display"."lds31" with TEMP"1"
end

rule "Primo VE - Lds31 - 751"
	when
		MARC is "751"
	then
		set TEMP"1" to MARC."751" sub without sort "3,a,g,e" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","","")		
		replace wrapping delimiters (TEMP"1","g"," -- ","")		
		replace wrapping delimiters (TEMP"1","e"," [","]")
		add prefix (TEMP"1","Geographic name: ")
		add suffix (TEMP"1","$$Q")
		set TEMP"2" to MARC."751" sub without sort "a,g"
		concatenate with delimiter (TEMP"1",TEMP"2","")
 		create pnx."display"."lds31" with TEMP"1"
end

rule "Primo VE - Lds31 - 370"
	when
		MARC is "370"
	then
		set TEMP"1" to MARC."370" sub without sort "3,c-t" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","i","",": ")		
		replace wrapping delimiters (TEMP"1","c","",". ")		
		replace wrapping delimiters (TEMP"1","f","",". ")		
		replace wrapping delimiters (TEMP"1","g","Place of origin of work or expression: ",". ")		
		replace wrapping delimiters (TEMP"1","s","Start period: ",". ")		
		replace wrapping delimiters (TEMP"1","t","End period: ",". ")	
		replace string by string (TEMP"1","::",":")
		replace string by string (TEMP"1","..",".")
		add suffix (TEMP"1","$$Q")
		set TEMP"2" to MARC."370" sub without sort "c,f,g"
		concatenate with delimiter (TEMP"1",TEMP"2","") 		
        create pnx."display"."lds31" with TEMP"1"
end

// begin 880

rule "Primo VE - lds38 880-752"
	when
        MARC is "880" AND
        MARC."880"."6" match "752-.*"
	then
		set TEMP"1" to MARC."880" sub without sorting "a-d,f-h" delimited by " -- "
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
        add prefix (TEMP"1","Hierarchical: ")
		set TEMP"2" to MARC."880" sub without sort "e"
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2","")
		add suffix (TEMP"1","$$Q")
		set TEMP"3" to MARC."880" sub without sort "a-d,f-h"
		concatenate with delimiter (TEMP"1",TEMP"3","")
 		create pnx."display"."lds31" with TEMP"1"
end

rule "Primo VE - lds38 880-751"
	when
        MARC is "880" AND
        MARC."880"."6" match "751-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a,g,e" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","a","","")		
		replace wrapping delimiters (TEMP"1","g"," -- ","")		
		replace wrapping delimiters (TEMP"1","e"," [","]")
		add prefix (TEMP"1","Geographic name: ")
		add suffix (TEMP"1","$$Q")
		set TEMP"2" to MARC."880" sub without sort "a,g"
		concatenate with delimiter (TEMP"1",TEMP"2","")
 		create pnx."display"."lds31" with TEMP"1"
end

rule "Primo VE - lds38 880-370"
	when
        MARC is "880" AND
        MARC."880"."6" match "370-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,c-t" wrap subfields
		replace wrapping delimiters (TEMP"1","3","",": ")
		replace wrapping delimiters (TEMP"1","i","",": ")		
		replace wrapping delimiters (TEMP"1","c","",". ")		
		replace wrapping delimiters (TEMP"1","f","",". ")		
		replace wrapping delimiters (TEMP"1","g","Place of origin of work or expression: ",". ")		
		replace wrapping delimiters (TEMP"1","s","Start period: ",". ")		
		replace wrapping delimiters (TEMP"1","t","End period: ",". ")	
		replace string by string (TEMP"1","::",":")
		replace string by string (TEMP"1","..",".")
		add suffix (TEMP"1","$$Q")
		set TEMP"2" to MARC."880" sub without sort "c,f,g"
		concatenate with delimiter (TEMP"1",TEMP"2","") 		
        create pnx."display"."lds31" with TEMP"1"
end