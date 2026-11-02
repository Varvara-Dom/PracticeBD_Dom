## Task 1. Создание базы и таблиц
### Вывод
Создала все таблицы, как по заданию - 4 шт.

## Task 2. INSERT: заполнение данными
### Вывод
Заполнила все таблицы снова по заданию.

## Task 3. SELECT + WHERE
### SQL
```sql
SELECT * FROM Employees WHERE Salary > 50000;
-- Таблица 1 --
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId
1	Анна Иванова	65000.00	2020-03-15	1	NULL
2	Пётр Сидоров	72000.00	2019-07-01	1	NULL
3	Мария Кузнецова	55000.00	2021-11-20	1	2
5	Ольга Смирнова	61000.00	2020-09-05	2	NULL
6	Дмитрий Орлов	58000.00	2022-04-18	2	5
7	Елена Волкова	52000.00	2023-06-01	2	NULL
10	Алексей Лебедев	90000.00	2018-05-25	4	NULL

SELECT * FROM Employees WHERE YEAR(HireDate) = 2023;
-- Таблица 2 --
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId
4	Иван Петров	48000.00	2023-02-10	1	1
7	Елена Волкова	52000.00	2023-06-01	2	NULL

SELECT * FROM Employees WHERE EmployeeName LIKE N'А%';
-- Таблица 3 --
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId
1	Анна Иванова	65000.00	2020-03-15	1	NULL
10	Алексей Лебедев	90000.00	2018-05-25	4	NULL

SELECT * FROM Employees WHERE DepartmentId = 2;
-- Таблица 4 --
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId
5	Ольга Смирнова	61000.00	2020-09-05	2	NULL
6	Дмитрий Орлов	58000.00	2022-04-18	2	5
7	Елена Волкова	52000.00	2023-06-01	2	NULL

SELECT * FROM Employees WHERE Salary BETWEEN 40000 AND 60000;
-- Таблица 5 --
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId
3	Мария Кузнецова	55000.00	2021-11-20	1	2
4	Иван Петров	48000.00	2023-02-10	1	1
6	Дмитрий Орлов	58000.00	2022-04-18	2	5
7	Елена Волкова	52000.00	2023-06-01	2	NULL
8	Сергей Морозов	45000.00	2021-12-12	3	NULL
9	Наталья Соколова	43000.00	2024-01-15	3	10
### Вывод
Запросы работают, но чтобы использовать русс. язык через like, нужно ставить букву n перед строкой.

## Task 4. ORDER BY + TOP
### SQL
```sql
SELECT TOP 3 EmployeeName, Salary
FROM Employees
ORDER BY Salary DESC;
-- Топ-3 по зарплате --
EmployeeName	Salary
Алексей Лебедев	90000.00
Пётр Сидоров	72000.00
Анна Иванова	65000.00

SELECT TOP 5 EmployeeName, HireDate
FROM Employees
ORDER BY HireDate ASC;
-- Топ-5 самых давних сотрудников --
EmployeeName	HireDate
Алексей Лебедев	2018-05-25
Пётр Сидоров	2019-07-01
Анна Иванова	2020-03-15
Ольга Смирнова	2020-09-05
Мария Кузнецова	2021-11-20

SELECT EmployeeName, DepartmentId, Salary
FROM Employees
ORDER BY DepartmentId ASC, Salary DESC;
-- Сотрудники, отсортированные по отделу, по зарплате --
EmployeeName	DepartmentId	Salary
Пётр Сидоров	1	72000.00
Анна Иванова	1	65000.00
Мария Кузнецова	1	55000.00
Иван Петров	1	48000.00
Ольга Смирнова	2	61000.00
Дмитрий Орлов	2	58000.00
Елена Волкова	2	52000.00
Сергей Морозов	3	45000.00
Наталья Соколова	3	43000.00
Алексей Лебедев	4	90000.00
### Вывод
Работает (но TOP без ORDER BY может выводить строки в случайном порядке).

## Task 5. COUNT, SUM, AVG, MIN и MAX
### SQL
```sql
SELECT COUNT(*) AS TotalEmployees FROM Employees;
-- Общее количество сотрудников --
TotalEmployees
10

SELECT SUM(Salary) AS TotalSalary FROM Employees;
-- Сумма всех зарплат  --
TotalSalary
589000.00

SELECT ROUND(AVG(Salary), 2) AS AvgSalary FROM Employees;
-- Средняя зарплата --
AvgSalary
58900.000000

SELECT MIN(Salary) AS MinSalary, MAX(Salary) AS MaxSalary FROM Employees;
-- Минимальная и максимальная зарплата --
MinSalary	MaxSalary
43000.00	90000.00

SELECT COUNT(*) AS HighPaidCount FROM Employees WHERE Salary > 50000;
-- Количество сотрудников с зарплатой > 50000 --
HighPaidCount
7
### Вывод
Снова всё работает.

## Task 6. GROUP BY: статистика по отделам
### SQL
```sql
SELECT 
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    ROUND(AVG(Salary), 2) AS AvgSalary,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AvgSalary DESC;

DepartmentId	EmployeeCount	AvgSalary	TotalSalary
4	1	90000.000000	90000.00
1	4	60000.000000	240000.00
2	3	57000.000000	171000.00
3	2	44000.000000	88000.00
### Вывод
Работает + если использовать GROUP BY, то в SELECT можно выводить только те колонки, по которым идет группировка и функции.

## Task 7. GROUP BY + HAVING: фильтрация групп
### SQL
```sql
SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2;
-- Отделы, в которых больше 2 сотрудников --
DepartmentId	EmployeeCount
1	4
2	3

SELECT DepartmentId, ROUND(AVG(Salary), 2) AS AvgSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000;
-- Отделы со средней зарплатой > 55000 --
DepartmentId	AvgSalary
1	60000.000000
2	57000.000000
4	90000.000000

SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000;
-- Отделы, где суммарная зарплата > 150000 --
DepartmentId	TotalSalary
1	240000.00
2	171000.00
### Вывод
Работает + WHERE фильтрует строки до группировки, а HAVING — уже сгруппированные данные

## Task 8. INNER JOIN: сотрудники и отделы
### SQL
```sql
SELECT 
    e.EmployeeName, 
    d.DepartmentName, 
    e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName ASC, e.Salary DESC;
-- сотрудники + отделы
EmployeeName	DepartmentName	Salary
Ольга Смирнова	Аналитика	61000.00
Дмитрий Орлов	Аналитика	58000.00
Елена Волкова	Аналитика	52000.00
Алексей Лебедев	Менеджмент	90000.00
Пётр Сидоров	Разработка	72000.00
Анна Иванова	Разработка	65000.00
Мария Кузнецова	Разработка	55000.00
Иван Петров	Разработка	48000.00
Сергей Морозов	Тестирование	45000.00
Наталья Соколова	Тестирование	43000.00
### Вывод
Смогла объединить таблицы.

## Task 9. LEFT JOIN: сотрудники без проектов
### SQL
```sql
SELECT 
    e.EmployeeId, 
    e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON ep.EmployeeId = e.EmployeeId
WHERE ep.EmployeeId IS NULL;
-- сотрудники, не назначенные ни на один проект
EmployeeId	EmployeeName
9	Наталья Соколова
### Вывод
Работает +  LEFT JOIN и IS NULL - способ найти записи, у которых нет связей в другой таблице

## Task 10. Множественный JOIN: сотрудники, отделы, проекты
### SQL
```sql
SELECT 
    e.EmployeeName, 
    d.DepartmentName, 
    p.ProjectName, 
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON d.DepartmentId = e.DepartmentId
INNER JOIN EmployeeProjects ep ON ep.EmployeeId = e.EmployeeId
INNER JOIN Projects p ON p.ProjectId = ep.ProjectId
ORDER BY d.DepartmentName ASC, e.EmployeeName ASC, p.ProjectName ASC;
-- назначения
EmployeeName	DepartmentName	ProjectName	Hours
Дмитрий Орлов	Аналитика	AI Assistant	50
Дмитрий Орлов	Аналитика	Data Warehouse	70
Елена Волкова	Аналитика	Mobile App	95
Ольга Смирнова	Аналитика	Data Warehouse	110
Алексей Лебедев	Менеджмент	AI Assistant	200
Алексей Лебедев	Менеджмент	CRM System	30
Анна Иванова	Разработка	CRM System	120
Анна Иванова	Разработка	Data Warehouse	80
Иван Петров	Разработка	Legacy Refactor	40
Иван Петров	Разработка	Mobile App	90
Мария Кузнецова	Разработка	Mobile App	100
Пётр Сидоров	Разработка	AI Assistant	60
Пётр Сидоров	Разработка	CRM System	150
Сергей Морозов	Тестирование	Legacy Refactor	130
### Вывод
Вроде получилось, хоть и не сразу.

## Task 11. Self-join: иерархия руководителей
### SQL
```sql
SELECT 
    e.EmployeeName, 
    m.EmployeeName AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerId = m.EmployeeId;
-- Вывести сотрудника и имя его руководителя --
EmployeeName	ManagerName
Анна Иванова	NULL
Пётр Сидоров	NULL
Мария Кузнецова	Пётр Сидоров
Иван Петров	Анна Иванова
Ольга Смирнова	NULL
Дмитрий Орлов	Ольга Смирнова
Елена Волкова	NULL
Сергей Морозов	NULL
Наталья Соколова	Алексей Лебедев
Алексей Лебедев	NULL
### Вывод
Тоже получилось, но было сложно

## Task 12. Подзапросы в WHERE
### SQL
```sql
SELECT EmployeeName, Salary 
FROM Employees 
WHERE Salary > (SELECT AVG(Salary) FROM Employees);
-- Сотрудник с зарплатой выше средней. --
EmployeeName	Salary
Анна Иванова	65000.00
Пётр Сидоров	72000.00
Ольга Смирнова	61000.00
Алексей Лебедев	90000.00

SELECT EmployeeName, Salary 
FROM Employees 
WHERE Salary = (SELECT MAX(Salary) FROM Employees);
-- Сотрудник с максимальной зарплатой (доп.) --
EmployeeName	Salary
Алексей Лебедев	90000.00
### Вывод
Разобралсь с вложенными запросами + сначала внутренний SELECT, а затем внешний

## Task 13. Скалярные подзапросы в SELECT
### SQL
```sql
SELECT 
    EmployeeName, 
    Salary, 
    DepartmentId,
    ROUND(Salary - (SELECT AVG(Salary) FROM Employees e2 WHERE e2.DepartmentId = e.DepartmentId), 2) AS DiffFromAvg
FROM Employees e;
-- Зарплата и отклонение от средней по отделу --
EmployeeName	Salary	DepartmentId	DiffFromAvg
Анна Иванова	65000.00	1	5000.000000
Пётр Сидоров	72000.00	1	12000.000000
Мария Кузнецова	55000.00	1	-5000.000000
Иван Петров	48000.00	1	-12000.000000
Ольга Смирнова	61000.00	2	4000.000000
Дмитрий Орлов	58000.00	2	1000.000000
Елена Волкова	52000.00	2	-5000.000000
Сергей Морозов	45000.00	3	1000.000000
Наталья Соколова	43000.00	3	-1000.000000
Алексей Лебедев	90000.00	4	0.000000
### Вывод
Разбиралась со скалярными запросами.

## Task 14. EXISTS / NOT EXISTS
### SQL
```sql
SELECT EmployeeName 
FROM Employees e
WHERE EXISTS (
    SELECT 1 FROM EmployeeProjects ep WHERE ep.EmployeeId = e.EmployeeId
);
-- Сотрудники, у которых есть хотя бы один проект --
EmployeeName
Анна Иванова
Пётр Сидоров
Мария Кузнецова
Иван Петров
Ольга Смирнова
Дмитрий Орлов
Елена Волкова
Сергей Морозов
Алексей Лебедев

SELECT EmployeeName 
FROM Employees e
WHERE NOT EXISTS (
    SELECT 1 FROM EmployeeProjects ep WHERE ep.EmployeeId = e.EmployeeId
);
-- Сотрудники, у которых нет проектов --
EmployeeName
Наталья Соколова
### Вывод
Познакмилась со exists, как альтернатива join.

## Task 15. UNION / UNION ALL
### SQL
```sql
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE Salary > 60000
UNION
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE YEAR(HireDate) < 2022;
-- Сотрудники с зарплатой > 60000 + UNION (без дубликатов) --
EmployeeName	Salary	HireDate
Алексей Лебедев	90000.00	2018-05-25
Анна Иванова	65000.00	2020-03-15
Мария Кузнецова	55000.00	2021-11-20
Ольга Смирнова	61000.00	2020-09-05
Пётр Сидоров	72000.00	2019-07-01
Сергей Морозов	45000.00	2021-12-12

SELECT EmployeeName, Salary, HireDate FROM Employees WHERE Salary > 60000
UNION ALL
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE YEAR(HireDate) < 2022;
-- Сотрудники, нанятые до 2022 года + UNION ALL (с дубликатами) --
EmployeeName	Salary	HireDate
Анна Иванова	65000.00	2020-03-15
Пётр Сидоров	72000.00	2019-07-01
Ольга Смирнова	61000.00	2020-09-05
Алексей Лебедев	90000.00	2018-05-25
Анна Иванова	65000.00	2020-03-15
Пётр Сидоров	72000.00	2019-07-01
Мария Кузнецова	55000.00	2021-11-20
Ольга Смирнова	61000.00	2020-09-05
Сергей Морозов	45000.00	2021-12-12
Алексей Лебедев	90000.00	2018-05-25
### Вывод
Разбиралась, что UNION схлопывает дубликаты, а UNION ALL выводит всё подряд.

## Task 16. UPDATE: изменение данных
### SQL
``` sql
-- 16.1 Увеличить зарплату всех сотрудников отдела 1 на 10% --
SELECT EmployeeId, EmployeeName, DepartmentId, Salary FROM Employees WHERE DepartmentId = 1;
-- Изначально --
EmployeeId	EmployeeName	DepartmentId	Salary
1	Анна Иванова	1	65000.00
2	Пётр Сидоров	1	72000.00
3	Мария Кузнецова	1	55000.00
4	Иван Петров	1	48000.00

UPDATE Employees 
SET Salary = Salary * 1.1 
WHERE DepartmentId = 1;

SELECT EmployeeId, EmployeeName, DepartmentId, Salary FROM Employees WHERE DepartmentId = 1;
-- Потом --
EmployeeId	EmployeeName	DepartmentId	Salary
1	Анна Иванова	1	71500.00
2	Пётр Сидоров	1	79200.00
3	Мария Кузнецова	1	60500.00
4	Иван Петров	1	52800.00

-- 16.2 Увеличить зарплату сотрудников, нанятых до 2022 года, на 5000 --
SELECT EmployeeName, HireDate, Salary FROM Employees WHERE HireDate < '2022-01-01';
-- Изначально --
EmployeeName	HireDate	Salary
Анна Иванова	2020-03-15	71500.00
Пётр Сидоров	2019-07-01	79200.00
Мария Кузнецова	2021-11-20	60500.00
Ольга Смирнова	2020-09-05	61000.00
Сергей Морозов	2021-12-12	45000.00
Алексей Лебедев	2018-05-25	90000.00

UPDATE Employees 
SET Salary = Salary + 5000 
WHERE HireDate < '2022-01-01';

SELECT EmployeeName, HireDate, Salary FROM Employees WHERE HireDate < '2022-01-01';
-- Потом --
EmployeeName	HireDate	Salary
Анна Иванова	2020-03-15	76500.00
Пётр Сидоров	2019-07-01	84200.00
Мария Кузнецова	2021-11-20	65500.00
Ольга Смирнова	2020-09-05	66000.00
Сергей Морозов	2021-12-12	50000.00
Алексей Лебедев	2018-05-25	95000.00

-- 16.3 Обновить HireDate одного сотрудника --
SELECT EmployeeId, EmployeeName, HireDate FROM Employees WHERE EmployeeId = 1;
-- ИЗначально --
EmployeeId	EmployeeName	HireDate
1	Анна Иванова	2020-03-15

UPDATE Employees 
SET HireDate = '2023-05-01' 
WHERE EmployeeId = 1;

SELECT EmployeeId, EmployeeName, HireDate FROM Employees WHERE EmployeeId = 1;
-- Потом --
EmployeeId	EmployeeName	HireDate
1	Анна Иванова	2023-05-01
### Вывод
Тяжеловато, но справилась. 

## Task 17. DELETE: удаление данных
### SQL
```sql
-- 17.1 Удалить назначения на проект с Hours = 0 --
SELECT COUNT(*) FROM EmployeeProjects WHERE Hours = 0;
-- Изначально --
(Отсутствует имя столбца)
0

DELETE FROM EmployeeProjects WHERE Hours = 0;

SELECT COUNT(*) FROM EmployeeProjects WHERE Hours = 0;
-- Потом --
(Отсутствует имя столбца)
0

-- 17.2 Удалить сотрудника по EmployeeId --
SELECT * FROM Employees WHERE EmployeeId = 8;
-- Изначально --
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId
8	Сергей Морозов	50000.00	2021-12-12	3	NULL

DELETE FROM EmployeeProjects WHERE EmployeeId = 8;
DELETE FROM Employees WHERE EmployeeId = 8;

SELECT * FROM Employees WHERE EmployeeId = 8;
-- Потом --
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId

-- 17.3 Продемонстрировать DELETE с WHERE и без --
SELECT * INTO #TestTable FROM Employees;
-- Тестовая копия таблицы по заданию. --

SELECT COUNT(*) AS BeforeDelete FROM #TestTable;
-- Кол-во строк --
BeforeDelete
9

DELETE FROM #TestTable;

SELECT COUNT(*) AS AfterDelete FROM #TestTable;
-- Потом --
AfterDelete
0

DROP TABLE #TestTable;
-- Удаляем тестовую копию таблицы --
### Вывод
Было интересно поработать с удалёнными данными, тк был прикол с сотрудником, у которого есть проект

## Task 18. Транзакции: BEGIN TRAN / COMMIT / ROLLBACK
### SQL
```sql
-- 18.1 BEGIN TRANSACTION --
SELECT EmployeeName, Salary FROM Employees WHERE EmployeeId = 2;
-- Изначально --
EmployeeName	Salary
Пётр Сидоров	84200.00

BEGIN TRANSACTION;

UPDATE Employees SET Salary = 100000 WHERE EmployeeId = 2;
-- Смена зарплаты --

SELECT EmployeeName, Salary FROM Employees WHERE EmployeeId = 2;
-- Чек внутрь транзакции --
EmployeeName	Salary
Пётр Сидоров	100000.00

ROLLBACK TRANSACTION;
-- Откат --

SELECT EmployeeName, Salary FROM Employees WHERE EmployeeId = 2;
-- Потом, после отката --
EmployeeName	Salary
Пётр Сидоров	84200.00

-- 18.2 UPDATE зарплаты сотрудника --
BEGIN TRANSACTION;

UPDATE Employees SET Salary = 100000 WHERE EmployeeId = 2;
-- Смена зарплаты --

COMMIT TRANSACTION;
-- Сохранение --

SELECT EmployeeName, Salary FROM Employees WHERE EmployeeId = 2;
-- Проверяем --
EmployeeName	Salary
Пётр Сидоров	100000.00
### Вывод
Интересно работать с транзакциями)) 

## Task 19. Представления (VIEW)
### SQL
```sql
CREATE VIEW vw_EmployeeDetails AS
SELECT 
    e.EmployeeName, 
    d.DepartmentName, 
    p.ProjectName, 
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON d.DepartmentId = e.DepartmentId
INNER JOIN EmployeeProjects ep ON ep.EmployeeId = e.EmployeeId
INNER JOIN Projects p ON p.ProjectId = ep.ProjectId;
GO
-- Создаём представление --

SELECT * FROM vw_EmployeeDetails;
GO
-- Проверяем на работоспособность --
EmployeeName	DepartmentName	ProjectName	Hours
Анна Иванова	Разработка	CRM System	120
Анна Иванова	Разработка	Data Warehouse	80
Пётр Сидоров	Разработка	CRM System	150
Пётр Сидоров	Разработка	AI Assistant	60
Мария Кузнецова	Разработка	Mobile App	100
Иван Петров	Разработка	Mobile App	90
Иван Петров	Разработка	Legacy Refactor	40
Ольга Смирнова	Аналитика	Data Warehouse	110
Дмитрий Орлов	Аналитика	Data Warehouse	70
Дмитрий Орлов	Аналитика	AI Assistant	50
Елена Волкова	Аналитика	Mobile App	95
Алексей Лебедев	Менеджмент	CRM System	30
Алексей Лебедев	Менеджмент	AI Assistant	200

DROP VIEW vw_EmployeeDetails;
GO
-- Удаляеми представление --
### Вывод
Представление получились +  join сохраняет длинный запрос внутри себя, а drop view удаляет.

## Task 20. Индексы: создание и анализ
### SQL
```sql
-- 20.1 Создать индекс на Employees(DepartmentId) --
SET STATISTICS IO ON;
GO

SELECT * FROM Employees WHERE DepartmentId = 1 AND Salary > 50000;
GO

-- 20.2 Создать индекс на Employees(Salary) --
CREATE INDEX IX_Employees_DepartmentId ON Employees(DepartmentId);
CREATE INDEX IX_Employees_Salary ON Employees(Salary);
GO

-- 20.3 Выполнить WHERE DepartmentId = 1 AND Salary > 50000 до и после --
SELECT * FROM Employees WHERE DepartmentId = 1 AND Salary > 50000;
GO
EmployeeId	EmployeeName	Salary	HireDate	DepartmentId	ManagerId
1	Анна Иванова	76500.00	2023-05-01	1	NULL
2	Пётр Сидоров	100000.00	2019-07-01	1	NULL
3	Мария Кузнецова	65500.00	2021-11-20	1	2
4	Иван Петров	52800.00	2023-02-10	1	1

-- 20.4 Включить SET STATISTICS IO ON и сравнить logical reads --
SET STATISTICS IO OFF;
GO
### Вывод
Ну-с, пойдёт..

## Task 21. Хранимые процедуры
### SQL
```sql
-- 21.1 ..сотрудников отдела --
DROP PROCEDURE IF EXISTS sp_GetEmployeesByDepartment;
DROP PROCEDURE IF EXISTS sp_GetAvgSalaryByDept;
GO
-- Перестраховываемся --

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DeptId INT
AS
BEGIN
    SELECT EmployeeName, Salary, HireDate
    FROM Employees
    WHERE DepartmentId = @DeptId;
END;
GO
-- С входным параметром --

CREATE PROCEDURE sp_GetAvgSalaryByDept
    @DeptId INT,
    @AvgSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @AvgSalary = AVG(Salary)
    FROM Employees
    WHERE DepartmentId = @DeptId;
END;
GO
-- OUTPUT-параметр --

-- 21.2 Вызвать:.. --
EXEC sp_GetEmployeesByDepartment @DeptId = 1;
-- Вызываем первую --
EmployeeName	Salary	HireDate
Анна Иванова	76500.00	2023-05-01
Пётр Сидоров	100000.00	2019-07-01
Мария Кузнецова	65500.00	2021-11-20
Иван Петров	52800.00	2023-02-10

DECLARE @MyAvg DECIMAL(10,2);
EXEC sp_GetAvgSalaryByDept @DeptId = 1, @AvgSalary = @MyAvg OUTPUT;
SELECT @MyAvg AS AverageSalary_Dept1;
-- Вызываем вторую --
AverageSalary_Dept1
73700.00
### Вывод
Получилось включить SET STATISTICS IO ON и сравнить logical reads + можно передавать параметры и возвращать значения через OUTPUT

## Task 22. Функции: скалярная и табличная
### SQL
```sql
DROP FUNCTION IF EXISTS fn_GetAnnualSalary;
DROP FUNCTION IF EXISTS fn_GetEmployeesBySalaryRange;
GO
-- Удалили то, что сделали в 21 задании --

CREATE FUNCTION fn_GetAnnualSalary (@MonthlySalary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @MonthlySalary * 12;
END;
GO
-- Функция скалярная --

CREATE FUNCTION fn_GetEmployeesBySalaryRange (@Min DECIMAL(10,2), @Max DECIMAL(10,2))
RETURNS TABLE
AS
RETURN (
    SELECT EmployeeName, Salary 
    FROM Employees 
    WHERE Salary BETWEEN @Min AND @Max
);
GO
-- Функция табличная --

-- Сам вызов --
SELECT EmployeeName, Salary, dbo.fn_GetAnnualSalary(Salary) AS AnnualSalary
FROM Employees;
-- Скалярная в SELECT --
EmployeeName	Salary	AnnualSalary
Анна Иванова	76500.00	918000.00
Пётр Сидоров	100000.00	1200000.00
Мария Кузнецова	65500.00	786000.00
Иван Петров	52800.00	633600.00
Ольга Смирнова	66000.00	792000.00
Дмитрий Орлов	58000.00	696000.00
Елена Волкова	52000.00	624000.00
Наталья Соколова	43000.00	516000.00
Алексей Лебедев	95000.00	1140000.00

SELECT * FROM dbo.fn_GetEmployeesBySalaryRange(50000, 70000);
-- Табличная в FROM --
EmployeeName	Salary
Мария Кузнецова	65500.00
Иван Петров	52800.00
Ольга Смирнова	66000.00
Дмитрий Орлов	58000.00
Елена Волкова	52000.00
### Вывод
Синтаксис был сложноват, но запомнила, что скалярная работает внутри select, а табличная  в from.

## Task 23. Оконные функции: ROW_NUMBER, RANK, DENSE_RANK
### SQL
```sql
SELECT 
    EmployeeName, 
    DepartmentId, 
    Salary,
    ROW_NUMBER() OVER (ORDER BY Salary DESC) AS RowNum,
    -- Сквозная нумерация всех сотрудников по убыванию зарплаты --

    -- Ранкирование внутри отделов --
    RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rnk,
    -- RANK пропускает числа при равной зарплате --
    
    DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS DenseRnk
    -- DENSE_RANK не пропускает числа при равной зарплате --
FROM Employees;
-- Табличка --
EmployeeName	DepartmentId	Salary	RowNum	Rnk	DenseRnk
Пётр Сидоров	1	100000.00	1	1	1
Анна Иванова	1	76500.00	3	2	2
Мария Кузнецова	1	65500.00	5	3	3
Иван Петров	1	52800.00	7	4	4
Ольга Смирнова	2	66000.00	4	1	1
Дмитрий Орлов	2	58000.00	6	2	2
Елена Волкова	2	52000.00	8	3	3
Наталья Соколова	3	43000.00	9	1	1
Алексей Лебедев	4	95000.00	2	1	1
### Вывод
Поняла различие в работе rank и dense rank, постараюсь запомнить.

## Task 24. Оконные агрегаты: SUM OVER, AVG OVER
### SQL
```sql
SELECT 
    EmployeeName, 
    DepartmentId, 
    Salary,
    SUM(Salary) OVER (PARTITION BY DepartmentId) AS DeptTotalSalary,
    -- Зарплата для каждого сотрудника --
    
    AVG(Salary) OVER (PARTITION BY DepartmentId) AS DeptAvgSalary,
    -- Средняя зарплата для каждого сотрудника по отделу --
    
    ROUND(Salary - AVG(Salary) OVER (PARTITION BY DepartmentId), 2) AS DiffFromAvg
    -- Отклонение от средней --
FROM Employees;
-- Табличка --
EmployeeName	DepartmentId	Salary	DeptTotalSalary	DeptAvgSalary	DiffFromAvg
Анна Иванова	1	76500.00	294800.00	73700.000000	2800.000000
Пётр Сидоров	1	100000.00	294800.00	73700.000000	26300.000000
Мария Кузнецова	1	65500.00	294800.00	73700.000000	-8200.000000
Иван Петров	1	52800.00	294800.00	73700.000000	-20900.000000
Ольга Смирнова	2	66000.00	176000.00	58666.666666	7333.330000
Дмитрий Орлов	2	58000.00	176000.00	58666.666666	-666.670000
Елена Волкова	2	52000.00	176000.00	58666.666666	-6666.670000
Наталья Соколова	3	43000.00	43000.00	43000.000000	0.000000
Алексей Лебедев	4	95000.00	95000.00	95000.000000	0.000000
### Вывод
Познакомилась с OVER (PARTITION BY ..) и её функционалом --

## Task 25. CTE (Common Table Expressions)
### SQL
```sql
WITH AvgSalary AS (
    SELECT AVG(Salary) AS AvgSal FROM Employees
)
SELECT e.EmployeeName, e.Salary
FROM Employees e
CROSS JOIN AvgSalary a
WHERE e.Salary > a.AvgSal;
-- Как в task12 --
EmployeeName	Salary
Анна Иванова	76500.00
Алексей Лебедев	95000.00
Пётр Сидоров	100000.00

WITH DeptAvg AS (
    SELECT DepartmentId, AVG(Salary) AS AvgSalary
    FROM Employees
    GROUP BY DepartmentId
)
SELECT TOP 3 d.DepartmentName, ROUND(da.AvgSalary, 2) AS AvgSalary
FROM DeptAvg da
JOIN Departments d ON d.DepartmentId = da.DepartmentId
ORDER BY da.AvgSalary DESC;
-- Доп: топ-3 отделов по средней зарплате --
DepartmentName	AvgSalary
Менеджмент	95000.000000
Разработка	73700.000000
Аналитика	58666.670000
### Вывод
Если сравнивать с таском 12, то сейчас было делать посложнее

## Task 26. CASE: условная логика в SELECT
### SQL
```sql
SELECT 
    EmployeeName, 
    Salary,    
    CASE 
        WHEN Salary > 60000 THEN 'High'
        WHEN Salary BETWEEN 40000 AND 60000 THEN 'Medium'
        ELSE 'Low'
    END AS SalaryLevel,
    -- Оцениваем зарплату --

    HireDate,    
    CASE 
        WHEN YEAR(HireDate) < 2020 THEN 'Senior'
        WHEN YEAR(HireDate) BETWEEN 2020 AND 2022 THEN 'Mid'
        ELSE 'Junior'
    END AS Tenure
    -- Оцениваем стаж --
FROM Employees;
-- Табличка --
EmployeeName	Salary	SalaryLevel	HireDate	Tenure
Анна Иванова	76500.00	High	2023-05-01	Junior
Пётр Сидоров	100000.00	High	2019-07-01	Senior
Мария Кузнецова	65500.00	High	2021-11-20	Mid
Иван Петров	52800.00	Medium	2023-02-10	Junior
Ольга Смирнова	66000.00	High	2020-09-05	Mid
Дмитрий Орлов	58000.00	Medium	2022-04-18	Mid
Елена Волкова	52000.00	Medium	2023-06-01	Junior
Наталья Соколова	43000.00	Medium	2024-01-15	Junior
Алексей Лебедев	95000.00	High	2018-05-25	Senior
### Вывод
Буду знать, что case — это аналог if-else.

## Task 27. Работа с датами: DATEADD, DATEDIFF, FORMAT
### SQL
```sql
SELECT 
    EmployeeName, 
    HireDate,    
    DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsOfTenure,
    -- Полных лет стажа --
    
    DATEDIFF(MONTH, HireDate, GETDATE()) AS MonthsOfTenure,
    -- Количество месяцев стажа --
    
    DATEADD(YEAR, 1, HireDate) AS DateAfterOneYear,
    -- Дата через 1 год после найма --
    
    FORMAT(HireDate, 'dd.MM.yyyy') AS FormattedHireDate
    -- Форматированная дата найма --
FROM Employees;
-- Табличка --
EmployeeName	HireDate	YearsOfTenure	MonthsOfTenure	DateAfterOneYear	FormattedHireDate
Анна Иванова	2023-05-01	3	41	2024-05-01	01.05.2023
Пётр Сидоров	2019-07-01	7	87	2020-07-01	01.07.2019
Мария Кузнецова	2021-11-20	5	59	2022-11-20	20.11.2021
Иван Петров	2023-02-10	3	44	2024-02-10	10.02.2023
Ольга Смирнова	2020-09-05	6	73	2021-09-05	05.09.2020
Дмитрий Орлов	2022-04-18	4	54	2023-04-18	18.04.2022
Елена Волкова	2023-06-01	3	40	2024-06-01	01.06.2023
Наталья Соколова	2024-01-15	2	33	2025-01-15	15.01.2024
Алексей Лебедев	2018-05-25	8	101	2019-05-25	25.05.2018
### Вывод
Нравится работать с датами, получилось
