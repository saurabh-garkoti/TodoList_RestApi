1.dotnet ef migrations add InitialCreate
2.dotnet ef database update

3.CREATE TABLE Lists (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    DueDate DATETime,  
    IsActive BOOLEAN NOT NULL DEFAULT FALSE
);

4.INSERT INTO [listDB].[dbo].[Lists] (Name, category, IsActive)
VALUES 
('Item 1', 'Category 1', 1),
('Item 2', 'Category 2', 1),
('Item 3', 'Category 3', 0),
('Item 4', 'Category 1', 1),
('Item 5', 'Category 2', 0),
('Item 6', 'Category 3', 1),
('Item 7', 'Category 1', 1),
('Item 8', 'Category 2', 0),
('Item 9', 'Category 3', 1),
('Item 10', 'Category 1', 1);

 5.  EXEC sp_rename 'listDB.dbo.Lists.IsActive', 'IsCompleted', 'COLUMN';

6.ALTER TABLE listDB.dbo.Lists
ALTER COLUMN IsCompleted BIT;
7.SELECT TOP (1000) [ID]
      ,[Title]
      ,[Description]
      ,[IsCompleted]
      ,[DueDate]
  FROM [listDB].[dbo].[Lists]


