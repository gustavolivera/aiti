using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
	public class Funcao
	{
        public int Id { get; set; }
		public string Nome { get; set; }
        public virtual Setor Setor { get; set; }
        public int SetorId { get; set; }
        public virtual List<Pessoa> Pessoas { get; set; }

        #region CRUD

        public static List<Funcao> Listar(Context context)
        {
            List<Funcao> funcoes = context.Funcoes.ToList();
            return funcoes;
        }
        public void Salvar(Context context)
        {
            context.Funcoes.Add(this);
            context.SaveChanges();
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Funcao BuscarPorId(Context context, int id)
        {
            Funcao funcao = context.
                Funcoes.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return funcao;
        }

        public List<Funcao> BuscarTodos(Context context)
        {
            List<Funcao> funcoes = context.Funcoes.ToList();
            return funcoes;
        }

        public void Remover(Context context)
        {
            context.Funcoes.Remove(this);
            context.SaveChanges();
        }

        #endregion

    }


}
