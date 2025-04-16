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
declare @вместимость int = (select sum(AUDITORIUM.AUDITORIUM_CAPACITY) from AUDITORIUM);
if @вместимость > 200
begin
declare @колвојудиторий int, @средн€€¬местимость decimal,
@колвоћеньше—реднего int;

select @колвојудиторий = count(*),@средн€€¬местимость = avg(AUDITORIUM.AUDITORIUM_CAPACITY)
from AUDITORIUM;
select @колвоћеньше—реднего = count(*) from AUDITORIUM where AUDITORIUM.AUDITORIUM_CAPACITY < @средн€€¬местимость
declare @процентћеньше—реднего decimal;
set @процентћеньше—реднего  = (@колвоћеньше—реднего*100.0)/@колвојудиторий

select @колвојудиторий as количествојудиторий,@средн€€¬местимость as средн€€¬местимость,
@колвоћеньше—реднего as количествоћеньше—реднего,@процентћеньше—реднего as процентћеньше—реднего
end
else
begin
select @колвојудиторий as общее оличествојудиторий
end


