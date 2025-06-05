rule "Primo VE - Lds80"
	when
		MARC is "245"
	then
		set TEMP"1" to MARC."245" sub without sort "a,b,f-s"
		remove string (TEMP"1","\\[microform\\]")
		remove string (TEMP"1","\\[electronic resource\\]")
		remove string (TEMP"1","\\[video recording\\]")
		remove string (TEMP"1","\\[videorecording\\]")
		remove string (TEMP"1","\\[sound recording\\]")
		remove substring using regex (TEMP"1","(,|/|:|;)+$")
		create pnx."display"."lds80" with TEMP"1"
end
