use UNIVER

--task1
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE * 1.0)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%���%'
group by rollup( g.PROFESSION, p.SUBJECT);

--task2
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE * 1.0)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%���%'
group by cube( g.PROFESSION, p.SUBJECT);

--task3
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%���%'
group by g.PROFESSION,p.SUBJECT,f.FACULTY
union all
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%����%'
group by g.PROFESSION, p.SUBJECT,f.FACULTY

--task4
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%���%'
group by g.PROFESSION,p.SUBJECT,f.FACULTY
intersect
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%����%'
group by g.PROFESSION, p.SUBJECT,f.FACULTY

--task5
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%���%'
group by g.PROFESSION,p.SUBJECT,f.FACULTY
except
select g.PROFESSION,p.SUBJECT,AVG(p.NOTE)[������� ������] from
FACULTY f inner join GROUPS g
on f.FACULTY = g.FACULTY
inner join STUDENT s on s.IDGROUP = g.IDGROUP
inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT
where g.FACULTY like '%����%'
group by g.PROFESSION, p.SUBJECT,f.FACULTY