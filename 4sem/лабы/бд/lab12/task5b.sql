----b-----
begin transaction 
--------t1--------
delete from STUDENT 
		where IDSTUDENT = 1132;
-----------t2----------
commit;
