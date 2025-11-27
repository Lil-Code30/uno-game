namespace uno_game.classes
{
    class Jeu
    {
        public List<Joueur> Joueurs { get; set; }
        public Paquet Paquet { get; set; }

        // The discard pile where played cards are placed.
        public List<Carte> Defausse { get; set; }

        /// <summary>
        /// Direction of play. 
        /// 1 represents clockwise, -1 represents counterclockwise.
        /// </summary>
        public int Direction { get; set; } = 1;


        /// <summary>
        /// Initializes and starts a new UNO game.
        /// Sets up players, shuffles the deck, deals cards, 
        /// and prepares the first card in the discard pile.
        /// </summary>
        public void DemarrerPartie()
        {
            ///
        }

        /// <summary>
        /// Passe au tour du joueur suivant en tenant compte de la direction du jeu.
        /// Met à jour l'indice du joueur actuel.
        /// </summary>
        public void TourSuivant()
        {

        }

        /// <summary>
        /// Vérifie si la carte donnée peut être jouée par le joueur actuel.
        /// Retourne true si la carte est compatible avec la dernière carte de la défausse.
        /// </summary>
        /// <param name="carte">La carte à vérifier</param>
        /// <param name="joueur">Le joueur qui tente de jouer la carte</param>
        /// <returns>True si la carte peut être jouée, false sinon</returns>
        public bool verifierCarte(Carte carte, Joueur joueur)
        {
            return true;
        }

        /// <summary>
        /// Joue la carte donnée pour le joueur spécifié.
        /// Applique les effets de la carte si elle est spéciale et met à jour la défausse.
        /// </summary>
        /// <param name="joueur">Le joueur qui joue la carte</param>
        /// <param name="carte">La carte à jouer</param>
        public void JouerCarte(Joueur joueur, Carte carte)
        {

        }

        /// <summary>
        /// Change la direction du jeu (horaire <-> antihoraire).
        /// </summary>
        public void ChangerDirection()
        {

        }

        /// <summary>
        /// Permet au joueur spécifié de tirer une carte du paquet.
        /// Ajoute la carte à la main du joueur.
        /// </summary>
        /// <param name="joueur">Le joueur qui tire la carte</param>
        public void TirerCarte(Joueur joueur)
        {

        }

        /// <summary>
        /// Vérifie si un joueur a atteint les conditions de victoire (ex : main vide).
        /// </summary>
        public void ConditionVictoire()
        {

        }
    }
}
