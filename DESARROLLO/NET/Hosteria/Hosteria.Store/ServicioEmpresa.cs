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
    public class ServicioEmpresa
    {
        private readonly string ConnString = "";
        public ServicioEmpresa()
        {
            ConnString = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
        }
        public int Crear(Empresa empresa)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_EMPRESA.SP_CREAR";

                cmd.Parameters.Add(new OracleParameter("p_RUTCLIENTE", OracleDbType.Varchar2, empresa.RutCliente, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_NOMBRECLIENTE", OracleDbType.Varchar2, empresa.Nombrecliente, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_DIRECCION", OracleDbType.Varchar2, empresa.Direccion, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_REGION", OracleDbType.Int32, empresa.Region, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_CIUDAD", OracleDbType.Varchar2, empresa.Ciudad.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_EMAIL", OracleDbType.Varchar2, empresa.Email.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_TELEFONO", OracleDbType.Int32, empresa.Telefono, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_CELULAR", OracleDbType.Int32, empresa.Celular, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_IDCOMUNA", OracleDbType.Int32, empresa.Comuna, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_CLAVE", OracleDbType.Varchar2, empresa.Clave.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_GIRO", OracleDbType.Varchar2, empresa.Giro.ToString(), System.Data.ParameterDirection.Input)); 
                cmd.Parameters.Add(new OracleParameter("p_IdCliente", OracleDbType.Int32, System.Data.ParameterDirection.Output));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));

                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["p_IdCliente"].Value.ToString());



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
        public Empresa Modificar(Empresa empresa)
        {
            return null;
        }
        public Empresa Traer(int idCliente, string RutCliente)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_EMPRESA.SP_TRAER";
                cmd.Parameters.Add(new OracleParameter("p_RutCliente", OracleDbType.Varchar2, RutCliente, System.Data.ParameterDirection.Input));
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
                Empresa empresa = new Clases.Empresa();
                while (reader.Read())
                {
                    empresa = new Empresa() {
                        RutCliente = (string)reader.GetValue(0),                        
                        Nombrecliente = (string)reader.GetValue(1),
                        Direccion = (string)reader.GetValue(2),
                        Region = int.Parse(reader.GetValue(3).ToString()),
                        Ciudad = (string)reader.GetValue(4),
                        Email = (string)reader.GetValue(5),
                        Telefono = int.Parse(reader.GetValue(6).ToString()),
                        Celular = int.Parse(reader.GetValue(7).ToString()),
                        Comuna = int.Parse(reader.GetValue(8).ToString()),
                        Giro  = (string)reader.GetValue(9),
                        IdCliente = int.Parse(reader.GetValue(10).ToString()),
                        Estado = int.Parse(reader.GetValue(10).ToString()).Equals(1)
                    };
                }
                reader.Close();
                return empresa;
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
