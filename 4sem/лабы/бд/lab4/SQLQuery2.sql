use UNIVER

select STUDENT.NAME,GROUPS.FACULTY,PROGRESS.SUBJECT,PULPIT.PULPIT,PROFESSION.PROFESSION_NAME,
Case
when(PROGRESS.NOTE = 8) then 'восемь'
when(PROGRESS.NOTE = 7) then 'семь'
when(PROGRESS.NOTE = 6) then 'шесть'
end [ќценка]
from STUDENT inner join PROGRESS on student.IDSTUDENT = PROGRESS.IDSTUDENT
inner join GROUPS on student.IDGROUP = GROUPS.IDGROUP
inner join PULPIT on groups.FACULTY = PULPIT.FACULTY
inner join PROFESSION on groups.FACULTY = PROFESSION.FACULTY

where PROGRESS.NOTE between 6 and 8
order by ќценка
--задание 3
