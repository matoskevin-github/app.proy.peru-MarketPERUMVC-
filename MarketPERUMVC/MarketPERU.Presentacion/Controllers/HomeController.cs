using MarketPERU.Entidades;
using MarketPERU.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MarketPERU.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private ProveedorBO proveedorBO;

        public HomeController()
        {
            proveedorBO = new ProveedorBO();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListaProveedores()
        {
            List<ProveedorBE> lista = proveedorBO.ObtenerProveedores();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProveedor(ProveedorBE proveedorBE)
        {
            RespuestaBE respuestaBE = proveedorBO.GuardarProveedor(proveedorBE);
            return Json(respuestaBE, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ActualizarProveedor(ProveedorBE proveedorBE)
        {
            RespuestaBE respuestaBE = proveedorBO.ActualizarProveedor(proveedorBE);
            return Json(respuestaBE, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerProveedor(string IdProveedor)
        {
            ProveedorBE entidad = proveedorBO.ObtenerProveedores().Find( X => X.IdProveedor == Convert.ToInt32(IdProveedor));      
             return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProveedor(string IdProveedor)
        {
            RespuestaBE respuestaBE = proveedorBO.EliminarProveedor(new ProveedorBE()
            {
                IdProveedor = Convert.ToInt32(IdProveedor)
            });
            return Json(respuestaBE, JsonRequestBehavior.AllowGet);
        }
    }
}
