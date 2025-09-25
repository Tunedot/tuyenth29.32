
IF DB_ID(N'StudentManagerDB') IS NULL
BEGIN
    CREATE DATABASE StudentManagerDB;
END
GO

USE StudentManagerDB;
GO


IF OBJECT_ID(N'dbo.Students', N'U') IS NOT NULL
    DROP TABLE dbo.Students;
GO

CREATE TABLE dbo.Students
(
    StudentId      NVARCHAR(20)  NOT NULL PRIMARY KEY,
    FullName       NVARCHAR(120) NOT NULL,
    Gender         NVARCHAR(10)  NOT NULL CHECK (Gender IN (N'Nam', N'Nữ', N'Khác')),
    Class          NVARCHAR(50)  NOT NULL,
    BirthDate      DATE          NOT NULL CHECK (BirthDate >= '1900-01-01' AND BirthDate <= CAST(GETDATE() AS DATE)),
    CreatedAt      DATETIME2(0)  NOT NULL CONSTRAINT DF_Students_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt      DATETIME2(0)  NOT NULL CONSTRAINT DF_Students_UpdatedAt DEFAULT SYSUTCDATETIME()
);
GO


CREATE INDEX IX_Students_FullName ON dbo.Students(FullName);
CREATE INDEX IX_Students_Class ON dbo.Students(Class);
GO


IF OBJECT_ID(N'dbo.trg_Students_SetUpdatedAt', N'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_Students_SetUpdatedAt;
GO
CREATE TRIGGER dbo.trg_Students_SetUpdatedAt
ON dbo.Students
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE s
    SET UpdatedAt = SYSUTCDATETIME()
    FROM dbo.Students s
    JOIN inserted i ON s.StudentId = i.StudentId;
END;
GO


IF OBJECT_ID(N'dbo.sp_Student_Create', N'P') IS NOT NULL DROP PROCEDURE dbo.sp_Student_Create;
GO
CREATE PROC dbo.sp_Student_Create
    @StudentId NVARCHAR(20),
    @FullName  NVARCHAR(120),
    @Gender    NVARCHAR(10),
    @Class     NVARCHAR(50),
    @BirthDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Students(StudentId, FullName, Gender, Class, BirthDate)
    VALUES (@StudentId, @FullName, @Gender, @Class, @BirthDate);
END;
GO

IF OBJECT_ID(N'dbo.sp_Student_Update', N'P') IS NOT NULL DROP PROCEDURE dbo.sp_Student_Update;
GO
CREATE PROC dbo.sp_Student_Update
    @StudentId NVARCHAR(20),
    @FullName  NVARCHAR(120),
    @Gender    NVARCHAR(10),
    @Class     NVARCHAR(50),
    @BirthDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Students
    SET FullName = @FullName,
        Gender   = @Gender,
        Class    = @Class,
        BirthDate = @BirthDate
    WHERE StudentId = @StudentId;
END;
GO

IF OBJECT_ID(N'dbo.sp_Student_Delete', N'P') IS NOT NULL DROP PROCEDURE dbo.sp_Student_Delete;
GO
CREATE PROC dbo.sp_Student_Delete
    @StudentId NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Students WHERE StudentId = @StudentId;
END;
GO

IF OBJECT_ID(N'dbo.sp_Student_GetById', N'P') IS NOT NULL DROP PROCEDURE dbo.sp_Student_GetById;
GO
CREATE PROC dbo.sp_Student_GetById
    @StudentId NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.Students WHERE StudentId = @StudentId;
END;
GO

IF OBJECT_ID(N'dbo.sp_Student_Search', N'P') IS NOT NULL DROP PROCEDURE dbo.sp_Student_Search;
GO
CREATE PROC dbo.sp_Student_Search
    @q NVARCHAR(200) = N'' 
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @pattern NVARCHAR(210) = N'%' + ISNULL(@q, N'') + N'%';
    SELECT *
    FROM dbo.Students
    WHERE @q = N''
       OR StudentId LIKE @pattern
       OR FullName  LIKE @pattern
       OR Gender    LIKE @pattern
       OR Class     LIKE @pattern
    ORDER BY FullName;
END;
GO


MERGE dbo.Students AS t
USING (VALUES
    (N'SV001', N'Nguyễn Văn A', N'Nam', N'CTK44', '2002-08-12'),
    (N'SV002', N'Trần Thị B',   N'Nữ',  N'CTK44', '2003-01-05'),
    (N'SV003', N'Lê Minh C',    N'Nam', N'QTKD01','2001-12-23')
) AS s(StudentId, FullName, Gender, Class, BirthDate)
ON (t.StudentId = s.StudentId)
WHEN NOT MATCHED THEN
    INSERT (StudentId, FullName, Gender, Class, BirthDate)
    VALUES (s.StudentId, s.FullName, s.Gender, s.Class, s.BirthDate);
GO


EXEC dbo.sp_Student_Search N'CTK';
GO
USE StudentManagerDB;
SELECT * FROM dbo.Students;

