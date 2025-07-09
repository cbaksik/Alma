rule "Primo VE - Uniform Title 130"
	when
		MARC is "130"
	then
		set TEMP"1" to MARC."130" excluding num subfields without sort
		set TEMP"4" to MARC."130" sub without sort "a,d,g,k-t"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		concatenate with delimiter (TEMP"1",TEMP"4","$$Q")
		create pnx."display"."unititle" with TEMP"1"
end

rule "Primo VE - Uniform Title 240"
	when
		MARC is "240"
	then
		create pnx."display"."unititle" with MARC."240" excluding num subfields without sort
end

rule "Primo VE - Uniform Title 243"
	when
		MARC is "243"
	then
		create pnx."display"."unititle" with MARC."243" excluding num subfields without sort
end
rule "Primo VE - Alternate Uniform Title 880-130"
	when
		MARC is "880" AND
		MARC."880"."6" match "130-.*"
	then
		set TEMP"1" to MARC."880" excluding num subfields without sort
		create pnx."display"."alternate_uniform_title" with TEMP"1"
end

rule "Primo VE - Alternate Uniform Title 880-240"
	when
		MARC is "880" AND
		MARC."880"."6" match "240-.*"
	then
		set TEMP"1" to MARC."880" excluding num subfields without sort
		create pnx."display"."alternate_uniform_title" with TEMP"1"
end

rule "Primo VE - Alternate Uniform Title 880-243"
	when
		MARC is "880" AND
		MARC."880"."6" match "243-.*"
	then
		set TEMP"1" to MARC."880" excluding num subfields without sort
		create pnx."display"."alternate_uniform_title" with TEMP"1"
end