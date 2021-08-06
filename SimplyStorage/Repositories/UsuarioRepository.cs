using SimplyStorage.Contexts;
using SimplyStorage.Domains;
using SimplyStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyStorage.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
         SimplyContext ctx = new SimplyContext();

        public Usuario BuscarEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}

