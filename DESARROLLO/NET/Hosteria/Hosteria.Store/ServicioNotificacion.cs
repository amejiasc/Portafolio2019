using Hosteria.Clases;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Store
{
    public class ServicioNotificacion
    {
        private readonly string ConnString = "";
        public ServicioNotificacion()
        {
            ConnString = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
        }

        public int Crear(Notificacion notificacion)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_NOTIFICACION.SP_CREAR";

                cmd.Parameters.Add(new OracleParameter("p_ASUNTO ", OracleDbType.Varchar2, notificacion.Asunto, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_MENSAJE ", OracleDbType.Varchar2, notificacion.Mensaje, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_DESTINATARIO ", OracleDbType.Varchar2, notificacion.Destinatario, System.Data.ParameterDirection.Input));

                cmd.Parameters.Add(new OracleParameter("p_IdNotificacion", OracleDbType.Int32, System.Data.ParameterDirection.Output));
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.Output));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);

                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["p_IdNotificacion"].Value.ToString());

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
        public List<Notificacion> ListarNotificaciones()
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_NOTIFICACION.SP_LISTAR";

                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));
                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                List<Notificacion> notificaciones = new List<Notificacion>();
                while (reader.Read())
                {
                    notificaciones.Add(new Notificacion()
                    {
                        IdNotificacion = int.Parse(reader.GetValue(0).ToString()),
                        Asunto = (string)reader.GetValue(1),
                        Mensaje = (string)reader.GetValue(2),
                        Destinatario = (string)reader.GetValue(3),
                        Fecha   = ((DateTime)reader.GetValue(4)).ToString("dd-MM-yyyy HH:mm:ss"),
                        Estado = (string)reader.GetValue(5)
                    });
                }
                reader.Close();
                return notificaciones;
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


    }


}
