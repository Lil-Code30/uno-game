using uno_game.classes;
class Program
{
    static void Main()
    {
        bool continuerAJouer = true;

        while (continuerAJouer)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║        🎴 BIENVENUE AU UNO 🎴          ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            try
            {
                Jeu jeu = new Jeu();
                jeu.DemarrerPartie();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Erreur : {ex.Message}");
            }

            Console.WriteLine("\n\nVoulez-vous jouer une nouvelle partie ? (o/n) : ");
            string reponse = Console.ReadLine()?.ToLower();

            continuerAJouer = (reponse == "o" || reponse == "oui");
        }

        Console.WriteLine("\n Merci d'avoir joué ! À bientôt !");

    }
}