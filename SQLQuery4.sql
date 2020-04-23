select id , 
from vAfisareDetaliiEntitati
where  valoare='Asociatia Crocodil'
--
select count( id_master)
 from vAfisareDetaliiEntitati
 where id_master=1003

----
 insert into Tabela_Organizatii (id_master, id_tip, valoare)  values(1022 , 7, 'Nume Prenume') ;values(1022 , 12, 'CUI') values(1022 , 17, 0)