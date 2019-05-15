using Hosteria.Tipos.Store;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Store
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly string ConnString = "";
        public ServicioUsuario() {
            ConnString = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
        }

        #region "Sincronos"
        public bool Actualizar(IUsuario usuario)
        {
            throw new NotImplementedException();
        }
        public bool Eliminar(IUsuario usuario)
        {
            throw new NotImplementedException();
        }
        public int Insertar(IUsuario usuario)
        {
            return 1;
            //throw new NotImplementedException();
        }
        public List<IUsuario> Listar(int idUsuario, string rut)
        {
            throw new NotImplementedException();
        }
        public IUsuario Traer(int idUsuario, string rut)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_USUARIO.SP_TRAER";
                cmd.Parameters.Add(new OracleParameter("p_IdUsuario", OracleDbType.Int32, idUsuario, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_RutUsuario", OracleDbType.Varchar2, rut, System.Data.ParameterDirection.Input));

                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));

                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                IUsuario usuario = new Clases.Usuario();
                while (reader.Read())
                {
                    usuario.IdUsuario = int.Parse(reader.GetValue(0).ToString());
                    usuario.Rut = (string)reader.GetValue(1);
                    usuario.Email = (string)reader.GetValue(2);
                    usuario.Nombres = (string)reader.GetValue(3);
                    usuario.Apellidos = (string)reader.GetValue(4);
                    usuario.IdSucursal = int.Parse(reader.GetValue(5).ToString());
                    usuario.Codigo = (string)reader.GetValue(6);
                }
                reader.Close();

           
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }                          
        public int TraerLogin(string rut, string email, string clave)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_USUARIO.SP_LOGINUSUARIO";

                cmd.Parameters.Add(new OracleParameter("p_RutUsuario", OracleDbType.Varchar2, rut.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_EmailUsuario", OracleDbType.Varchar2, email.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_ClaveUsuario", OracleDbType.Varchar2, clave.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_IdUsuario", OracleDbType.Int32, System.Data.ParameterDirection.Output));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.Output));

                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["p_IdUsuario"].Value.ToString());

              

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public void CrearLoginUsuario(string rut, Guid guid) {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_USUARIO.SP_LoginSesionUsuario";

                cmd.Parameters.Add(new OracleParameter("p_RutUsuario", OracleDbType.Varchar2, rut.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_IdSession", OracleDbType.Varchar2, guid.ToString(), System.Data.ParameterDirection.Input));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.Output));

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception( string.Concat("Ha ocurrido un error: ", ex.Message) );
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion


    }
}

