using CRUDCoreMVC.Models;
using System.Data.SqlClient;
using System.Data;


namespace CRUDCoreMVC.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSQl()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSQl()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto)
        {
            bool rpt;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.GetCadenaSQl()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpt = false;
            }

            return rpt;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool rpt;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.GetCadenaSQl()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpt = false;
            }

            return rpt;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpt;
            var cn = new Conexion();
            using (var cadena = new SqlConnection(cn.GetCadenaSQl()))
            {
                try
                {
                    cadena.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", cadena);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.ExecuteNonQuery();
                    rpt = true;
                }
                catch (Exception e)
                {
                    rpt = false;
                    var error = e.Message;
                }
            }
            return rpt;
        }
    }
}
