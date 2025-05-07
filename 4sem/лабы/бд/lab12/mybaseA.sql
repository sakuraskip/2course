--task4
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRANSACTION;
-----------t1-----------
SELECT @@SPID, 'Чтение Ответственных', * 
FROM Ответственные 
WHERE [Фамилия ответственного] LIKE '%Иванов%';

SELECT @@SPID, 'Чтение Оборудования', * 
FROM Оборудование 
WHERE [Название оборудования] LIKE '%Проектор%';

COMMIT;

--task5
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;

SELECT COUNT(*) 
FROM Ответственные 
WHERE [Номер ответственного] > 1;

--------t1--------

--------t2--------

SELECT 'Количество оборудования' AS 'результат', COUNT(*) 
FROM Оборудование 
WHERE [Количество оборудования] > 5;

COMMIT;

--task6
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;

SELECT [Фамилия ответственного], [Имя ответственного] 
FROM Ответственные 
WHERE [Номер ответственного] > 5;

------------t1----------

------------t2-----------
SELECT CASE 
    WHEN [Фамилия ответственного] LIKE '%и%' THEN 'insert ответственный' 
    ELSE '' 
END AS 'результат', [Фамилия ответственного], [Имя ответственного] 
FROM Ответственные 
WHERE [Номер ответственного] > 5;

COMMIT;

--task7
---------A-----------
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;

DELETE FROM Ответственные WHERE [Номер ответственного] > 14;

INSERT INTO Ответственные ([Номер ответственного], [Фамилия ответственного], [Имя ответственного], [Отчество ответственного], Должность, [Дата приема на работу]) 
VALUES (16, 'Иванов', 'Иван', 'Иванович', 'Менеджер', '2023-05-01');

UPDATE Ответственные 
SET [Фамилия ответственного] = 'Обновленный' 
WHERE [Фамилия ответственного] LIKE '%Иван%';

SELECT [Фамилия ответственного] FROM Ответственные WHERE [Фамилия ответственного] LIKE '%Иван%';

-------------t1-----------
SELECT [Фамилия ответственного] FROM Ответственные WHERE [Фамилия ответственного] LIKE '%Иван%';

-------------t2----------
COMMIT;
