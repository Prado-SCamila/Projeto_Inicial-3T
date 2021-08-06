using SimplyStorage.Contexts;
using SimplyStorage.Domains;
using SimplyStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyStorage.Repositories
{
    public class SalaRepository : iSala
    {
        /// <summary>
        /// Objeto contexto por onde são chamados os métodos do EF Core
        /// </summary> 
        SimplyContext ctx = new SimplyContext();

        /// <summary>
        /// Atualiza uma sala existente
        /// </summary>
        /// <param name="id">id da sala que será atualizada</param>
        /// <param name="salaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Sala salaAtualizada)
        {
            // Busca uma sala através do id
            Sala salaBuscada = ctx.Salas.Find(id);

            // Verifica se o nome da sala foi informado
            if(salaAtualizada.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                salaBuscada.Nome = salaAtualizada.Nome;
            }

            // Atualiza a sala buscada
            ctx.Salas.Update(salaBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma sala através do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma sala buscada</returns>
        public Sala BuscarPorId(int id)
        {
            // Retorna a primeira sala encontrada para o id informado
            return ctx.Salas.FirstOrDefault(te => te.CodSala == id);
        }

        /// <summary>
        /// Cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala">Objeto novaSala que será cadastrado</param>
        public void Cadastrar(Sala novaSala)
        {
            // Adiciona essa nova sala
            ctx.Salas.Add(novaSala);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma sala existente
        /// </summary>
        /// <param name="id">id da sala que será deletada</param>
        public void Deletar(int id)
        {
            // Busca uma sala através do id
            Sala salaBuscada = ctx.Salas.Find(id);

            // Remove a sala buscada
            ctx.Salas.Remove(salaBuscada);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as salas
        /// </summary>
        /// <returns>Uma lista de todas de salas</returns>
        public List<Sala> Listar()
        {
            // Retorna uma lista com todas as informações das salas
            return ctx.Salas.ToList();
        }
    }
}
