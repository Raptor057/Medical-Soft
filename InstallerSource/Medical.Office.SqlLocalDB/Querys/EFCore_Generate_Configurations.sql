DECLARE @TableName sysname = 'ActiveMedications';  -- Reemplaza con el nombre de la tabla deseada
-- Asegúrate de que la tabla exista en la base de datos
SELECT @TableName = name FROM sys.tables WHERE name = @TableName;

DECLARE @CRLF NVARCHAR(2) = CHAR(13) + CHAR(10);

DECLARE @Result NVARCHAR(MAX) =
'using Microsoft.EntityFrameworkCore;' + @CRLF +
'using Microsoft.EntityFrameworkCore.Metadata.Builders;' + @CRLF +
'using WebApiMigracion.Entities;' + @CRLF + @CRLF +
'public class ' + @TableName + 'Configuration : IEntityTypeConfiguration<' + @TableName + '>' + @CRLF +
'{' + @CRLF +
'    public void Configure(EntityTypeBuilder<' + @TableName + '> builder)' + @CRLF +
'    {' + @CRLF +
'        builder.ToTable("' + @TableName + '");' + @CRLF;

-- Determinar la clave primaria (se asume la primera PK encontrada)
;WITH PrimaryKeyInfo AS (
    SELECT TOP 1 c.name AS ColumnName
    FROM sys.indexes i
    JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    JOIN sys.columns c ON ic.object_id = c.object_id AND c.column_id = ic.column_id
    WHERE i.object_id = OBJECT_ID(@TableName) AND i.is_primary_key = 1
    ORDER BY ic.key_ordinal
)
SELECT @Result = @Result + '        builder.HasKey(x => x.' + ColumnName + ');' + @CRLF
FROM PrimaryKeyInfo;

-- Generar la configuración de cada propiedad
;WITH ColumnData AS (
    SELECT 
         REPLACE(c.name, ' ', '_') AS ColumnName,
         c.column_id,
         t.name AS SqlType,
         c.is_nullable,
         c.max_length,
         c.precision,
         c.scale,
         dc.definition AS DefaultDefinition
    FROM sys.columns c
    JOIN sys.types t 
         ON c.system_type_id = t.system_type_id 
         AND c.user_type_id = t.user_type_id
    LEFT JOIN sys.default_constraints dc 
         ON c.default_object_id = dc.object_id
    WHERE c.object_id = OBJECT_ID(@TableName)
)
SELECT @Result = @Result + 
'        builder.Property(x => x.' + ColumnName + ')'
    + CASE WHEN is_nullable = 0 THEN '.IsRequired()' ELSE '' END
    + CASE 
         WHEN SqlType IN ('varchar','char','text') 
              THEN '.HasColumnType("VARCHAR(' + CASE WHEN max_length = -1 THEN 'MAX' ELSE CAST(max_length AS VARCHAR(10)) END + '")'
         WHEN SqlType IN ('nvarchar','nchar','ntext') 
              THEN '.HasColumnType("NVARCHAR(' + CASE WHEN max_length = -1 THEN 'MAX' ELSE CAST(max_length AS VARCHAR(10)) END + '")'
         ELSE ''
      END
    + CASE WHEN DefaultDefinition IS NOT NULL 
           THEN '.HasDefaultValueSql("' + 
                REPLACE(
                    CASE 
                        WHEN LEFT(DefaultDefinition,1) = '(' AND RIGHT(DefaultDefinition,1) = ')' 
                            THEN SUBSTRING(DefaultDefinition,2, LEN(DefaultDefinition)-2)
                        ELSE DefaultDefinition
                    END
                , '"', '\"') + '")'
           ELSE ''
      END
    + ';' + @CRLF
FROM ColumnData
ORDER BY column_id;

SET @Result = @Result +
'    }' + @CRLF +
'}' + @CRLF;

PRINT @Result;
