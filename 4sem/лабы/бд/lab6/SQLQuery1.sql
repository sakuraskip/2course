--task1
select AUDITORIUM_TYPE.AUDITORIUM_TYPE ,max(AUDITORIUM.AUDITORIUM_CAPACITY)[������������ �����������],
min(AUDITORIUM.AUDITORIUM_CAPACITY)[����������� �����������],
AVG(AUDITORIUM.AUDITORIUM_CAPACITY)[������� �����������],
sum(AUDITORIUM.AUDITORIUM_CAPACITY)[�����],
count(*)[���-�� ���������]
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE
group by AUDITORIUM_TYPE.AUDITORIUM_TYPE


--task2/3
select * from(select
case 
when PROGRESS.NOTE between 5 and 7 then '�� 5 �� 7'
when PROGRESS.NOTE between 8 and 10 then '�� 8 �� 10'
else '���� 5' end [������], count(*)[���������� ������]
from PROGRESS group by 
case 
when PROGRESS.NOTE between 5 and 7 then '�� 5 �� 7'
when PROGRESS.NOTE between 8 and 10 then '�� 8 �� 10'
else '���� 5' end) as T
order by Case [������]
when '�� 5 �� 7' then 2
when '�� 8 �� 10' then 3
when '���� 5' then 1
else 0
end

--task4
select g.PROFESSION,f.FACULTY_NAME,
round(avg(p.NOTE * 1.0),2)[������� ������]
from FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s 
on g.IDGROUP = s.IDGROUP
inner join PROGRESS p
on p.IDSTUDENT = s.IDSTUDENT
group by g.PROFESSION,
f.FACULTY_NAME
order by [������� ������] desc

--task5
select g.PROFESSION,f.FACULTY_NAME,
round(avg(p.NOTE * 1.0),2)[������� ������]
from FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s 
on g.IDGROUP = s.IDGROUP
inner join PROGRESS p
on p.IDSTUDENT = s.IDSTUDENT
where p.SUBJECT like '%����%' or p.SUBJECT like '%��%'
group by g.PROFESSION,
f.FACULTY_NAME
order by [������� ������] desc

--task 6
select g.PROFESSION, p.SUBJECT, avg(p.NOTE)[������� ������]
from FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on g.IDGROUP = s.IDGROUP
inner join PROGRESS p
on p.IDSTUDENT = s.IDSTUDENT
where f.FACULTY in ('���')
group by g.PROFESSION,p.SUBJECT

--task7
select p.subject, count(p.idstudent)[���-�� ���������]
from PROGRESS p
where p.note in(8,9)
group by p.SUBJECT
having count(p.idstudent) >0
