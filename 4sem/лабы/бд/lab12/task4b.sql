begin transaction
select @@SPID
insert into STUDENT(NAME,INFO,FOTO) values ('�������',null,null);
update FACULTY set FACULTY_NAME = '��������������' where
FACULTY_NAME like '%���������%'
------------------t1----------------
---------------------t2--------------
rollback;

