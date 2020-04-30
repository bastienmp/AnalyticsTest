# AnalyticsTest
Le temps que vous avez passé sur ce projet.
4h

Vos choix techniques / architecturaux.
- Puisqu'il met demmandé de pouvoir integrer rapidement d autres services, sans pour autant modifier le code dans le gameplay, j ai rapidement choisi d utiliser une interface, qui pourront etre utilisée en standalone si il le faut, ainsi qu un "manager" qui permet de gerer plusieurs services facilement.

Ce qui vous a semblé difficile.
- Le plus compliqué a été de decouvrir GameAnalytics, la documentation n est pas mauvaise mais manque de precision, et il y a peux de discution sur stackoverflow ou autre pour trouver des reponses.

Ce que vous feriez si vous deviez pousser ce projet un cran plus loin.
- La gestion d erreur peut etre poussée beaucoup plus loin
- Des unit test pourraient etre créés pour tester les nouvelles implementations de IANalytics ou apres des mises a jour (surtout si celle-ci sont nombreuses).
- Les parametre envoyés au services de tracking pourrait etre verifié, et si l approche de GameAnalytics convient mieu que celle de facebook, peut etre developer une fonction par type d evenement (voir ci dessous).

Vos éventuels commentaires.
- L'implementation du tracking de Facebook et celui de GameAnalytics sont tres different:
- Facebook laisse une grande libertée quand a l utilisation des evenement custom, alors que les evenement custom chez GameAnalytics sont tres limité avec seulement 2 parametres : un eventID, et une valeur numerique. GameAnalytics dispose egalement de 4 autre types d'evenements principalement pour les achats, les monais, la progression du joueur ainsi que un system d erreur (https://gameanalytics.com/docs/item/events-introduction).
- Si on tiens a harmoniser les comportements des deux systems, 'limiter' facebook analytics a la facon dont GameAnalytics gere les events parait facilement realisable, en revanche l inverse serait impossible avec les limitations decouvertes (cf nombre de nom unique : https://gameanalytics.com/docs/item/design-events)

