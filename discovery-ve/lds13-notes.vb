rule "Primo VE - Lds13"
	when
		MARC."500" has any "3,a"
	then
		create pnx."display"."lds13" with MARC "500" subfields "3,a" delimited by ": " remove substring using regex ":"
end

rule "Primo VE - Lds13 501"
	when
		MARC."501" has any "a"
	then
		create pnx."display"."lds13" with MARC "501" sub without sort "a"
end

rule "Primo VE - Lds13 504"
	when
		MARC."504" has any "a,b"
	then
		create pnx."display"."lds13" with MARC "504" sub without sorting "a,b" delimited by "--" 
end

rule "Primo VE - Lds13 - 508"
	when
		MARC."508" has any "3,a"
	then
		create pnx."display"."lds13" with MARC "508" subfields "3,a" delimited by ": " remove substring using regex ":"
end

rule "Primo VE - Lds13 - 510 first ind 0,1,2"
	when
		MARC."510" has any "3,a-c,x,u" AND 
		(MARC."510".ind"1" equals "0" OR 
		MARC."510".ind"1" equals "1" OR 
		MARC."510".ind"1" equals "2")
	then
		set TEMP"1" to MARC "510" sub without sort "3,a-c,x"
		add prefix (TEMP"1","Indexed by: ")
		set TEMP"2" to MARC."510" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">More information</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds13" with TEMP"1" 
end

rule "Primo VE - Lds13 - 510 first ind 3,4,null"
	when
		MARC."510" has any "3,a-c,x,u" AND 
		(MARC."510".ind"1" equals "3" OR 
		MARC."510".ind"1" equals "4" OR 
		MARC."510".ind"1" equals " ")
	then
		set TEMP"1" to MARC "510" sub without sort "3,a-c,x"
		add prefix (TEMP"1","References: ")
		set TEMP"2" to MARC."510" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">Citation</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds13" with TEMP"1" 
end

rule "Primo VE - lds13 511"
	when
		MARC."511" has any "3,a"
	then
		set TEMP"1" to MARC."511" subfields "3,a" delimited by ": " remove substring using regex ":" 
		add prefix (TEMP"1","Participants: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 513"
	when
		MARC."513" has any "a,b"
	then
		create pnx."display"."lds13" with MARC "513" sub without sort "a,b"
end

rule "Primo VE - Lds13 515"
	when
		MARC."515" has any "a"
	then
		create pnx."display"."lds13" with MARC "515" sub without sort "a"
end

rule "Primo VE - Lds13 516"
	when
		MARC."516" has any "a"
	then
		create pnx."display"."lds13" with MARC "516" sub without sort "a"
end

rule "Primo VE - lds13 518"
	when
		MARC."518" has any "3,a,d,o,p"
	then
		set TEMP"1" to MARC."518" subfields "3,a,d,o,p" delimited by ": " remove substring using regex ":" 
		add prefix (TEMP"1","Event: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 522"
	when
		MARC."522" has any "a"
	then
		set TEMP"1" to MARC."522" subfields "a" 
		add prefix (TEMP"1","Geographic coverage: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 525"
	when
		MARC."525" has any "a"
	then
		create pnx."display"."lds13" with MARC "525" sub without sort "a"
end

rule "Primo VE - Lds13 530"
	when
		MARC."530" has any "a,b"
	then
		create pnx."display"."lds13" with MARC "530" sub without sort "a-b" 
end

rule "Primo VE - lds13 532"
	when
		MARC."532" has any "3,a"
	then
		set TEMP"1" to MARC."532" subfields "3,a" delimited by ": " remove substring using regex ":" 
		add prefix (TEMP"1","Accessibility: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 533"
	when
		MARC."533" has any "3,a-n" 
	then
		set TEMP"1" to MARC."533" sub without sort "3,a-n"
		add prefix (TEMP"1","Reproduction: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 534"
	when
		MARC."534" has any "3,a-z"
	then
		create pnx."display"."lds13" with MARC "534" sub without sort "3,a-z"
end

rule "Primo VE - lds13 535"
	when
		MARC."535" has any "3,a-c" 
	then
		set TEMP"1" to MARC."535" sub without sort "3,a-c"
		add prefix (TEMP"1","Originals: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 536"
	when
		MARC."536" has any "a-h"
	then
		set TEMP"1" to MARC."536" subfields "a-h" delimited by " -- " remove substring using regex ":" 
		add prefix (TEMP"1","Funding: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 544"
	when
		MARC."544" has any "3,a-e,n" 
	then
		set TEMP"1" to MARC."544" sub without sort "3,a-e,n" 
		add prefix (TEMP"1","Related materials: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 546"
	when
		MARC."546" has any "3,a-b" 
	then
		set TEMP"1" to MARC."546" sub without sort "3,a-b" 
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 547"
	when
		MARC."547" has any "a"
	then
		create pnx."display"."lds13" with MARC "547" sub without sort "a"
end

rule "Primo VE - Lds13 550"
	when
		MARC."550" has any "a"
	then
		create pnx."display"."lds13" with MARC "550" sub without sort "a"
end

rule "Primo VE - Lds13 556"
	when
		MARC."556" has any "a,z"
	then
		create pnx."display"."lds13" with MARC "556" sub without sort "a,z"
end

rule "Primo VE - Lds13 561"
	when
		MARC."561" has any "3,a" AND 
		MARC."561".ind"1" equals "1"
	then
		set TEMP"1" to MARC."561" subfields "3,a" 
		add prefix (TEMP"1","Provenance: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 563"
	when
		MARC."563" has any "3,a" 
	then
		set TEMP"1" to MARC."563" sub without sort "3,a" 
		add prefix (TEMP"1","Binding: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 565"
	when
		MARC."565" has any "3,a-e" 
	then
		set TEMP"1" to MARC."565" sub without sort "3,a-e" 
		add prefix (TEMP"1","Variables: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 567"
	when
		MARC."567" has any "a,b" 
	then
		set TEMP"1" to MARC."567" sub without sort "a,b" 
		add prefix (TEMP"1","Methodology: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 581"
	when
		MARC."581" has any "3,a,z" 
	then
		set TEMP"1" to MARC."581" subfields "3,a,z" 
		add prefix (TEMP"1","Publications: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 583"
	when
		MARC."583" has any "3,a-o,z" AND 
		MARC."583".ind"1" equals "1"
	then
		set TEMP"1" to MARC."583" subfields "3,a-o,z" delimited by " -- " remove substring using regex ":" 
		add prefix (TEMP"1","Action: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 585"
	when
		MARC."585" has any "3,a"
	then
		create pnx."display"."lds13" with MARC "585" sub without sort "3,a"
end

rule "Primo VE - Lds13 586"
	when
		MARC."586" has any "3,a" 
	then
		set TEMP"1" to MARC."586" subfields "3,a" 
		add prefix (TEMP"1","Awards: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 588"
	when
		MARC."588" has any "a" AND 
		(MARC."588".ind"1" equals " " OR 
		MARC."588".ind"1" equals "0")
	then
		set TEMP"1" to MARC."588" subfields "a" 
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 588 1st ind 1"
	when
		MARC."588" has any "a" AND 
		MARC."588".ind"1" equals "1"
	then
		set TEMP"1" to MARC."588" subfields "a" 
		add prefix (TEMP"1","Latest issue consulted: ")
		create pnx."display"."lds13" with TEMP"1"
end

// begin 880

rule "Primo VE - Lds13 500-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "500.*"
	then
		create pnx."display"."lds13" with MARC "880" subfields "3,a" delimited by ": " remove substring using regex ":"
end

rule "Primo VE - Lds13 501-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "501.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a"
end

rule "Primo VE - Lds13 504-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "504.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sorting "a,b" delimited by "--" 
end

rule "Primo VE - Lds13 506-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "506.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "3,a-g,q" 
end

rule "Primo VE - Lds13 - 508-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "508.*"
	then
		create pnx."display"."lds13" with MARC "880" subfields "3,a" delimited by ": " remove substring using regex ":"
end

rule "Primo VE - Lds13 - 510 first ind 0,1,2-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "510.*" AND 
		(MARC."880".ind"1" equals "0" OR 
		MARC."880".ind"1" equals "1" OR 
		MARC."880".ind"1" equals "2")
	then
		set TEMP"1" to MARC "880" sub without sort "3,a-c,x"
		add prefix (TEMP"1","Indexed by: ")
		set TEMP"2" to MARC."880" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">More information</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds13" with TEMP"1" 
end

rule "Primo VE - Lds13 - 510 first ind 3,4,null-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "510.*" AND 
		(MARC."880".ind"1" equals "3" OR 
		MARC."880".ind"1" equals "4" OR 
		MARC."880".ind"1" equals " ")
	then
		set TEMP"1" to MARC "880" sub without sort "3,a-c,x"
		add prefix (TEMP"1","References: ")
		set TEMP"2" to MARC."880" sub without sort "u"
		add prefix (TEMP"2","<a href=\"")
		add suffix (TEMP"2","\">Citation</a>")
		concatenate with delimiter (TEMP"1",TEMP"2"," ")
		create pnx."display"."lds13" with TEMP"1" 
end

rule "Primo VE - lds13 511-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "511.*"
	then
		set TEMP"1" to MARC."880" subfields "3,a" delimited by ": " remove substring using regex ":" 
		add prefix (TEMP"1","Participants: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 513-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "513.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a,b"
end

rule "Primo VE - Lds13 515-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "515.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a"
end

rule "Primo VE - Lds13 516-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "516.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a"
end

rule "Primo VE - lds13 518-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "518.*"
	then
		set TEMP"1" to MARC."880" subfields "3,a,d,o,p" delimited by ": " remove substring using regex ":" 
		add prefix (TEMP"1","Event: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 522-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "522.*"
	then
		set TEMP"1" to MARC."880" subfields "a" 
		add prefix (TEMP"1","Geographic coverage: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 525-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "525.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a"
end

rule "Primo VE - Lds13 530-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "530.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a-b" 
end

rule "Primo VE - lds13 532-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "532.*"
	then
		set TEMP"1" to MARC."880" subfields "3,a" delimited by ": " remove substring using regex ":" 
		add prefix (TEMP"1","Accessibility: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 533-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "533.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-n"
		add prefix (TEMP"1","Reproduction: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 534-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "534.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "3,a-z"
end

rule "Primo VE - lds13 535-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "535.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-c"
		add prefix (TEMP"1","Originals: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 536-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "536.*"
	then
		set TEMP"1" to MARC."880" subfields "a-h" delimited by " -- " remove substring using regex ":" 
		add prefix (TEMP"1","Funding: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 544-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "544.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-e,n" 
		add prefix (TEMP"1","Related materials: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 546-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "546.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-b" 
		add prefix (TEMP"1","Language: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 547-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "547.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a"
end

rule "Primo VE - Lds13 550-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "550.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a"
end

rule "Primo VE - Lds13 556-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "556.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "a,z"
end

rule "Primo VE - Lds13 561-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "561.*" AND 
		MARC."880".ind"1" equals "1"
	then
		set TEMP"1" to MARC."880" subfields "3,a" 
		add prefix (TEMP"1","Provenance: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 563-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "563.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a" 
		add prefix (TEMP"1","Binding: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 565-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "565.*"
	then
		set TEMP"1" to MARC."880" sub without sort "3,a-e" 
		add prefix (TEMP"1","Variables: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 567-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "567.*"
	then
		set TEMP"1" to MARC."880" sub without sort "a,b" 
		add prefix (TEMP"1","Methodology: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 581-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "581.*"
	then
		set TEMP"1" to MARC."880" subfields "3,a,z" 
		add prefix (TEMP"1","Publications: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - lds13 583-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "583.*" AND 
		MARC."880".ind"1" equals "1"
	then
		set TEMP"1" to MARC."880" subfields "3,a-o,z" delimited by " -- " remove substring using regex ":" 
		add prefix (TEMP"1","Action: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 585-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "585.*"
	then
		create pnx."display"."lds13" with MARC "880" sub without sort "3,a"
end

rule "Primo VE - Lds13 586-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "586.*"
	then
		set TEMP"1" to MARC."880" subfields "3,a" 
		add prefix (TEMP"1","Awards: ")
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 588-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "588.*" AND 
		(MARC."880".ind"1" equals " " OR 
		MARC."880".ind"1" equals "0")
	then
		set TEMP"1" to MARC."880" subfields "a" 
		create pnx."display"."lds13" with TEMP"1"
end

rule "Primo VE - Lds13 588 1st ind 1-880"
	when
		MARC is "880" AND
		MARC."880"."6" match "588.*" AND 
		MARC."880".ind"1" equals "1"
	then
		set TEMP"1" to MARC."880" subfields "a" 
		add prefix (TEMP"1","Latest issue consulted: ")
		create pnx."display"."lds13" with TEMP"1"
end