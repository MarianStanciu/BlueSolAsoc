select
  id_master, id_tip, valoare, den_asoc, den_bloc, den_scara, presedinte, cod_fiscal
from
vAfisareDetaliiEntitati
pivot
(
count  (id) 
for denumire
in( [den_asoc],[den_bloc],[den_scara],[presedinte],[cod_fiscal])

)
as Pivoting