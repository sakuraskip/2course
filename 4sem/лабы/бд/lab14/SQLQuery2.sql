use S_MyBase3
go
drop function fObor;
go

create function fObor(@param varchar(50)) returns int as
begin
declare @result int =0;

set @result = (select count(*) from ������������ � inner join �������� � 
on �.[�������� ������������] = �.[�������� ������������] where
�.[�������� ������������] like @param)
return @result;
end;
go
declare @pr int  = dbo.fObor('%������%');
print @pr

go


drop function ��������������3;
go
create function ��������������3()
returns nvarchar(max)
as
begin
    declare @��������� nvarchar(max) = '';
    declare @�����_�������� int, @�������� nvarchar(50), @���������� int, 
            @������� nvarchar(50), @���� date, @������������� varchar(50);

    declare ��������_������ cursor local for
    select c.[����� ��������],c.[�������� ������������],
	c.[���������� ���������� ������������],c.[������� ��������],c.[���� ��������],o.[��� ������������] from ������������ o inner join �������� c on
    o.[�������� ������������] = c.[�������� ������������]
    where [���������� ���������� ������������] > 3;

    open ��������_������;
    fetch next from ��������_������ into @�����_��������, @��������, @����������, @�������, @����, @�������������;
    
    while @@fetch_status = 0
    begin
        set @��������� = @��������� + 
            cast(@�����_�������� as varchar)+ ': ' +
            @�������� + ' '+ cast(@���������� as varchar(50)) + ' ��.' +
            '�������: ' + @������� + 
           + ' ��� ������������: ' + 
            @�������������;
        
        fetch next from ��������_������ into @�����_��������, @��������, @����������, @�������, @����, @�������������;
    end;

    close ��������_������;
    deallocate ��������_������;
    
    return @���������;
end;
go

print dbo.��������������3();
--task3
go
drop function task3
go
create function task3(@name varchar(50)) returns table
as
return(
select * from ������������ where ������������.[�������� ������������] = isnull(@name,������������.[�������� ������������]))
go
select * from dbo.task3('����-�����')
go

--task4
drop function task4
go
create function task4(@type varchar(50)) returns int as
begin
declare @res int =0;
set @res = (select count(*) from ������������ where ������������.[��� ������������] like @type);
return @res;
end;
go
select dbo.task4('%��������%')[���-�� ��������� ������������]
