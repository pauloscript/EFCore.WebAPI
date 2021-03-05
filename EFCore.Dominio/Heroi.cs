using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class Heroi
    {
        public Heroi()
        {
            Armas = new HashSet<Arma>();
            HeroiBatalhas = new HashSet<HeroiBatalha>();
            IdentidadeSecreta = new HashSet<IdentidadeSecreta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Arma> Armas { get; set; }
        public virtual ICollection<HeroiBatalha> HeroiBatalhas { get; set; }
        public virtual ICollection<IdentidadeSecreta> IdentidadeSecreta { get; set; }
    }
}
