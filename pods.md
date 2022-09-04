# PODS

## Mise en situation

Nous sommes en 20xx, les humains ne se déplacent plus que pour leurs loisirs (vacances, rencontres entre amis, fêtes, événements culturels ou sportifs, ...).

Les voitures individuelles (mais aussi les cars, camions, motos) ont été remplacées par un unique type de véhicule: le **Pod**. 

Il y a des pods à 0, 1, 2, 3, 5, 8, 13 ou 21 personnes.

Pourquoi 0 ? Parce qu'il est toujours nécessaire de déplacer des choses (nourriture, boissons, matériel, ...). Un pod est donc également caractérisé par le nombre de container qu'il peut transporter: 2, 4, 8 ou 16.

L'OFROU existe encore (!) et elle est toujours aussi tâtillonne. Elle a émis les règles suivantes:

- La **jauge** d'un pod est la somme du nombre de passagers et de containers qu'il peut transporter. Ce nombre ne peut pas dépasser 21.  
- Bien que les pods soient autonomes, au moins un passager doit avoir le "permis pod" s'il y a plus de 5 passagers dans un pod.
- Un pod ne peut pas s'engager sur une route s'il n'est pas au moins à moitié plein (en passagers uniquement)

Les pods circulent sur des routes unidirectionnelles qui ne se croisent jamais! Elles commencent et se terminent dans des endroits appelés **hub**.

Un hub:

- Peut abriter un certain nombre de personnes (venus là pour prendre un pod)  
- Peut stocker un certain nombre de container  
- Peut parquer un certain nombre de Pods  

## Travail à effectuer

### Minimal

- Faire un modèle conceptuel du réseau PODS
- Faire un modèle logique (diagramme de classe UML)
- Créer les classes vides
- Ecrire les tests unitaires permettant de vérifier
  - Que les règles de l'OFROU sont respectées
  - Les limites de capacité des hubs
- Implémenter le modèle

### et après...

- Choisir une représentation pour le système
- Simuler le traffic de personnes et de marchandises