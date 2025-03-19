rule "Primo VE - Format 300"
	when
		MARC is "300"
	then
	    create pnx."display"."format" with MARC."300" sub without sort "3,a-z"
end

rule "Primo VE - Format 251"
	when
		MARC is "251"
	then
	    set TEMP"1" to MARC."251" sub without sort "3,a"
	    add prefix (TEMP"1","Version: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 254"
	when
		MARC is "254"
	then
	    create pnx."display"."format" with MARC."254" sub without sort "3,a-z"
end

rule "Primo VE - Format 255"
	when
		MARC is "255"
	then
	    create pnx."display"."format" with MARC."255" sub without sort "3,a-z"
end

rule "Primo VE - Format 256"
	when
		MARC is "256"
	then
	    create pnx."display"."format" with MARC."256" sub without sort "3,a-z"
end

rule "Primo VE - Format 340"
	when
		MARC is "340"
	then
	    create pnx."display"."format" with MARC."340" sub without sort "3,a-z"
end

rule "Primo VE - Format 341"
	when
		MARC is "341"
	then
	    set TEMP"1" to MARC."341" sub without sort "3,a"
	    add prefix (TEMP"1","Accessibility: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 344"
	when
		MARC is "344"
	then
	    set TEMP"1" to MARC."344" sub without sort "3,a"
	    add prefix (TEMP"1","Sound: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 345"
	when
		MARC is "345"
	then
	    set TEMP"1" to MARC."345" sub without sort "3,a"
	    add prefix (TEMP"1","Moving image: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 346"
	when
		MARC is "346"
	then
	    set TEMP"1" to MARC."346" sub without sort "3,a"
	    add prefix (TEMP"1","Video: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 347"
	when
		MARC is "347"
	then
	    set TEMP"1" to MARC."347" sub without sort "3,a"
	    add prefix (TEMP"1","Digital: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 348"
	when
		MARC is "348"
	then
	    set TEMP"1" to MARC."348" sub without sort "3,a"
	    add prefix (TEMP"1","Notated music: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 351"
	when
		MARC is "351"
	then
	    create pnx."display"."format" with MARC."351" sub without sort "3,a-z"
end

rule "Primo VE - Format 353"
	when
		MARC is "353"
	then
	    set TEMP"1" to MARC."353" sub without sorting "3,a" delimited by " -- "
	    add prefix (TEMP"1","Supplementary: ")
		create pnx."display"."format" with TEMP"1"
end

rule "Primo VE - Format 507"
	when
		MARC."507" has any "a,b"
	then
		create pnx."display"."format" with MARC "507" sub without sort "a-b" 
end

// 880

rule "Primo VE - Format 880-300"
	when
        MARC is "880" AND
        MARC."880"."6" match "300-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-251"
	when
        MARC is "880" AND
        MARC."880"."6" match "251-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-254"
	when
        MARC is "880" AND
        MARC."880"."6" match "254-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-255"
	when
        MARC is "880" AND
        MARC."880"."6" match "255-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-256"
	when
        MARC is "880" AND
        MARC."880"."6" match "256-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-340"
	when
        MARC is "880" AND
        MARC."880"."6" match "340-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-341"
	when
        MARC is "880" AND
        MARC."880"."6" match "341-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-344"
	when
        MARC is "880" AND
        MARC."880"."6" match "344-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-345"
	when
        MARC is "880" AND
        MARC."880"."6" match "345-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-346"
	when
        MARC is "880" AND
        MARC."880"."6" match "346-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-347"
	when
        MARC is "880" AND
        MARC."880"."6" match "347-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-348"
	when
        MARC is "880" AND
        MARC."880"."6" match "348-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-351"
	when
        MARC is "880" AND
        MARC."880"."6" match "351-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-353"
	when
        MARC is "880" AND
        MARC."880"."6" match "353-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end

rule "Primo VE - Format 880-507"
	when
        MARC is "880" AND
        MARC."880"."6" match "507-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sort "3,a-z" 
end