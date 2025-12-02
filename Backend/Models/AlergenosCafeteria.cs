namespace Models;
public class AlergenosCafeteria

{
    public int AlergenosId {get; set;}
    public int ProductoId {get; set;}

    public ProductosCafeteria? Producto {get; set;}
    public string Alergeno {get; set;}

    public AlergenosCafeteria() { }

    public AlergenosCafeteria(int alergenoId, int productoId, ProductosCafeteria? producto, string alergeno)
    {
        AlergenosId = alergenoId;
        ProductoId = productoId;
        Producto = producto;
        Alergeno = alergeno;
    }
}