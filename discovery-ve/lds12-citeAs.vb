rule "Primo VE - Lds12"
	when
		MARC is "524"."a"
	then
		create pnx."display"."lds12" with MARC "524" sub without sorting "3,a" delimited by ": "
end

rule "Primo VE - Format 880-524"
	when
        MARC is "880" AND
        MARC."880"."6" match "524-.*"
	then
        create pnx."display"."format" with MARC."880" sub without sorting "3,a" delimited by ": "
end
