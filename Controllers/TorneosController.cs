using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TorneosITM.Clases;
using TorneosITM.Models;

namespace TorneosITM.Controllers
{
    [RoutePrefix("api/Torneos")]
    [Authorize]
    public class TorneosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXId")]
        public Torneo ConsultarXId(int IdTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarXId(IdTorneo);
        }

        [HttpGet]
        [Route("ConsultarXTipo")]
        public List<Torneo> ConsultarXTipo(string TipoTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarXTipo(TipoTorneo);
        }

        [HttpGet]
        [Route("ConsultarXNombreTorneo")]
        public List<Torneo> Consultar(string NombreTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarXNombreTorneo(NombreTorneo);
        }

        [HttpGet]
        [Route("ConsultarXFecha")]
        public List<Torneo> ConsultarXFecha(DateTime FechaTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarXFecha(FechaTorneo);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Torneo torneo)
        {
            clsTorneo Torneo = new clsTorneo();
            Torneo.torneo = torneo;
            return Torneo.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            clsTorneo Torneo = new clsTorneo();
            Torneo.torneo = torneo;
            return Torneo.Actualizar();
        }

        
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar (int IdTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.Eliminar(IdTorneo);
        }
    }
}