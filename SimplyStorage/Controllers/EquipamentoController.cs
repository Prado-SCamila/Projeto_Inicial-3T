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
    [Route("api/equipamento")]
    [Produces("application/json")]
    [ApiController]
    public class EquipamentoController : Controller
    {
        private iEquipamento _EquipamentoRepository { get; set; }
        public EquipamentoController()
        {
            _EquipamentoRepository = new EquipamentoRepository();
        }
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_EquipamentoRepository.buscar());
        }
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_EquipamentoRepository.buscarPorID(id));
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult post(Equipamento novoEquipamento)
        {
            _EquipamentoRepository.cadastrar(novoEquipamento);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        public IActionResult delete(int id)
        {
            _EquipamentoRepository.delete(id);
            return StatusCode(202);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public IActionResult put(int id, Equipamento equipamento)
        {
            _EquipamentoRepository.update(id, equipamento);
            return StatusCode(204);
        }
    }
}
