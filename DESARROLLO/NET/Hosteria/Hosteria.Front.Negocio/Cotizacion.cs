using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hosteria.Front.Negocio
{
    public class Cotizacion
    {
        public RespuestaCargarCotizacion Cargar(Clases.Cotizacion cotizacion, HttpPostedFileBase archivo)
        {

            var lista = ListarValores(archivo.InputStream);
            if (lista == null) {
                return new RespuestaCargarCotizacion() { Exito=false, Mensaje="No fue posible leer el excel" };
            }

            ServicioReserva.ServicioReservaClient servicioReserva = new ServicioReserva.ServicioReservaClient();
            var respuesta = servicioReserva.CrearReserva(new Clases.Entrada.EntradaReservaCrear() { IdCliente=cotizacion.IdCliente, IdSucursal=cotizacion.IdSucursal, Pasajeros=lista } );
            servicioReserva.Close();
            if (!respuesta.Exito) {
                switch (respuesta.MotivoNoExito) {
                    case Clases.Respuesta.MotivoNoReservaCrear.NoSeCreoReserva:
                        return new RespuestaCargarCotizacion() { Exito = false, Mensaje = "No fue posible crear la reserva" };
                    case Clases.Respuesta.MotivoNoReservaCrear.ErrorNoControlado:
                        return new RespuestaCargarCotizacion() { Exito = false, Mensaje = "Ha ocurrido un error no controlado" };
                }
            }
            return new RespuestaCargarCotizacion() { Exito = true, Mensaje = "" };
        }
        private List<Clases.Pasajero> ListarValores(Stream archivo)
        {
            //Create a test file   
            List<Clases.Pasajero> respuestas = new List<Clases.Pasajero>();
            try
            {                                                                                          
                using (var package = new ExcelPackage(archivo))
                {
                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets.First();
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;     //get row count
                    for (int row = 2; row <= rowCount; row++)
                    {
                        /*for (int col = 1; col <= colCount; col++)
                        {*/
                        //Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value.ToString().Trim());
                        respuestas.Add(new Clases.Pasajero()
                        {
                            RutTrabajador = worksheet.Cells[row, 1].Value.ToString().Trim().Replace(".", ""),
                            Nombre = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Apellidos = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Celular = int.Parse(worksheet.Cells[row, 4].Value.ToString().Trim()),
                            Email = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            FechaDesde = DateTime.Parse(worksheet.Cells[row, 6].Value.ToString()).ToString("dd-MM-yyyy"),
                            FechaHasta = DateTime.Parse(worksheet.Cells[row, 7].Value.ToString()).ToString("dd-MM-yyyy"),
                            Pension = int.Parse(worksheet.Cells[row, 8].Value.ToString().Trim())
                        });
                        /*}*/
                    }
                    package.Save();
                }
            }
            catch (Exception ex) {
                return null;
            }
            
            return respuestas;
        }
    }
    
    public class RespuestaCargarCotizacion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public RespuestaCargarCotizacion() {
            Exito = true;
            Mensaje = "";
        }
    }

    

}
