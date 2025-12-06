namespace uno_game.classes
{
    class Jeu
    {
        public List<Joueur> Joueurs { get; set; }
        public Paquet Paquet { get; set; }

        // La pile de défausse où les cartes jouées sont placées.
        public List<Carte> Defausse { get; set; }
        public int IndexJoueurActuel { get; private set; }

        /// <summary>
        /// Sens du jeu.
        /// 1 représente le sens horaire, -1 représente le sens antihoraire.
        /// </summary>
        public int Direction { get; set; } = 1;


        public Jeu()
        {
            Joueurs = new List<Joueur>();
            Defausse = new List<Carte>();
            IndexJoueurActuel = 0;
        }

        /// <summary>
        /// Initialise et démarre une partie d’UNO.
        /// Configure les joueurs
        /// Initialise et mélange le paquet, distribue les cartes
        /// et prépare la première carte de la pile de défausse.
        /// </summary>
        public void DemarrerPartie()
        {
            int nombreJoueurs = 3;

            // creation des Joueurs
            Console.WriteLine("creation des Joueurs...");
            for (int i = 0; i < nombreJoueurs; i++)
            {
                Console.Write($"Nom du joueur {i + 1}: ");
                string nom = Console.ReadLine();
                Joueurs.Add(new Joueur(nom));
            }

            // init Paquet et melanger
            Paquet = new Paquet();
            Paquet.Melanger();
            Console.WriteLine("Paquet mélangé !");

            // Distribution des cartes
            Console.WriteLine("Distribution de 7 Cartes par joueur...");
            foreach (Joueur joueur in Joueurs)
            {
                for (int i = 0; i < 7; i++)
                {
                    joueur.Piocher(Paquet);
                }
            }
            Console.WriteLine("Fin de la distribution des carte");

            // Retourner la première carte pour démarrer la défausse
            Carte premiereCarte = Paquet.TirerCarte();

            // S'assurer que la première carte n'est pas une carte spéciale complexe
            while (premiereCarte is CarteSpeciale carteSpec && (carteSpec.TypeEffect == "JokerPlus4" || carteSpec.TypeEffect == "Joker"))
            {
                Paquet.AjouterCarte(premiereCarte);
                Paquet.Melanger();
                premiereCarte = Paquet.TirerCarte();
            }

            Console.WriteLine("\nPartie démarrée !");
            Console.WriteLine("Carte de départ :");

            Defausse.Add(premiereCarte);
            premiereCarte.AfficherCarte();         

            // Lancer la boucle de jeu
            BoucleDeJeu();
        }

        /// <summary>
        /// Boucle principale du jeu
        /// </summary>
        private void BoucleDeJeu()
        {
            bool partieEnCours = true;
            while (partieEnCours)
            {
                Joueur joueurActuel = Joueurs[IndexJoueurActuel];

                Console.WriteLine($"\nC'est le tour de {joueurActuel.Nom}");

                // Afficher la carte courante sur la défausse
                AfficherCarteCourante();

                // Afficher la main du joueur
                joueurActuel.AfficherMain();

                // Obtenir la carte au sommet de la défausse
                int indexLastCarte = Defausse.Count - 1;
                Carte carteCourante = Defausse[indexLastCarte];

                // Verifier si le joueur a au moins une carte jouable
                if(!PossedeCoupJouable(joueurActuel, carteCourante))
                {
                    Console.WriteLine("\nVous n'avez aucune carte jouable.");
                    Console.WriteLine("Vous devez piocher une carte.");
                    Console.WriteLine("\nAppuyez sur Entrée pour piocher...");
                    Console.ReadLine();

                    //verifier si le paquet est vide avant de piocher
                    if (Paquet.EstVide())
                    {
                        Console.WriteLine("Le paquet est vide ! Reconstitution...");
                        Paquet.Reconstituer(Defausse);
                    }

                    joueurActuel.Piocher(Paquet);
                    Console.WriteLine("Carte piochée !");

                    // Vérifier si la carte piochée est jouable
                    int indexCartePiochee = joueurActuel.Main.Count - 1;
                    Carte cartePiochee = joueurActuel.Main[indexCartePiochee];
                    if (cartePiochee.EstCompatible(carteCourante))
                    {
                        Console.WriteLine("\nLa carte que vous venez de piocher est jouable !");
                        JouerCarte(joueurActuel, cartePiochee);

                        //verifier la victoire 
                        if (ConditionVictoire(joueurActuel))
                        {
                            AfficherGagnant(joueurActuel);
                            partieEnCours = false;
                            break;
                        }

                        // Verifier UNO
                        if(joueurActuel.Main.Count == 1)
                        {
                            joueurActuel.DireUNO();
                        }
                    }

                    PasserJoueurSuivant();
                    continue;
                }

                // le joueur a des cartes jouables - choisie une carte 
                int choix = 0;
                bool choixValide = false;

                while (!choixValide)
                {            
                    Console.Write("\nChoisissez le numéro de la carte à jouer (ou 0 pour piocher) : ");
                    choix = Int32.Parse(Console.ReadLine());

                    // le joueur choisit de piocher
                    if (choix == 0)
                    {
                        if (Paquet.EstVide())
                        {
                            Console.WriteLine("Le paquet est vide ! Reconstitution...");
                            Paquet.Reconstituer(Defausse);
                        }

                        joueurActuel.Piocher(Paquet);
                        choixValide = true;
                    } else if (choix > 0 && choix <= joueurActuel.Main.Count)
                    {
                        Carte carteChoisie = joueurActuel.Main[choix - 1];
                        if(joueurActuel.PeutJouer(carteChoisie, carteCourante))
                        {
                            JouerCarte(joueurActuel, carteChoisie);
                            choixValide = true;

                            // Verifier la victoire 
                            if (ConditionVictoire(joueurActuel))
                            {
                                AfficherGagnant(joueurActuel);
                                partieEnCours = false;
                                break;
                            }

                            // Vérifier UNO
                            if (joueurActuel.Main.Count == 1)
                            {
                                joueurActuel.DireUNO();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cette carte ne peut pas être jouable ! Elle ne correspond pas à la carte actuelle.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Numéro invalide ! Choisissez un numéro entre 1 et {joueurActuel.Main.Count}.");
                    }
                }

                if (partieEnCours)
                {
                    PasserJoueurSuivant();
                }
            }

        }

        /// <summary>
        /// Affiche la carte actuellement au sommet de la défausse
        /// </summary>
        private void AfficherCarteCourante()
        {
            if(Defausse.Count > 0)
            {
                Console.WriteLine("\n=== CARTE ACTUELLE SUR LA TABLE ===");
                int indexLastCarte = Defausse.Count - 1;
                Carte carteCourante = Defausse[indexLastCarte];
                carteCourante.AfficherCarte();
                Console.WriteLine("===================================\n");
            }
        }

        /// <summary>
        /// Vérifie si le joueur possède au moins une carte jouable
        /// </summary>
        private bool PossedeCoupJouable(Joueur joueur, Carte carteCourante)
        {
            foreach(Carte carte in joueur.Main)
            {
                if (carte.EstCompatible(carteCourante))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Joue la carte donnée pour le joueur spécifié
        /// </summary>
        private void JouerCarte(Joueur joueur, Carte carte)
        {
            joueur.JouerCarte(carte);
            Defausse.Add(carte);

            Console.WriteLine($"\n{joueur.Nom} joue :");
            carte.AfficherCarte();

            // Appliquer l'effet si c'est une carte spéciale
            if(carte is CarteSpeciale carteSpec)
            {
                carteSpec.AppliquerEffet(this);
            }
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
        /// Vérifie si un joueur a atteint les conditions de victoire
        /// </summary>
        public bool ConditionVictoire(Joueur joueur)
        {
            return joueur.Main.Count == 0;
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

        /// <summary>
        /// Affiche le gagnant 
        /// </summary>
        private void AfficherGagnant(Joueur gagnant)
        {
            Console.WriteLine("====== PARTIE TERMINÉE ! ======");
            Console.WriteLine($"\n{gagnant.Nom} A GAGNÉ LA PARTIE !");
            Console.WriteLine($"\nFélicitations {gagnant.Nom} ! Vous n'avez plus de cartes !\n");
            Console.WriteLine("=================================================\n");
        }
    }
}
