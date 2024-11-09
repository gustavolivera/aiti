using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
    public class Complemento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Motivo Motivo { get; set; }
        public int MotivoId { get; set; }
        public virtual List<Chamado> Chamados {  get; set; }  

        #region CRUD

        public static List<Complemento> Listar(Context context)
        {
            List<Complemento> complementos = context.Complementos.ToList();
            return complementos;
        }

        public void Salvar(Context context)
        {
            context.Complementos.Add(this);
            context.SaveChanges();
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Complemento BuscarPorId(Context context, int id)
        {
            Complemento complemento = context.
                Complementos.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return complemento;
        }

        public List<Complemento> BuscarTodos(Context context)
        {
            List<Complemento> complementos = context.Complementos.ToList();
            return complementos;
        }

        public void Remover(Context context)
        {
            context.Complementos.Remove(this);
            context.SaveChanges();
        }

        #endregion

    }
}
