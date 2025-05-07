begin tran
insert into GROUPS(FACULTY,YEAR_FIRST) values ('»Ё‘',2025);
	begin tran
	update STUDENT set student.IDGROUP = 28 where STUDENT.NAME like '%аааааа%';
	commit;
	if @@TRANCOUNT >0 rollback;
select 
	(select count(*) from STUDENT where IDGROUP =28) 'студенты',
	(select count(*) from GROUPS where YEAR_FIRST = 2025) 'группы';
