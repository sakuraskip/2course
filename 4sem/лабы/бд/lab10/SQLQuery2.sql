use S_MyBase3


--clustered PK__��������__DA7CBAF73F60B186
SELECT * FROM �������������
WHERE [����� ��������������] > 3;

CREATE  INDEX index_������������� ON �������������([������� ��������������], [��� ��������������]);
select  * from ������������� where [������� ��������������] like '%�%'

drop  INDEX index_������������� ON �������������

CREATE  INDEX index_�������� ON ��������([�������� ������������])
INCLUDE ([������� ��������], [���� ��������],[������������]);

drop  INDEX index_�������� ON ��������

SELECT [�������� ������������], [������� ��������], [���� ��������]
FROM ��������
WHERE [�������� ������������] like '%������%';
go
--task4
CREATE  INDEX index_������������ ON ������������([���������� ������������])
WHERE [���������� ������������] > 2;

SELECT * FROM ������������
WHERE [���������� ������������] > 3;

--task5
drop index index_������������ on ������������
go

create index index_������������ on ������������([���������� ������������])

SELECT 
    i.name AS [������], 
    ps.avg_fragmentation_in_percent AS [������������ (%)]
FROM 
    sys.dm_db_index_physical_stats(DB_ID(N'S_MyBase3'), 
    OBJECT_ID(N'S_MyBase3'), NULL, NULL, null) AS ps
JOIN 
    sys.indexes AS i ON ps.object_id = i.object_id AND ps.index_id = i.index_id
WHERE 
    i.name IS NOT NULL;

alter index index_������������ on ������������ reorganize

alter index index_������������ on ������������ rebuild with (online=off)


--task6
select * from ������������
drop index index_������������ on ������������

create index index_������������ on ������������([���������� ������������])
WHERE [���������� ������������] > 2 with(fillfactor=65);

