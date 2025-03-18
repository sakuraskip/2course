ALTER table Ответственные add Пол nchar(7) default 'мужской' check (Пол in('мужской','женский'));

alter table Ответственные drop column Пол;

--задание 3

