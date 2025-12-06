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
        /// Change la direction du jeu (horaire <-> antihoraire).
        /// </summary>
        public void ChangerDirection()
        {

        }

        /// <summary>
        /// Vérifie si un joueur a atteint les conditions de victoire (ex : main vide).
        /// </summary>
        public void ConditionVictoire()
        {

        }
        
        /// <summary>
        /// Advances the turn to the next player in the sequence.
        /// </summary>
        public void PasserJoueurSuivant()
        {

        }
    }
}
