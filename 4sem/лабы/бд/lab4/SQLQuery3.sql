use UNIVER

select ISNULL(teacher.TEACHER_NAME,'***')[��� �������������],
PULPIT.PULPIT
from PULPIT left outer join TEACHER on TEACHER.PULPIT = PULPIT.PULPIT;--������� 4

use �������

select * from ������ at full outer join ������ aa 
on aa.������������_������ = at.������������

use �������

select * from ������ at full outer join ������ aa 
on aa.������������ = at.������������_������

use �������
select * from ������ full outer join ������ on ������.������������ = ������.������������_������
where ������.������������_������ is null --5.1

select * from ������ full outer join ������ on ������.������������ = ������.������������_������
where ������.������������_������ is null --5.2

select * from ��������� full outer join ������ on ���������.������������_����� = ������.��������
where ���������.������������_����� is not null and ������.�������� is not null --5.3

