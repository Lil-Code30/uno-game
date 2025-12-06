namespace uno_game.classes
{
    class Joueur
    {
        public string Nom { get; set; }
        public List<Carte> Main {  get; set; }

        public Joueur(string nom)
        {
            this.Nom = nom;
            this.Main = new List<Carte>();
        }

        /// <summary>
        /// Allows the player to play a specific card from their hand.
        /// Validates that the card exists in the player's hand before removing it.
        /// </summary>
        /// <param name="carte">The card the player wants to play.</param>
        public void JouerCarte(Carte carte)
        {
            if (Main.Contains(carte))
            {
                Main.Remove(carte);
            }
        }

        /// <summary>
        /// Draws a card from the deck and adds it to the player's hand.
        /// Should be called when the player cannot or chooses not to play a card.
        /// </summary>
        public void Piocher(Paquet paquet)
        {
            if (!paquet.EstVide())
            {
                Carte carte = paquet.TirerCarte();
                Main.Add(carte);
            }
        }

        /// <summary>
        /// Takes the player card and the deck top card and verify if the player is able to play
        /// </summary>
        /// <param name="carte"></param>
        /// <param name="topCarte"></param>
        /// <returns></returns>
        public bool PeutJouer(Carte carte, Carte topCarte)
        {
           return carte.EstCompatible(topCarte);
        }

        /// <summary>
        /// Display the player's current hand of cards.
        /// </summary>
        public void AfficherMain()
        {
           Console.WriteLine($"\n==== Main de {Nom} avec {Main.Count} Cartes ====");
            for(int i = 0; i < Main.Count; i++)
            {
                if (Main[i] is CarteNumerique carteNum)
                {
                    Console.Write($"{i + 1} - ");
                    carteNum.AfficherCarte();
                }

                if (Main[i] is CarteSpeciale carteSpec)
                {
                    Console.Write($"{i + 1} - ");
                    carteSpec.AfficherCarte();
                }
            }
        }

        /// <summary>
        /// Announces "UNO" when the player has only one card remaining.
        /// </summary>
        public void DireUNO()
        {
            if(Main.Count == 1)
            {
                Console.WriteLine($"{this.Nom} dire UNOOOOO!");
            }
        }
    }
}
