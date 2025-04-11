rule "Primo VE - contents 505"
	when
		MARC is "505" AND 
		(MARC."505".ind"1" equals "0" OR 
		MARC."505".ind"1" equals "8" OR 
		MARC."505".ind"1" equals " ")
	then
		set TEMP"1" to MARC."505" sub without sort "a,g,r,t" 
		add prefix (TEMP"1","<span class='hvd-toc-fields'>")
		replace string by string (TEMP"1"," -- ","<br> &middot; ")
		add suffix (TEMP"1","</span>")
		create pnx."display"."contents" with TEMP"1"
end

rule "Primo VE - contents 505 1st ind 1"
	when
		MARC is "505" AND 
		MARC."505".ind"1" equals "1"
	then
		set TEMP"1" to MARC."505" sub without sort "a,g,r,t" 
		add prefix (TEMP"1","<span class='hvd-toc-fields'>Incomplete contents: ")
		replace string by string (TEMP"1"," -- "," <br> &middot; ")
		add suffix (TEMP"1","</span>")
		create pnx."display"."contents" with TEMP"1"
end

rule "Primo VE - contents 505 1st ind 2"
	when
		MARC is "505" AND 
		MARC."505".ind"1" equals "2"
	then
		set TEMP"1" to MARC."505" sub without sort "a,g,r,t" 
		add prefix (TEMP"1","<span class='hvd-toc-fields'>Partial contents: ")
		replace string by string (TEMP"1"," -- ","<br> &middot; ")
		add suffix (TEMP"1","</span>")
		create pnx."display"."contents" with TEMP"1"
end


rule "Prima_Display - contents 880-505"
	when
		MARC is "880" AND
		MARC."880"."6" match "505-.*"
	then
		create pnx."display"."contents" with MARC "880" sub without sort "a,g,r,t" 
end