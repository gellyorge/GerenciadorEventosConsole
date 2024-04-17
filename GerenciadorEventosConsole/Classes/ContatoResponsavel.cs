using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEventosConsole.Classes
{
    public class ContatoResponsavel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public void CadastrarContato(int controle, string nome, string email, string telefone)
        {
            ID = controle;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
        public override string ToString()
        {
            return $"\nID: {ID}\nNome: {Nome}\nEmail: {Email}\nTelefone: {Telefone}";
        }
    }
}
