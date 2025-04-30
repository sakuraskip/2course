declare @char char(20) = 'aaaaa',
@varchar varchar(30) = 'bbbbb',
@datetime datetime = getdate(),
@time time,
@int int,
@smallint smallint,
@tinyint tinyint,
@numeric numeric(12,5);

select
@time = '13:56:00',
@int = 3,
@smallint = 2;

set @tinyint = 1;
set @numeric = 123.45678;

select @char,@varchar,@datetime,@time

print 'int = ' + cast(@int as varchar);
print 'numeric =' + cast(@numeric as varchar);
--task2
declare @����������� int = (select sum(AUDITORIUM.AUDITORIUM_CAPACITY) from AUDITORIUM);
if @����������� > 200
begin
declare @�������������� int, @������������������ decimal,
@������������������� int;

select @�������������� = count(*),@������������������ = avg(AUDITORIUM.AUDITORIUM_CAPACITY)
from AUDITORIUM;
select @������������������� = count(*) from AUDITORIUM where AUDITORIUM.AUDITORIUM_CAPACITY < @������������������
declare @��������������������� decimal;
set @���������������������  = (@�������������������*100.0)/@��������������

select @�������������� as �������������������,@������������������ as ������������������,
@������������������� as ������������������������,@��������������������� as ���������������������
end
else
begin
select @�������������� as ������������������������
end
--task3
print 'rowcount :' + cast(@@rowcount as varchar)
print 'version : '+cast(@@version as varchar)
print 'spid : '+cast(@@spid as varchar)
print 'error : '+cast(@@error as varchar)
print 'servername : '+cast(@@servername as varchar)
print 'trancount : '+cast(@@trancount as varchar)
print 'fetch_status : '+cast(@@fetch_status as varchar)
print 'nestlevel : '+cast(@@nestlevel as varchar)

--task4
declare @t int,@x int,@z float;
set @t =2
set @x = 1;
if(@t > @x) set @z = POWER(sin(@t),2);
else if (@t<@x) set @z = 4*(@t+@x);
else set @z = 1-exp(@x-2);
print 'z = '+cast(@z as varchar)

declare @fullname varchar(100) set @fullname = '����� ������� ��������'
declare @firstSpaceIndex int = charindex(' ',@fullname)
declare @surname nvarchar(50) = left(@fullname,@firstSpaceIndex-1)
declare @secondSpaceIndex int = charindex(' ',@fullname,@firstSpaceIndex)
declare @nameLetter1 nvarchar(1) = substring(@fullname, @firstSpaceIndex + 1, 1);
declare @nameLetter2 nvarchar(1) = substring(@fullname, @secondSpaceIndex + 1, 1);

print @surname + ' '  + @nameLetter1  +'.'+@nameLetter2+'.'

select STUDENT.NAME,DATEDIFF(year,student.BDAY,GETDATE())as �������
from STUDENT
where MONTH(student.BDAY) = MONTH(getdate())+1

select datename(WEEKDAY,p.PDATE)as ����������,p.NOTE,g.IDGROUP from PROGRESS p inner join STUDENT s
on p.IDSTUDENT = s.IDSTUDENT inner join GROUPS g
on s.IDGROUP = g.IDGROUP
where p.SUBJECT like '%��%'

--task5
go
declare @group5 int;
select @group5 = avg(p.NOTE)*1.0
from PROGRESS p inner join STUDENT s on p.IDSTUDENT = s.IDSTUDENT
where s.IDGROUP = 5

declare @group6 int;
select @group6 = avg(p.NOTE)*1.0
from PROGRESS p inner join STUDENT s on p.IDSTUDENT = s.IDSTUDENT
where s.IDGROUP = 6
if(@group6 > @group5) print '������ 6 �������� �������� ����� 5'
else
print '������ 5 �������� �������� ����� ������ 6'

--task6
select STUDENT.NAME, g.FACULTY,
case 
when PROGRESS.NOTE between 5 and 7 then '�� 5 �� 7'
when PROGRESS.NOTE between 8 and 10 then '�� 8 �� 10'
else '���� 5' end [������]
from PROGRESS inner join STUDENT on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
inner join GROUPS g on g.IDGROUP = STUDENT.IDGROUP
where g.FACULTY like '%�%'
--task7

create table #expired
(
id int,
name varchar(100),
bday date)
declare @counter int =0
while @counter <=10
begin
insert into #expired(id,name,bday)
select top 1 s.IDSTUDENT, s.NAME,s.BDAY
from STUDENT s
where s.IDSTUDENT not in(select id from #expired)
set @counter = @counter+1;
end

select * from #expired;

--task8
go
declare @counter1 int = 14
while(@counter1 < 100)
begin
if(@counter1 %26 =0) begin print 'return ' + cast(@counter1 as varchar); return;--����������� ��������� ����������  ����� ������
end
else set  @counter1 = @counter1+ 1
end
print 'counter: ' + cast(@counter1 as varchar)
select * from GROUPS
--task9
begin try
update dbo.GROUPS set  YEAR_FIRST = 'dfgfdgdfg' where YEAR_FIRST =2012
end try
begin catch
PRINT '������ �����: ' + CAST(ERROR_NUMBER() AS VARCHAR);
PRINT '���������: ' + ERROR_MESSAGE();
PRINT '����� ������: ' + CAST(ERROR_LINE() AS VARCHAR);
PRINT '��� ���������: ' + ISNULL(ERROR_PROCEDURE(), 'NULL');
PRINT '����������� ������: ' + CAST(ERROR_SEVERITY() AS VARCHAR);
PRINT 'state ������: ' + CAST(ERROR_STATE() AS VARCHAR)
end catch