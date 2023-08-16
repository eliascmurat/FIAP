namespace Cap7;

public class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; }
    public string[] Armas { get; set; }

    public Personagem() { }
    
    public Personagem(string nome, int vida)
    {
        Nome = nome;
        Vida = vida;
        Armas = new string[4];
    }

    public void adicionarArma(string arma)
    {
        for (int i = 0; i < Armas.Length; i++)
        {
            if (Armas[i] == null)
            {
                Armas[i] = arma;
                Console.WriteLine("Arma " + arma + " adicionada ao inventário.");
            }
            else
            {
                Console.WriteLine("Inventário de armas está cheio. Não é possível adicionar mais armas.");
            }
        }
    }
    
    public void adicionarArmas(string[] armas)
    {
        foreach (var arma in armas)
        {
            adicionarArma(arma);   
        }
    }

    public void mostraArmas()
    {
        Console.WriteLine("Inventário de armas:");
        for (int i = 0; i < Armas.Length; i++)
        {
            string arma = Armas[i];
            Console.WriteLine("Slot " + (i + 1) + ": " + (arma != null ? arma : "Vazio"));
        }
    }
}