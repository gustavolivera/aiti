using Domain.Domain;
using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public virtual Funcao Funcao { get; set; }
        public int FuncaoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<Atendimento> Atendimentos { get; set; }
        public virtual List<Chamado> Chamados { get; set; }

        #region CRUD

        public static List<Pessoa> Listar(Context context)
        {
            List<Pessoa> pessoas = context.Pessoas.ToList();
            return pessoas;
        }
        public void Salvar(Context context)
        {
            context.Pessoas.Add(this);
            context.SaveChanges();
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Pessoa BuscarPorId(Context context, int id)
        {
            Pessoa pessoa = context.
                Pessoas.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return pessoa;
        }
        public List<Pessoa> BuscarTodos(Context context)
        {
            List<Pessoa> pessoas = context.Pessoas.ToList();
            return pessoas;
        }

        public void Remover(Context context)
        {
            context.Pessoas.Remove(this);
            context.SaveChanges();
        }

        #endregion

    }

}

