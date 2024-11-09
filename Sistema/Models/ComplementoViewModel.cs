using Domain.Domain;
using System.Collections.Generic;

namespace Sistema.Models
{
    public class ComplementoViewModel
    {
        public IEnumerable<Complemento> Complementos {  get; set; }
        public Complemento NovoComplemento { get; set; }
    }
}
