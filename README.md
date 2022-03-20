# Delta

Delta est un jeu de tir codé en C# avec le framework Monogame pour le côté jeu et Myra pour la partie graphique (menus)


# Prérequis
Une release portable est disponible pour ce projet, il s'agit de la façon conseillée pour jouer au jeu (cela évite davoir à recompiler les .xnb et à remettre les niveaux dans le dossier de l'exécutable).
## nugets
Pour compiler ce projet vous aurez besoin d'un certain nombre de nugets (qui devraient être pré-installés):

`MonoGame.Framework.WindowsDX`
C'est le nuget de monogame, il vous faudra la version `3.7.1.189` pour ce projet (donc pas la plus récente)

`Newtonsoft.json`
C'est le nuget utilisé pour les sérialisations de niveaux.

## langage
Ce projet est ciblé vers .NET Framework 4.8, car les dépendances requises pour le kinect V1 n'existent pas en dehors de .NET Framework.

## Dépendances kinect
Pour que le jeu fonctionne, il vous faudra absolument le `kinect runtime V1.8` trouvé ici: https://www.microsoft.com/en-us/download/details.aspx?id=40277

Il vous faudra également le `developper toolkit 1.8` trouvé ici: https://www.microsoft.com/en-us/download/details.aspx?id=40276

Enfin, pour compiler du code pour la Kinect V1, il vous faudra le SDk qui existe ici: https://www.microsoft.com/en-us/download/details.aspx?id=40278

(les .dll kinect requis par le projet sont livrés avec dans le dossier `Delta\Src\KinectDependencies`)

# le jeu
## but
Le but du jeu est de tirer sur les cibles qui apparaissent à l'écran, chaque cible rapporte 10 points et pour gagner il faut arriver à un certain score précisé par le niveau.

Des armes peuvent apparaître pendant le jeu et si touchées par une balle elles donneront une arme au hasard au joueur.

Les cibles, quand trop près du joueur, deviendront orange pour l'avertir, et feront des dégâts au joueur avant de disparaître (ce qui retirera une vie au joueur).

## fonctionnalités
Le jeu supporte jusqu'à 2 joueurs en co-op dans un même niveau (max testé). En théorie, dans un environnement idéal, la kinect V1 devrait supporter jusqu'à 10 joueurs, mais les tests n'ont pas permi cela (perturbations extérieures?).

La kinect passera automatiquement des armes aux joueurs dont elle détecte la main droite (montré par un réticule sur l'écran). Elle redémarre également à chaque nouvelle partie pour prévenir des problèmes liés aux perturbations extérieures (elle a tendance à détecter des sources de lumière infrarouge sinon).

Les niveaux sont caractérisés par un fichier de configuration présent dans le dossier `./level/` qui contiendra un ou plusieurs fichiers json de la forme `<nom_du_niveau.json>`. L'interface graphique affichera les niveaux qu'elle trouve sur le menu principal pour que le joueuren choisisse un.

# niveaux
n'oubliez pas d'aller voir le wiki pour plus d'informations sur les niveaux et comment les configurer!

Le jeu a différents niveaux sous la forme de fichiers .json qu'il est posible d'éditer pour créer ses properes niveaux, voici un test global de l'application avec tous les niveaux par défaut en facile:

https://www.youtube.com/watch?v=iok65KI_y6Q

et voici un test d'une version normale et difficile (créés en modifiant la valeur de vitesse des cibles `TargetSpeed`

https://www.youtube.com/watch?v=nbpAwVdXggk
