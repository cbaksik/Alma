rule "Primo VE Marc - Lsr43"
	when
		MARC is "041"."j"
	then
		set TEMP"2" to MARC."041"."j"
		lower case (TEMP"2")
		return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
		normalize discovery lang (TEMP"1")
		add prefix to list (TEMP"1","lang.")
		create pnx."search"."lsr43" with list TEMP"1"
end

rule "Primo VE Marc - Lsr43 p"
	when
		MARC is "041"."p"
	then
		set TEMP"2" to MARC."041"."p"
		lower case (TEMP"2")
		return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
		normalize discovery lang (TEMP"1")
		add prefix to list (TEMP"1","lang.")
		create pnx."search"."lsr43" with list TEMP"1"
end

rule "Primo VE Marc - Lsr43 q"
	when
		MARC is "041"."q"
	then
		set TEMP"2" to MARC."041"."q"
		lower case (TEMP"2")
		return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
		normalize discovery lang (TEMP"1")
		add prefix to list (TEMP"1","lang.")
		create pnx."search"."lsr43" with list TEMP"1"
end

rule "Primo VE Marc - Lsr43 r"
	when
		MARC is "041"."r"
	then
		set TEMP"2" to MARC."041"."r"
		lower case (TEMP"2")
		return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
		normalize discovery lang (TEMP"1")
		add prefix to list (TEMP"1","lang.")
		create pnx."search"."lsr43" with list TEMP"1"
end

rule "Primo VE Marc - Lsr43 t"
	when
		MARC is "041"."t"
	then
		set TEMP"2" to MARC."041"."t"
		lower case (TEMP"2")
		return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
		normalize discovery lang (TEMP"1")
		add prefix to list (TEMP"1","lang.")
		create pnx."search"."lsr43" with list TEMP"1"
end

