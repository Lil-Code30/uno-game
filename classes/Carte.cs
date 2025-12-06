namespace uno_game.classes
{
    abstract class Carte
    {
        public string Couleur { get; set; }
        public string Type { get; protected set; }

        public Carte(string type, string couleur)
        {
            this.Type = type;
            this.Couleur = couleur;
        }

        public abstract bool EstCompatible(Carte courant);

        public abstract void AfficherCarte();
    }
}
