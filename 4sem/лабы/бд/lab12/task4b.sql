begin transaction
select @@SPID
insert into STUDENT(NAME,INFO,FOTO) values ('андрюха',null,null);
update FACULTY set FACULTY_NAME = 'автотракторный' where
FACULTY_NAME like '%автоматич%'
------------------t1----------------
---------------------t2--------------
rollback;

