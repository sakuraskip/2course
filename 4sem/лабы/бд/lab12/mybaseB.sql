BEGIN TRANSACTION;

INSERT INTO ������������� ([����� ��������������], [������� ��������������], [��� ��������������], [�������� ��������������], ���������, [���� ������ �� ������]) 
VALUES (21, '�������', '�����', '���������', '�����������', '2023-03-01');

UPDATE ������������ 
SET [���������� ������������] = [���������� ������������] - 1 
WHERE [�������� ������������] = '��������';

ROLLBACK;

--task5
BEGIN TRANSACTION;

--------t1--------
DELETE FROM ������������ 
WHERE [���������� ������������] < 5;

COMMIT;

-----------t2----------

--task6
BEGIN TRANSACTION;

-----------t1-----------
INSERT INTO ������������� ([����� ��������������], [������� ��������������], [��� ��������������], [�������� ��������������], ���������, [���� ������ �� ������]) 
VALUES (15, '�������', '�������', '����������', '�����������', '2023-04-01');

COMMIT;

--task7
BEGIN TRANSACTION;

DELETE FROM ������������� WHERE [����� ��������������] > 14;

INSERT INTO ������������� ([����� ��������������], [������� ��������������], [��� ��������������], [�������� ��������������], ���������, [���� ������ �� ������]) 
VALUES (17, '������', '����', '��������', '�����������', '2023-06-01');

UPDATE ������������� 
SET [������� ��������������] = '�����������' 
WHERE [������� ��������������] LIKE '%������%';

SELECT [������� ��������������] FROM ������������� WHERE [������� ��������������] = '�����������';

--------------t1-----------
COMMIT;

SELECT [������� ��������������] FROM ������������� WHERE [������� ��������������] LIKE '%�����������%';