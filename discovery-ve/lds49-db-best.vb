rule "Primo VE - Lds49"
	when
		MARC is "916"."b"
	then
		set TEMP"1" to MARC."916" sub without sort "a"
		add prefix (TEMP"1","&#x272A; Best bet for ")
		create pnx."display"."lds49" with TEMP"1"
end
