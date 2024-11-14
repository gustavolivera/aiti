using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EF
{
    public class DBInitializer
    {
        public static void Initialize(Context context)
        {
            if (context.Database.EnsureCreated())
            {
                var setorTecnologia = context.Setores.FirstOrDefault(s => s.Nome == "Tecnologia");
                if (setorTecnologia == null)
                {
                    setorTecnologia = new Setor { Nome = "Tecnologia" };
                    context.Setores.Add(setorTecnologia);
                    context.SaveChanges();
                }

                // Verificar se a função "Técnico" já existe e está associada ao setor "Tecnologia"
                var funcaoTecnico = context.Funcoes.FirstOrDefault(f => f.Nome == "Técnico" && f.SetorId == setorTecnologia.Id);
                if (funcaoTecnico == null)
                {
                    funcaoTecnico = new Funcao
                    {
                        Nome = "Técnico",
                        SetorId = setorTecnologia.Id
                    };
                    context.Funcoes.Add(funcaoTecnico);
                    context.SaveChanges();
                }

                // Verificar se a pessoa "Administrador" já existe
                var pessoaAdministrador = context.Pessoas.FirstOrDefault(p => p.Nome == "Administrador" && p.Email == "tecnologia@email.com");
                if (pessoaAdministrador == null)
                {
                    // Criar o usuário associado
                    var usuarioAdministrador = new Usuario
                    {
                        Login = "tecnologia@email.com",
                        Senha = "123" // Lembre-se de que senhas devem ser armazenadas de forma segura (hashing)
                    };
                    context.Usuarios.Add(usuarioAdministrador);
                    context.SaveChanges();

                    // Criar a pessoa "Administrador" e associá-la ao usuário e à função de "Técnico"
                    pessoaAdministrador = new Pessoa
                    {
                        Nome = "Administrador",
                        Email = "tecnologia@email.com",
                        Senha = "123", // Mesma observação de segurança sobre hashing de senha
                        Telefone = "11 111111111",
                        FuncaoId = funcaoTecnico.Id,
                        UsuarioId = usuarioAdministrador.Id // Associa o ID do usuário à pessoa
                    };
                    context.Pessoas.Add(pessoaAdministrador);
                    context.SaveChanges();
                }
            }
        }
    }
}
