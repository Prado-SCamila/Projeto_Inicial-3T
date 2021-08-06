using Microsoft.AspNetCore.Mvc;
using SimplyStorage.Domains;
using SimplyStorage.Interfaces;
using SimplyStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyStorage.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes as salas
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class SalaController : Controller
    {
        /// <summary>
        /// Objeto _SalaRepository que irá receber os métodos definidos na interface iSala
        /// </summary>
        private iSala _SalaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _SalaRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public SalaController()
        {
            _SalaRepository = new SalaRepository();
        }

        /// <summary>
        /// Lista todas as salas
        /// </summary>
        /// <returns>Uma lista com as salas e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_SalaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma sala através do id
        /// </summary>
        /// <param name="id">id da sala que será buscada</param>
        /// <returns>um tipo de evento buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_SalaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala">Objeto novaSala que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Sala novaSala)
        {
            try
            {
                // Faz a chamada para o método
                _SalaRepository.Cadastrar(novaSala);

                // retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma sala existente
        /// </summary>
        /// <param name="id">id da sala que será atualizada</param>
        /// <param name="salaAtualizada">Um status code 204 - No Content</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Sala salaAtualizada)
        {
            try
            {
                // Faz a chamada para o método
                _SalaRepository.Atualizar(id, salaAtualizada);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma sala existente
        /// </summary>
        /// <param name="id">id da sala que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _SalaRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
