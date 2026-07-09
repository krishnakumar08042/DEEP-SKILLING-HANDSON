/* EXERCISE 5 : RETURN TOTAL EMPLOYEES */

CREATE PROCEDURE sp_TotalEmployees

@DepartmentID INT

AS

BEGIN

SELECT

COUNT(*) AS TotalEmployees

FROM Employees

WHERE DepartmentID = @DepartmentID;

END;


EXEC sp_TotalEmployees 1;


/* EXERCISE 6 : OUTPUT PARAMETERS */

CREATE PROCEDURE sp_TotalSalary

@DepartmentID INT,

@TotalSalary DECIMAL(10,2) OUTPUT

AS

BEGIN

SELECT

@TotalSalary = SUM(Salary)

FROM Employees

WHERE DepartmentID = @DepartmentID;

END;


DECLARE @Result DECIMAL(10,2);

EXEC sp_TotalSalary

1,

@Result OUTPUT;

SELECT @Result AS TotalSalary;


/* EXERCISE 7 : UPDATE EMPLOYEE SALARY */

CREATE PROCEDURE sp_UpdateEmployeeSalary

@EmployeeID INT,

@Salary DECIMAL(10,2)

AS

BEGIN

UPDATE Employees

SET Salary = @Salary

WHERE EmployeeID = @EmployeeID;

END;


EXEC sp_UpdateEmployeeSalary 1,5500.00;


/* EXERCISE 8 : GIVE BONUS */

CREATE PROCEDURE sp_GiveBonus

@DepartmentID INT,

@Bonus DECIMAL(10,2)

AS

BEGIN

UPDATE Employees

SET Salary = Salary + @Bonus

WHERE DepartmentID = @DepartmentID;

END;


EXEC sp_GiveBonus 1,500.00;


/* EXERCISE 9 : TRANSACTIONS */

CREATE PROCEDURE sp_UpdateSalaryTransaction

@EmployeeID INT,

@Salary DECIMAL(10,2)

AS

BEGIN

BEGIN TRY

BEGIN TRANSACTION;

UPDATE Employees

SET Salary = @Salary

WHERE EmployeeID = @EmployeeID;

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Transaction Failed';

END CATCH

END;


/* EXERCISE 10 : DYNAMIC SQL */

CREATE PROCEDURE sp_SearchEmployees

@FilterColumn VARCHAR(50),

@FilterValue VARCHAR(50)

AS

BEGIN

DECLARE @SQL NVARCHAR(MAX);

SET @SQL =

'SELECT *

FROM Employees

WHERE '

+ QUOTENAME(@FilterColumn)

+ ' = '''

+ @FilterValue

+ '''';

EXEC sp_executesql @SQL;

END;


EXEC sp_SearchEmployees 'FirstName','John';


/* EXERCISE 11 : ERROR HANDLING */

CREATE PROCEDURE sp_UpdateSalaryWithErrorHandling

@EmployeeID INT,

@Salary DECIMAL(10,2)

AS

BEGIN

BEGIN TRY

UPDATE Employees

SET Salary = @Salary

WHERE EmployeeID = @EmployeeID;

PRINT 'Salary Updated Successfully';

END TRY

BEGIN CATCH

PRINT 'Error Occurred';

PRINT ERROR_MESSAGE();

END CATCH

END;


EXEC sp_UpdateSalaryWithErrorHandling 1,6500;