rule "Primo VE Marc - Lsr87"
	when
		MARC is "690"
	then
		create pnx."search"."lsr87" with MARC "690" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 691"
	when
		MARC is "691"
	then
		create pnx."search"."lsr87" with MARC "691" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 692"
	when
		MARC is "692"
	then
		create pnx."search"."lsr87" with MARC "692" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 693"
	when
		MARC is "693"
	then
		create pnx."search"."lsr87" with MARC "693" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 694"
	when
		MARC is "694"
	then
		create pnx."search"."lsr87" with MARC "694" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 695"
	when
		MARC is "695"
	then
		create pnx."search"."lsr87" with MARC "695" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 010"
	when
		MARC is "010"
	then
		create pnx."search"."lsr87" with MARC "010" sub without sort "a"
end

rule "Primo VE Marc - Lsr87 017"
	when
		MARC is "017"
	then
		create pnx."search"."lsr87" with MARC "017" sub without sort "a"
end

rule "Primo VE Marc - Lsr87 074"
	when
		MARC is "074"
	then
		create pnx."search"."lsr87" with MARC "074" sub without sort "a"
end

rule "Primo VE Marc - Lsr87 088"
	when
		MARC is "088"
	then
		create pnx."search"."lsr87" with MARC "088" sub without sort "a,z"
end

rule "Primo VE Marc - Lsr87 386"
	when
		MARC is "386"
	then
		create pnx."search"."lsr87" with MARC "386" sub without sort "a"
end

rule "Primo VE Marc - Lsr87 388"
	when
		MARC is "388"
	then
		create pnx."search"."lsr87" with MARC "388" sub without sort "a"
end

rule "Primo VE Marc - Lsr87 500"
	when
		MARC is "500"
	then
		create pnx."search"."lsr87" with MARC "500" sub without sort "a"
end

rule "Primo VE Marc - Lsr87 504"
	when
		MARC is "504"
	then
		create pnx."search"."lsr87" with MARC "504" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 510"
	when
		MARC is "510"
	then
		create pnx."search"."lsr87" with MARC "510" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 511"
	when
		MARC is "511"
	then
		create pnx."search"."lsr87" with MARC "511" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 515"
	when
		MARC is "515"
	then
		create pnx."search"."lsr87" with MARC "515" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 532"
	when
		MARC is "532"
	then
		create pnx."search"."lsr87" with MARC "532" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 536"
	when
		MARC is "536"
	then
		create pnx."search"."lsr87" with MARC "536" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 538"
	when
		MARC is "538"
	then
		create pnx."search"."lsr87" with MARC "538" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 545"
	when
		MARC is "545"
	then
		create pnx."search"."lsr87" with MARC "545" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 546"
	when
		MARC is "546"
	then
		create pnx."search"."lsr87" with MARC "546" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 552"
	when
		MARC is "552"
	then
		create pnx."search"."lsr87" with MARC "552" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 555"
	when
		MARC is "555"
	then
		create pnx."search"."lsr87" with MARC "555" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 565"
	when
		MARC is "565"
	then
		create pnx."search"."lsr87" with MARC "565" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 588"
	when
		MARC is "588"
	then
		create pnx."search"."lsr87" with MARC "588" sub without sort "a-z"
end

rule "Primo VE Marc - Lsr87 242"
	when
		MARC is "242"
	then
		create pnx."search"."lsr87" with MARC "242" sub without sort "a-z"
end

// 880

rule "Primo VE Marc - Lsr87 880-500"
	when
        MARC is "880" AND
        MARC."880"."6" match "500-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-504"
	when
        MARC is "880" AND
        MARC."880"."6" match "504-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-510"
	when
        MARC is "880" AND
        MARC."880"."6" match "510-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-511"
	when
        MARC is "880" AND
        MARC."880"."6" match "511-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-515"
	when
        MARC is "880" AND
        MARC."880"."6" match "515-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-532"
	when
        MARC is "880" AND
        MARC."880"."6" match "532-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-536"
	when
        MARC is "880" AND
        MARC."880"."6" match "536-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-538"
	when
        MARC is "880" AND
        MARC."880"."6" match "538-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-545"
	when
        MARC is "880" AND
        MARC."880"."6" match "545-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-546"
	when
        MARC is "880" AND
        MARC."880"."6" match "546-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-552"
	when
        MARC is "880" AND
        MARC."880"."6" match "552-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-555"
	when
        MARC is "880" AND
        MARC."880"."6" match "555-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-565"
	when
        MARC is "880" AND
        MARC."880"."6" match "565-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

rule "Primo VE Marc - Lsr87 880-588"
	when
        MARC is "880" AND
        MARC."880"."6" match "588-.*"
	then
        create pnx."search"."lsr87" with MARC."880" sub without sort "a-z" 
end

// via

rule "Primo VE Marc - Lsr87 via alt terms"	
	when
		MARC."590" has any "v" AND
		MARC."590".ind"2"  equals "9"
	then
		create pnx."search"."lsr87" with MARC."590" sub without sort "v" 
end

rule "Primo VE Marc - Lsr87 via surrogates"	
	when
		MARC."598" has any "a,n,s,t,w,z" AND
		MARC."598".ind"2"  equals "9"
	then
		create pnx."search"."lsr87" with MARC."598" sub without sort "a,n,s,t,w,z" 
end

rule "Primo VE Marc - Lsr87 via components"	
	when
		MARC."599" has any "0,2,5,9,a-b,s-t,n,w,z" AND
		MARC."599".ind"2"  equals "9"
	then
		create pnx."search"."lsr87" with MARC."599" sub without sort "0,2,5,9,a-b,s-t,n,w,z" 
end



