rule "Primo VE - Lds38"
	when
		MARC is "830"
	then
		set TEMP"1" to MARC."830" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."830" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."830" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."830" sub without sort "a-u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end

rule "Primo VE - Lds38 800"
	when
		MARC is "800"
	then
		set TEMP"1" to MARC."800" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."800" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."800" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."800" sub without sort "a-u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end

rule "Primo VE - Lds38 810"
	when
		MARC is "810"
	then
		set TEMP"1" to MARC."810" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."810" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."810" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."810" sub without sort "a-u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end

rule "Primo VE - Lds38 811"
	when
		MARC is "811"
	then
		set TEMP"1" to MARC."811" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."811" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."811" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."811" sub without sort "a-u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end

// begin 880

rule "Primo VE - lds38 880-830"
	when
        MARC is "880" AND
        MARC."880"."6" match "830-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."880" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "a-t"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end

rule "Primo VE - lds38 880-800"
	when
        MARC is "880" AND
        MARC."880"."6" match "800-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."880" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end

rule "Primo VE - lds38 880-810"
	when
        MARC is "880" AND
        MARC."880"."6" match "810-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."880" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end

rule "Primo VE - lds38 880-811"
	when
        MARC is "880" AND
        MARC."880"."6" match "811-.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-u"
		remove substring using regex (TEMP"1","(;|,|\\.)+$")
		set TEMP"2" to MARC."880" sub without sort "v"
		add prefix (TEMP"2"," ; ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "a-u"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4","")
		create pnx."display"."lds38" with TEMP"1"
end
