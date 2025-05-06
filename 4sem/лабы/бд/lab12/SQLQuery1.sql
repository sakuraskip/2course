--task1
set nocount on
if exists(select * from SYS.objects where
object_id = object_id(N'DBO.X'))
drop table X;

declare @c int, @flag char = 'r';
set implicit_transactions on
create table X(K int);
	insert X values (1),(2),(3);
	set @c = (select count(*) from X);
	print '���������� ����� � ������� X: ' + cast( @c as varchar(2));
		if @flag = 'c'  commit;                   
	          else   rollback;                                 
      SET IMPLICIT_TRANSACTIONS  OFF   
	
	if  exists (select * from  SYS.OBJECTS      
	            where OBJECT_ID= object_id(N'DBO.X') )
	print '������� X ����';  
      else print '������� X ���'

--task2
begin try
	begin tran
	delete STUDENT where IDSTUDENT >1173
	insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (1312,'���',null,null)
	update STUDENT set IDGROUP = 3345 where name like 'aaa';
	commit tran
end try
begin catch
	print '������ '+case
	when error_number() = 2627 and patindex('%UNIVER',error_message())>0
	then '������������ ��������'
	else '����������� ������ ' + cast(error_number()as varchar(5)) + error_message()
	end;
	if @@TRANCOUNT >0 rollback tran;--���� ������ ���� - ���������� �� ���������
	end catch;
--task3
declare @point varchar(52);
begin try
	begin tran
	delete STUDENT where IDSTUDENT = 1173;
	set @point = 'p1'; save tran @point;
	insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (1312,'���',null,null)
	set @point = 'p2'; save tran @point;
	commit tran;
end try
begin catch
	print '������ '+case
	when error_number() = 2627 and patindex('%UNIVER',error_message())>0
	then '������������ ��������'
	else '����������� ������ ' + cast(error_number()as varchar(5)) + error_message()
	end;
	if @@TRANCOUNT >0 
	begin
		print '����������� �����: ' +@point;
		rollback tran @point;
		commit tran;
		end;
end catch;

