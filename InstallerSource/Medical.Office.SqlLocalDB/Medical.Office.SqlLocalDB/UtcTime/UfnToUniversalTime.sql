CREATE FUNCTION [dbo].[UfnToUniversalTime](@utcTime DATETIME)
RETURNS DATETIME
AS BEGIN
    DECLARE @localTime AS DATETIME;
    SELECT @localTime = CAST(@utcTime AT TIME ZONE TimeZone AT TIME ZONE 'UTC' AS DATETIME) FROM GlobalSettings;
    RETURN @localTime;
END
