using GerenciadorEventosConsole.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciadorEventosConsole.Dicionarios
{
    public class DicionarioEvento
    {
        private static Dictionary<string, Evento> eventos = new Dictionary<string, Evento>();
        private static string IdEvento = GeradorEventoIdAlfanumerico();

        public static string GeradorEventoIdAlfanumerico()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            string codigo;
            do
            {
                // Gera um código aleatório de 6 caracteres
                codigo = "";
                for (int i = 0; i < 6; i++)
                {
                    codigo += caracteres[random.Next(caracteres.Length)];
                }
            } while (eventos.ContainsKey(codigo)); // Verifica se o código já existe no dicionário

            return codigo;
        }
        //funcoes basicas
        public static void InsertEvento()
        {
            if (DicionarioContato.DicionarioContatosVazio())
            {
                Console.WriteLine("Crie um Contato para Adicionar um Evento!");
                return;
            }

            Evento novoEvento = new();

            Console.WriteLine("Digite o título do evento: ");
            novoEvento.TituloEvento = Console.ReadLine();
            Console.Clear();

            DateTime DataInicio,DataFinal;//verificacao de data
            do
            {
                Console.WriteLine("Digite a data e hora de início do evento:");
               DataInicio = TratamentoInput.ColetarData();
                Console.WriteLine("Digite a data e hora de término do evento:");
               DataFinal = TratamentoInput.ColetarData();
                Console.Clear();

            } while (DataInicio >= DataFinal);

            novoEvento.DataInicio = DataInicio;
            novoEvento.DataFinal =DataFinal;

            Console.WriteLine("Digite a quantidade aproximada de pessoas: ");
            novoEvento.QuantidadePessoas = TratamentoInput.VerificadorNumeroInteiroValido();
            Console.Clear();

            Console.WriteLine("Digite a descrição do evento: ");
            novoEvento.DescricaoEvento = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite o público-alvo do evento: ");
            novoEvento.PubAlvo = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite o ID do contato responsável pelo evento: ");
            ContatoResponsavel idContato = DicionarioContato.SelectContatoId();
            Console.Clear();

            novoEvento.ContatoEvento = idContato;
            novoEvento.ID = GeradorEventoIdAlfanumerico();

            eventos.Add(novoEvento.ID, novoEvento);

            Console.WriteLine("Evento cadastrado com sucesso!");
        }

        public static void SelectEvento()
        {
            if (eventos.Count > 0)
            {
                foreach (var evento in eventos)
                {
                    Console.WriteLine(evento.Value);
                }
            }
            else
            {
                Console.WriteLine("0 eventos cadastrados!");
            }
        }

        public static void UpdateEvento()
        {
            if (DicionarioEventosVazio())
            {
                Console.WriteLine("Crie um evento para ultilar essa funcionalidade!");
                return;
            }

            var evento = SelectEventoId();

            Console.WriteLine("Digite o Titulo do evento atualizado ou tecle ENTER para manter o valor atual: ");
            var entrada = Console.ReadLine();
            if (entrada != "")
            {
                eventos[evento.ID].TituloEvento = entrada;
            }

            Console.WriteLine("Tecle ENTER para Manter a Data Inicial ou digite qualquer coisa para alterar: ");
            entrada = Console.ReadLine();
            if (entrada != "")
            {
                eventos[evento.ID].DataInicio = TratamentoInput.ColetarData();
            }

            Console.WriteLine("Tecle ENTER para Manter a Data Final ou digite qualquer coisa para alterar: ");
            entrada = Console.ReadLine();
            if (entrada != "")
            {
                eventos[evento.ID].DataFinal = TratamentoInput.ColetarData();
            }
            Console.WriteLine("Ttecle ENTER para manter o valor atual de numero de pessoas ou Digite qualquer coisa para Alterar: ");
            entrada = Console.ReadLine();
            if (entrada != "")
            {
                eventos[evento.ID].QuantidadePessoas = TratamentoInput.VerificadorNumeroInteiroValido();
            }

            Console.WriteLine("Digite o Publico Alvo atualizado ou tecle ENTER para manter o valor atual: ");
            entrada = Console.ReadLine();
            if (entrada != "")
            {
                eventos[evento.ID].PubAlvo = entrada;
            }

            Console.WriteLine("Tecle Enter para Manter o Contato Responsavel ou digite qualquer coisa para alterar: ");
            entrada = Console.ReadLine();
            if (entrada != "")
            {
                eventos[evento.ID].ContatoEvento = DicionarioContato.SelectContatoId();
            }
        }

        public static void DeleteEvento()
        {
            if (DicionarioEventosVazio())
            {
                Console.WriteLine("Crie um Evento para ultlizar a opcao Deletar um Evento!");
                return;
            }

            var evento = SelectEventoId();
            eventos.Remove(evento.ID);
        }

        //derivacao das funcoes
        public static Evento SelectEventoId()
        {
            SelectEvento();
            Console.WriteLine("Digite o Id do evento: ");
            var id = Console.ReadLine();
           

            foreach (var evento in eventos)
            {
                if (evento.Value.ID == id.ToUpper())
                {
                    return evento.Value;
                }
            }

            Console.WriteLine("Digite um ID valido!");
            return SelectEventoId();
        }

        public static void SelectEventoData()
        {
            DateTime data1, data2;

            do
            {
                Console.Write("Exibir eventos de: ");
                data1 = TratamentoInput.ColetarData();
                Console.WriteLine("Ate: ");
                data2 = TratamentoInput.ColetarData();

                if (data1 >= data2)
                {
                    Console.WriteLine("A data de início deve ser anterior à data de término. Tente novamente! ");
                }
            } while (data1 >= data2);

            int cont=0;
            foreach (var evento in eventos)
            {
                if (evento.Value.DataInicio <= data1 && evento.Value.DataFinal <= data2)
                {
                    Console.WriteLine(evento);
                }
                cont++;
            }
            if (cont == 0)
            {
                Console.WriteLine("Nenhum Evento foi encontrado nesse periodo! ");
            }
        }

        public static void SelectEventoDia()
        { 
            int cont = 0;
            DateTime data = TratamentoInput.ColetarData();
            foreach (var evento in eventos) {
                if(evento.Value.DataInicio >= data) { Console.WriteLine(evento); }    
                cont++;
            }
            if(cont == 0)
            {
                Console.WriteLine($"Nao ha eventos Iniciados em {data}");
            }
           
        }

        public static bool DicionarioEventosVazio()
        {
            return eventos.Count == 0;
        }

        public static void ExportarEventoParaTXT()
        {
            if (DicionarioEventosVazio())
            {
                Console.WriteLine("Não há eventos para exportar!");
                return;
            }

            Console.Clear();
            Console.WriteLine("Digite o ID do evento para exportar:");
            var evento = SelectEventoId();
            string filePath = $"{evento.TituloEvento}.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(evento);
            }

            Console.WriteLine($"Os dados do evento foram exportados para o arquivo: {filePath}");
        }
    }
}
