use S_MyBase3
declare @�������������������� nvarchar(50);

declare ������������cursor cursor for 
select rtrim([�������� ������������]) 
from ������������;

open ������������cursor;

fetch next from ������������cursor into @��������������������;

while @@fetch_status = 0
begin
    print @��������������������;
    fetch next from ������������cursor into @��������������������;
end;

close ������������cursor;
deallocate ������������cursor;
go
declare @�������������������� nvarchar(50);

declare ���������cursor cursor local for 
select [�������� ������������] 
from ������������;

declare ����������cursor cursor global for 
select [�������� ������������] 
from ������������;

open ���������cursor;
fetch next from ���������cursor into @��������������������;
print '��������� ������: ' + @��������������������;
close ���������cursor;

open ����������cursor;
fetch next from ����������cursor into @��������������������;
print '���������� ������: ' + @��������������������;
fetch next from ����������cursor into @��������������������;
print '���������� ������ 2: ' + @��������������������;
close ����������cursor;

deallocate ���������cursor;
deallocate ����������cursor;
go

declare @�������������������� nvarchar(50);

declare �����������cursor cursor static for 
select [�������� ������������] 
from ������������;

declare ������������cursor cursor dynamic for 
select [�������� ������������] 
from ������������;

open �����������cursor;
fetch next from �����������cursor into @��������������������;
print '����������� ������: ' + @��������������������;
close �����������cursor;

open ������������cursor;
fetch next from ������������cursor into @��������������������;
print '������������ ������: ' + @��������������������;
close ������������cursor;

deallocate �����������cursor;
deallocate ������������cursor;
go
declare @�������������������� nvarchar(50);
declare ������������cursor cursor scroll for 
select [�������� ������������] 
from ������������;

open ������������cursor;

fetch first from ������������cursor into @��������������������;
print '������ ������: ' + @��������������������;

fetch last from ������������cursor into @��������������������;
print '��������� ������: ' + @��������������������;

fetch absolute -1 from ������������cursor into @��������������������;
print '������������� ������: ' + @��������������������;

close ������������cursor;
deallocate ������������cursor;
go
declare @������������� int, @�������������������� nvarchar(50);

declare ��������cursor cursor for 
select [����� ��������], [�������� ������������] 
from ��������;

open ��������cursor;

fetch next from ��������cursor into @�������������, @��������������������;

while @@fetch_status = 0
begin
    if @������������� % 2 = 0
    begin
        update �������� set [�������� ������������] = [�������� ������������]+'(���������)' where current of ��������cursor;
    end
    else
    begin
        delete from �������� where current of ��������cursor;
    end;

    fetch next from ��������cursor into @�������������, @��������������������;
end;

close ��������cursor;
deallocate ��������cursor;
go