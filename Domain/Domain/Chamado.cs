using Domain.Domain;
using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
	public class Chamado
	{
		public int Id { get; set; }
		public virtual Pessoa Pessoa { get; set; }
		public int PessoaId { get; set; }
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

        #region CRUD

        public static List<Chamado> Listar(Context context)
        {
            List<Chamado> chamados = context.Chamados.ToList();
            return chamados;
        }
        public void Salvar(Context context)
        {
            context.Chamados.Add(this);
            context.SaveChanges();
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Chamado BuscarPorId(Context context, int id)
        {
            Chamado chamado = context.
                Chamados.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return chamado;
        }

        public List<Chamado> BuscarTodos(Context context)
        {
            List<Chamado> chamados = context.Chamados.ToList();
            return chamados;
        }

        public void Remover(Context context)
        {
            context.Chamados.Remove(this);
            context.SaveChanges();
        }

        #endregion
    }
}
