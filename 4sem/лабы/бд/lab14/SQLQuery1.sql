use UNIVER
go
--task1
drop function count_students;
go
create function count_students(@faculty varchar(50)) returns int as
begin
declare @result int = 0;
set @result = (select count(*) from
FACULTY f inner join GROUPS g on f.FACULTY = g.FACULTY
inner join STUDENT s on g.IDGROUP = s.IDGROUP where f.FACULTY = @faculty);
return @result;
end;
go

declare @facult varchar(50) = 'ИЭФ';
print dbo.count_students(@facult)
--task1.2
go
alter function count_students(@faculty varchar(50),@prof varchar(50) = '%к%') returns int as
begin
declare @result int = 0;
set @result = (select count(*) from STUDENT s
        inner join GROUPS g on s.IDGROUP = g.IDGROUP
		inner join PROFESSION p on p.FACULTY = g.FACULTY
        where g.FACULTY = @faculty
        and p.PROFESSION_NAME like @prof);
return @result;
end;
go

select * from STUDENT s
        inner join GROUPS g on s.IDGROUP = g.IDGROUP
		inner join PROFESSION p on p.FACULTY = g.FACULTY
        where g.FACULTY = 'ИЭФ'
        and p.PROFESSION_NAME like '%к%'

select * from GROUPS where FACULTY = 'ИЭФ';
print dbo.count_students('ИЭФ',default)



--task2
drop function FSubjects
go
create function FSubjects (@p varchar(20)) returns varchar(300) as
begin
declare @line varchar(50),@text varchar(300) = '';
declare curs cursor local for 
select SUBJECT.SUBJECT from SUBJECT where SUBJECT.PULPIT = @p;
open curs
fetch curs into @line;
while @@FETCH_STATUS =0
begin 
	set @text = @text + ''+@line;
	fetch curs into @line;
end;
return @text;
end;
go
declare @printer varchar(500)
set @printer = dbo.FSubjects('ИСиТ')
print @printer
go
--task3
drop function ffacpul
go
create function ffacpul(@faculty varchar(50),@pulpit varchar(50)) returns table as

return (
select FACULTY_NAME,PULPIT,PULPIT_NAME
from FACULTY f left join PULPIT p on f.FACULTY = p.FACULTY
where f.FACULTY = isnull(@faculty,f.FACULTY) and
p.PULPIT = isnull(@pulpit,p.PULPIT));
go
select * from ffacpul('ИЭФ',null)
go
--task4
drop function fcteacher
go
create function fcteacher(@pulpit varchar(50)) returns int as
begin
declare @res int = (select count(*) from TEACHER where
TEACHER.PULPIT = isnull(@pulpit,TEACHER.PULPIT))
return @res
end;
go
select dbo.fcteacher(null)[всего преподавателей]

--task5
go
create function dbo.count_pulpits(@faculty varchar(50))
returns int
as
begin
    declare @count int;
    select @count = count(*) from pulpit where faculty = @faculty;
    return @count;
end;
go

create function dbo.count_groups(@faculty varchar(50))
returns int
as
begin
    declare @count int;
    select @count = count(*) from groups where faculty = @faculty;
    return @count;
end;
go

create function dbo.count_professions(@faculty varchar(50))
returns int
as
begin
    declare @count int;
    select @count = count(profession) from profession where faculty = @faculty;
    return @count;
end;
go

go
create function FACULTY_REPORT(@c int) returns @fr table
	                        ( [Факультет] varchar(50), [Количество кафедр] int, [Количество групп]  int, 
	                                                                 [Количество студентов] int, [Количество специальностей] int )
	as begin 
                 declare cc CURSOR static for 
	       select FACULTY from FACULTY 
                                                    where dbo.COUNT_STUDENTS(FACULTY, default) > @c; 
	       declare @f varchar(30);
	       open cc;  
                 fetch cc into @f;
	       while @@fetch_status = 0
	       begin
	            insert @fr values( @f,  (dbo.COUNT_PULPITS(@f)),
	            (dbo.COUNT_GROUPS(@f)),   dbo.COUNT_STUDENTS(@f, default),
	            (dbo.COUNT_PROFESSIONS(@f))); 
	            fetch cc into @f;  
	       end;   
                 return; 
	end;
go
select * from dbo.FACULTY_REPORT(0)
