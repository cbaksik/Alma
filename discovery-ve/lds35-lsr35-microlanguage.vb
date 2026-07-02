rule "Primo VE Marc - Lsr35"
	when
        MARC is "041"."a" AND
	   MARC."041"."2" match "iso639-3"
	then
	    set TEMP"2" to MARC."041"."a"
		remove substring using regex (TEMP"2","(ara|ben|ces|dan|deu|eng|fra|ita|jpn|kor|por|rus|spa|tur|urd|zho)")
        return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
        add prefix to list (TEMP"1","lang.")
        create pnx."search"."lsr35" with list TEMP"1"
end

rule "Primo VE - Lsr35 sung"
	when
        MARC is "041"."d" AND
	   MARC."041"."2" match "iso639-3"
	then
	    set TEMP"2" to MARC."041"."d"
        return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
        add prefix to list (TEMP"1","lang.")
        create pnx."search"."lsr35" with list TEMP"1"
end

rule "Primo VE - Lsr35 libretto"
	when
        MARC is "041"."e" AND
	   MARC."041"."2" match "iso639-3"
	then
	    set TEMP"2" to MARC."041"."e"
        return list using regex (TEMP"1",TEMP"2","[a-z]{3}")
        add prefix to list (TEMP"1","lang.")
        create pnx."search"."lsr35" with list TEMP"1"
end




