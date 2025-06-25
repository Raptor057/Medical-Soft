-- Vista de Ventas por Día
CREATE VIEW VentasPorDia AS
SELECT 
    CAST(FechaHora AS DATE) AS Fecha,
    COUNT(VentaID) AS TotalVentas,
    SUM(Total) AS TotalVendido
FROM Ventas
GROUP BY CAST(FechaHora AS DATE);
