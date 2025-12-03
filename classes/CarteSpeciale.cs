namespace uno_game.classes
{
    class CarteSpeciale : Carte
    {
       
        /// <summary>
        /// Type of special effect associated with this card
        /// (e.g., "Passer", "Inverser", "Plus2", "Joker", "JokerPlus4").
        /// </summary>
        public string TypeEffect { get; set; }
        
        public CarteSpeciale(string type, string couleur, int points, string typeEffect) : base(type, couleur, points )
        {
            this.TypeEffect = typeEffect;
        }

        /// <summary>
        /// Applies the card's special effect to the current game state.
        /// </summary>
        /// <param name="jeu">The current game instance where the effect is applied.</param>
        public void AppliquerEffet(Jeu jeu)
        {
            // TODO: Implement effect logic
        }

        public override bool estCompatible(Carte courant)
        {
            // A special card is compatible if it matches the color or is a Wild card
            return this.Couleur == courant.Couleur || this.TypeEffect.StartsWith("Wild");
        }
    }
}
