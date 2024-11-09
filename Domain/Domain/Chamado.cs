using Domain.Domain;
using Domain.EF;
using System;
using System.Collections.Generic;

namespace Domain.Domain
{
	public class Chamado
	{
		public int Id { get; set; }
		public virtual Motivo Motivos { get; set; }
        public int MotivoId { get; set; }
		public virtual Complemento Complemento { get; set; }
        public int ComplementoId { get; set; }
        public string Urgencia { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataHora_inicio { get; set; }
        public DateTime DataHora_fim { get; set; }
		public virtual List<Atendimento> Atendimento { get; set; }

		public void Salvar(Context context)
		{
			context.Chamados.Add(this);
			context.SaveChanges();
		}
	}
}
