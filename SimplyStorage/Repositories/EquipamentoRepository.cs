using Microsoft.EntityFrameworkCore;
using SimplyStorage.Contexts;
using SimplyStorage.Domains;
using SimplyStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyStorage.Repositories
{
    public class EquipamentoRepository : iEquipamento
    {
        SimplyContext _context = new SimplyContext();

        public List<Equipamento> buscar()
        {
            return _context.Equipamentos.Include(x => x.TipoEquipamentoNavigation).ToList();
        }

        public Equipamento buscarPorID(int id)
        {
            return _context.Equipamentos.FirstOrDefault(x => x.CodEquipamento == id);
        }

        public void cadastrar(Equipamento novoEquipamento)
        {
            _context.Equipamentos.Add(novoEquipamento);
        }

        public void delete(int id)
        {
            Equipamento novoEquipamento = _context.Equipamentos.Find(id);
            _context.Equipamentos.Remove(novoEquipamento);
            _context.SaveChanges();
        }

        public void update(int id, Equipamento novoEquipamento)
        {
            Equipamento EquipamentoBuscado = _context.Equipamentos.Find(id);
            if (EquipamentoBuscado.Marca != null)
            {
                EquipamentoBuscado.Marca = novoEquipamento.Marca;
                _context.Equipamentos.Update(EquipamentoBuscado);
                _context.SaveChanges();
            }
        }
    }
}
