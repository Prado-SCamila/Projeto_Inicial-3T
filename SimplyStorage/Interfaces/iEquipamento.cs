using SimplyStorage.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyStorage.Interfaces
{
    interface iEquipamento
    {
        void cadastrar(Equipamento novaEquipamento);
        // Read
        List<Equipamento> buscar();
        Equipamento buscarPorID(int id);

        // Update
        void update(int id, Equipamento EquipamentoAtualizada);
        // Delete
        void delete(int id);
    }
}
