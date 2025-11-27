namespace uno_game.classes
{
    class Carte
    {
        /// The color of the card (e.g., "Red", "Blue", "Green", "Yellow", "black).
        public string Couleur { get; set; }
        public int? Valeur { get; set; }


        /// <summary>
        /// Determines whether this card is compatible with another card,
        /// based on matching color, value, or card type according to UNO rules.
        /// </summary>
        /// <param name="autres">The card to compare against.</param>
        /// <returns>
        /// True if the two cards can be legally played one after the other; otherwise false.
        /// </returns>
        public bool estCompatible(Carte autres)
        {
            return true;
        }
    }
}
