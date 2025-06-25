-- Vista de Ventas por Día
CREATE VIEW VentasPorDia AS
SELECT 
    DATE(FechaHora) AS Fecha,
    COUNT(VentaID) AS TotalVentas,
    SUM(Total) AS TotalVendido
FROM Ventas
GROUP BY DATE(FechaHora);