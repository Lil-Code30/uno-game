namespace uno_game.classes
{
    class Paquet
    {
        private List<Carte> cartes;

        public Paquet()
        {
            cartes = new List<Carte>();
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

                cartes.Add(new CarteNumerique(couleur, 0));

                // Ajout des carte 1-9 (deux cartes de chaque chiffre)
                for(int i = 1; i <= 9; i++)
                {
                    cartes.Add(new CarteNumerique(couleur, i));
                    cartes.Add(new CarteNumerique(couleur, i));
                }

                // Ajout des cartes spéciales (2 de chaque)
                cartes.Add(new CarteSpeciale( couleur, "Plus2"));
                cartes.Add(new CarteSpeciale( couleur, "Plus2"));

                cartes.Add(new CarteSpeciale( couleur, "Inverser"));
                cartes.Add(new CarteSpeciale( couleur, "Inverser"));

                cartes.Add(new CarteSpeciale( couleur, "Passer"));
                cartes.Add(new CarteSpeciale( couleur, "Passer"));
            }

            // Ajout 4 Jokers
            for(int i = 1; i<=4; i++)
            {
                cartes.Add(new CarteSpeciale( "NOIR", "Joker"));
            }

            // Ajout 4 Joker +4
            for(int i =1; i<=4; i++)
            {
                cartes.Add(new CarteSpeciale("NOIR", "JokerPlus4"));
            }
            

        }


        /// <summary>
        /// Mélange le paquet aléatoirement.
        /// Fisher–Yates shuffle : http://stackoverflow.com/questions/273313/randomize-a-listt
        /// </summary>
        public void Melanger()
        {
            Random rng = new Random();
            int n = cartes.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carte temp = cartes[k];
                cartes[k] = cartes[n];
                cartes[n] = temp;
            }
        }

        /// <summary>
        /// Détermine si le paquet est vide.
        /// </summary>
        /// <returns>Vrai si aucune carte ne reste dans le paquet ; sinon, faux.</returns>
        public bool EstVide()
        {
            if (cartes.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Retire et renvoie la carte du dessus du paquet.
        /// </summary>
        /// <returns> La carte retirée du dessus du paquet</returns>
        public Carte TirerCarte()
        {
            Carte newCarte = cartes[0];
            // -1 carte de la liste
            cartes.RemoveAt(0);

            return newCarte;
        }

        /// <summary>
        /// Ajoute une carte dans le paquet.
        /// Utile pour remettre une carte dans le paquet après qu'elle a été jouée ou pour reconstituer le paquet.
        /// </summary>
        /// <param name="carte">La carte à ajouter au paquet</param>
        public void AjouterCarte(Carte carte)
        {
            cartes.Add(carte);
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

                // du 1er - avant derniere
                for(int i = 0; i < defausse.Count - 1 ; i++)
                {
                    cartes.Add(defausse[i]);
                }

                defausse.Clear();
                defausse.Add(lastCarte);

                Melanger();
            }
        }
    }
}
