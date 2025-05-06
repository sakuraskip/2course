----b-----
begin transaction 
--------t1--------
delete from STUDENT 
		where IDSTUDENT >1160
commit;
-----------t2----------