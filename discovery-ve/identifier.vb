rule "Primo VE - Identifier 020"
	when
		MARC is "020"."a"
	then
		set TEMP"1" to MARC "020"."a"
		add prefix (TEMP"1","$$CISBN$$V")
		create pnx."display"."identifier" with TEMP"1"
end

rule "Primo VE - Identifier 022"
	when
		MARC is "022"."a"
	then
		set TEMP"1" to MARC "022"."a"
		add prefix (TEMP"1","$$CISSN$$V")
		create pnx."display"."identifier" with TEMP"1"
end

rule "Primo VE - Identifier 028"
	when
		MARC is "028"."a"
	then
		set TEMP"1" to MARC "028"."a"
		add prefix (TEMP"1","$$CPUBNUM$$V")
		create pnx."display"."identifier" with TEMP"1"
end

rule "Primo VE - Identifier 086"
	when
		MARC is "086"
	then
		set TEMP"1" to MARC."086" sub without sort "0,8,6,a,f,2"
		add prefix (TEMP"1","$$CGOVDOC$$V")
		create pnx."display"."identifier" with TEMP"1"
end

rule "Primo VE - Identifier 017"
	when
		MARC is "017"
	then
		set TEMP"1" to MARC."017" sub without sort "a,b"
		add prefix (TEMP"1","$$CDEPOSIT$$V")
		create pnx."display"."identifier" with TEMP"1"
end
