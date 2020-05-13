using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Taller.BussinesLogic;
using Taller.Domain;

namespace WebAPIClientes
{
    public class LoginController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody]Usuario usuario)
        {
            string result = "Usuario o clave incorrecta";

            List<Usuario> lista = UsuariosManager.Get();

            foreach(Usuario user in lista)
            {
                if (((usuario.User).Equals(user.User) && (usuario.Clave).Equals(user.Clave)))
                {
                    if (user.NLogins < 3)
                    {
                        UsuariosManager.Actualizar(usuario);
                        result = "Usuario autenticado";
                   }
                    else
                    {
                        result = "Usuario bloqueado";
                    }
                   
                    
                }
                else if ((usuario.User).Equals(user.User) && !((usuario.Clave).Equals(user.Clave)))
                {
                    if (user.NLogins < 3)
                    {
                        usuario.NLogins = user.NLogins + 1;
                        UsuariosManager.Actualizar(usuario);
                        result = "Usuario o clave incorrecta";
                    }
                    else
                    {
                        result = "Usuario bloqueado";
                    }
                    
                }
            }
            return result;
        }
       
 

    }
}