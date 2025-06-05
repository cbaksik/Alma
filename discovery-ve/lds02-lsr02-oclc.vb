rule "Primo VE Marc - Lsr02"
	when
		MARC is "035"."a" AND 
		MARC."035"."a" match ".OCoLC.*"
	then
		set TEMP"1" to MARC "035" sub without sort "a,z"
		replace string by string (TEMP"1",".OCoLC.","")
		create pnx."search"."lsr02" with TEMP"1"
end
