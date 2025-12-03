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
        -List<Joueur> joueurs
        -Paquet paquet
        -List<Carte> defausse
        -Carte courant
        -string direction

        +void demarrerPartie() 
        +void TourSuivant()
        +void ChangerDirection()
        +bool ConditionVictoire(Joueur joueur )
    }

    class Joueur {
        -string nom 
        -List<Carte> main 

        +void jouerCarte(Carte carte) 
        +void piocher(Paquet paquet) 
        +bool peutJouer(Carte courant) 
        +int CompterPoints()
    }

    class Paquet {
        -List<Carte> cartes

        +void melanger()
        +bool estVide()
        +void AjouterCarte(carte: Carte)
        +void Reconstituer(defausse: List<Carte>)
    }

    class Carte {
        <<abstract>>
        #string couleur 
        #string type 
        #int points 

        *+bool estCompatible(Carte courant )*;
    }

    class CarteSpeciale {
        -string typeEffet

        +void appliquerEffet(jeu : Jeu)
        +bool estCompatible(courant : Carte) <<override>>;
    }

    class CarteNumerique {
        -int valeur

        +void appliquerEffet(jeu : Jeu)
        +bool estCompatible(courant : Carte) <<override>>;
    }

    Jeu --> Joueur : "gère"
    Jeu --> Paquet : "utilise"
    Joueur --> Carte : "possède *"
    Paquet --> Carte : "contient *"
    Carte <|-- CarteSpeciale
    Carte <|-- CarteNumerique
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

    enum Couleur {
        ROUGE
        VERT
        BLEU
        JAUNE
        NOIR
    }
```