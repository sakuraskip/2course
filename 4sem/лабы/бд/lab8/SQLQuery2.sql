--task1
CREATE VIEW [������ �������������] AS
SELECT 
    [����� ��������������] AS [���], 
    [������� ��������������] AS [�������], 
    [��� ��������������] AS [���], 
    [�������� ��������������] AS [��������], 
    ��������� AS [���������], 
    [���� ������ �� ������] AS [���� ������]
FROM 
    �������������;

SELECT * FROM [������ �������������];
--task2
CREATE VIEW [������ ������������] AS
SELECT 
    [�������� ������������] AS [���], 
    [��� ������������] AS [���], 
    [���������� ������������] AS [����������], 
    [���� �����������] AS [���� �����������], 
    [������������� ���������] AS [�������������]
FROM 
    ������������;

SELECT * FROM [������ ������������];

--task3

CREATE VIEW [������] AS
SELECT 
    [�������� ������������] AS [���], 
    [��� ������������] AS [���], 
    [���������� ������������] AS [����������], 
    [���� �����������] AS [���� �����������], 
    [������������� ���������] AS [�������������]
FROM 
    ������������
	where ������������.[�������� ������������] like '%������%'

	select * from [������]

	--task5
	drop view [��� 5 ��������]
create view [��� 5 ��������] as
select top 5 ��������.[�������� ������������],��������.[���������� ���������� ������������],��������.[������� ��������]
from ��������
order  by [������� ��������]

select * from [��� 5 ��������]

--task 6
drop view [������ ������������]
CREATE VIEW [������ ������������] with schemabinding AS
SELECT 
    [�������� ������������] AS [���], 
    [��� ������������] AS [���], 
    [���������� ������������] AS [����������], 
    [���� �����������] AS [���� �����������], 
    [������������� ���������] AS [�������������]
FROM 
    dbo.������������;

	