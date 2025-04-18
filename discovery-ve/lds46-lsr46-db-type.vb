rule "Primo VE Marc - Lsr46"
	when
		MARC is "915"."a"
	then
		set TEMP"1" to MARC."915" sub without sort "a"
		replace string by string (TEMP"1","archival","Archival materials")
		replace string by string (TEMP"1","audiovisual","Video and sound")
		replace string by string (TEMP"1","data","Data")
		replace string by string (TEMP"1","ebook","E-books and texts")
		replace string by string (TEMP"1","ejournal","E-journals")
		replace string by string (TEMP"1","harvard","Harvard digital collections")
		replace string by string (TEMP"1","image","Images and maps")
		replace string by string (TEMP"1","index","Indexes/bibliographies")
		replace string by string (TEMP"1","news","News, current and historical")
		replace string by string (TEMP"1","ref","Reference and guides")
		create pnx."search"."lsr46" with TEMP"1"
end
