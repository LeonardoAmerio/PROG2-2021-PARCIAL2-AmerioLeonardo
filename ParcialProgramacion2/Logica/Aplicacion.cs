using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public sealed class Aplicacion
    {

        public static List<Envio> envios { get; set; }
        public static List<Persona> Personas { get; set; }


        public static Envio ObtenerEnvioPorID(string id)
        {
            if (envios != null)
            {
                foreach (var item in envios)
                {
                    if (item.CodigoEnvio == id)
                        return item;
                }
            }
            return null;
        }
        public static string AgregarEnvio(Persona destinatario, Envio envio)
        {
            Persona persona = BuscarPersona(destinatario.Dni);
            if (persona == null)
            {
                return null;
            }
            else
            {
                Envio nuevoEnvio = new Envio();
                if (envios == null)
                    envios = new List<Envio>();

                nuevoEnvio.CodigoEnvio = envio.GenerarCodigo();
                nuevoEnvio.Destinatario = destinatario;
                envio.Repartidor = envio.Repartidor;
                nuevoEnvio.estadoEnvio = Envio.Estado.Pendiente;
                nuevoEnvio.FechaEstimadaEntrega = envio.FechaEstimadaEntrega;
                nuevoEnvio.Descripcion = envio.Descripcion;
                envios.Add(nuevoEnvio);
                return nuevoEnvio.CodigoEnvio;
            }
        }
        public static Persona BuscarPersona(int dni)
        {
            Persona persona = Personas.Find(x => x.Dni == dni);
            if (persona != null)
            {
                return persona;
            }
            return null;
        }

        public static double ModificarEnvio(Envio EnvioModificado, int dni)
        {
            double comision = 0;
            Persona persona = BuscarPersona(dni);
            Envio envio = envios.Find(x => x.CodigoEnvio == EnvioModificado.CodigoEnvio);
            if (envio != null)
            {
                envio.estadoEnvio = EnvioModificado.estadoEnvio;
                if(envio.estadoEnvio == Envio.Estado.Entregado)
                {
                    comision = ObtenerComisionyEntrega(persona);
                    return comision;
                }
            }
            return comision;
        }

        public static double ObtenerComisionyEntrega(Persona persona)
        {
            double EarthRadius = 6371000;
            double distance = 0;
            double Lat = (persona.Cliente.Latitud - persona.Delivery.Latitud) * (Math.PI / 180);
            double Lon = (persona.Cliente.Longitud - persona.Delivery.Longitud) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(persona.Delivery.Latitud * (Math.PI / 180)) * Math.Cos(persona.Cliente.Latitud * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            return distance;
        }
    }
}

