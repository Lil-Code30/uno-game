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
        /// Permet au joueur de jouer une carte spécifique de sa main.
        /// Vérifie que la carte existe dans la main du joueur avant de la retirer.
        /// </summary>
        /// <param name="carte">La carte que le joueur souhaite jouer.</param>
        public void JouerCarte(Carte carte)
        {
            if (Main.Contains(carte))
            {
                Main.Remove(carte);
            }
        }

        /// <summary>
        /// Pioche une carte du paquet et l’ajoute à la main du joueur.
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
        /// Prend la carte du joueur et la carte courante, puis vérifie si le joueur peut jouer cette carte.
        /// </summary>
        /// <param name="carte"></param>
        /// <param name="carteCourant"></param>
        /// <returns></returns>
        public bool PeutJouer(Carte carte, Carte carteCourant)
        {
           return carte.EstCompatible(carteCourant);
        }

        /// <summary>
        /// Affiche la main actuelle du joueur.
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
