CREATE TABLE [dbo].[Feedback]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TeamId] int NOT NULL, 
    [SprintEnd] date NOT NULL, 
    [Value] int NOT NULL, 
    [Compared] int NOT NULL, 
    [CreatedDate] date NOT NULL, 
    [CreatedUser] varchar(100) NOT NULL,
    [UpdatedDate] date NOT NULL, 
    [UpdatedUser] varchar(100) NOT NULL
)
