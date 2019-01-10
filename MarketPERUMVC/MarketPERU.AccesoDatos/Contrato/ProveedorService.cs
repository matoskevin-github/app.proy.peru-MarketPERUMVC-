using System.Collections.Generic;
using MarketPERU.Entidades;

namespace MarketPERU.AccesoDatos.Contrato
{
    public interface ProveedorService
    {
        List<ProveedorBE> ObtenerProveedores();
        RespuestaBE GuardarProveedor(ProveedorBE proveedorBE);
        RespuestaBE ActualizarProveedor(ProveedorBE proveedorBE);
        RespuestaBE EliminarProveedor(ProveedorBE proveedorBE);
    }
}
