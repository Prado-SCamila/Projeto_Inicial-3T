using System;
using System.Collections.Generic;

#nullable disable

namespace SimplyStorage.Domains
{
    public partial class TipoEquipamento
    {
        public TipoEquipamento()
        {
            Equipamentos = new HashSet<Equipamento>();
        }

        public int CodTipo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
