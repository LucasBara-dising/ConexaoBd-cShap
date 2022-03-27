create database db_EXEMPLO;
use db_EXEMPLO;

create table tb_USUARIO
(
idusu int primary key auto_increment,
nomeusu varchar(50) not null,
cargo varchar(50) not null,
Datanasc date 
);

insert into tb_USUARIO(nomeusu, cargo, Datanasc)
			values('Bob','Monstronista','1975/04/16'),
				  ('Maria','171','1972/07/13'); 	
                  
select * from tb_USUARIO;

Delimiter $$
create procedure insereusu(pnomeusu varchar(50), pcargo varchar(50), pDatanasc date)
begin
insert into tb_USUARIO(nomeusu, cargo, Datanasc)
			values(pnomeusu, pcargo, pDatanasc);
end
$$

call insereusu('DST', 'Aluno', '2020/02/07');