SELECT TOP (1000) [Id]
      ,[IDPatient]
      ,[FileName]
      ,[FileType]
      ,[FileExtension]
      ,[Description]
      --,[FileData]
      ,CONCAT(ROUND(SUM(CAST(DATALENGTH(FileData) AS FLOAT)) / 1048576, 2), ' MB') AS TotalSizeInMB
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles] 
  GROUP BY Id,
  [IDPatient]
      ,[FileName]
      ,[FileType]
      ,[FileExtension]
      ,[Description]

--TRUNCATE TABLE [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles]