using System;

namespace GerenciadorEventosConsole.Classes
{
    public static class TratamentoInput
    {
        public static DateTime ColetarData()
        {
            Console.WriteLine("Digite uma data e hora (no formato dd/mm/aaaa HH:mm):");
            string entrada = Console.ReadLine();

            DateTime data;
            if (DateTime.TryParseExact(entrada, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out data))
            {
                return data;
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Tente novamente.");
                return ColetarData();
            }
        }

        public static int VerificadorNumeroInteiroValido()
        {
            int inteiro;
            while (!int.TryParse(Console.ReadLine(), out inteiro))
            {
                Console.WriteLine("Digite um número inteiro válido!");
            }
            return inteiro;
        }
    }
}
