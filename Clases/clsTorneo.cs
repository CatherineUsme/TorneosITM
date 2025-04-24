using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorneosITM.Models;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;

namespace TorneosITM.Clases
{
	public class clsTorneo
	{
		private DBExamen3Entities dbSuper = new DBExamen3Entities();

		public Torneo torneo { get; set; }

        public string Insertar()
        {
            try
            {
                dbSuper.Torneos.Add(torneo);
                dbSuper.SaveChanges();
                return "Torneo creado con exito";
            }
            catch (Exception ex)
            {
                return "Error al crear el torneo: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Torneo tor = ConsultarXId(torneo.idTorneos);
                if (tor == null)
                {
                    return "El torneo con el nombre ingresado no existe, no se puede actualizar";
                }
                dbSuper.Torneos.AddOrUpdate(torneo);
                dbSuper.SaveChanges();
                return ("Torneo actualizado con exito");

            }
            catch (Exception ex)
            {
                return "Error al actualizar el torneo: " + ex.Message;
            }

        }

        public Torneo ConsultarXId(int IdTorneo)
        {
            return dbSuper.Torneos.FirstOrDefault(t => t.idTorneos == IdTorneo);
        }

        public List<Torneo> ConsultarXNombreTorneo(string NombreTorneo)
        {
            return dbSuper.Torneos
                .Where(t => t.NombreTorneo == NombreTorneo)
                .OrderBy(t => t.idTorneos)
                .ToList();
        }

        public List<Torneo> ConsultarXTipo(string TipoTorneo)
        {
            return dbSuper.Torneos
                .Where(t=>t.TipoTorneo==TipoTorneo)
                .OrderBy(t => t.idTorneos) 
                .ToList(); 
        }

        public List<Torneo> ConsultarXFecha(DateTime FechaTorneo)
        {
            return dbSuper.Torneos
                .Where(t => t.FechaTorneo == FechaTorneo)
                .OrderBy(t => t.idTorneos)
                .ToList();
        }

        public string Eliminar(int IdTorneo)
        {
            try
            {
                Torneo tor = ConsultarXId(IdTorneo);
                if (tor == null)
                {
                    return "El torneo con el nombre ingresado no existe, no se puede eliminar";
                }
                dbSuper.Torneos.Remove(tor);
                dbSuper.SaveChanges(); 
                return ("Torneo eliminado con exito");

            }
            catch (Exception ex)
            {
                return "Error al eliminar el torneo: " + ex.Message;
            }

        }

    }
}