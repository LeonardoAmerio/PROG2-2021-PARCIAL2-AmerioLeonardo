using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Envio
    {
        public string CodigoEnvio { get; set; }
        public Persona Destinatario { get; set; }
        public Repartidor Repartidor { get; set; }
        public enum Estado { Pendiente, AsignadoARepartidor, EnCamino, Entregado }
        public Estado estadoEnvio { get; set; }
        public DateTime FechaEstimadaEntrega { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }

        public string GenerarCodigo()
        {
            Random random = new Random();
            return CodigoEnvio = Convert.ToString(random.Next());

        }
    }
}
