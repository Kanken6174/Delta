# Delta

Delta est un jeu de tir codé en C# avec le framework Monogame pour le côté jeu et Myra pour la partie graphique (menus)


# Prérequis
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

Enfin, pour compiler du code pour le Kinect V1, il vous faudra le SDk qui existe ici: https://www.microsoft.com/en-us/download/details.aspx?id=40278

(les .dll kinect requis par le projet sont livrés avec dans le dossier `Delta\Src\KinectDependencies`)
