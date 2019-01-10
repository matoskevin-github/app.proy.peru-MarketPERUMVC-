using MarketPERU.AccesoDatos;
using MarketPERU.Entidades;
using System.Collections.Generic;

namespace MarketPERU.LogicaNegocio
{
    public class ProveedorBO
    {
        private ProveedorDAO proveedorDAO;

        public ProveedorBO()
        {
            proveedorDAO = new ProveedorDAO();
        }

        public List<ProveedorBE> ObtenerProveedores()
        {
            return proveedorDAO.ObtenerProveedores();
        }
        public RespuestaBE GuardarProveedor(ProveedorBE proveedorBE)
        {
            return proveedorDAO.GuardarProveedor(proveedorBE);
        }
        public RespuestaBE ActualizarProveedor(ProveedorBE proveedorBE)
        {
            return proveedorDAO.ActualizarProveedor(proveedorBE);
        }
        public RespuestaBE EliminarProveedor(ProveedorBE proveedorBE)
        {
            return proveedorDAO.EliminarProveedor(proveedorBE);

        }
    }
}
