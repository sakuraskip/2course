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
	print 'количество строк в таблице X: ' + cast( @c as varchar(2));
		if @flag = 'c'  commit;                   
	          else   rollback;                                 
      SET IMPLICIT_TRANSACTIONS  OFF   
	
	if  exists (select * from  SYS.OBJECTS      
	            where OBJECT_ID= object_id(N'DBO.X') )
	print 'таблица X есть';  
      else print 'таблицы X нет'

--task2
begin try
	begin tran
	delete STUDENT where IDSTUDENT >1173
	insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (1312,'ааа',null,null)
	update STUDENT set IDGROUP = 3345 where name like 'aaa';
	commit tran
end try
begin catch
	print 'ошибка '+case
	when error_number() = 2627 and patindex('%UNIVER',error_message())>0
	then 'дублирование студента'
	else 'неизвестная ошибка ' + cast(error_number()as varchar(5)) + error_message()
	end;
	if @@TRANCOUNT >0 rollback tran;--если больше нуля - транзакция не завершена
	end catch;
--task3
declare @point varchar(52);
begin try
	begin tran
	delete STUDENT where IDSTUDENT = 1173;
	set @point = 'p1'; save tran @point;
	insert into STUDENT(IDGROUP,NAME,INFO,FOTO) values (1312,'ааа',null,null)
	set @point = 'p2'; save tran @point;
	commit tran;
end try
begin catch
	print 'ошибка '+case
	when error_number() = 2627 and patindex('%UNIVER',error_message())>0
	then 'дублирование студента'
	else 'неизвестная ошибка ' + cast(error_number()as varchar(5)) + error_message()
	end;
	if @@TRANCOUNT >0 
	begin
		print 'контрольная точка: ' +@point;
		rollback tran @point;
		commit tran;
		end;
end catch;

