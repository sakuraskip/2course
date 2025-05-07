------------B----------
begin transaction
delete STUDENT where STUDENT.IDSTUDENT > 1134;
insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (4,'студент7Б',null,null);
update student set student.NAME = 'студент обнрвленный' where student.NAME like '%7Б%';
select student.NAME from STUDENT where student.NAME = 'студент обнрвленный'
--------------t1-----------
commit;
select student.NAME from STUDENT where student.NAME like '%студент%';

