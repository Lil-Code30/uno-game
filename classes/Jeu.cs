namespace uno_game.classes
{
    class Jeu
    {
        public List<Joueur> Joueurs { get; set; }
        public Paquet Paquet { get; set; }

        // The discard pile where played cards are placed.
        public List<Carte> Defausse { get; set; }
        public int IndexJoueurActuel { get; set; }

        /// <summary>
        /// Direction of play. 
        /// 1 represents clockwise, -1 represents counterclockwise.
        /// </summary>
        public int Direction { get; set; } = 1;


        public Jeu()
        {
            Joueurs =new List<Joueur>();
            Defausse = new List<Carte>();
            IndexJoueurActuel = 0;
        }

        /// <summary>
        /// Initializes and starts a new UNO game.
        /// Sets up players, shuffles the deck, deals cards, 
        /// and prepares the first card in the discard pile.
        /// </summary>
        public void DemarrerPartie()
        {
            Console.WriteLine("==== BIENVENUE DANS LE JEU UNO ====\n");

            int nombreJoueurs = 3;

            // creation des Joueurs
            Console.WriteLine("creation des Joueurs...");
            for(int i = 0; i < nombreJoueurs; i++)
            {
                Console.Write($"Nom du joueur {i + 1 }: ");
                string nom = Console.ReadLine();
                Joueurs.Add(new Joueur(nom));
            }

            // init Paquet et melanger
            Paquet = new Paquet();
            Paquet.Melanger();
            Console.WriteLine("Paquet mélangé !");

            // Distribution des cartes
            Console.WriteLine("Distribution de 7 Cartes par joueur...");
            foreach(Joueur joueur in Joueurs)
            {
                for(int i = 0; i < 7; i++)
                {
                    joueur.Piocher(Paquet);
                }
            }
            Console.WriteLine("Fin de la distribution des carte");

            // Retourner la première carte pour démarrer la défausse
            Carte premiereCarte = Paquet.TirerCarte();

            // S'assurer que la première carte n'est pas une carte spéciale complexe
            while(premiereCarte is CarteSpeciale carteSpec && (carteSpec.TypeEffect =="JokerPlus4" || carteSpec.TypeEffect == "Joker"))
            {
                Paquet.AjouterCarte(premiereCarte);
                Paquet.Melanger();
                premiereCarte = Paquet.TirerCarte();
            }

            Console.WriteLine("\n✅ Partie démarrée !");
            Console.WriteLine("Carte de départ :");
            premiereCarte.AfficherCarte();
        }


        /// <summary>
        /// Change la direction du jeu (horaire <-> antihoraire).
        /// </summary>
        public void ChangerDirection()
        {
            Direction *= -1;
            Console.WriteLine("La direction du jeu a changé !");
        }

        /// <summary>
        /// Vérifie si un joueur a atteint les conditions de victoire (ex : main vide).
        /// </summary>
        /// <returns>Le joueur gagnant, ou null si aucun joueur n'a gagné</returns>
        public Joueur ConditionVictoire()
        {
            foreach (Joueur joueur in Joueurs)
            {
                if (joueur.Main.Count == 0)
                {
                    return joueur; 
                }
            }
            return null;
        }

        /// <summary>
        /// Passe au tour du joueur suivant en tenant compte de la direction du jeu.
        /// </summary>
        public void PasserJoueurSuivant()
        {
            IndexJoueurActuel += Direction;

            // Gérer le retour au début ou à la fin de la liste
            if (IndexJoueurActuel >= Joueurs.Count)
            {
                IndexJoueurActuel = 0;
            }
            else if (IndexJoueurActuel < 0)
            {
                IndexJoueurActuel = Joueurs.Count - 1;
            }
        }
    }
}
