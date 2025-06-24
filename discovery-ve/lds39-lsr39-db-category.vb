rule "Primo VE Marc - Lsr39"
	when
		MARC."916" has any "a" 
	then		
		create pnx."search"."lsr39" with MARC "916" subfields "a" append translation "a"
end