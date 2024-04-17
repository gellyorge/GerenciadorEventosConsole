using GerenciadorEventosConsole.Classes;
using System;
using System.Collections.Generic;

namespace GerenciadorEventosConsole.Dicionarios
{
    class DicionarioContato
    {
        private static Dictionary<int, ContatoResponsavel> contatos = new Dictionary<int, ContatoResponsavel>();
        private static int controleContato = 0;

        public static void InsertContato()
        {
            Console.WriteLine($"Contato ID: {controleContato}");
            ContatoResponsavel novoContato = new();
            string Nome, Email, Telefone;

            do
            {
                Console.Write("Digite o nome: ");
                Nome = Console.ReadLine();
            } while (string.IsNullOrEmpty(Nome));

            do
            {
                Console.Write("Digite o email: ");
                Email = Console.ReadLine();
            } while (string.IsNullOrEmpty(Email) || !Email.Contains('@'));

            do
            {
                Console.Write("Digite o telefone: ");
                Telefone = Console.ReadLine();
            } while (string.IsNullOrEmpty(Telefone) || Telefone.Length != 11);

            novoContato.CadastrarContato(controleContato, Nome, Email, Telefone);
            contatos.Add(controleContato, novoContato);
            controleContato++;

            Console.WriteLine("Contato cadastrado com sucesso!");
            Console.WriteLine();
        }

        public static void SelectContato()
        {
            if (contatos.Count == 0)
            {
                Console.WriteLine("0 Itens encontrados!");
            }

            foreach (var contato in contatos)
            {
                Console.WriteLine(contato.Value);
            }
        }

        public static void UpdateContato()
        {
            if (DicionarioContatosVazio())
            {
                Console.WriteLine("Crie um Contato para ultiliar a opcao atualizar contato!");
                return;
            }

            var contato = SelectContatoId();

            Console.WriteLine("Digite o Nome atualizado ou tecle ENTER para manter o nome atual:");
            var entrada = Console.ReadLine();
            if (entrada != "")
            {
                contatos[contato.ID].Nome = entrada;
            }

            Console.WriteLine("Digite o Email atualizado ou tecle ENTER para manter o email atual:");
            entrada = Console.ReadLine();
            if (entrada != "")
            {
                contatos[contato.ID].Email = entrada;
            }

            Console.WriteLine("Digite o Telefone atualizado ou tecle ENTER para manter o telefone atual:");
            entrada = Console.ReadLine();
            if (entrada != "")
            {
                contatos[contato.ID].Telefone = entrada;
            }
        }

        public static ContatoResponsavel SelectContatoId()
        {
            SelectContato();
            Console.WriteLine("Digite o ID do Contato: ");
            int id = TratamentoInput.VerificadorNumeroInteiroValido();

            foreach (var contato in contatos)
            {
                if (contato.Key == id)
                {
                    return contato.Value;
                }
            }

            Console.WriteLine("Digite um ID valido!");
            return SelectContatoId();
        }

        public static bool DicionarioContatosVazio()
        {
            return controleContato == 0;
        }
    }
}
