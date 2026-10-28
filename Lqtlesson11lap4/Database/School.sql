CREATE DATABASE School;
GO

USE School;
GO

CREATE TABLE [Major] (
    [MajorID] int IDENTITY(1,1) NOT NULL,
    [MajorName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Major] PRIMARY KEY ([MajorID])
);
GO

CREATE TABLE [Course] (
    [CourseID] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Credits] int NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([CourseID])
);
GO

CREATE TABLE [Learner] (
    [LearnerID] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [FirstMidName] nvarchar(max) NOT NULL,
    [EnrollmentDate] datetime2 NOT NULL,
    [MajorID] int NOT NULL,
    CONSTRAINT [PK_Learner] PRIMARY KEY ([LearnerID]),
    CONSTRAINT [FK_Learner_Major_MajorID] FOREIGN KEY ([MajorID]) REFERENCES [Major] ([MajorID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Enrollment] (
    [EnrollmentID] int IDENTITY(1,1) NOT NULL,
    [CourseID] int NOT NULL,
    [LearnerID] int NOT NULL,
    [Grade] real NOT NULL,
    CONSTRAINT [PK_Enrollment] PRIMARY KEY ([EnrollmentID]),
    CONSTRAINT [FK_Enrollment_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollment_Learner_LearnerID] FOREIGN KEY ([LearnerID]) REFERENCES [Learner] ([LearnerID]) ON DELETE CASCADE
);
GO

SET IDENTITY_INSERT [Major] ON;
INSERT INTO [Major] ([MajorID], [MajorName]) VALUES (1, N'IT');
INSERT INTO [Major] ([MajorID], [MajorName]) VALUES (2, N'Economics');
INSERT INTO [Major] ([MajorID], [MajorName]) VALUES (3, N'Mathematics');
SET IDENTITY_INSERT [Major] OFF;
GO

INSERT INTO [Course] ([CourseID], [Title], [Credits]) VALUES (1050, N'Chemistry', 3);
INSERT INTO [Course] ([CourseID], [Title], [Credits]) VALUES (4022, N'Microeconomics', 3);
INSERT INTO [Course] ([CourseID], [Title], [Credits]) VALUES (4041, N'Macroeconomics', 3);
GO

SET IDENTITY_INSERT [Learner] ON;
INSERT INTO [Learner] ([LearnerID], [LastName], [FirstMidName], [EnrollmentDate], [MajorID]) VALUES (1, N'Lê Quốc', N'Trường', '2005-09-01', 1);
INSERT INTO [Learner] ([LearnerID], [LastName], [FirstMidName], [EnrollmentDate], [MajorID]) VALUES (2, N'Nguyễn Hải', N'Nam', '2002-09-01', 2);
INSERT INTO [Learner] ([LearnerID], [LastName], [FirstMidName], [EnrollmentDate], [MajorID]) VALUES (3, N'Trần Minh', N'Tú', '2003-09-01', 1);
INSERT INTO [Learner] ([LearnerID], [LastName], [FirstMidName], [EnrollmentDate], [MajorID]) VALUES (4, N'Phạm Xuân', N'Mai', '2004-09-01', 3);
SET IDENTITY_INSERT [Learner] OFF;
GO

SET IDENTITY_INSERT [Enrollment] ON;
INSERT INTO [Enrollment] ([EnrollmentID], [CourseID], [LearnerID], [Grade]) VALUES (1, 1050, 1, 5.5);
INSERT INTO [Enrollment] ([EnrollmentID], [CourseID], [LearnerID], [Grade]) VALUES (2, 4022, 1, 7.5);
INSERT INTO [Enrollment] ([EnrollmentID], [CourseID], [LearnerID], [Grade]) VALUES (3, 1050, 2, 3.5);
INSERT INTO [Enrollment] ([EnrollmentID], [CourseID], [LearnerID], [Grade]) VALUES (4, 4041, 2, 7.0);
SET IDENTITY_INSERT [Enrollment] OFF;
GO
