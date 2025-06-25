CREATE VIEW VentasPorDia AS
SELECT 
    CONVERT(DATE, FechaHora) AS Fecha,
    COUNT(VentaID) AS TotalVentas,
    SUM(Total) AS TotalVendido
FROM Ventas
GROUP BY CONVERT(DATE, FechaHora);
