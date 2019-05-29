using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Hosteria.Clases;
using Hosteria.Clases.Entrada;
using Hosteria.Clases.Respuesta;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioEmpresa" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioEmpresa.svc o ServicioEmpresa.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioEmpresa : IServicioEmpresa
    {

        Store.ServicioEmpresa servicioEmpresa;
        Store.ServicioNotificacion servicioNotificacion;
        public ServicioEmpresa()
        {
            servicioEmpresa = new Store.ServicioEmpresa();
            servicioNotificacion = new Store.ServicioNotificacion();
        }
        public RespuestaEmpresaCrear CrearEmpresa(EntradaEmpresaCrear entradaEmpresaCrear)
        {

            Empresa empresa = new Empresa();
            empresa = servicioEmpresa.Traer(0, entradaEmpresaCrear.empresa.RutCliente);
            if (empresa.IdCliente==0) {
                return new RespuestaEmpresaCrear() { Empresa = null, Exito = false, MotivoNoExito = MotivoNoExitoEmpresaCrear.EmpresayaExiste };
            }
            if (empresa == null)
            {
                return new RespuestaEmpresaCrear() { Empresa = null, Exito = false, MotivoNoExito = MotivoNoExitoEmpresaCrear.ErrorNoControlado };
            }

            int IdEmpresa = servicioEmpresa.Crear(entradaEmpresaCrear.empresa);

            if (IdEmpresa == 0)
            {
                return new RespuestaEmpresaCrear() { Empresa = null, Exito = false, MotivoNoExito = MotivoNoExitoEmpresaCrear.ErrorNoControlado };
            }

            servicioNotificacion.Crear(new Notificacion() {
                 Asunto = "[Hostal] - Creación de Cuenta",
                 Destinatario = empresa.Email,
                 Mensaje = string.Format("Estimado {0}:<br />Favor confirme su correo electronico en el siguiente link<br /> Atte. Hostal", empresa.Nombrecliente)
            });

            entradaEmpresaCrear.empresa.IdCliente = IdEmpresa;
            return new RespuestaEmpresaCrear() { Empresa = entradaEmpresaCrear.empresa, Exito = true, MotivoNoExito = MotivoNoExitoEmpresaCrear.Exito };

        }

        public RespuestaEmpresasListar ListarEmpresas()
        {
            throw new NotImplementedException();
        }

        public RespuestaEmpresaModificar ModificarEmpresa(EntradaEmpresaModificar entradaEmpresaModificar)
        {
            throw new NotImplementedException();
        }

        public RespuestaEmpresasTraer TraerEmpresa(int idEmpresa, string rutEmpresa)
        {
            Empresa empresa = new Empresa();
            rutEmpresa = string.IsNullOrEmpty(rutEmpresa) ? "-1" : rutEmpresa;
            empresa = servicioEmpresa.Traer(idEmpresa, rutEmpresa);
            if (empresa.IdCliente == 0)
            {
                return new RespuestaEmpresasTraer() { Empresa = null, Exito = false, MotivoNoExito = MotivoNoExitoEmpresaTraer.NoExiste };
            }
            if (empresa == null)
            {
                return new RespuestaEmpresasTraer() { Empresa = null, Exito = false, MotivoNoExito = MotivoNoExitoEmpresaTraer.ErrorNoControlado};
            }
           
            return new RespuestaEmpresasTraer() { Empresa = empresa, Exito = true, MotivoNoExito = MotivoNoExitoEmpresaTraer.Exito };

        }
    }
}

