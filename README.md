# Projet UNO – INF11107 : Programmation orientée objet I

## Informations générales
**Cours :** INF11107 – Programmation orientée objet I  
**Projet :** Implémentation du jeu de cartes UNO  
**Travail en équipe :** Groupe de 4 étudiants  
**Date de remise :** Avant **16h00**, le **9 décembre 2025**  

---

## Objectif du projet
L’objectif de ce projet est de mettre en pratique les concepts fondamentaux de la programmation orientée objet (POO) en développant une version fonctionnelle du jeu de cartes **UNO**.

La logique du jeu devra être programmée en respectant les règles essentielles, la gestion des joueurs, des cartes, des effets spéciaux, ainsi que le déroulement du tour de jeu.

---

## Référence vidéo
Pour comprendre le déroulement du jeu UNO, visionnez la vidéo suivante :  
https://www.youtube.com/watch?v=gxVgV6NkJf0&ab_channel=pratiqueTV

---

# Diagramme UML – Projet UNO

```mermaid
classDiagram
    class Jeu {
        - joueurs : List<Joueur>
        - paquet : Paquet
        - defausse : List<Carte>
        - courant : Carte
        + demarrerPartie() void
        + TourSuivant() void
        + verifierCarte(carte : Carte, joueur : Joueur) boolean
        + JouerCarte(joueur: Joueur, carte: Carte): void
        + ChangerDirection(): void
        + TirerCarte(joueur: Joueur, nb: int = 1): void
        + ConditionVictoire(joueur: Joueur): bool
    }

    class Joueur {
        - nom : String
        - main : List<Carte>
        + jouerCarte(carte : Carte) void
        + piocher(paquet : Paquet) void
        + peutJouer(courant : Carte) boolean
        + CompterPoints(): int
    }

    class Paquet {
        - cartes : List<Carte>
        + melanger() void
        + piocher() Carte
        + estVide() boolean
        + AjouterCarte(carte: Carte): void
        + Reconstituer(defausse: List<Carte>): void
    }

    class Carte {
        - couleur : Couleur
        - valeur : String
        + estCompatible(autre : Carte) boolean
    }

    class CarteSpeciale {
        - typeEffet : String
        + appliquerEffet(jeu : Jeu) void
    }

    class Couleur {
        <<enumeration>>
        ROUGE
        VERT
        BLEU
        JAUNE
        NOIR
    }

    Jeu --> Joueur : "gère"
    Jeu --> Paquet : "utilise"
    Joueur --> Carte : "possède *"
    Paquet --> Carte : "contient *"
    Carte <|-- CarteSpeciale
```

### Enums 

```markdown
enum Direction {
        Horaire
        AntiHoraire
    }

    enum TypeEffect {
        Plus2
        Inverser
        Passer
        Joker
        JokerPlus4
    }
```