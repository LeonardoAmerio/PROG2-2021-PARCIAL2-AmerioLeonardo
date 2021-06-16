using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Persona
    { 
        public int Dni { get; set; }
        public string NombreApellido { get; set; }
        public int CodigoPostal { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Telefono { get; set; }
        public Destinatario Cliente { get; set; }
        public Repartidor Delivery { get; set; }


    }
}
