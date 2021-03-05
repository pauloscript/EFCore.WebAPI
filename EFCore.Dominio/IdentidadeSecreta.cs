using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class IdentidadeSecreta
    {
        public int Id { get; set; }
        public string NomeReal { get; set; }
        public int HeroiId { get; set; }

        public virtual Heroi Heroi { get; set; }
    }
}
