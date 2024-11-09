using Domain.Domain;
using System.Collections.Generic;

namespace Sistema.Models
{
    public class SetorViewModel
    {
        public IEnumerable<Setor> Setores { get; set; }
        public Setor NovoSetor { get; set;}
        }
}
