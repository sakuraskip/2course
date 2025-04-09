--task1
CREATE VIEW [Преподаватель] AS --запускать отдельно от всего
SELECT 
    t.TEACHER AS [код], 
    t.TEACHER_NAME AS [имя], 
    t.GENDER AS [пол], 
    t.PULPIT AS [кафедра]
FROM 
    TEACHER t;

use UNIVER;
select * from Преподаватель

--task2
create view [Количество кафедр] as
select f.FACULTY,count(p.PULPIT)[кол-во  кафедр] from FACULTY f inner join PULPIT p
on f.FACULTY = p.FACULTY
group by f.FACULTY

select * from [Количество кафедр]

--task3
CREATE VIEW [Аудитории] WITH SCHEMABINDING AS
SELECT aud.AUDITORIUM[код], aud.[AUDITORIUM_NAME]
FROM dbo.AUDITORIUM aud
WHERE aud.AUDITORIUM_TYPE LIKE 'ЛК%'

select * from  Аудитории

--task4
create view [лекционные аудитории] as
SELECT aud.AUDITORIUM[код], aud.[AUDITORIUM_NAME]
FROM dbo.AUDITORIUM aud
WHERE aud.AUDITORIUM_TYPE LIKE 'ЛК%'

select * from [лекционные аудитории]

--task5
create view Дисциплины as
select top 10 s.SUBJECT,s.SUBJECT_NAME,s.PULPIT from SUBJECT s
order by s.SUBJECT

select * from Дисциплины

--task6
drop view [Количество кафедр]
create view [Количество кафедр] with SCHEMAbinding as
select f.FACULTY,count(p.PULPIT)[кол-во  кафедр] from dbo.FACULTY f inner join dbo.PULPIT p
on f.FACULTY = p.FACULTY
group by f.FACULTY


select * from [Количество кафедр]