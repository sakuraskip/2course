ALTER table Ответственные add [Отчество ответственного] nvarchar(50);
ALTER table Ответственные add Пол nchar(7) default 'мужской' check (Пол in('мужской','женский'));