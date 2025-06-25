using System.Runtime.InteropServices.JavaScript;

namespace Medical.Office.Domain.Entities.ExpressPos.Views;

public class DetalleDeVentas
{
    public int VentaID { get; set; }

    public DateTime? FechaHora { get; set; }

    public string Producto { get; set; }

    public int Cantidad { get; set; }

    public double Subtotal { get; set; }
    
    public long IDPatient { get; set; }

}