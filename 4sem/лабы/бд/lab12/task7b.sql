------------B----------
begin transaction
delete STUDENT where STUDENT.NAME like '%7�%';
insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (4,'�������7�',null,null);
update student set student.NAME = '������� �����������' where student.NAME like '%7�%';
select student.NAME from STUDENT where student.NAME like '%�������%';
--------------t1-----------
commit;
select student.NAME from STUDENT where student.NAME like '%�������%';

