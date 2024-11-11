using Domain.Domain;
using System.Collections.Generic;

namespace Sistema.Models
{
    public class MotivoViewModel
    {
        public IEnumerable<Motivo> Motivos { get; set; }
        public Motivo NovoMotivo { get; set; }
    }
}
