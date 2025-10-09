rule "Primo VE Marc - Lsr61"
	when
		MARC is "245"."k"
	then
		create pnx."search"."lsr61" with MARC "245"."k"
end

rule "Primo VE Marc - Lsr61 222"
	when
		MARC is "222"."a"
	then
		create pnx."search"."lsr61" with MARC "222"."a"
end

rule "Primo VE Marc - Lsr61 130 serials"
	when
		MARC.control."LDR"(6-8) matches "ai|as" AND
		MARC is "130"."a"
	then
		create pnx."search"."lsr61" with MARC "130"."a"
end

rule "Primo VE Marc - Lsr61 best bet dbs"
	when
		MARC."916" has any "b"
	then
		set TEMP"1" to MARC."916" sub without sort "a"
		add suffix (TEMP"1","-hvd-db-sub")
		replace string by string (TEMP"1","s-asian-hvd-db-sub","Asian Studies - South and Southeast")
		replace string by string (TEMP"1","afr-hvd-db-sub","African Studies")
		replace string by string (TEMP"1","afr-am-hvd-db-sub","African-American Studies")
		replace string by string (TEMP"1","agri-hvd-db-sub","Agriculture")
		replace string by string (TEMP"1","anthro-hvd-db-sub","Anthropology and Archaeology")
		replace string by string (TEMP"1","arts-hvd-db-sub","Arts and Architecture")
		replace string by string (TEMP"1","e-asian-hvd-db-sub","Asian Studies - East")
		replace string by string (TEMP"1","astro-hvd-db-sub","Astronomy and Space Sciences")
		replace string by string (TEMP"1","bio-hvd-db-sub","Biology")
		replace string by string (TEMP"1","bus-hvd-db-sub","Business and Management")
		replace string by string (TEMP"1","chem-hvd-db-sub","Chemistry")
		replace string by string (TEMP"1","compsci-hvd-db-sub","Computer Science")
		replace string by string (TEMP"1","econ-hvd-db-sub","Economics")
		replace string by string (TEMP"1","educ-hvd-db-sub","Education")
		replace string by string (TEMP"1","engin-hvd-db-sub","Engineering")
		replace string by string (TEMP"1","enviro-hvd-db-sub","Environmental Studies")
		replace string by string (TEMP"1","film-tv-hvd-db-sub","Film, TV, Theater, and Dance")
		replace string by string (TEMP"1","gender-hvd-db-sub","Women, Gender, and Sexuality Studies")
		replace string by string (TEMP"1","geog-hvd-db-sub","Geography")
		replace string by string (TEMP"1","geol-hvd-db-sub","Geology")
		replace string by string (TEMP"1","hist-hvd-db-sub","History")
		replace string by string (TEMP"1","hist-sci-hvd-db-sub","History of Science")
		replace string by string (TEMP"1","native-hvd-db-sub","Native American Studies")
		replace string by string (TEMP"1","info-hvd-db-sub","Information Science")
		replace string by string (TEMP"1","jewish-hvd-db-sub","Jewish Studies")
		replace string by string (TEMP"1","lang-lit-hvd-db-sub","Language and Literature")
		replace string by string (TEMP"1","latin-hvd-db-sub","Latin American, Caribbean, and Latino Studies")
		replace string by string (TEMP"1","law-hvd-db-sub","Law")
		replace string by string (TEMP"1","math-hvd-db-sub","Mathematics")
		replace string by string (TEMP"1","med-hvd-db-sub","Medicine and Public Health")
		replace string by string (TEMP"1","mideast-hvd-db-sub","Middle Eastern Studies")
		replace string by string (TEMP"1","music-hvd-db-sub","Music")
		replace string by string (TEMP"1","news-hvd-db-sub","News and Media Studies")
		replace string by string (TEMP"1","ocean-hvd-db-sub","Oceanography")
		replace string by string (TEMP"1","phil-rel-hvd-db-sub","Philosophy and Religion")
		replace string by string (TEMP"1","phys-hvd-db-sub","Physics")
		replace string by string (TEMP"1","polisci-hvd-db-sub","Government, Political Science, and International Relations")
		replace string by string (TEMP"1","psyc-hvd-db-sub","Psychology")
		replace string by string (TEMP"1","ref-hvd-db-sub","Reference")
		replace string by string (TEMP"1","slavic-hvd-db-sub","Slavic Studies")
		replace string by string (TEMP"1","socio-hvd-db-sub","Sociology")
		replace string by string (TEMP"1","classics-hvd-db-sub","Classics and Medieval Studies")
		replace string by string (TEMP"1","rel-hvd-db-sub","Religion")
		replace string by string (TEMP"1","phil-hvd-db-sub","Philosophy")
		create pnx."search"."lsr61" with TEMP"1"
end


