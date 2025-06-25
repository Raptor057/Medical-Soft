DECLARE @TableName sysname = 'PatientData';  -- Reemplaza con el nombre de la tabla
DECLARE @Result NVARCHAR(MAX) = '';
DECLARE @CRLF NVARCHAR(2) = CHAR(13) + CHAR(10);

-- Encabezado de la clase
SET @Result = 'public class ' + @TableName + @CRLF +
'{' + @CRLF;

-- Genera las propiedades basándose en las columnas
;WITH ColumnInfo AS (
    SELECT 
         c.column_id,
         c.name AS ColumnName,
         t.name AS SqlType,
         CASE 
            WHEN t.name IN ('bigint') THEN 'long'
            WHEN t.name IN ('binary', 'image', 'varbinary') THEN 'byte[]'
            WHEN t.name IN ('bit') THEN 'bool'
            WHEN t.name IN ('char', 'nchar', 'ntext', 'nvarchar', 'text', 'varchar') THEN 'string'
            WHEN t.name IN ('date', 'datetime', 'datetime2', 'smalldatetime') THEN 'DateTime'
            WHEN t.name IN ('datetimeoffset') THEN 'DateTimeOffset'
            WHEN t.name IN ('decimal', 'money', 'numeric', 'smallmoney') THEN 'decimal'
            WHEN t.name IN ('float') THEN 'float'
            WHEN t.name IN ('int') THEN 'int'
            WHEN t.name IN ('real') THEN 'double'
            WHEN t.name IN ('smallint') THEN 'short'
            WHEN t.name IN ('time') THEN 'TimeSpan'
            WHEN t.name IN ('tinyint') THEN 'byte'
            WHEN t.name IN ('uniqueidentifier') THEN 'Guid'
            ELSE 'object'
         END AS ClrType,
         c.is_nullable
    FROM sys.columns c
    JOIN sys.types t ON c.user_type_id = t.user_type_id
    WHERE c.object_id = OBJECT_ID(@TableName)
)
SELECT @Result = @Result +
'    public ' + ClrType + 
    CASE WHEN is_nullable = 1 AND ClrType NOT IN ('string', 'byte[]') THEN '?' ELSE '' END +
    ' ' + ColumnName + ' { get; set; }' + @CRLF
FROM ColumnInfo
ORDER BY column_id;

-- Cierra la clase
SET @Result = @Result +
'}';

PRINT @Result;
