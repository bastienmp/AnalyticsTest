# AnalyticsTest
Le temps que vous avez passé sur ce projet.
5h

Vos choix techniques / architecturaux.
- Puisqu'il met demandé de pouvoir intégrer rapidement d'autres services, sans pour autant modifier le code dans le gameplay, j'ai rapidement choisi d'utiliser une interface, qui pourront être utilisée en standalone si il le faut, ainsi qu un "manager" qui permet de gérer plusieurs services facilement.

Ce qui vous a semblé difficile.
- Le plus compliqué a été de découvrir GameAnalytics, la documentation n est pas mauvaise mais manque de précision, et il y a peux de discussion sur stackoverflow ou autre pour trouver des réponses.

Ce que vous feriez si vous deviez pousser ce projet un cran plus loin.
- La gestion d'erreur peut être poussée beaucoup plus loin
- Des unit test pourraient être créés pour tester les nouvelles implémentations de IAnalytics ou après des mises à jour (surtout si celle-ci sont nombreuses).
- Les parametre envoyés au services de tracking pourrait etre verifié, et si l approche de GameAnalytics convient mieu que celle de facebook, peut être développer une fonction par type d événement (voir ci dessous).

Vos éventuels commentaires.
- L'implementation du tracking de Facebook et celui de GameAnalytics sont tres different:
- Facebook laisse une grande libertée quand à l'utilisation des événement custom, alors que les événement custom chez GameAnalytics sont très limité avec seulement 2 paramètres : un eventID, et une valeur numérique. GameAnalytics dispose egalement de 4 autre types d'evenements principalement pour les achats, les monais, la progression du joueur ainsi que un system d erreur (https://gameanalytics.com/docs/item/events-introduction).
- Si on tient à harmoniser les comportements des deux systèmes, 'limiter' facebook analytics a la façon dont GameAnalytics gérer les events paraît facilement réalisable, en revanche l'inverse serait impossible avec les limitations decouvertes (cf nombre de nom unique : https://gameanalytics.com/docs/item/design-events)


