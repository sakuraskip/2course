--task4A
set transaction isolation level read uncommitted
begin transaction

---------------t1------------

 select @@spid, 'insert STUDENT' 'результат',* from
 STUDENT where STUDENT.NAME like '%андрюха%';

 select @@spid,'update FACULTY' 'результат',FACULTY.FACULTY_NAME,
 FACULTY from FACULTY where FACULTY_NAME like '%трак%';
 commit;
 -------------t2-------------