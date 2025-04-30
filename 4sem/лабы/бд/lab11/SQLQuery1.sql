use univer
declare @line varchar(50), @text varchar(500) =  '';
declare DisciplinesCursor  cursor for select SUBJECT_NAME from SUBJECT s
inner join PULPIT p on s.PULPIT = p.PULPIT and p.PULPIT like 'ИСиТ'

open DisciplinesCursor;
fetch DisciplinesCursor into @line;
print 'список дисциплин на кафедре ИСиТ';
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
