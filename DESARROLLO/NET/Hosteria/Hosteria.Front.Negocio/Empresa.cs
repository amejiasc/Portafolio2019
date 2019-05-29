using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Front.Negocio
{
    public class Empresa
    {
        public Empresa() {
            
        }

        public static RespuestaTraerEmpresa Traer(int id) {
            ServiciosEmpresa.ServicioEmpresaClient servicioEmpresaClient = new ServiciosEmpresa.ServicioEmpresaClient();
            var respuesta = servicioEmpresaClient.TraerEmpresa(id, string.Empty);      
            servicioEmpresaClient.Close();
            if (!respuesta.Exito)
            {
                switch (respuesta.MotivoNoExito)
                {
                    case Clases.Respuesta.MotivoNoExitoEmpresaTraer.NoExiste:
                        return new RespuestaTraerEmpresa() { Exito = false, Mensaje = "Cliente/Empresa no existe" };
                    case Clases.Respuesta.MotivoNoExitoEmpresaTraer.ErrorNoControlado:
                        return new RespuestaTraerEmpresa() { Exito = false, Mensaje = "Ha ocurrido un error al momento de la creación" };
                    default:
                        break;
                }
            }

            return new RespuestaTraerEmpresa() { Empresa= respuesta.Empresa };
        }

        public Respuesta Registrar(Clases.Empresa empresa) {

            ServiciosEmpresa.ServicioEmpresaClient servicioEmpresaClient = new ServiciosEmpresa.ServicioEmpresaClient();
            var respuesta  = servicioEmpresaClient.CrearEmpresa
                             (
                                new Clases.Entrada.EntradaEmpresaCrear()
                                {
                                   empresa = empresa
                                }
                             );

            servicioEmpresaClient.Close();
            if (!respuesta.Exito) {
                switch (respuesta.MotivoNoExito)
                {
                    case Clases.Respuesta.MotivoNoExitoEmpresaCrear.EmpresayaExiste:
                        return new Respuesta() { Exito=false, Mensaje="Cliente/Empresa ya existe"};
                    case Clases.Respuesta.MotivoNoExitoEmpresaCrear.ErrorNoControlado:
                        return new Respuesta() { Exito = false, Mensaje = "Ha ocurrido un error al momento de la creación" };
                    default:
                        break;
                }
            }

            return new Respuesta();
        }
    }
    public class Respuesta
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public Respuesta() {
            Exito = true;
            Mensaje = "";
        }
    }
    public class RespuestaTraerEmpresa
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public Clases.Empresa Empresa { get; set; }
        public RespuestaTraerEmpresa()
        {
            Exito = true;
            Mensaje = "";
            Empresa = new Clases.Empresa();
        }
    }

}
