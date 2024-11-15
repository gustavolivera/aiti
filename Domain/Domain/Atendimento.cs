﻿using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
	public class Atendimento
	{
		public int Id { get; set; }
        public virtual Chamado Chamado { get; set; }
		public int ChamadoId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
		public DateTime DataHora_inicio { get; set; }
		public DateTime DataHora_fim { get; set; }


        #region CRUD

        public static List<Atendimento> Listar(Context context)
        {
            List<Atendimento> atendimentos = context.Atendimentos.ToList();
            return atendimentos;
        }
        public void Salvar(Context context)
        {
            context.Atendimentos.Add(this);
            context.SaveChanges();
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Atendimento BuscarPorId(Context context, int id)
        {
            Atendimento atendimento = context.
                Atendimentos.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return atendimento;
        }

        public List<Atendimento> BuscarTodos(Context context)
        {
            List<Atendimento> atendimentos = context.Atendimentos.ToList();
            return atendimentos;
        }

        public void Remover(Context context)
        {
            context.Atendimentos.Remove(this);
            context.SaveChanges();
        }

        #endregion
    }
}
