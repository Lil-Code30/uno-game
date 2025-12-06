namespace uno_game.classes
{
    class Paquet
    {
        public List<Carte> Cartes { get; set; }

        public Paquet()
        {
            Cartes = new List<Carte>();
            InitialiserPaquet();

        }

        /// <summary>
        /// Initialise un paquet de 108 cartes UNO selon les règles officielles.
        /// </summary>
        private void InitialiserPaquet()
        {
            string[] couleurs = { "ROUGE", "VERT", "BLEU", "JAUNE" };

            // pour chaque couleur
            foreach(string couleur in couleurs)
            {
                
                Cartes.Add(new CarteNumerique("Numerique", couleur, 0));

                // Ajout des carte 1-9 (deux cartes de chaque chiffre)
                for(int i = 1; i <= 9; i++)
                {
                    Cartes.Add(new CarteNumerique("Numerique", couleur, i));
                    Cartes.Add(new CarteNumerique("Numerique", couleur, i));
                }

                // Ajout des cartes spéciales (2 de chaque)
                Cartes.Add(new CarteSpeciale("Speciale", couleur, "Plus2"));
                Cartes.Add(new CarteSpeciale("Speciale", couleur, "Plus2"));

                Cartes.Add(new CarteSpeciale("Speciale", couleur, "Inverser"));
                Cartes.Add(new CarteSpeciale("Speciale", couleur, "Inverser"));

                Cartes.Add(new CarteSpeciale("Speciale", couleur, "Passer"));
                Cartes.Add(new CarteSpeciale("Speciale", couleur, "Passer"));
            }

            // Ajout 4 Jokers
            for(int i = 1; i<=4; i++)
            {
                Cartes.Add(new CarteSpeciale("Speciale", "NOIR", "Joker"));
            }

            // Ajout 4 Joker +4
            for(int i =1; i<=4; i++)
            {
                Cartes.Add(new CarteSpeciale("Speciale", "NOIR", "JokerPlus4"));
            }
            

        }


        /// <summary>
        /// Mélange le paquet aléatoirement.
        /// Fisher–Yates shuffle : http://stackoverflow.com/questions/273313/randomize-a-listt
        /// </summary>
        public void Melanger()
        {
            Random rng = new Random();
            int n = Cartes.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carte temp = Cartes[k];
                Cartes[k] = Cartes[n];
                Cartes[n] = temp;
            }
        }

        /// <summary>
        /// Détermine si le paquet est vide.
        /// </summary>
        /// <returns>Vrai si aucune carte ne reste dans le paquet ; sinon, faux.</returns>
        public bool EstVide()
        {
            if (Cartes.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Removes and returns the top card from the deck.
        /// </summary>
        /// <returns>The card removed from the top of the deck, or null if the deck is empty.</returns>
        public Carte TirerCarte()
        {
            if (EstVide())
            {
                // call the Reconstituer function here
                return null; // for the moment
            }

            Carte newCarte = Cartes[0];
            // -1 carte de la liste
            Cartes.RemoveAt(0);

            return newCarte;
        }

        /// <summary>
        /// Ajoute une carte dans le paquet.
        /// Utile pour remettre une carte dans le paquet après qu'elle a été jouée ou pour reconstituer le paquet.
        /// </summary>
        /// <param name="carte">La carte à ajouter au paquet</param>
        public void AjouterCarte(Carte carte)
        {
            Cartes.Add(carte);
        }

        /// <summary>
        /// Reconstitue le paquet à partir de la défausse.
        /// Mélange les cartes de la défausse et les ajoute au paquet.
        /// Garde la derniere carte de la defausse
        /// </summary>
        /// <param name="defausse">Liste des cartes de la défausse à remettre dans le paquet</param>
        public void Reconstituer(List<Carte> defausse)
        {
            if(defausse.Count > 1)
            {
                
                Carte lastCarte = defausse[defausse.Count - 1];  

                // du 1 - avant derniere
                for(int i = 0; i < defausse.Count - 1 ; i++)
                {
                    Cartes.Add(defausse[i]);
                }

                defausse.Clear();
                defausse.Add(lastCarte);

                Melanger();
            }
        }
    }
}
