rule "Primo VE - Lds49"
	when
		MARC is "916"."b"
	then
		set TEMP"1" to MARC."916" sub without sort "a"
		add prefix (TEMP"1","$$T")
		add suffix (TEMP"1","$$")
		add prefix (TEMP"1","✪ Best Bet for ")
		create pnx."display"."lds49" with TEMP"1"
end

//"lsr49" : "$$Tmideast$$"