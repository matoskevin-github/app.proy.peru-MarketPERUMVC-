using MarketPERU.AccesoDatos.Conexion;
using MarketPERU.AccesoDatos.Contrato;
using MarketPERU.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MarketPERU.AccesoDatos
{
    public class ProveedorDAO : ProveedorService
    {
        private DatabaseFactorySectionHandler DbConnection;

        public ProveedorDAO()
        {
            DbConnection = new DatabaseFactorySectionHandler();
        }

        public List<ProveedorBE> ObtenerProveedores()
        {
            var listaResp = new List<ProveedorBE>();
            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(DbConnection.DbCnxStr))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SP_SEL_OBTENER_PROVEEDORES";
                        sqlCmd.Connection = sqlCnx;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var proveedorBE = new ProveedorBE();
                                proveedorBE.IdProveedor = Convert.ToInt32(reader["IdProveedor"]);
                                proveedorBE.Nombre = Convert.ToString(reader["Nombre"]);
                                proveedorBE.Representante = Convert.ToString(reader["Representante"]);
                                proveedorBE.Direccion = Convert.ToString(reader["Direccion"]);
                                proveedorBE.Ciudad = Convert.ToString(reader["Ciudad"]);
                                proveedorBE.Departamento = Convert.ToString(reader["Departamento"]);
                                proveedorBE.CodigoPostal = Convert.ToString(reader["CodigoPostal"]);
                                proveedorBE.Telefono = Convert.ToString(reader["Telefono"]);
                                proveedorBE.Fax = Convert.ToString(reader["Fax"]);
                                listaResp.Add(proveedorBE);
                            }
                        }
                    }
                    sqlCnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaResp;
        }

        public RespuestaBE GuardarProveedor(ProveedorBE proveedorBE)
        {
            var respuestaBE = new RespuestaBE();
            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(DbConnection.DbCnxStr))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SP_INS_GUARDAR_EMPLEADO";
                        sqlCmd.Connection = sqlCnx;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = proveedorBE.Nombre;
                        sqlCmd.Parameters.Add("@Representante", SqlDbType.VarChar).Value = proveedorBE.Representante;
                        sqlCmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = proveedorBE.Direccion;
                        sqlCmd.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = proveedorBE.Ciudad;
                        sqlCmd.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = proveedorBE.Departamento;
                        sqlCmd.Parameters.Add("@CodigoPostal", SqlDbType.VarChar).Value = proveedorBE.CodigoPostal;
                        sqlCmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = proveedorBE.Telefono;
                        sqlCmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = proveedorBE.Fax;
                        string strRespuesta = sqlCmd.ExecuteScalar().ToString();
                        respuestaBE = ObtenerEntidadRespuesta(strRespuesta);
                    }
                    sqlCnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuestaBE;
        }

        public RespuestaBE ActualizarProveedor(ProveedorBE proveedorBE)
        {
            var respuestaBE = new RespuestaBE();
            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(DbConnection.DbCnxStr))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SP_UPD_ACTUALIZAR_EMPLEADO";
                        sqlCmd.Connection = sqlCnx;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = proveedorBE.IdProveedor;
                        sqlCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = proveedorBE.Nombre;
                        sqlCmd.Parameters.Add("@Representante", SqlDbType.VarChar).Value = proveedorBE.Representante;
                        sqlCmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = proveedorBE.Direccion;
                        sqlCmd.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = proveedorBE.Ciudad;
                        sqlCmd.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = proveedorBE.Departamento;
                        sqlCmd.Parameters.Add("@CodigoPostal", SqlDbType.VarChar).Value = proveedorBE.CodigoPostal;
                        sqlCmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = proveedorBE.Telefono;
                        sqlCmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = proveedorBE.Fax;
                        string strRespuesta = sqlCmd.ExecuteScalar().ToString();
                        respuestaBE = ObtenerEntidadRespuesta(strRespuesta);
                    }
                    sqlCnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuestaBE;
        }

        public RespuestaBE EliminarProveedor(ProveedorBE proveedorBE)
        {
            var respuestaBE = new RespuestaBE();
            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(DbConnection.DbCnxStr))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SP_DEL_ELIMINAR_EMPLEADO";
                        sqlCmd.Connection = sqlCnx;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = proveedorBE.IdProveedor;
                        string strRespuesta = sqlCmd.ExecuteScalar().ToString();
                        respuestaBE = ObtenerEntidadRespuesta(strRespuesta);
                    }
                    sqlCnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuestaBE;
        }

        private RespuestaBE ObtenerEntidadRespuesta(string strRespuesta)
        {
            var respuestaBE = new RespuestaBE();
            string valorObject = string.Empty;
            try
            {
                if (strRespuesta != string.Empty)
                {
                    string[] array = strRespuesta.Split('|');
                    respuestaBE.Respuesta = Convert.ToInt32(array[0].Trim());
                    respuestaBE.Mensaje = Convert.ToString(array[1].Trim());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuestaBE;
        }
    }
}
