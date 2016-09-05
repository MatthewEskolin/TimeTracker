use TimeTracker
GO


DECLARE @tableName nvarchar(100)
DECLARE @primeColumnName nvarchar(200)
DECLARE @foreignColumnName nvarchar(200)
DECLARE @primeTableNAme nvarchar(200)

DECLARE @sqld varchar(3000)


SET @tableName = 'DJobItems'
SET @primeColumnName = 'DeveloperId'
SET @foreignColumnName = 'DeveloperId'
SET @primeTAbleName = 'DDevelopers'


SET @sqld = 'ALTER TABLE ' + @tableName + ' ADD CONSTRAINT FK_' + @tableName + '_' + @primeColumnName + ' FOREIGN KEY '+ '(' + @foreignColumnName + ')' +
 ' REFERENCES ' + @primeTableName + ' (' + @primeColumnName + ')'


PRINT @sqld

EXEC (@sqld)
