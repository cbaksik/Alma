rule "Primo VE Display - Subject 600"
	when
		MARC."600" has any "a-z" AND
		MARC."600".ind"2"  equals "0"
	then
		set TEMP"1" to MARC."600" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."600" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "600" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."600" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 610"
	when
		MARC."610" has any "a-z" AND
		MARC."610".ind"2"  equals "0"
	then
		set TEMP"1" to MARC."610" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."610" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "610" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."610" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 611"
	when
		MARC."611" has any "a-z" AND
		MARC."611".ind"2"  equals "0"
	then
		set TEMP"1" to MARC."611" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."611" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "611" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."611" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 630"
	when
		MARC."630" has any "a-z" AND
		MARC."630".ind"2"  equals "0"
	then
		set TEMP"1" to MARC."630" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."630" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		kormarc remove nonfiling brackets MARC."630" sourcetag "630" from TEMP"1"
		set TEMP"3" to multilingual by "630" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","") 
		set TEMP"4" to MARC."630" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 648"
	when
		MARC."648" has any "a-z" AND
		MARC."648".ind"2"  equals "0"
	then
		set TEMP"1" to MARC."648" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."648" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "648" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."648" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 650"
	when
		MARC."650" has any "a-z" AND
		MARC."650".ind"2"  equals "0"
	then
		set TEMP"1" to MARC."650" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."650" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "650" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."650" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Prima_Display - Subject 651"
	when
		MARC."651" has any "a-z" AND
		MARC."651".ind"2"  equals "0"  
	then
		set TEMP"1" to MARC."651" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."651" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "651" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."651" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create operational."prima_display"."subject" with TEMP"1"
end

// begin 880 for LCSH

rule "Primo VE Display- Subject 880-600"
	when
		MARC."880" has any "a-z" AND 
		MARC."880".ind"2"  equals "0" AND
		MARC."880"."6" match "600-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-610"
	when
		MARC."880" has any "a-z" AND 
		MARC."880".ind"2"  equals "0" AND
		MARC."880"."6" match "610-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-611"
	when
		MARC."880" has any "a-z" AND
		MARC."880".ind"2"  equals "0" AND
		MARC."880"."6" match "611-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-630"
	when
		MARC."880" has any "a-z" AND
		MARC."880".ind"2"  equals "0" AND
		MARC."880"."6" match "630-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-648"
	when
		MARC."880" has any "a-z" AND
		MARC."880".ind"2"  equals "0" AND
		MARC."880"."6" match "648-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-650"
	when
		MARC."880" has any "a-z" AND
		MARC."880".ind"2"  equals "0" AND
		MARC."880"."6" match "650-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-651"
	when
		MARC."880" has any "a-z" AND
		MARC."880".ind"2"  equals "0" AND
		MARC."880"."6" match "651-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

// end 880 LCSH - begin non LCSH

rule "Prima_Display - Subject 651 wikidata"
	when
		MARC."651" has any "a-z" AND
		MARC."651".ind"2"  equals "7" AND
		MARC."651"."2" match "wikidata"
	then
		set TEMP"1" to MARC."651" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."651" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "651" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."651" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create operational."prima_display"."subject" with TEMP"1"
end

rule "Prima_Display - Subject 650 ascl,homoit,fnhl,wikidata"
	when
		MARC."650" has any "a-z" AND
		MARC."650".ind"2"  equals "7" AND
		(MARC."650"."2" match "wikidata" OR
		MARC."650"."2" match "ascl" OR
		MARC."650"."2" match "homoit" OR
		MARC."650"."2" match "fnhl")
	then
		set TEMP"1" to MARC."650" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."650" sub without sorting "x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "650" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."650" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
		concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
		create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE - Lds31 662"
	when
		MARC is "662"
	then
		set TEMP"1" to MARC."662" sub without sorting "a-d,f-h" delimited by " -- "
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."662" sub without sort "e"
		add prefix (TEMP"2","[")
		add suffix (TEMP"2","]")
		concatenate with delimiter (TEMP"1",TEMP"2","")
		add suffix (TEMP"1","$$Q")
		set TEMP"3" to MARC."662" sub without sort "a-d,f-h"
		concatenate with delimiter (TEMP"1",TEMP"3","")
 		create pnx."display"."subject" with TEMP"1"
end