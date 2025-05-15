------------B----------
begin transaction
delete STUDENT where STUDENT.NAME like '%7Б%';
insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (4,'студент7Б',null,null);
update student set student.NAME = 'студент обновленный' where student.NAME like '%7Б%';
select student.NAME from STUDENT where student.NAME like '%студент%';
--------------t1-----------
commit;
select student.NAME from STUDENT where student.NAME like '%студент%';

