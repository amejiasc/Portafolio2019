using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Store
{
    public class ServicioTrabajador
    {
        private readonly string ConnString = "";
        public ServicioTrabajador()
        {
            ConnString = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
        }

        public int Crear(Clases.Trabajador trabajador, int idCliente)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_TRABAJADOR.SP_CREAR";

                cmd.Parameters.Add(new OracleParameter("p_RUTTRABAJADOR", OracleDbType.Varchar2, trabajador.RutTrabajador, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_NOMBRES", OracleDbType.Varchar2, trabajador.Nombre, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_APELLIDOS", OracleDbType.Varchar2, trabajador.Apellidos, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_CELULAR", OracleDbType.Int32, trabajador.Celular, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_EMAIL", OracleDbType.Varchar2, trabajador.Email, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_IDCLIENTE", OracleDbType.Int32, idCliente, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_IDTRABAJADOR", OracleDbType.Int32, System.Data.ParameterDirection.Output));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));

                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["p_IDTRABAJADOR"].Value.ToString());

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

        public List<Clases.Trabajador> Listar(int idCliente)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_TRABAJADOR.SP_LISTAR";
                cmd.Parameters.Add(new OracleParameter("p_IdCliente", OracleDbType.Int32, idCliente, System.Data.ParameterDirection.Input));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));
                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                List<Clases.Trabajador> trabajadores = new List<Clases.Trabajador>();
                while (reader.Read())
                {
                    trabajadores.Add(new Clases.Trabajador()
                    {
                        RutTrabajador = (string)reader.GetValue(0),
                        Nombre= (string)reader.GetValue(1),
                        Apellidos = (string)reader.GetValue(2),
                        Celular = int.Parse(reader.GetValue(3).ToString()),
                        Email = (string)reader.GetValue(4),
                        RutCliente = (string)reader.GetValue(5),
                        IdCliente = int.Parse(reader.GetValue(6).ToString()),
                        IdTrabajador = int.Parse(reader.GetValue(7).ToString())
                    });
                }
                reader.Close();
                return trabajadores;
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
