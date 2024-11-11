using Domain.Domain;
using System.Collections.Generic;

namespace Sistema.Models
{
    public class FuncaoViewModel
    {
        public IEnumerable<Funcao> Funcoes { get; set; }
        public Funcao NovaFuncao { get; set; }
    }
}
