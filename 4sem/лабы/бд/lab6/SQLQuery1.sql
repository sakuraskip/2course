--task1
select AUDITORIUM_TYPE.AUDITORIUM_TYPE ,max(AUDITORIUM.AUDITORIUM_CAPACITY)[максимальна€ вместимость],
min(AUDITORIUM.AUDITORIUM_CAPACITY)[минимальна€ вместимость],
AVG(AUDITORIUM.AUDITORIUM_CAPACITY)[средн€€ вместимость],
sum(AUDITORIUM.AUDITORIUM_CAPACITY)[сумма],
count(*)[кол-во аудиторий]
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE
group by AUDITORIUM_TYPE.AUDITORIUM_TYPE


--task2/3
select * from(select
case 
when PROGRESS.NOTE between 5 and 7 then 'от 5 до 7'
when PROGRESS.NOTE between 8 and 10 then 'от 8 до 10'
else 'ниже 5' end [оценка], count(*)[количество оценок]
from PROGRESS group by 
case 
when PROGRESS.NOTE between 5 and 7 then 'от 5 до 7'
when PROGRESS.NOTE between 8 and 10 then 'от 8 до 10'
else 'ниже 5' end) as T
order by Case [оценка]
when 'от 5 до 7' then 2
when 'от 8 до 10' then 3
when 'ниже 5' then 1
else 0
end

--task4
select g.PROFESSION,f.FACULTY_NAME,
round(avg(p.NOTE * 1.0),2)[средн€€ оценка]
from FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s 
on g.IDGROUP = s.IDGROUP
inner join PROGRESS p
on p.IDSTUDENT = s.IDSTUDENT
group by g.PROFESSION,
f.FACULTY_NAME
order by [средн€€ оценка] desc

--task5
select g.PROFESSION,f.FACULTY_NAME,
round(avg(p.NOTE * 1.0),2)[средн€€ оценка]
from FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s 
on g.IDGROUP = s.IDGROUP
inner join PROGRESS p
on p.IDSTUDENT = s.IDSTUDENT
where p.SUBJECT like '%ќјип%' or p.SUBJECT like '%Ѕƒ%'
group by g.PROFESSION,
f.FACULTY_NAME
order by [средн€€ оценка] desc

--task 6
select g.PROFESSION, p.SUBJECT, avg(p.NOTE)[средн€€ оценка]
from FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on g.IDGROUP = s.IDGROUP
inner join PROGRESS p
on p.IDSTUDENT = s.IDSTUDENT
where f.FACULTY in ('“ќ¬')
group by g.PROFESSION,p.SUBJECT

--task7
select p.subject, count(p.idstudent)[кол-во студентов]
from PROGRESS p
where p.note in(8,9)
group by p.SUBJECT
having count(p.idstudent) >0
