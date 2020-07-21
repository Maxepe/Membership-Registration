using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Parcial2_PROGIII_110925.Models;
using Parcial2_PROGIII_110925.ViewModels;

namespace Parcial2_PROGIII_110925.AccesoDatos
{
    public class AccDatosSocio
    {
        public static bool InsertarSocio(Socio s)
        {
            bool resultado = false;
            string stringConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection conn = new SqlConnection(stringConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Socios VALUES(@Nombre, @Apellido, @IdTipoDocumento, @NroDocumento, @IdDeporte)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nombre", s.pNombre);
                cmd.Parameters.AddWithValue("@Apellido", s.pApellido);
                cmd.Parameters.AddWithValue("@IdTipoDocumento", s.pIdTipoDocumento);
                cmd.Parameters.AddWithValue("@NroDocumento", s.pNroDocumento);
                cmd.Parameters.AddWithValue("@IdDeporte", s.pIdDeporte);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }

        public static List<Socio> ObtenerListaSocio()
        {
            List<Socio> listaSocios = new List<Socio>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Socios";
                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Socio aux = new Socio();
                        aux.pIdSocio = int.Parse(dr["Id"].ToString());
                        aux.pNombre = dr["Nombre"].ToString();
                        aux.pApellido = dr["Apellido"].ToString();
                        aux.pNroDocumento = dr["NroDocumento"].ToString();


                        listaSocios.Add(aux);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return listaSocios;
        }

        public static List<TipoDocItemVM> ObtenerTiposDoc()
        {
            List<TipoDocItemVM> listaTipos = new List<TipoDocItemVM>();
            string stringConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection conn = new SqlConnection(stringConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM TiposDocumentos";
                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                conn.Open();
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        TipoDocItemVM tipoDoc = new TipoDocItemVM();
                        tipoDoc.pIdTipoDoc = int.Parse(dr["Id"].ToString());
                        tipoDoc.pNombre = dr["Nombre"].ToString();

                        listaTipos.Add(tipoDoc);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return listaTipos;
        }
        public static List<DeporteItemVM> ObtenerDeportes()
        {
            List<DeporteItemVM> listaDeportes = new List<DeporteItemVM>();
            string stringConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection conn = new SqlConnection(stringConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Deportes";
                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                conn.Open();
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        DeporteItemVM deporte = new DeporteItemVM();
                        deporte.pIdDeporte = int.Parse(dr["Id"].ToString());
                        deporte.pNombre = dr["Nombre"].ToString();

                        listaDeportes.Add(deporte);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return listaDeportes;
        }

        public static List<DeporteItemVM> ObtenerCantPorDeporte()
        {
            List<DeporteItemVM> listaDeportes = new List<DeporteItemVM>();
            string stringConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection conn = new SqlConnection(stringConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT d.Nombre Nombre, COUNT(*) Cantidad
                                   FROM Deportes d JOIN Socios s ON s.IdDeporte = d.Id
                                  GROUP BY d.Nombre";
                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                conn.Open();
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        DeporteItemVM deporte = new DeporteItemVM();
                        deporte.pNombre = dr["Nombre"].ToString();
                        deporte.pCantidad = int.Parse(dr["Cantidad"].ToString());

                        listaDeportes.Add(deporte);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return listaDeportes;
        }
    }
}