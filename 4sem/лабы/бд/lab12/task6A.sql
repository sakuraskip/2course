set transaction isolation level repeatable read
begin transaction
select STUDENT.NAME from STUDENT where IDSTUDENT > 1060;
------------t1----------
------------t2-----------
select case 
when NAME like '%и%' then 'insert student' else ''
end 'результат', STUDENT.NAME from STUDENT where IDSTUDENT >1140;
commit;