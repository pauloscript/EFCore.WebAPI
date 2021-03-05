using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class Batalha
    {
        public Batalha()
        {
            HeroiBatalhas = new HashSet<HeroiBatalha>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }

        public virtual ICollection<HeroiBatalha> HeroiBatalhas { get; set; }
    }
}
