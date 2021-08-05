using System;
using System.Collections.Generic;

#nullable disable

namespace SimplyStorage.Domains
{
    public partial class Equipamento
    {
        public int CodEquipamento { get; set; }
        public int? CodSala { get; set; }
        public int? TipoEquipamento { get; set; }
        public string Marca { get; set; }
        public Guid NumeroSerie { get; set; }
        public decimal NumeroPatrimonio { get; set; }
        public string Descricao { get; set; }
        public bool BitAtivo { get; set; }

        public virtual Sala CodSalaNavigation { get; set; }
        public virtual TipoEquipamento TipoEquipamentoNavigation { get; set; }
    }
}
