begin tran
insert into GROUPS(FACULTY,YEAR_FIRST) values ('���',2025);
	begin tran
	update STUDENT set student.IDGROUP = 28 where STUDENT.NAME like '%������%';
	commit;
	if @@TRANCOUNT >0 rollback;
select 
	(select count(*) from STUDENT where IDGROUP =28) '��������',
	(select count(*) from GROUPS where YEAR_FIRST = 2025) '������';
