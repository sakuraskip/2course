begin transaction
-----------t1-----------
insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (6,'игнатий',null,null);
commit;
-----------t2------------
