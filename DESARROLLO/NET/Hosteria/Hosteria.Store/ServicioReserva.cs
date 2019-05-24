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
    public class ServicioReserva
    {
        private readonly string ConnString = "";
        public ServicioReserva()
        {
            ConnString = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
        }
        public List<Reserva> ListarReserva(int idReserva, string rutEmpresa, 
                                           string rutPasajero, string nombreEmpresa, 
                                           DateTime fechaDesde, DateTime fechaHasta, 
                                           int estadoReserva,
                                           int idSucursal) {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_RESERVA.SP_LISTARRESERVAS";


                cmd.Parameters.Add(new OracleParameter("p_IdReserva", OracleDbType.Int32, idReserva, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_RutEmpresa", OracleDbType.Varchar2, rutEmpresa.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_RutPasajero", OracleDbType.Varchar2, rutPasajero.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_NombreEmpresa", OracleDbType.Varchar2, nombreEmpresa.ToString(), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_FechaDesde", OracleDbType.Varchar2, fechaDesde.ToString("dd-MM-yyyy"), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_FechaHasta", OracleDbType.Varchar2, fechaHasta.ToString("dd-MM-yyyy"), System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_EstadoReserva", OracleDbType.Int32, estadoReserva, System.Data.ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_IdSucursal", OracleDbType.Int32, idSucursal, System.Data.ParameterDirection.Input));

                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));
                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                List<Reserva> reservas = new List<Reserva>();
                while (reader.Read())
                {
                    reservas.Add(new Reserva()
                    {
                        IdReserva = int.Parse(reader.GetValue(0).ToString()),
                        FechaReserva = DateTime.Parse(reader.GetValue(1).ToString()).ToString("dd-MM-yyyy"),
                        FechaDesde = ((DateTime)reader.GetValue(2)).ToString("dd-MM-yyyy"),
                        FechaHasta = ((DateTime)reader.GetValue(3)).ToString("dd-MM-yyyy"),
                        RutCliente = (string)reader.GetValue(4),
                        NombreCliente = (string)reader.GetValue(5),
                        EstadoReserva = int.Parse(reader.GetValue(6).ToString()),
                        IdSucursal = int.Parse(reader.GetValue(7).ToString()),
                        NombreSucursal = (string)reader.GetValue(8),
                        Monto = int.Parse(reader.GetValue(9).ToString()),
                    });
                }
                reader.Close();
                return reservas;
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

        public List<Pasajero> ListarPasajeros(int idReserva)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_RESERVA.SP_LISTARPASAJEROS";


                cmd.Parameters.Add(new OracleParameter("p_IdReserva", OracleDbType.Int32, idReserva, System.Data.ParameterDirection.Input));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));
                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                List<Pasajero> pasajeros = new List<Pasajero>();
                while (reader.Read())
                {
                    pasajeros.Add(new Pasajero()
                    {   
                        RutTrabajador = (string)reader.GetValue(0),
                        Nombre = (string)reader.GetValue(1),
                        Apellidos = (string)reader.GetValue(2),
                        Celular = int.Parse(reader.GetValue(3).ToString()),
                        Email = (string)reader.GetValue(4),
                        Estado = (string)reader.GetValue(5),
                        FechaCheckin = (string)reader.GetValue(6).ToString(),
                        FechaDesde = (string)reader.GetValue(7).ToString(),
                        FechaHasta = (string)reader.GetValue(8).ToString(),
                        Habitacion = !string.IsNullOrEmpty(reader.GetValue(9).ToString()) ? int.Parse(reader.GetValue(9).ToString()) : 0,
                        RutCliente = (string)reader.GetValue(10).ToString(),
                    });
                }
                reader.Close();
                return pasajeros;
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

        public List<Habitacion> ListarHabitaciones(int idReserva)
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_RESERVA.SP_LISTARHABITACIONES";


                cmd.Parameters.Add(new OracleParameter("p_IdReserva", OracleDbType.Int32, idReserva, System.Data.ParameterDirection.Input));
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));
                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                List<Habitacion> habitaciones = new List<Habitacion>();
                while (reader.Read())
                {
                    habitaciones.Add(new Habitacion()
                    {
                        NroHabitacion = int.Parse(reader.GetValue(0).ToString()),
                        Tipo = int.Parse(reader.GetValue(1).ToString()),
                        Precio = int.Parse(reader.GetValue(2).ToString()),
                        Estado = int.Parse(reader.GetValue(3).ToString()),
                        Nombre = (string)reader.GetValue(4)                        
                    });
                }
                reader.Close();
                return habitaciones;
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
