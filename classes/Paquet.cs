using static System.Runtime.InteropServices.JavaScript.JSType;

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

        /// <summary>
        /// Reconstitue le paquet à partir de la défausse.
        /// Mélange les cartes de la défausse et les ajoute au paquet.
        /// </summary>
        /// <param name="defausse">Liste des cartes de la défausse à remettre dans le paquet</param>
        public void Reconstituer(List<Carte> defausese)
        {

        }
    }
}
