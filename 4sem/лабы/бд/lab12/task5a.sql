---a---
set transaction isolation level read committed
begin transaction 
select count(*) from STUDENT where STUDENT.IDSTUDENT > 1100
--------t1--------
--------t2--------
select 'update student' 'результат',count(*)
		from STUDENT where STUDENT.IDSTUDENT>1100;
commit;
