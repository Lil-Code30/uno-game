namespace uno_game.classes
{
     class CarteNumerique : Carte
    {
        public int Valeur { get; set; }

        public CarteNumerique(string type, string couleur, int valeur) : base(type, couleur)
        {
            this.Valeur = valeur;
        }

        public override bool estCompatible(Carte courant)
        {
            // A numeric card is compatible if it matches the color or the value
            if (courant is CarteNumerique carteNum)
            {
                return this.Couleur == courant.Couleur || this.Valeur == carteNum.Valeur;
            }
            return this.Couleur == courant.Couleur;
        }

        /// <summary>
        /// Displays the card's value and color to the console output.
        /// </summary>
        public override void AfficherCarte()
        {
            Console.WriteLine($"[Carte:{Valeur} - {Couleur}]");
        }
    }
}
