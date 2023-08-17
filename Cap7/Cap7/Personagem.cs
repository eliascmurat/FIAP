namespace Cap7;

public class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; }
    public string[] Armas { get; set; }

    public Personagem()
    {
        Armas = new string[4];
    }

    public Personagem(string nome, int vida)
    {
        Nome = nome;
        Vida = vida;
        Armas = new string[4];
    }

    public void AdicionarArma(string arma)
    {
        for (int i = 0; i < Armas.Length; i++)
        {
            if (Armas[i] == null)
            {
                Armas[i] = arma;
                Console.WriteLine(arma + ", adicionada no slot: " + (i + 1));
                break;
            }
            
            //Console.WriteLine("Slot " + (i + 1) + " está cheio. Não é possível adicionar mais armas.");
        }
    }
    
    public void AdicionarArmas(string[] armas)
    {
        foreach (var arma in armas)
        {
            AdicionarArma(arma);   
        }
    }

    public void MostraArmas()
    {
        Console.WriteLine("Inventário de armas:");
        for (int i = 0; i < Armas.Length; i++)
        {
            string arma = Armas[i];
            Console.WriteLine("Slot " + (i + 1) + ": " + (arma != null ? arma : "Vazio"));
        }
    }
    
    public int ContarNulos<T>(T[] array)
    {
        int contador = 0;
        
        foreach (T elemento in array)
        {
            if (elemento == null || elemento.Equals(default(T))) contador++;
        }
        
        return contador;
    }
}