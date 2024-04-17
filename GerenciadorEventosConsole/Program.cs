using GerenciadorEventosConsole.Classes;
using GerenciadorEventosConsole.Dicionarios;
while (true)
{
    //Menu para seleção das funções
    Console.WriteLine("========================================================================");
    Console.WriteLine("Digite 1 para cadastrar um contato");
    Console.WriteLine("Digite 2 para listar contatos");
    Console.WriteLine("Digite 3 para cadastrar um evento");
    Console.WriteLine("Digite 4 para listar eventos");
    Console.WriteLine("Digite 5 para apagar um evento pelo ID");
    Console.WriteLine("digite 6 para atualizar um contato");
    Console.WriteLine("digite 7 para atualizar um Evento");
    Console.WriteLine("Digite 8 para exportar os dados de um evento em TXT");
    Console.WriteLine("Digite 9 para Exibir Eventos por periodo expecifico ");
    Console.WriteLine("digite 10 para Exibir Eventos por dia expecifico ");
    Console.WriteLine("Digite 0 para sair");
    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            DicionarioContato.InsertContato();
            break;
        case "2": 
            Console.Clear();
            DicionarioContato.SelectContato(); 
            break;
        case "3":
            Console.Clear();
            DicionarioEvento.InsertEvento();
            break;
        case "4":
            Console.Clear();
            DicionarioEvento.SelectEvento();
            break;
        case "5":  
            Console.Clear();
            DicionarioEvento.DeleteEvento();
            break;
        case "6":
            Console.Clear();
            DicionarioContato.UpdateContato();
            break;
        case "7":
            Console.Clear();
            DicionarioEvento.UpdateEvento();
            break;
        case "8":
            Console.Clear();
            DicionarioEvento.ExportarEventoParaTXT();
            break;
        case "9":
            Console.Clear();
            DicionarioEvento.SelectEventoData();
            break;
        case "10":
            Console.Clear();
            DicionarioEvento.SelectEventoDia();
            break;
        case "0":
            return;

    }

 }
 
 