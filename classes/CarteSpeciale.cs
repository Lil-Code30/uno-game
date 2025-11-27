namespace uno_game.classes
{
    class CarteSpeciale : Carte
    {
       
        /// <summary>
        /// Type of special effect associated with this card
        /// (e.g., "Skip", "Reverse", "Plus2", "Wild", "WildPlus4").
        /// </summary>
        public string TypeEffect { get; set; }

        /// <summary>
        /// Applies the card's special effect to the current game state.
        /// </summary>
        /// <param name="jeu">The current game instance where the effect is applied.</param>
        public void AppliquerEffet(Jeu jeu)
        {
            // TODO: Implement effect logic
        }
    }
}
