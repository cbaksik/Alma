rule "Primo VE - Lds39"
      when
            MARC."916" has any "a"
      then
            create pnx."display"."lds39" with MARC "916" subfields "a" append translation "a"
end

