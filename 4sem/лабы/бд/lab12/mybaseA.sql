--task4
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRANSACTION;
-----------t1-----------
SELECT @@SPID, '������ �������������', * 
FROM ������������� 
WHERE [������� ��������������] LIKE '%������%';

SELECT @@SPID, '������ ������������', * 
FROM ������������ 
WHERE [�������� ������������] LIKE '%��������%';

COMMIT;

--task5
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;

SELECT COUNT(*) 
FROM ������������� 
WHERE [����� ��������������] > 1;

--------t1--------

--------t2--------

SELECT '���������� ������������' AS '���������', COUNT(*) 
FROM ������������ 
WHERE [���������� ������������] > 5;

COMMIT;

--task6
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;

SELECT [������� ��������������], [��� ��������������] 
FROM ������������� 
WHERE [����� ��������������] > 5;

------------t1----------

------------t2-----------
SELECT CASE 
    WHEN [������� ��������������] LIKE '%�%' THEN 'insert �������������' 
    ELSE '' 
END AS '���������', [������� ��������������], [��� ��������������] 
FROM ������������� 
WHERE [����� ��������������] > 5;

COMMIT;

--task7
---------A-----------
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;

DELETE FROM ������������� WHERE [����� ��������������] > 14;

INSERT INTO ������������� ([����� ��������������], [������� ��������������], [��� ��������������], [�������� ��������������], ���������, [���� ������ �� ������]) 
VALUES (16, '������', '����', '��������', '��������', '2023-05-01');

UPDATE ������������� 
SET [������� ��������������] = '�����������' 
WHERE [������� ��������������] LIKE '%����%';

SELECT [������� ��������������] FROM ������������� WHERE [������� ��������������] LIKE '%����%';

-------------t1-----------
SELECT [������� ��������������] FROM ������������� WHERE [������� ��������������] LIKE '%����%';

-------------t2----------
COMMIT;
