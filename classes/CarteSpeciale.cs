namespace uno_game.classes
{
    class CarteSpeciale : Carte
    {
       
        /// <summary>
        /// Type effet
        /// ("Passer", "Inverser", "Plus2", "Joker", "JokerPlus4").
        /// </summary>
        public string TypeEffect { get; private set; }
        
        public CarteSpeciale(string couleur, string typeEffect) : base("Speciale", couleur )
        {
            this.TypeEffect = typeEffect;
        }

        /// <summary>
        /// Permet au joeur de choisir une nouvelle couleur pour les Jokers
        /// </summary>
        private void ChoisirCouleur()
        {
            Console.WriteLine("\nChoississez une couleur :");
            Console.WriteLine("1. ROUGE");
            Console.WriteLine("2. VERT");
            Console.WriteLine("3. BLEU");
            Console.WriteLine("4. JAUNE");

            int choix = 0;
            bool choixValide = false;

            while (!choixValide)
            {
                Console.WriteLine("Votre choix (1-4) :");
                choix = Int32.Parse(Console.ReadLine());

                if (choix >= 1 && choix <= 4)
                {
                    choixValide = true;
                }
                else
                {
                    Console.WriteLine("Choix Invalide. Veuillez entrer un nombre entre 1 et 4");
                }
            }

            switch (choix)
            {
                case 1:
                    this.Couleur = "ROUGE";
                    break;
                case 2:
                    this.Couleur = "VERT";
                    break;
                case 3:
                    this.Couleur = "BLEU";
                    break;
                case 4:
                    this.Couleur = "JAUNE";
                    break;
            }

            Console.WriteLine($"Nouvelle couleur : {this.Couleur}");
        }

        /// <summary>
        /// Applique l'effet spécial de la carte à l'état actuel de la partie.
        /// </summary>
        /// <param name="jeu">L'instance actuelle du jeu sur laquelle l'effet est appliqué.</param>
        public void AppliquerEffet(Jeu jeu)
        {
            switch (TypeEffect)
            {
                case "Plus2":
                    Console.WriteLine($"Effet +2 ! Le joeur suivant pioche 2 cartes.");
                    int prochainJoueur = jeu.IndexJoueurActuel + jeu.Direction;
                    if(prochainJoueur >= jeu.Joueurs.Count)
                    {
                        prochainJoueur = 0;
                    }
                    if(prochainJoueur < 0)
                    {
                        prochainJoueur = jeu.Joueurs.Count - 1;
                    }

                    // joueur pioche 2 cartes
                    for (int i = 0; i < 2; i++)
                    {
                        if (jeu.Paquet.EstVide())
                        {
                            jeu.Paquet.Reconstituer(jeu.Defausse);
                        }
                        jeu.Joueurs[prochainJoueur].Piocher(jeu.Paquet);
                    }

                    jeu.PasserJoueurSuivant();
                    break;
                case "Inverser":
                    Console.WriteLine("Effet Inverser ! Le sens de jeu change.");
                    jeu.ChangerDirection();
                    break;
                case "Passer":
                    Console.WriteLine("Effet Passer ! Le joueur suivant perd son tour.");
                    jeu.PasserJoueurSuivant();  
                    break;
                case "Joker":
                    Console.WriteLine("Joker joué ! Choississez une nouvelle couleur.");
                    ChoisirCouleur();
                    break;
                case "JokerPlus4":
                    Console.WriteLine("Joker +4 ! Le jouer suivant pioche 4 cartes et perd son tour.");
                    ChoisirCouleur();

                    int prochainJoueur4 = jeu.IndexJoueurActuel + jeu.Direction;
                    if (prochainJoueur4 >= jeu.Joueurs.Count)
                    {
                        prochainJoueur4 = 0;
                    }
                    if (prochainJoueur4 < 0) 
                    { 
                        prochainJoueur4 = jeu.Joueurs.Count - 1; 
                    }

                    // joueur pioche 4 cartes
                    for (int i = 0; i < 4; i++)
                    {
                        if (jeu.Paquet.EstVide())
                        {
                            jeu.Paquet.Reconstituer(jeu.Defausse);
                        }
                        jeu.Joueurs[prochainJoueur4].Piocher(jeu.Paquet);
                    }

                    // le joueur qui pioche perd son tour
                    jeu.PasserJoueurSuivant();
                    break;
            }
        }

        /// <summary>
        /// Détermine si cette carte est compatible avec une autre carte,
        /// </summary>
        /// <param name="courant">La carte à laquelle comparer.</param>
        /// <returns>
        /// Vrai si les deux cartes peuvent être jouées; sinon, faux.
        /// </returns>
        public override bool EstCompatible(Carte courant)
        {
            // Joker ou JokerPlus2 toujours compatible
            if( this.TypeEffect == "Joker" || this.TypeEffect == "JokerPlus4")
            {
                return true;
            }

            // carte speciale compatible si meme couleur ou effet
            if (courant is CarteSpeciale carteSpec)
            {
                return this.Couleur == courant.Couleur || this.TypeEffect == carteSpec.TypeEffect;

            }

            // meme couleur
            return this.Couleur == courant.Couleur;
        }

        /// <summary>
        /// Affiche une représentation textuelle de la carte, incluant son type d’effet et sa couleur
        /// </summary>
        public override void AfficherCarte()
        {
            Console.WriteLine($"[Carte:{TypeEffect} - {Couleur}]");
        }
    }
}
