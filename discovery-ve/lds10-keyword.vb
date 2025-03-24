rule "Primo VE - Lds10"
	when
		MARC is "653"
	then
		create pnx."display"."lds10" with MARC "653" sub without sorting "3,a-z" delimited by " -- "
end

rule "Primo VE - Lds10 tucua"
	when
		MARC."610" has any "a-z" AND
		MARC."610".ind"2"  equals "7" AND
		MARC."610"."2" match "tucua"
	then
		create pnx."display"."lds10" with MARC "610" sub without sorting "3,a-z" delimited by " -- "
end


rule "Primo VE - Lds10 - 654"
	when
		MARC is "654"
	then
		create pnx."display"."lds10" with MARC "654" sub without sorting "3,a-z" delimited by " -- "
end

rule "Primo VE - Lds10 - 656"
	when
		MARC is "656"
	then
		set TEMP"1" to MARC."656" sub without sorting "3,a-z" delimited by " -- "
		add prefix (TEMP"1","Occupation: ")
		create pnx."display"."lds10" with TEMP"1"
end

rule "Primo VE - Lds10 - 657"
	when
		MARC is "657"
	then
		set TEMP"1" to MARC."657" sub without sorting "3,a-z" delimited by " -- "
		add prefix (TEMP"1","Function: ")
		create pnx."display"."lds10" with TEMP"1"
end

rule "Primo VE - Lds10 - 658"
	when
		MARC is "658"
	then
		set TEMP"1" to MARC."658" sub without sorting "3,a-z" delimited by " -- "
		add prefix (TEMP"1","Curriculum objective: ")
		create pnx."display"."lds10" with TEMP"1"
end

rule "Primo VE - Lds10 - 690"
	when
		MARC is "690"
	then
		create pnx."display"."lds10" with MARC "690" sub without sorting "3,a-z" delimited by " -- "
end

rule "Primo VE - Lds10 - 691"
	when
		MARC is "691"
	then
		create pnx."display"."lds10" with MARC "691" sub without sorting "3,a-z" delimited by " -- "
end

rule "Primo VE - Lds10 - 692"
	when
		MARC is "692"
	then
		create pnx."display"."lds10" with MARC "692" sub without sorting "3,a-z" delimited by " -- "
end

rule "Primo VE - Lds10 - 693"
	when
		MARC is "693"
	then
		create pnx."display"."lds10" with MARC "693" sub without sorting "3,a-z" delimited by " -- "
end

rule "Primo VE - Lds10 - 694"
	when
		MARC is "694"
	then
		create pnx."display"."lds10" with MARC "694" sub without sorting "3,a-z" delimited by " -- "
end

rule "Primo VE - Lds10 - 695"
	when
		MARC is "695"
	then
		create pnx."display"."lds10" with MARC "695" sub without sorting "3,a-z" delimited by " -- "
end