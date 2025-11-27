namespace uno_game.classes
{
    class Joueur
    {
        public string Nom { get; set; }
        public List<Carte> Main {  get; set; }

        /// <summary>
        /// Allows the player to play a specific card from their hand.
        /// Validates that the card exists in the player's hand before removing it.
        /// </summary>
        /// <param name="carte">The card the player wants to play.</param>
        public void JouerCarte(Carte carte)
        {
            // later
        }

        /// <summary>
        /// Draws a card from the deck and adds it to the player's hand.
        /// Should be called when the player cannot or chooses not to play a card.
        /// </summary>
        public void Piocher()
        {
            ///
        }

        /// <summary>
        /// Takes the player card and the deck top card and verify if the player is able to play
        /// </summary>
        /// <param name="carte"></param>
        /// <param name="topCarte"></param>
        /// <returns></returns>
        public bool PeutJouer(Carte carte, Carte topCarte)
        {
            return true;
        }

        /// <summary>
        /// Returns the player's current hand of cards.
        /// Useful for display, validation, or game-logic decisions.
        /// </summary>
        /// <returns>A list containing all cards currently held by the player.</returns>
        public List<Carte> ObtenirMain()
        {
            return Main;
        }

        /// <summary>
        /// Calcule et retourne le total des points du joueur.
        /// Les points sont généralement basés sur les cartes restantes dans la main d'un joueur
        /// à la fin de la partie (ex : cartes numériques = valeur, cartes spéciales = points définis).
        /// </summary>
        /// <returns>Le total des points du joueur</returns>
        public int CompterPoints()
        {
            return 2;
        }
    }
}
