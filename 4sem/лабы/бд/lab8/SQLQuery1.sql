--task1
drop view [�������������]

CREATE VIEW [�������������] AS --��������� �������� �� �����
SELECT 
    t.TEACHER AS [���], 
    t.TEACHER_NAME AS [���], 
    t.GENDER AS [���], 
    t.PULPIT AS [�������]
FROM 
    TEACHER t;

use UNIVER;
select * from �������������

--task2
drop view [���������� ������]
create view [���������� ������] as
select f.FACULTY,count(p.PULPIT)[���-��  ������] from FACULTY f inner join PULPIT p
on f.FACULTY = p.FACULTY
group by f.FACULTY

select * from [���������� ������]

--task3
drop view [���������]
CREATE VIEW [���������] WITH SCHEMABINDING AS
SELECT aud.AUDITORIUM[���], aud.[AUDITORIUM_NAME]
FROM dbo.AUDITORIUM aud
WHERE aud.AUDITORIUM_TYPE LIKE '��%'

select * from  ���������

--task4
drop view [���������� ���������]
create view [���������� ���������] as
SELECT aud.AUDITORIUM[���], aud.[AUDITORIUM_NAME]
FROM dbo.AUDITORIUM aud
WHERE aud.AUDITORIUM_TYPE LIKE '��%'

select * from [���������� ���������]

--task5
drop view ����������
create view ���������� as
select top 10 s.SUBJECT,s.SUBJECT_NAME,s.PULPIT from SUBJECT s
order by s.SUBJECT

select * from ����������

--task6
drop view [���������� ������]
create view [���������� ������] with SCHEMAbinding as
select f.FACULTY,count(p.PULPIT)[���-��  ������] from dbo.FACULTY f inner join dbo.PULPIT p
on f.FACULTY = p.FACULTY
group by f.FACULTY


select * from [���������� ������]