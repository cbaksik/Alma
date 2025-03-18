

rule "Primo VE Display- Subject 653"
	when
		MARC."653" has any "a-w"
	then
		set TEMP"1" to MARC."653" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to multilingual by "653" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"2","")
		set TEMP"3" to MARC."653" sub without sort "v"
		remove substring using regex (TEMP"3","\\.+$")
		add suffix (TEMP"3",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 654"
	when
		MARC."654" has any "a-z"
	then
		set TEMP"1" to MARC."654" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."654" sub without sorting "x-z" delimited by " -- "
        remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "654" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."654" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 656"
	when
		MARC."656" has any "a-z"
	then
		set TEMP"1" to MARC."656" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."656" sub without sorting "x-z" delimited by " -- "
        remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "656" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."656" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 657"
	when
		MARC."657" has any "a-z"
	then
		set TEMP"1" to MARC."657" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."657" sub without sorting "x-z" delimited by " -- "
        remove substring using regex (TEMP"2","\\.+$")		
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		set TEMP"3" to multilingual by "657" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"3","")
		set TEMP"4" to MARC."657" sub without sort "v"
		remove substring using regex (TEMP"4","\\.+$")
		add suffix (TEMP"4",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"4"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 658"
	when
		MARC."658" has any "a-w"
	then
		set TEMP"1" to MARC."658" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to multilingual by "658" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"2","")
		set TEMP"3" to MARC."658" sub without sort "v"
		remove substring using regex (TEMP"3","\\.+$")
		add suffix (TEMP"3",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 662"
	when
		MARC."662" has any "a-w"
	then
		set TEMP"1" to MARC."662" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to multilingual by "662" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"2","")
		set TEMP"3" to MARC."662" sub without sort "v"
		remove substring using regex (TEMP"3","\\.+$")
		add suffix (TEMP"3",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end


rule "Primo VE Display- Subject 880-653"
	when
		MARC."880" has any "a-w" AND
		MARC."880"."6" match "653-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"2","")
		set TEMP"3" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"3","\\.+$")
		add suffix (TEMP"3",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-654"
	when
		MARC."880" has any "a-z" AND
		MARC."880"."6" match "654-.*"
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

rule "Primo VE Display- Subject 880-655"
	when
		MARC."880" has any "a-z" AND NOT
		MARC."880".ind"2"  equals "2" AND
		MARC."880"."6" match "655-.*"
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

rule "Primo VE Display- Subject 880-656"
	when
		MARC."880" has any "a-z" AND
		MARC."880"."6" match "656-.*"
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

rule "Primo VE Display- Subject 880-657"
	when
		MARC."880" has any "a-z" AND
		MARC."880"."6" match "657-.*"
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

rule "Primo VE Display- Subject 880-658"
	when
		MARC."880" has any "a-w" AND
		MARC."880"."6" match "658-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
        set TEMP"2" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"2","")
		set TEMP"3" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"3","\\.+$")
		add suffix (TEMP"3",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end

rule "Primo VE Display- Subject 880-662"
	when
		MARC."880" has any "a-w" AND
		MARC."880"."6" match "662-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
        set TEMP"2" to multilingual by "880" "Subject" "display"
		concatenate with delimiter (TEMP"1",TEMP"2","")
		set TEMP"3" to MARC."880" sub without sort "v"
		remove substring using regex (TEMP"3","\\.+$")
		add suffix (TEMP"3",".")	
        concatenate with delimiter (TEMP"1",TEMP"1","$$Q")
        concatenate with delimiter (TEMP"1",TEMP"3"," -- ")
		remove substring using regex (TEMP"1","\\$\\$Q.+[^.]$")
		remove substring using regex (TEMP"1","\\.$")
        create pnx."display"."subject" with TEMP"1"
end
=