rule "Primo VE - Lds78"
	when
		MARC is "760" AND
		MARC."760".ind"1" equals "0"
	then
		set TEMP"1" to MARC."760" sub without sort "a-v"
		add prefix (TEMP"1","Main series: ")
		set TEMP"2" to MARC."760" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."760" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."760" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."760" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 762"
	when
		MARC is "762" AND
		MARC."762".ind"1" equals "0"
	then
		set TEMP"1" to MARC."762" sub without sort "a-v"
		add prefix (TEMP"1","Subseries: ")
		set TEMP"2" to MARC."762" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."762" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."762" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."762" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 765"
	when
		MARC is "765" AND
		MARC."765".ind"1" equals "0"
	then
		set TEMP"1" to MARC."765" sub without sort "a-v"
		add prefix (TEMP"1","Translation of: ")
		set TEMP"2" to MARC."765" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."765" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."765" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."765" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		replace string by string (TEMP"1","Translation of: Translation of:","Translation of:")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 767"
	when
		MARC is "767" AND
		MARC."767".ind"1" equals "0"
	then
		set TEMP"1" to MARC."767" sub without sort "a-v"
		add prefix (TEMP"1","Translated as: ")
		set TEMP"2" to MARC."767" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."767" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."767" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."767" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 770"
	when
		MARC is "770" AND
		MARC."770".ind"1" equals "0"
	then
		set TEMP"1" to MARC."770" sub without sort "a-v"
		add prefix (TEMP"1","Has supplement: ")
		set TEMP"2" to MARC."770" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."770" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."770" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."770" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 772"
	when
		MARC is "772" AND
		MARC."772".ind"1" equals "0"
	then
		set TEMP"1" to MARC."772" sub without sort "a-v"
		add prefix (TEMP"1","Supplement to: ")
		set TEMP"2" to MARC."772" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."772" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."772" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."772" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 774"
	when
		MARC is "774" AND
		MARC."774".ind"1" equals "0"
	then
		set TEMP"1" to MARC."774" sub without sort "a-v"
		add prefix (TEMP"1","Constituent unit: ")
		set TEMP"2" to MARC."774" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."774" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."774" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."774" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 775"
	when
		MARC is "775" AND
		MARC."775".ind"1" equals "0"
	then
		set TEMP"1" to MARC."775" sub without sort "a-v"
		add prefix (TEMP"1","Other edition: ")
		set TEMP"2" to MARC."775" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."775" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."775" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."775" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end 

rule "Primo VE - Related 777"
	when
		MARC is "777" AND
		MARC."777".ind"1" equals "0"
	then
		set TEMP"1" to MARC."777" sub without sort "a-v"
		add prefix (TEMP"1","Issued with: ")
		set TEMP"2" to MARC."777" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."777" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."777" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."777" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 780 0"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "0"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Continues: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 780 1"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "1"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Continues in part: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 780 2"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "2"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Supersedes: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end


rule "Primo VE - Related 780 3"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "3"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Supersedes in part: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 780 4"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "4"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Formed by the union of: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 780 5"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "5"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Absorbed: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 780 6"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "6"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Absorbed in part: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 780 7"
	when
		MARC is "780" AND
		MARC."780".ind"1" equals "0" AND
		MARC."780".ind"2" equals "7"
	then
		set TEMP"1" to MARC."780" sub without sort "a-v"
		add prefix (TEMP"1","Separated from: ")
		set TEMP"2" to MARC."780" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."780" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."780" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."780" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end


rule "Primo VE - Related 785 0"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "0"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Continued by: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 785 1"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "1"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Continued in part by: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 785 2"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "2"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Superseded by: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end


rule "Primo VE - Related 785 3"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "3"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Superseded in part by: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 785 4"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "4"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Absorbed by: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 785 5"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "5"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Absorbed in part by: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 785 6"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "6"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Split into: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 785 7"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "7"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Merged with: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end
rule "Primo VE - Related 785 8"
	when
		MARC is "785" AND
		MARC."785".ind"1" equals "0" AND
		MARC."785".ind"2" equals "8"
	then
		set TEMP"1" to MARC."785" sub without sort "a-v"
		add prefix (TEMP"1","Changed back to: ")
		set TEMP"2" to MARC."785" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."785" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."785" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."785" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 786"
	when
		MARC is "786" AND
		MARC."786".ind"1" equals "0"
	then
		set TEMP"1" to MARC."786" sub without sort "a-v"
		add prefix (TEMP"1","Data source: ")
		set TEMP"2" to MARC."786" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."786" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."786" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."786" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 787"
	when
		MARC is "787" AND
		MARC."787".ind"1" equals "0"
	then
		set TEMP"1" to MARC."787" sub without sort "a-v"
		set TEMP"2" to MARC."787" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."787" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."787" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."787" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

// begin 880

rule "Primo VE - Related 880-760"
	when
		MARC is "880" AND
		MARC."880"."6" match "760.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Main series: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-762"
	when
		MARC is "880" AND
		MARC."880"."6" match "762.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Subseries: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-765"
	when
		MARC is "880" AND
		MARC."880"."6" match "765.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Translation of: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		replace string by string (TEMP"1","Translation of: Translation of:","Translation of:")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-767"
	when
		MARC is "880" AND
		MARC."880"."6" match "767.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Translated as: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-770"
	when
		MARC is "880" AND
		MARC."880"."6" match "770.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Has supplement: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-772"
	when
		MARC is "880" AND
		MARC."880"."6" match "772.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Supplement to: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-774"
	when
		MARC is "880" AND
		MARC."880"."6" match "774.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Constituent unit: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-775"
	when
		MARC is "880" AND
		MARC."880"."6" match "775.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Other edition: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-777"
	when
		MARC is "880" AND
		MARC."880"."6" match "777.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Issued with: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-780"
	when
		MARC is "880" AND
		MARC."880"."6" match "780.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-785"
	when
		MARC is "880" AND
		MARC."880"."6" match "785.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-786"
	when
		MARC is "880" AND
		MARC."880"."6" match "786.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		add prefix (TEMP"1","Data source: ")
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-787"
	when
		MARC is "880" AND
		MARC."880"."6" match "787.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "a-v"
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

// end 880; begin 773 has sf3

rule "Primo VE - Related 773 0-"
	when
		MARC is "773" AND
		MARC."773".ind"1" equals "0" AND
		MARC."773".ind"2" equals " "
	then
		set TEMP"1" to MARC."773" sub without sort "3,a-v"
		add prefix (TEMP"1","In: ")
		set TEMP"2" to MARC."773" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."773" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."773" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."773" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 773 08"
	when
		MARC is "773" AND
		MARC."773".ind"1" equals "0" AND
		MARC."773".ind"2" equals "8"
	then
		set TEMP"1" to MARC."773" sub without sort "3,a-v"
		set TEMP"2" to MARC."773" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."773" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."773" sub without sort "x,v"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."773" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end

rule "Primo VE - Related 880-773"
	when
		MARC is "880" AND
		MARC."880"."6" match "773.*" AND
		MARC."880".ind"1" equals "0"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-v"
		set TEMP"2" to MARC."880" sub without sort "z"
		add prefix (TEMP"2","ISBN: ")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		set TEMP"3" to MARC."880" sub without sort "x"
		add prefix (TEMP"3","ISSN: ")
		concatenate with delimiter (TEMP"1",TEMP"3"," ")
		set TEMP"4" to MARC."880" sub without sort "x,z"
		remove substring using regex (TEMP"4","(;|,|\\.)+$")
		add prefix (TEMP"4","$$Q")
		concatenate with delimiter (TEMP"1",TEMP"4"," ")
		set TEMP"5" to MARC."880" sub without sort "a,k,o,p,s,t"
		remove substring using regex (TEMP"5","(;|,|\\.)+$")
		add prefix (TEMP"5","$$R")
		concatenate with delimiter (TEMP"1",TEMP"5"," ")
		replace string by string (TEMP"1","\\$\\$Q(.*?)\\$\\$R.*","\\$\\$Q$1")
		replace string by string (TEMP"1","\\$\\$R","\\$\\$Q")
		create pnx."display"."lds78" with TEMP"1"
end