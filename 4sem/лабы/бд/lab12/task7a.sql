---------A-----------
set transaction isolation level serializable
begin transaction
delete STUDENT where STUDENT.IDSTUDENT > 1134;
insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (4,'�������7�',null,null);
update student set student.NAME = '������� �����������' where student.NAME like '%7�%';
select student.NAME from STUDENT where student.NAME like '%�������%';
-------------t1-----------
select student.NAME from STUDENT where student.NAME like '%�������%';
-------------t2----------
commit;