using Cap7;

class Program
{
    static void Main(string[] args)
    {
        Personagem player = new Personagem();
        string nome = "";
        int vida = 0;
        
        while (true)
        {
            Console.WriteLine("=========================== JOGO ==========================");
            Console.WriteLine("Bem-vindo ao criador de persongem!\n");

            try
            {
                Console.Write("Digite o seu nome: ");
                nome = Console.ReadLine();
                if (ValidarEntrada(nome)) continue;
                player.Nome = nome;

                Console.Write("Digite a quantidade de vida que deseja iniciar (1 - 9): ");
                vida = int.Parse(Console.ReadLine());
                if (ValidarEntrada(vida)) continue;
                player.Vida = vida;
                
                int slotsNulos = player.ContarNulos(player.Armas);
                while (slotsNulos > 0)
                {
                    Console.Write("Digite o nome de uma arma, você possui " + slotsNulos + " slots sobrando: ");
                    String arma = Console.ReadLine();
                    if (!ValidarEntrada(arma))
                    {
                        slotsNulos--;
                        player.AdicionarArma(arma);
                    }
                }
                
                Console.WriteLine("===========================================================");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                PrecioneEnter("Precione [ENTER] para digitar novamente...");
                Console.Clear();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                PrecioneEnter("Precione [ENTER] para digitar novamente...");
                Console.Clear();
            }
        }
        
        Console.Write("\n");
        MostraInformacaoPlayer(player);
        SimularBatalha(player);
    }

    public static bool ValidarEntrada(String entrada)
    {
        if (string.IsNullOrEmpty(entrada))
        {
            Console.WriteLine("Todos os atributos devem ser preenchidos.");
            PrecioneEnter("Precione [ENTER] para digitar novamente...");
            Console.Clear();
            return true;
        }
        
        return false;
    }
    
    public static bool ValidarEntrada(int entrada)
    {
        if (entrada < 1 || entrada > 9)
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número entre (1 - 9).");
            PrecioneEnter("Precione [ENTER] para digitar novamente...");
            Console.Clear();
            return true;
        }

        return false;
    }

    public static void PrecioneEnter(string mensagem)
    {
        Console.WriteLine("\n" + mensagem);
        Console.ReadKey();
    }
    
    public static void MostraInformacaoPlayer(Personagem player)
    {
        Console.WriteLine("=========================== INFO ==========================");
        Console.WriteLine("Personagem criado com sucesso!\n");
        Console.WriteLine("Nome: " + player.Nome);
        Console.WriteLine("Vida: " + player.Vida);
        player.MostraArmas();
        Console.WriteLine("===========================================================\n");
    }

    public static void SimularBatalha(Personagem player)
    {
        Random random = new Random();
        Personagem mob = new Personagem();
        mob.Nome = "Dragão";
        mob.Vida = 9;
        
        Console.WriteLine("========================= SIMULAÇÂO =======================");
        Console.WriteLine("Um monstro apareceu! Hora de lutar");
        Console.WriteLine("Seu dano será com base no valor sorteado por um dado, entre 0 a 6.\n");
        PrecioneEnter("Precione [ENTER] para comecar a batalha.");
        Console.Clear();
        
        while (true)
        {
            Console.WriteLine("========================== BATALHA ========================");
            
            Console.WriteLine("Nome: " + mob.Nome);
            Console.WriteLine("Vida: " + mob.Vida);
            String statusMob = (mob.Vida > 1) ? "Em jogo" : "Morto";
            Console.WriteLine("Status: " + statusMob);
            
            Console.WriteLine("---");
            
            Console.WriteLine("Nome: " + player.Nome);
            Console.WriteLine("Vida: " + player.Vida);
            String statusPlayer = (player.Vida > 1) ? "Em jogo" : "Morto";
            Console.WriteLine("Status: " + statusPlayer);

            if (player.Vida < 1 || mob.Vida < 1)
            {
                Console.WriteLine("===========================================================\n");
                Console.WriteLine("Fim do jogo");
                break;
            }
            
            player.MostraArmas();

            Console.WriteLine("===========================================================\n");
            
            try
            {
                Console.Write("Digite o número do slot da arma que deseja utilizar: ");
                int escolha = int.Parse(Console.ReadLine());
                if (ValidarEntrada(escolha) && escolha > 1 && escolha < 5 ) continue;
            
                PrecioneEnter("Precione [ENTER] para jogar um dado\n");
                int numeroAleatorioPlayer = random.Next(0, 7);
                int numeroAleatorioMob = random.Next(0, 7);

                Console.WriteLine("Número sorteado do player " + player.Nome + ": " + numeroAleatorioPlayer);
                Console.WriteLine("Número sorteado do mob " + mob.Nome + ": " + numeroAleatorioMob);

                if (numeroAleatorioPlayer < numeroAleatorioMob)
                {
                    player.Vida -= numeroAleatorioMob;
                    Console.WriteLine("O dano do mob foi maior");
                    PrecioneEnter("Precione [ENTER] para o proximo turno");
                    Console.Clear();
                } 
                else if (numeroAleatorioPlayer > numeroAleatorioMob)
                {
                    mob.Vida -= numeroAleatorioPlayer;
                    Console.WriteLine("O dano do player foi maior");
                    PrecioneEnter("Precione [ENTER] para o proximo turno");
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Empate entre os ataques!");
                    PrecioneEnter("Precione [ENTER] para o proximo turno");
                    Console.Clear();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                PrecioneEnter("Precione [ENTER] para digitar novamente...");
                Console.Clear();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                PrecioneEnter("Precione [ENTER] para digitar novamente...");
                Console.Clear();
            }
        }
    }
    
}