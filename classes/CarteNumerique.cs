namespace uno_game.classes
{
     class CarteNumerique : Carte
    {
        public int Valeur { get; set; }

        public CarteNumerique(string type, string couleur, int valeur) : base(type, couleur)
        {
            this.Valeur = valeur;
        }

        /// <summary>
        /// Détermine si cette carte est compatible avec une autre carte,
        /// </summary>
        /// <param name="courant">La carte à laquelle comparer.</param>
        /// <returns>
        /// Vrai si les deux cartes peuvent être jouées; sinon, faux.
        /// </returns>
        public override bool EstCompatible(Carte courant)
        {
            // Une carte numérique est compatible si elle correspond à la couleur ou à la valeur.
            if (courant is CarteNumerique carteNum)
            {
                return this.Couleur == courant.Couleur || this.Valeur == carteNum.Valeur;
            }
            return this.Couleur == courant.Couleur;
        }

        /// <summary>
        ///  Affiche la valeur et la couleur de la carte
        /// </summary>
        public override void AfficherCarte()
        {
            Console.WriteLine($"[Carte:{Valeur} - {Couleur}]");
        }
    }
}
