use S_MyBase3


--clustered PK__Ответств__DA7CBAF73F60B186
SELECT * FROM Ответственные
WHERE [Номер ответственного] > 3;

CREATE  INDEX index_Ответственные ON Ответственные([Фамилия ответственного], [Имя ответственного]);
select  * from Ответственные where [Фамилия ответственного] like '%к%'

drop  INDEX index_Ответственные ON Ответственные

CREATE  INDEX index_Списания ON Списания([Название оборудования])
INCLUDE ([Причина списания], [Дата списания],[Фрагментация]);

drop  INDEX index_Списания ON Списания

SELECT [Название оборудования], [Причина списания], [Дата списания]
FROM Списания
WHERE [Название оборудования] like '%станок%';
go
--task4
CREATE  INDEX index_Оборудование ON Оборудование([Количество оборудования])
WHERE [Количество оборудования] > 2;

SELECT * FROM Оборудование
WHERE [Количество оборудования] > 3;

--task5
drop index index_Оборудование on Оборудование
go

create index index_Оборудование on Оборудование([Количество оборудования])

SELECT 
    i.name AS [Индекс], 
    ps.avg_fragmentation_in_percent AS [Фрагментация (%)]
FROM 
    sys.dm_db_index_physical_stats(DB_ID(N'S_MyBase3'), 
    OBJECT_ID(N'S_MyBase3'), NULL, NULL, null) AS ps
JOIN 
    sys.indexes AS i ON ps.object_id = i.object_id AND ps.index_id = i.index_id
WHERE 
    i.name IS NOT NULL;

alter index index_Оборудование on Оборудование reorganize

alter index index_Оборудование on Оборудование rebuild with (online=off)


--task6
select * from Оборудование
drop index index_Оборудование on Оборудование

create index index_Оборудование on Оборудование([Количество оборудования])
WHERE [Количество оборудования] > 2 with(fillfactor=65);

