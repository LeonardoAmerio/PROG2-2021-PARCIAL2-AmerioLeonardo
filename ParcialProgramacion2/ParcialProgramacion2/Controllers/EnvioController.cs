using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;

namespace ParcialProgramacion2.Controllers
{
    [RoutePrefix("Envios/{idEnvio}")]
    public class EnvioController : ApiController
    {
        [Route("Envios")]
        public IHttpActionResult Get()
        {
            return Ok(Aplicacion.envios);
        }

        [Route("Envios/{idEnvios}")]
        public IHttpActionResult Get(string id)
        {
            if (Aplicacion.ObtenerEnvioPorID(id) == null)
                return BadRequest();

            return Ok(Aplicacion.ObtenerEnvioPorID(id));
        }

        [Route("Envios")]
        public IHttpActionResult Post(int idPersona, [FromBody]Envio value)
        {
            Persona persona = Aplicacion.BuscarPersona(idPersona);
            if (persona == null)
            {
                return BadRequest();
            }
            else
            {
                Envio envio = new Envio();
                envio = value;

                return Created("", Aplicacion.AgregarEnvio(persona, envio));
            }
        }

        [Route("Envios/{idEnvios}")]
        public IHttpActionResult Put(int id, [FromBody]Envio value)
        {
            Envio envioModificado = new Envio();
            Persona persona = Aplicacion.BuscarPersona(id);
            if (persona != null)
            {
                return Ok(Aplicacion.ModificarEnvio(value, id));
            }
            return BadRequest();

        }

        [Route("Envios/{idEnvios}")]
        public IHttpActionResult Delete(int id)
        {
        }
    }
}
