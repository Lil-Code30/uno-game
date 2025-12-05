namespace uno_game.classes
{

    /// <summary>
    /// Représente les couleurs disponibles dans le jeu UNO
    /// </summary>
    public enum Couleur
    {
        ROUGE,
        VERT,
        JAUNE,
        NOIR    
    }

    /// <summary>
    /// Représente les types d'effets spéciaux des cartes
    /// </summary>
    public enum TypeEffect
    {
        Plus2,  // +2 cartes
        Inverser, // Inverse la direction
        Passer,  // Passer
        Joker, // change la couleur
        JokerPlus4 // change la couleur + 4 cartes
    }

    /// <summary>
    /// Représente la direction du jeu
    /// </summary>
    public enum Direction
    {
        Horaire,
        AntiHoraire
    }
}
