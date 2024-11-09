using Domain.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public Dictionary<string, string> Salvar(Context context)
        {
            Dictionary<string, string> erros =
                new Dictionary<string, string>();

            if (Login.Length > 20)
            {
                erros.Add("Login", "Este campo deve possuir no máximo 20 caracteres");
            }
            if (Senha.Length > 10)
            {
                erros.Add("Senha", "Este campo deve possuir no máximo 20 caracteres");
            }

            if (erros.Count == 0)
            {
                context.Usuarios.Add(this);
                context.SaveChanges();
            }

            return erros;
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remover(Context context)
        {
            context.Usuarios.Remove(this);
            context.SaveChanges();
        }

        public Usuario BuscarPorId(Context context, int id)
        {
            Usuario usuario = context.
                Usuarios.Where(linha => linha.Id.Equals(id)).
                FirstOrDefault();
            return usuario;
        }

        public List<Usuario> BuscarTodos(Context context)
        {
            List<Usuario> usuarios = context.Usuarios.ToList();
            return usuarios;
        }

        public Usuario Entrar(Context context, string login, string senha)
        {
            Usuario usuario = context.Usuarios.
                Where(linha => linha.Login.Equals(login) && linha.Senha.Equals(senha)).
                FirstOrDefault();
            return usuario;
        }
    }
}
