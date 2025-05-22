use UNIVER
go
create procedure PSUBJECT
as
begin
declare @k int = (select count(*) from SUBJECT);
select * from SUBJECT;
return @k;
end;
go
declare @k int;
exec @k = PSUBJECT;
print cast(@k as  varchar);
--task2
go
declare @k int =0, @r int =0, @p varchar(50);
exec @k = PSUBJECT @p = 'БД', @c = @r output;
print '@k = ' +cast(@k as varchar) + ' @r = ' + cast(@r as varchar)
--task3
go
create table #subject(
subject char(10) primary key not null,
subject_name varchar(100),
pulpit char(20)
)
insert #subject exec PSUBJECT @p = 'КГ'
select * from #subject
--task4
go 
create procedure PAUDITORIUM_INSERT @a char(20), @n varchar(50), @c int =0,@t char(10)
as
declare @key int = 1;
begin try
insert AUDITORIUM(AUDITORIUM,AUDITORIUM_NAME,AUDITORIUM_CAPACITY,AUDITORIUM_TYPE)
values (@a,@n,@c,@t)
return @key;
end try
begin catch
	print 'номер ошибки: '+ cast(error_number() as varchar);
	print 'сообщение: '+ error_message();
	print 'номер строки: '+ cast(error_line() as varchar);
	return -1;
end catch;
exec PAUDITORIUM_INSERT @a = 'prikol',@n = 'prikol_name',@c = 40,@t = 'LC'
--task5
go
drop procedure subject_report
go
create procedure SUBJECT_REPORT @p char(10)--ne rabotaet pomogite pj
as
begin try
declare @text varchar(500)= '', @line char(50);
print @p
if not exists(select * from SUBJECT where SUBJECT = @p)
raiserror('ошибка',11,1)
else
begin
declare curs cursor for select SUBJECT.SUBJECT from SUBJECT where SUBJECT.SUBJECT = @p;
open curs
fetch curs into @line;
while @@FETCH_STATUS =0
begin
set @text = rtrim(@line)+ ','+@text;
fetch curs into @line;
end;
print @text;
close curs;
deallocate curs;
end
end try
begin catch
	print 'ошибка в параметрах'
	print ERROR_NUMBER()
end catch;
go
execute SUBJECT_REPORT @p = 'КГ';
select * from SUBJECT where SUBJECT = 'КГ'
--task6
go
drop procedure PAUDITORIUM_INSERTX
go
create procedure PAUDITORIUM_INSERTX @a char(20), @n varchar(50), @c int =0,@t char(10), @tn varchar(50)
as
begin
    begin try
        set transaction isolation level serializable;
        begin transaction;
        insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
        values (@t, @tn);

        exec PAUDITORIUM_INSERT @a, @n, @c, @t;

        commit transaction;

        return 1; 
    end try
    begin catch
        if @@TRANCOUNT > 0
            rollback transaction;
        print 'Ошибка: ' + error_message();
        
        return -1; 
    end catch;
end;
go
declare @rc int;
exec @rc = PAUDITORIUM_INSERTX @a = 'prikol',@n = 'prikol_name',@c = 40,@t = 'LC',@tn = 'prikol_typename'
print cast(@rc as varchar)

