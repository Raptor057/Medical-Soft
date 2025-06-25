using Medical.Office.Domain.Entities.ExpressPos;
using Medical.Office.Domain.Entities.ExpressPos.Views;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources;

public class ExpressPossSqlDb
{
    private readonly ConfigurationSqlDbConnection<ExpressPossSqlDb> _con;
    private readonly ILogger<ExpressPossSqlDb> _logger;

    public ExpressPossSqlDb(ILogger<ExpressPossSqlDb> logger,ConfigurationSqlDbConnection<ExpressPossSqlDb> con)
    {
        _con = con;
        _logger = logger;
    }
    
    
/// <summary>
/// Implementación de operaciones relacionadas con los productos.
/// </summary>
public async Task AgregarProducto(Productos producto)
{
    await _con.ExecuteAsync(
        "INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock)",
        new { producto.Nombre, producto.Precio, producto.Stock }).ConfigureAwait(false);
}

public async Task ActualizarProducto(Productos producto)
{
    await _con.ExecuteAsync(
        "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock WHERE ProductoID = @ProductoID",
        new { producto.ProductoID, producto.Nombre, producto.Precio, producto.Stock }).ConfigureAwait(false);
}

public async Task EliminarProducto(Productos producto)
{
    await _con.ExecuteAsync(
        "DELETE FROM Productos WHERE ProductoID = @ProductoID",
        new { producto.ProductoID }).ConfigureAwait(false);
}

public async Task<Productos> ObtenerProductoPorId(int productoId)
{
    return await _con.QuerySingleAsync<Productos>(
        "SELECT * FROM Productos WHERE ProductoID = @ProductoID",
        new { ProductoID = productoId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Productos>> ObtenerTodosLosProductos()
{
    return await _con.QueryAsync<Productos>("SELECT * FROM Productos").ConfigureAwait(false);
}

public async Task ActualizarStock(Productos producto)
{
    await _con.ExecuteAsync(
        "UPDATE Productos SET Stock = @Stock WHERE ProductoID = @ProductoID",
        new { producto.ProductoID, producto.Stock }).ConfigureAwait(false);
}

public async Task<IEnumerable<Productos>> ObtenerProductosConBajoStock(int limiteStock)
{
    return await _con.QueryAsync<Productos>(
        "SELECT * FROM Productos WHERE Stock < @LimiteStock",
        new { LimiteStock = limiteStock }).ConfigureAwait(false);
}

public async Task<IEnumerable<Productos>> ObtenerProductosPorIdsAsync(IEnumerable<int> productoIds)
{
    var productos = await _con.QueryAsync<Productos>(
        "SELECT * FROM Productos WHERE ProductoID IN @ProductoIDs",
        new { ProductoIDs = productoIds }).ConfigureAwait(false);

    return productos;
}




/// <summary>
/// Implementación de operaciones relacionadas con las ventas.
/// </summary>
public async Task<int> RegistrarVenta(Ventas venta, IEnumerable<DetalleVentas> detalles)
{
    var ventaId = await _con.QuerySingleAsync<int>(
        "INSERT INTO Ventas (FechaHora, Total) OUTPUT INSERTED.VentaID VALUES (GETDATE(), @Total)",
        new { venta.FechaHora, venta.Total }).ConfigureAwait(false);

    foreach (var detalle in detalles)
    {
        await _con.ExecuteAsync(
            "INSERT INTO DetalleVentas (VentaID, ProductoID, Cantidad, Subtotal) VALUES (@VentaID, @ProductoID, @Cantidad, @Subtotal)",
            new { VentaID = ventaId, detalle.ProductoID, detalle.Cantidad, detalle.Subtotal }).ConfigureAwait(false);
    }

    return ventaId;
}

public async Task EliminarVenta(Ventas venta)
{
    await _con.ExecuteAsync(
        "DELETE FROM DetalleVentas WHERE VentaID = @VentaID",
        new { VentaID = venta.VentaID }).ConfigureAwait(false);
    await _con.ExecuteAsync(
        "DELETE FROM Ventas WHERE VentaID = @VentaID",
        new { VentaID = venta.VentaID }).ConfigureAwait(false);
}

public async Task<Ventas> ObtenerVentaPorId(int ventaId)
{
    return await _con.QuerySingleAsync<Ventas>(
        @"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Total]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Ventas] WHERE VentaID = @VentaID",
        new { VentaID = ventaId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Ventas>> ObtenerVentas()
{
    return await _con.QueryAsync<Ventas>(@"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Total]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Ventas]").ConfigureAwait(false);
}

public async Task<IEnumerable<Ventas>> ObtenerVentasPorRango(DateTime fechaInicio, DateTime fechaFin)
{
    _logger.LogDebug($"Fecha Inicio: {fechaInicio}, Fecha Fin: {fechaFin}"); // Para depuración

    return await _con.QueryAsync<Ventas>(
        @"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Total]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Ventas] WHERE FechaHora BETWEEN CONVERT(datetime, @FechaInicio, 120) AND CONVERT(datetime, @FechaFin, 120)",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }
    ).ConfigureAwait(false);
}


public async Task<IEnumerable<DetalleVentas>> ObtenerDetalleDeVenta(int ventaId)
{
    return await _con.QueryAsync<DetalleVentas>(
        @"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Producto]
      ,[Cantidad]
      ,[Subtotal]
  FROM [Medical.Office.SqlLocalDB].[dbo].[DetalleDeVentas] WHERE VentaID = @VentaID",
        new { VentaID = ventaId }).ConfigureAwait(false);
}

/// <summary>
/// Implementación de operaciones relacionadas con los cortes de caja.
/// </summary>
public async Task RegistrarCorte(Cortes corte)
{
    await _con.ExecuteAsync(
        "INSERT INTO Cortes (FechaHora, TotalVendido, TotalVentas) VALUES (@FechaHora, @TotalVendido, @TotalVentas)",
        new { corte.FechaHora, corte.TotalVendido, corte.TotalVentas }).ConfigureAwait(false);
}

public async Task EliminarCorte(Cortes corte)
{
    await _con.ExecuteAsync(
        "DELETE FROM Cortes WHERE CorteID = @CorteID",
        new { corte.CorteID }).ConfigureAwait(false);
}

public async Task<Cortes> ObtenerCortePorId(int corteId)
{
    return await _con.QuerySingleAsync<Cortes>(
        @"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora] AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes] WHERE CorteID = @CorteID",
        new { CorteID = corteId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Cortes>> ObtenerCortes()
{
    return await _con.QueryAsync<Cortes>(@"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes]").ConfigureAwait(false);
}

public async Task<IEnumerable<Cortes>> ObtenerCortesPorRango(DateTime fechaInicio, DateTime fechaFin)
{
    return await _con.QueryAsync<Cortes>(
        @"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes] WHERE FechaHora BETWEEN @FechaInicio AND @FechaFin",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }).ConfigureAwait(false);
}

/// <summary>
/// Implementación de reportes y vistas.
/// </summary>
public async Task<IEnumerable<VentasPorDia>> ObtenerVentasPorDia(DateTime fechaInicio, DateTime fechaFin)
{
    return await _con.QueryAsync<VentasPorDia>(
        "SELECT CONVERT(DATE, FechaHora) AS Fecha, COUNT(*) AS TotalVentas, SUM(Total) AS TotalVendido " +
        "FROM Ventas WHERE FechaHora BETWEEN @FechaInicio AND @FechaFin GROUP BY CONVERT(DATE, FechaHora)",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }).ConfigureAwait(false);
}

public async Task<IEnumerable<DetalleDeVentas>> ObtenerDetalleDeVentas(int ventaId)
{
    return await _con.QueryAsync<DetalleDeVentas>(
        @"SELECT dv.VentaID, dbo.ufntolocaltime(v.FechaHora) AS [FechaHora], p.Nombre AS Producto, dv.Cantidad, dv.Subtotal 
        FROM DetalleVentas dv JOIN Ventas v ON dv.VentaID = v.VentaID JOIN Productos p ON dv.ProductoID = p.ProductoID  
        WHERE dv.VentaID = @VentaID",
        new { VentaID = ventaId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Cortes>> ObtenerResumenDeCortesPorDia(DateTime fechaInicio, DateTime fechaFin)
{
    return await _con.QueryAsync<Cortes>(
        @"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes] WHERE FechaHora BETWEEN @FechaInicio AND @FechaFin",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }).ConfigureAwait(false);
}
}