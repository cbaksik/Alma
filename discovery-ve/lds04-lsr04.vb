rule "Primo VE Marc - Lsr04"
	when
		MARC is "911"."a" AND NOT
		MARC."911"."a" match "GIFT.*"
	then
		set TEMP"1" to MARC."911"."a"
		replace string by string (TEMP"1","(.{3}).{8}(.{6}).*","$1_$2")
		create pnx."search"."lsr04" with TEMP"1"
end