﻿using Hosteria.Clases;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Store
{
    public class ServicioUtils
    {
        private readonly string ConnString = "";
        public ServicioUtils()
        {
            ConnString = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
        }

        public List<Region> ListarRegiones()
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_UTILS.SP_REGIONES";
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));

                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                List<Region> regiones = new List<Region>();
                while (reader.Read())
                {
                    regiones.Add(new Region()
                                {
                                    IdRegion = int.Parse(reader.GetValue(0).ToString()),
                                    Nombre = (string)reader.GetValue(1)
                                }
                    );
                }
                reader.Close();
                return regiones;
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
        public List<Comuna> ListarComunas()
        {
            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PKG_UTILS.SP_COMUNAS";
                OracleParameter oraP = new OracleParameter("p_glosa", OracleDbType.Varchar2, 2000);
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Int32, System.Data.ParameterDirection.InputOutput));

                OracleParameter oraP1 = new OracleParameter();
                oraP1.OracleDbType = OracleDbType.RefCursor;
                oraP1.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP1);

                OracleDataReader reader = cmd.ExecuteReader();
                List<Comuna> comunas = new List<Comuna>();
                while (reader.Read())
                {
                    comunas.Add(new Comuna()
                    {
                        IdComuna = int.Parse(reader.GetValue(0).ToString()),
                        Nombre = (string)reader.GetValue(1),
                        IdRegion = int.Parse(reader.GetValue(2).ToString())
                    }
                    );
                }
                reader.Close();
                return comunas;
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

        public DataSet Ejecutor(string sql, int tipoConsulta) {

            OracleConnection conn = new OracleConnection(ConnString);
            try
            {
                //Instantiate OracleDataAdapter to create DataSet
                OracleDataAdapter productsAdapter = new OracleDataAdapter();
                //Instantiate DataSet object
                DataSet dataset = new DataSet("Result");
                int rows = 0;
                conn.Open();
                //Fetch Product Details
                switch (tipoConsulta)
                {
                    case 1:
                        productsAdapter.SelectCommand = new OracleCommand(sql, conn);
                        //Fill the DataSet with data from 'Products' database table
                        productsAdapter.Fill(dataset, "Result");
                        break;
                    case 2:
                    case 3:
                    case 4:
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        //Fill the DataSet with data from 'Products' database table
                        rows = cmd.ExecuteNonQuery();
                        dataset.Tables.Add(new DataTable("Table"));
                        dataset.Tables[0].Columns.Add("Filas", typeof(int));
                        dataset.Tables[0].Rows.Add(rows);
                        break;
                    default:
                        return null;
                }
                

                

                return dataset;

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
