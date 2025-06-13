rule "Primo VE - Lds06"
	when
		MARC is "911"."a" AND NOT
		MARC."911"."a" match "GIFT.*"
	then
		set TEMP"1" to MARC."911"."a"
		replace string by string (TEMP"1","(.{3}).{8}(.{6}).*","$1_$2")
		create pnx."display"."lds06" with TEMP"1"
end