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


