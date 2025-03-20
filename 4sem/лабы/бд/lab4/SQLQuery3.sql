use UNIVER

select ISNULL(teacher.TEACHER_NAME,'***')[ФИО преподавателя],
PULPIT.PULPIT
from PULPIT left outer join TEACHER on TEACHER.PULPIT = PULPIT.PULPIT;--задание 4

use ПРОДАЖИ

select * from ТОВАРЫ at full outer join ЗАКАЗЫ aa 
on aa.Наименование_товара = at.Наименование

use ПРОДАЖИ

select * from ЗАКАЗЫ at full outer join ТОВАРЫ aa 
on aa.Наименование = at.Наименование_товара

use ПРОДАЖИ
select * from ТОВАРЫ full outer join ЗАКАЗЫ on ТОВАРЫ.Наименование = ЗАКАЗЫ.Наименование_товара
where ЗАКАЗЫ.Наименование_товара is null --5.1

select * from ЗАКАЗЫ full outer join ТОВАРЫ on ТОВАРЫ.Наименование = ЗАКАЗЫ.Наименование_товара
where ЗАКАЗЫ.Наименование_товара is null --5.2

select * from ЗАКАЗЧИКИ full outer join ЗАКАЗЫ on ЗАКАЗЧИКИ.Наименование_фирмы = ЗАКАЗЫ.Заказчик
where ЗАКАЗЧИКИ.Наименование_фирмы is not null and ЗАКАЗЫ.Заказчик is not null --5.3

