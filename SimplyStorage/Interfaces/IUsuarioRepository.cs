using SimplyStorage.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyStorage.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario BuscarEmailSenha(string email, string senha);
    }
}
