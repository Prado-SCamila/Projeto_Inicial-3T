using SimplyStorage.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyStorage.Interfaces
{
    interface iSala
    {
        /// <summary>
        /// Lista todas as salas
        /// </summary>
        /// <returns>Uma lista contendo as salas</returns>
        List<Sala> Listar();

        /// <summary>
        /// Busca uma sala através do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma sala buscada</returns>
        Sala BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala">Objeto novaSala que será cadastrado</param>
        void Cadastrar(Sala novaSala);

        /// <summary>
        /// Atualiza uma sala já existente
        /// </summary>
        /// <param name="salaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Sala salaAtualizada);
        
        /// <summary>
        /// Deleta uma sala existente
        /// </summary>
        /// <param name="id">id da sala que será deletada</param>
        void Deletar(int id);
    }
}
