use univer
declare @line varchar(50), @text varchar(500) =  '';
declare DisciplinesCursor  cursor for select SUBJECT_NAME from SUBJECT s
inner join PULPIT p on s.PULPIT = p.PULPIT and p.PULPIT like '»—и“'

open DisciplinesCursor;
fetch DisciplinesCursor into @line;
print 'список дисциплин на кафедре »—и“';
while @@FETCH_STATUS =0
begin
set @text = rtrim(@line)+','+@text;
fetch DisciplinesCursor into @line;
end;
print @text;
close DisciplinesCursor
go
--task2
declare localCurs cursor local for select PROFESSION from GROUPS where GROUPS.IDGROUP %2=0
declare @line varchar(50);
open localCurs
fetch localCurs into @line;
print '1.  '+@line
go
declare @line varchar(50);
open localCurs
fetch localCurs into @line;
print '2.  '+@line
go

declare globalCurs cursor global for select PROFESSION from GROUPS where GROUPS.IDGROUP %2=0
declare @line varchar(50);
open globalCurs
fetch globalCurs into @line;
print '1.  '+@line
go
declare @line varchar(50);
fetch globalCurs into @line;
print '2.  '+@line
close globalCurs;
deallocate globalCurs
go

--task3
declare @id char(20), @name char(50), @idgroup char(10);
declare line cursor static for select IDSTUDENT,NAME,IDGROUP from STUDENT
open line
print 'кол-во строк: ' + cast(@@cursor_rows as varchar(5));
update STUDENT set NAME = name where idstudent %5 =0;
INSERT INTO STUDENT (IDGROUP, NAME, INFO, FOTO)
VALUES (NULL, 'мишан€', NULL, NULL);
fetch line into @id,@name,@idgroup
while @@FETCH_STATUS =0
begin
	print @id + ' '+@name + ' '+@idgroup;
	fetch line into @id,@name,@idgroup;
end;
close line
deallocate line
go

--task4
declare @prof char(20), @facultyname char(10), @qual varchar(50);
declare line cursor scroll
for select PROFESSION,FACULTY,QUALIFICATION from PROFESSION
open line
while @@FETCH_STATUS =0
begin
	fetch line into @prof,@facultyname,@qual
	print @prof +''+@facultyname+''+@qual
	
end;
fetch last from line into @prof,@facultyname,@qual
print 'последн€€ строка: ' +@prof+''+@facultyname+''+@qual
fetch absolute-10 from line into @prof,@facultyname,@qual
print 'дес€та€ строка с конца: '+@prof+''+@facultyname +''+@qual
fetch relative-5 from line into @prof,@facultyname,@qual
print 'п€та€ строка от текущей назад: '+@prof+''+@facultyname +''+@qual
fetch next from line into @prof,@facultyname,@qual
print 'п€та€ строка от текущей назад+1: '+@prof+''+@facultyname +''+@qual
fetch prior from line into @prof,@facultyname,@qual
print 'п€та€ строка от текущей назад-1: '+@prof+''+@facultyname +''+@qual
close line
deallocate line
go
--task5

declare @id char(20), @name char(50), @idgroup char(10);
declare studentcursor cursor for 
    select idstudent, name, idgroup from STUDENT for update;

open studentcursor;

fetch next from studentcursor into @id, @name, @idgroup;

while @@fetch_status = 0
begin
    if @id %10 =0
    begin
        update student set name = @name + ' (обновлено)' where current of studentcursor;
    end

    fetch next from studentcursor into @id, @name, @idgroup;
end;

close studentcursor;
deallocate studentcursor;


declare deletecursor cursor for select idstudent from STUDENT where idgroup is null;

open deletecursor;

fetch next from deletecursor into @id;

while @@fetch_status = 0
begin
    delete from STUDENT where current of deletecursor;
    fetch next from deletecursor into @id;
end;

close deletecursor;
deallocate deletecursor;
go

--task6
declare @idstudent int,@note int;
declare deleteCursor cursor for select s.IDSTUDENT,NOTE from PROGRESS p inner join STUDENT s
on p.IDSTUDENT = s.IDSTUDENT inner join GROUPS g on s.IDGROUP = g.IDGROUP where p.NOTE <4

open deleteCursor
fetch deleteCursor into @idstudent,@note
while @@FETCH_STATUS =0
begin
	delete from PROGRESS where @idstudent = PROGRESS.IDSTUDENT
	and NOTE = @note;
	fetch deleteCursor into @idstudent,@note
end;
close deleteCursor
deallocate deleteCursor
go

declare progressCursor cursor for select NOTE from PROGRESS where PROGRESS.IDSTUDENT = 1056
declare @note int;

open progressCursor
fetch progressCursor into @note;
while @@FETCH_STATUS =0
begin
	update PROGRESS
	set NOTE = NOTE+1
	where current of progressCursor;
	fetch progressCursor into @note;
end;
close progressCursor
deallocate progressCursor

