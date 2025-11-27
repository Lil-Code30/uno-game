namespace uno_game.classes
{
    class Paquet
    {
        public List<Carte> Cartes { get; set; }

        /// <summary>
        /// Shuffles the deck using a random distribution.
        /// </summary>
        public void Melanger()
        {
            // TODO: Implement shuffle logic
        }

        /// <summary>
        /// Draws the top card from the deck.
        /// Returns the drawn card and removes it from the deck.
        /// </summary>
        public Carte Piocher()
        {
            return new Carte(); // TODO: Implement draw logic 
        }

        /// <summary>
        /// Determines whether the deck is empty.
        /// </summary>
        /// <returns>True if no cards remain in the deck; otherwise, false.</returns>
        public bool estVide()
        {
            if (Cartes.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
