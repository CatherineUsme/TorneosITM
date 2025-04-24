using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorneosITM.Models;

namespace TorneosITM.Clases
{
	public class clsLogin
	{
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        private DBExamen3Entities dbSuper = new DBExamen3Entities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }

        public bool ValidarUsuario()
        {
            try
            {
                AdministradorITM administrador = dbSuper.AdministradorITMs.FirstOrDefault(a => a.Usuario == login.Usuario);
                if (administrador == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }

        private bool ValidarClave()
        {
            try
            {
                AdministradorITM administrador = dbSuper.AdministradorITMs.FirstOrDefault(a => a.Usuario == login.Usuario && a.Clave == login.Clave);
                if (administrador == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }

        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                //Se genera el token
                string Token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from A in dbSuper.Set<AdministradorITM>()
                       where A.Usuario == login.Usuario &&
                               A.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = A.Usuario,
                           Autenticado = true,
                           Token = Token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> listRpta = new List<LoginRespuesta>();
                listRpta.Add(loginRespuesta);
                return listRpta.AsQueryable();
            }
        }

    }
}