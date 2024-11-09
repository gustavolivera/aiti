using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Funcao> Funcoes { get; set; }

        #region CRUD

        public static List<Setor> Listar(Context context)
        {
            List<Setor> setores = context.Setores.ToList();
            return setores;
        }
        public void Salvar(Context context)
        {
            context.Setores.Add(this);
            context.SaveChanges();
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Setor BuscarPorId(Context context, int id)
        {
            Setor setor = context.
                Setores.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return setor;
        }
        public List<Setor> BuscarTodos(Context context)
        {
            List<Setor> setores = context.Setores.ToList();
            return setores;
        }

        public void Remover(Context context)
        {
            context.Setores.Remove(this);
            context.SaveChanges();
        }

        #endregion

    }
}

