using Domain.Domain;
using System.Collections.Generic;

namespace Sistema.Models
{
    public class ChamadoViewModel
    {
        public List<Motivo> Motivos { get; set; }
        public List<Complemento> Complementos { get; set; }
        public Chamado NovoChamado { get; set; }
    }
}
