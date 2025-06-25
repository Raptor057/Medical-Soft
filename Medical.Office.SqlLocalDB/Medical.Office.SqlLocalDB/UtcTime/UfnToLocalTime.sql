CREATE FUNCTION [dbo].[UfnToLocalTime](@utcTime DATETIME)
RETURNS DATETIME
AS BEGIN
    DECLARE @localTime AS DATETIME;
    SELECT @localTime = CAST(@utcTime AT TIME ZONE 'UTC' AT TIME ZONE TimeZone AS DATETIME) FROM GlobalSettings;
    RETURN @localTime;
END
