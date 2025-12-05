namespace uno_game.classes
{
    abstract class Carte
    {
        public string Couleur { get; set; }
        public string Type { get; set; }

        public Carte(string type, string couleur)
        {
            this.Type = type;
            this.Couleur = couleur;
        }


        /// <summary>
        /// Determines whether this card is compatible with another card,
        /// based on matching color, value, or card type according to UNO rules.
        /// </summary>
        /// <param name="courant">The card to compare against.</param>
        /// <returns>
        /// True if the two cards can be legally played one after the other; otherwise false.
        /// </returns>
        public abstract bool estCompatible(Carte courant);
    }
}
