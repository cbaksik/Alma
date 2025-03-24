rule "Primo VE - Genre 600"
	when
		MARC."655" has any "a-z" AND
		MARC."655".ind"2" equals "0"
	then
		set TEMP"1" to MARC."655" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."655" sub without sorting "v,x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		create pnx."display"."genre" with TEMP"1"
end

rule "Primo VE - Genre 655 sf u"
	when
		MARC."655" has any "a-z" AND
		MARC."655".ind"2" equals "7" AND NOT
		(MARC."655"."2" match "barngf" OR
		MARC."655"."2" match "bellobv" OR
		MARC."655"."2" match "buscxf" OR
		MARC."655"."2" match "gatbeg" OR
		MARC."655"."2" match "gnd.*" OR
		MARC."655"."2" match "idref" OR
		MARC."655"."2" match "mts" OR
		MARC."655"."2" match "muzeukv" OR
		MARC."655"."2" match "nbdbgf" OR
		MARC."655"."2" match "ncr.*" OR
		MARC."655"."2" match "ndlgft" OR
		MARC."655"."2" match "nskzs" OR
		MARC."655"."2" match "ntsf" OR
		MARC."655"."2" match "rvmgf" OR
		MARC."655"."2" match "saogf" OR
		MARC."655"."2" match "sgp" OR
		MARC."655"."2" match "slm" OR
		MARC."655"."2" match "tgfbne" OR
		MARC."655"."2" match "tgfc" OR
		MARC."655"."2" match "tpro")
	then
		set TEMP"1" to MARC."655" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."655" sub without sorting "v,x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		create pnx."display"."genre" with TEMP"1"
end

rule "Primo VE - Genre 880-655"
	when
		MARC is "880"."v" AND
		MARC."880"."6" match "655-.*"
	then
		set TEMP"1" to MARC."880" subfields "a-u,w" delimited by " " remove substring using regex "\\.+$"
		set TEMP"2" to MARC."880" sub without sorting "v,x-z" delimited by " -- "
		remove substring using regex (TEMP"2","\\.+$")
		concatenate with delimiter (TEMP"1",TEMP"2"," -- ")
		create pnx."display"."genre" with TEMP"1"
end