using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
    public class Motivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Complemento> Complementos { get; set; }
        public virtual List<Chamado> Chamados { get; set; }

        #region CRUD

        public static List<Motivo> Listar(Context context)
        {
            List<Motivo> motivos = context.Motivos.ToList();
            return motivos;
        }

        public void Salvar(Context context)
        {
            context.Motivos.Add(this);
            context.SaveChanges();
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Motivo BuscarPorId(Context context, int id)
        {
            Motivo motivo= context.
                Motivos.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return motivo;
        }

        public List<Motivo> BuscarTodos(Context context)
        {
            List<Motivo> motivos = context.Motivos.ToList();
            return motivos;
        }

        public void Remover(Context context)
        {
            context.Motivos.Remove(this);
            context.SaveChanges();
        }

        #endregion
    }

}