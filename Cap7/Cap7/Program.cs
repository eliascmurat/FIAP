using Cap7;

class Program
{
    static void Main(string[] args)
    {
        string[] armas = { "Espada de madeira", "Arco e flecha", "Escudo", "Pedaço de pão" };
        
        Personagem player = new Personagem();
        player.Nome = "FIAPINHO";
        player.Vida = 9;
        player.adicionarArmas(armas);
        
        // TODO: Teste (2)
    }
}