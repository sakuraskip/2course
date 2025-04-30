--task1
use UNIVER
exec  sp_helpindex 'AUDITORIUM_TYPE'
go
drop table #expired
create table #expired
(
id int,
name varchar(100),
)
declare @i int =0
while @i<1000
begin
	Insert #expired(id,name) values (floor(2000*rand()),replicate('имя',10));
	set @i = @i+1;
end;
drop index #expired_ind on #expired
create clustered index #expired_ind  on #expired(id desc)
select * from  #expired where id between 1000 and 1999  order by id
go
--task2
drop table #expired1
create table #expired1
(
id int,
name varchar(100),
)
set nocount on;
declare @j int =0
while @j<10000
begin
	Insert #expired1(id,name) values (floor(10000*rand()),replicate('имя',5));
	set @j = @j+1;
end;
select * from #expired1
create index #expired1_ind on #expired1(id,name)
select *  from #expired1 where id=1794
drop index #expired1_ind on #expired1
--task3

create index #expired1_task3 on #expired1(id) include (name)
select name from #expired1 where id > 1300
drop index #expired1_task3 on #expired1

--task4
drop index #exp_task4 on #expired1
select id from #expired1 where id between 1000 and 3500;
select id from #expired1 where id > 5000 and id <7350;
select id from #expired1 where id = 7501;
create index #exp_task4 on #expired1(id) where (id>=3000 and id<9100)

--task5
drop table #expired1
create table #expired1
(
id int,
name varchar(100),
)
set nocount on;
declare @ii int =0
while @ii<10000
begin
	Insert #expired1(id,name) values (floor(10000*rand()),replicate('имя',5));
	set @ii = @ii+1;
end;
drop index #exp_task5 on #expired1

create index #exp_task5 on #expired1(id)

SELECT 
    i.name AS [Индекс], 
    ps.avg_fragmentation_in_percent AS [Фрагментация (%)]
FROM 
    sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), 
    OBJECT_ID(N'tempdb..#expired1'), NULL, NULL, 'LIMITED') AS ps
JOIN 
    tempdb.sys.indexes AS i ON ps.object_id = i.object_id AND ps.index_id = i.index_id
WHERE 
    i.name IS NOT NULL;

insert top (10000) #expired1(id,name) select id,name from #expired1
alter index #exp_task5 on #expired1 reorganize
alter index #exp_task5 on #expired1 rebuild with (online = off)
--task6
create index #exp_task6 on #expired1(id) with(fillfactor  = 65)
drop index #exp_task6 on #expired1
Insert top(50) percent into #expired1(id,name) select id,name from #expired1
delete top(10) percent from #expired1