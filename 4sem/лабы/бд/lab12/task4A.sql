--task4A
set transaction isolation level read uncommitted
begin transaction

---------------t1------------

 select @@spid, 'insert STUDENT' '���������',* from
 STUDENT where STUDENT.NAME like '%�������%';

 select @@spid,'update FACULTY' '���������',FACULTY.FACULTY_NAME,
 FACULTY from FACULTY where FACULTY_NAME like '%����%';
 commit;
 -------------t2-------------