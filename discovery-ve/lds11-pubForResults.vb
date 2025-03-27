rule "Primo VE - Lds11"
	when
		MARC."880" has any "a-g" AND
		MARC."880"."6" match "264-.*"
	then
		set pnx."display"."lds11" to MARC "880" sub without sort "3,a-g"
end

rule "Primo VE - lds11 880-260"
	when
		MARC."880" has any "a-g" AND
		MARC."880"."6" match "260-.*"
	then
		set pnx."display"."lds11" to MARC "880" sub without sort "3,a-g"
end

rule "Primo VE - lds11 264"
	when
		MARC."264" has any "a-c" AND NOT
		MARC."264"."6" match "880-.*"
	then
		set pnx."display"."lds11" to MARC "264" sub without sort "3,a-c"
end

rule "Primo VE - lds11 260"
	when
		MARC."260" has any "a-g" AND NOT
		MARC."260"."6" match "880-.*"
	then
		set pnx."display"."lds11" to MARC "260" sub without sort "3,a-g"
end