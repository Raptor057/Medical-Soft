CREATE VIEW DetalleDeVentas AS
SELECT 
    dv.VentaID,
    v.FechaHora,
    p.Nombre AS Producto,
    dv.Cantidad,
    dv.Subtotal,
    dv.IDPatient
FROM DetalleVentas dv
JOIN Ventas v ON dv.VentaID = v.VentaID
JOIN Productos p ON dv.ProductoID = p.ProductoID;
