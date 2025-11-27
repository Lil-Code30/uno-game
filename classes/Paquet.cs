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

        /// <summary>
        /// Ajoute une carte dans le paquet.
        /// Utile pour remettre une carte dans le paquet après qu'elle a été jouée ou pour reconstituer le paquet.
        /// </summary>
        /// <param name="carte">La carte à ajouter au paquet</param>
        public void AjouterCarte(Carte carte)
        {

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
