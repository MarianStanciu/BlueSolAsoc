select org.id,org.id_master, org.id_tip, org.valoare, 
tt.id_tip, tt.denumire
from
tabela_organizatii as org
inner join tabela_tipuri as tt
on
org.id_tip=tt.id_tip
where   tt.tip_afisare='tree'
