// List<string> bandas = new List<string>();
using System.Globalization;

Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();
bandas.Add("Linkin Park", new List<int> { 10, 8, 9 });
bandas.Add("The Beatles", new List<int> {6, 9});
bandas.Add("System of a Down", new List<int>());

void main()
{
    ExibirOpcoesMenu();
}

void ExibirLogo()
{
    Console.Clear();
    Console.WriteLine(@"
    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
}

void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine(" [1] - Registrar banda");
    Console.WriteLine(" [2] - Listar todas as bandas");
    Console.WriteLine(" [3] - Avaliar banda");
    Console.WriteLine(" [4] - Exibir a média de uma banda");
    Console.WriteLine(" [0] - Sair");

    Console.Write("\n --> ");
    int opc = int.Parse(Console.ReadLine()!);
    Menu(opc);
}

void Menu(int opc)
{
    ExibirLogo();
    switch (opc)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            ExibirBandas();
            Console.WriteLine("\n Pressione qualquer tecla para retornar ao Menu Principal \n");
            Console.ReadKey();
            ExibirOpcoesMenu();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            ExibirMediaBanda();
            Console.WriteLine("\n Pressione qualquer tecla para retornar ao Menu Principal \n");
            Console.ReadKey();
            ExibirOpcoesMenu();
            break;
        case 0:
        ExibirLogo();
        ExibirPlaca("Screen Sound Encerrado");
        Environment.Exit(0);
            break;
        default:
            Console.WriteLine("\n Escolha uma das opções dísponíveis\n");
            ExibirOpcoesMenu();
            break;
    }
}

void RegistrarBandas()
{
    ExibirPlaca("Registro de Bandas");
    Console.Write(" Nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandas.Add(nomeBanda, new List<int>());
    ExibirLogo();
    Console.WriteLine($"\n      A banda {nomeBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    ExibirOpcoesMenu();
}

void ExibirBandas()
{
    ExibirPlaca("Bandas Cadastradas");

    // for(int i=0; i<bandas.Count; i++){
    //     Console.WriteLine($" -: {bandas[i]}");
    // }

    foreach (string banda in bandas.Keys)
    {
        Console.WriteLine($" - {banda}");
    }
}

void AvaliarBanda()
{
    ExibirBandas();
    ExibirPlaca("Avaliar Banda"); 
    Console.Write(" Banda que será avaliada: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        Console.Write($" Nota para {nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeBanda].Add(nota);
        ExibirLogo();
        Console.WriteLine($"\n    A nota {nota} foi registrada com sucesso para a banda {nomeBanda}");
        Thread.Sleep(2000);
        ExibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine($" A banda {nomeBanda} não foi encontrada");
        Thread.Sleep(2000);
        ExibirLogo();
        AvaliarBanda();
    }
}

void ExibirMediaBanda(){
    ExibirBandas();
    Console.Write("\n Banda escolhida: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        int soma = 0;
        List<int> notas = bandas[nomeBanda];
        foreach(int nota in notas){
            soma += nota;
        }
        double media = (double)soma / notas.Count;
        ExibirLogo();
        // Console.Write(notas.Count);
        Console.Write($" Média da banda {nomeBanda}: {media.ToString("F1", CultureInfo.InvariantCulture)}");
    }
    else
    {
        Console.WriteLine($" A banda {nomeBanda} não foi encontrada");
        Thread.Sleep(2000);
        ExibirLogo();
        ExibirMediaBanda();
    }
}

void ExibirPlaca(string titulo)
{
    int qtdChar = titulo.Length + 4;
    string anderlines = string.Empty.PadLeft(qtdChar, '_');
    string tracos = string.Empty.PadLeft(qtdChar, '-');

    Console.WriteLine(" " + anderlines);
    Console.WriteLine($" | {titulo} |");
    Console.WriteLine(" " + tracos + "\n");
}

main();