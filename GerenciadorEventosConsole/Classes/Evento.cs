using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEventosConsole.Classes
{
    public class Evento : ContatoResponsavel
    {
        public String ID { get; set; }
        public string TituloEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public string DescricaoEvento { get; set; }
        public string PubAlvo { get; set; }
        public int QuantidadePessoas { get; set; }
        public ContatoResponsavel ContatoEvento { get; set; }

        public void CadastrarEvento(string controle, string titulo, DateTime dataInicio, DateTime dataFinal,int quantidadePessoas, string descricaoEvento, string publicoAlvo, ContatoResponsavel contato)
        {
            ID = controle;
            TituloEvento = titulo;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
            QuantidadePessoas = quantidadePessoas;
            DescricaoEvento = descricaoEvento;
            PubAlvo = publicoAlvo;
            ContatoEvento = contato;
        }
        public override string ToString()
        {
            return $"________________________________\nID: {ID}\nTítulo do Evento: {TituloEvento}\nData de Início: {DataInicio}\nData Final: {DataFinal}\nDescrição do Evento: {DescricaoEvento}\nPúblico-Alvo: {PubAlvo}\nContato Responsável:{ContatoEvento}";
        }
    }
}
