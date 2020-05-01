# AnalyticsTest
Le temps que vous avez passé sur ce projet.
4h

Vos choix techniques / architecturaux.
- Puisqu'il m'est demandé de pouvoir intégrer rapidement d'autres services, sans pour autant modifier le code dans le gameplay, j'ai rapidement choisi d'utiliser une interface, qui pourra être utilisée en standalone si il le faut, ainsi qu un "manager" qui permet de gérer plusieurs services facilement.

Ce qui vous a semblé difficile.
- Le plus compliqué a été de découvrir GameAnalytics, la documentation n est pas mauvaise mais manque de précision, et il y a peu de discussions sur Stackoverflow ou autre pour trouver des réponses.

Ce que vous feriez si vous deviez pousser ce projet un cran plus loin.
- La gestion d'erreur peut être poussée beaucoup plus loin
- Des units test pourraient être créés pour tester les nouvelles implémentations de IAnalytics ou après des mises à jour (surtout si celles-ci sont nombreuses).
- Les paramètres envoyés aux services de tracking pourraient être verifiés, et si l'approche de GameAnalytics convient mieux que celle de Facebook, peut-être faudrait-il développer une fonction par type d'événement (voir ci dessous).

Vos éventuels commentaires.
- L'implementation du tracking de Facebook et celui de GameAnalytics sont très differents:
- Facebook laisse une grande liberté quant à l'utilisation des événements personalisés, alors q'ils sont très limités chez GameAnalytics avec seulement 2 paramètres : un eventID, et une valeur numérique (ValueToSum). GameAnalytics dispose également de 4 autre types d'événements principalement pour les achats, les monnaies, la progression du joueur ainsi qu'un systeme d'erreur (https://gameanalytics.com/docs/item/events-introduction).
- Si on tient à harmoniser les comportements des deux systèmes, 'limiter' facebook analytics à la façon dont GameAnalytics gère les événements paraît facilement réalisable, en revanche l'inverse serait impossible avec les limitations decouvertes (cf nombre de nom unique : https://gameanalytics.com/docs/item/design-events)


