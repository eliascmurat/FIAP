using Cap7;

class Program
{
    static void Main(string[] args)
    {
        string nome = "";
        int vida = 0;
        
        while (true)
        {
            Console.WriteLine("=========================== JOGO ==========================");
            Console.WriteLine("Bem-vindo ao criador de persongem!");

            try
            {
                Console.Write("Digite o seu nome: ");
                nome = Console.ReadLine();
                if (validarEntrada(nome)) continue;

                Console.Write("Digite a quantidade de vida que deseja iniciar (1 - 9): ");
                vida = int.Parse(Console.ReadLine());
                if (validarEntrada(vida)) continue;


                Console.WriteLine("===========================================================");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                precioneEnter();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow aqui não parceiro! Sem vulnerabilidades por aqui!");
                precioneEnter();
            }
        }
        
        Personagem player = new Personagem(nome, vida);
        Console.Write("\n");
        mostraInformacaoPlayer(player);
    }

    public static bool validarEntrada(String entrada)
    {
        if (string.IsNullOrEmpty(entrada))
        {
            Console.WriteLine("Todos os atributos devem ser preenchidos.");
            precioneEnter();
            return true;
        }
        
        return false;
    }
    
    public static bool validarEntrada(int entrada)
    {
        if (entrada < 1 || entrada > 9)
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número entre (1 - 9).");
            precioneEnter();
            return true;
        }

        return false;
    }

    public static void precioneEnter()
    {
        Console.WriteLine("\nPrecione [ENTER] para digitar novamente...");
        Console.ReadKey();
        Console.Clear();
    }
    
    public static void mostraInformacaoPlayer(Personagem player)
    {
        Console.WriteLine("=========================== INFO ==========================");
        Console.WriteLine("Personagem criado com sucesso!");
        Console.WriteLine("Nome: " + player.Nome);
        Console.WriteLine("Vida: " + player.Vida);
        //player.mostraArmas();
        Console.WriteLine("===========================================================\n");
    }
    
    
}