# P2 DFS — Application de gestion de budget en C#

> Instructions fournies à l'étudiant.

---

## Contexte

Vous venez de rejoindre une startup fintech en tant que développeur·se back-end junior. L'entreprise développe une application qui aide les jeunes actifs de 20 à 30 ans à mieux gérer leur argent : suivre leur budget, épargner et préparer des projets d'achat ou d'emprunt.

Votre manageuse, Mai, vous accompagne dans vos premiers pas. Pour votre première mission, vous allez prendre en main une application console existante de suivi des dépenses, puis y ajouter des fonctionnalités simples.

---

## Objectifs pédagogiques

- Installer et configurer un environnement .NET 10 et C# 14.
- Cloner, exécuter et versionner une application console.
- Lire et écrire des données dans un fichier CSV.
- Lire du code existant et identifier les responsabilités des fichiers principaux.
- Manipuler des collections, des chaînes, des dates et des nombres en C#.
- Utiliser progressivement une classe simple pour représenter une dépense.
- Implémenter des calculs de budget et de capacité d'emprunt.
- Gérer les saisies invalides et vérifier les résultats affichés.
- Utiliser Git avec une branche `develop` fusionnée dans `main`.
- Expliquer ses choix et son code lors d'une démonstration.

Les tests automatisés ne font pas partie du starter : ils seront abordés plus tard dans le parcours.

---

## Scénario

Le projet est un fil rouge en deux parties.

### Partie 1 — Mettez en place l'application

Installez le SDK .NET 10, votre IDE, Git et les outils nécessaires. Clonez le dépôt de départ, exécutez l'application console, créez une branche `develop` et poussez votre dépôt dans votre espace GitHub.

### Partie 2 — Implémentez des fonctionnalités

Explorez le starter code, comprenez son point d'entrée et ses fichiers principaux, puis implémentez les fonctionnalités demandées dans le menu CLI. Le code doit rester simple, clair et adapté aux fondamentaux du back-end.

---

## Starter kit

Le starter fournit :

- une application console .NET 10 fonctionnelle ;
- la classe représentant une dépense, avec le montant converti en `decimal` ;
- la lecture du fichier CSV ;
- l'ajout d'une dépense dans le CSV ;
- une saisie clavier robuste, notamment pour les montants avec `,` ou `.` ;
- le menu CLI et sa boucle principale ;
- l'affichage de l'historique et des statistiques de base ;
- un fichier CSV d'exemple contenant une année de dépenses.

Le starter ne contient pas de tests automatisés préécrits, de fichiers Python, de fichiers spécifiques à l'IA, de Docker ou de base de données.

### Exercice 1 — Mettez en place l'application

Installez et configurez votre environnement de développement, clonez le dépôt de départ et exécutez l'application avec `dotnet run`. Créez une branche `develop`, réalisez vos commits et poussez le dépôt dans votre espace GitHub.

Préparez une courte démonstration de l'IDE, du dépôt GitHub, de l'application et de vos outils.

### Exercice 2 — Implémentez les fonctionnalités de gestion du budget

Explorez le code existant jusqu'à pouvoir expliquer le point d'entrée, la classe de dépense, le composant de lecture/écriture CSV, le menu et l'affichage. Exécutez l'application et manipulez le fichier de données.

Implémentez ensuite les trois évolutions suivantes.

#### 1. Statistiques par catégorie

Lorsque l'utilisateur choisit `Statistiques`, affichez :

- le total de toutes les dépenses ;
- le nombre de mois distincts couverts par l'historique ;
- le total dépensé pour chaque catégorie ;
- la moyenne mensuelle de chaque catégorie ;
- la moyenne mensuelle globale.

La moyenne mensuelle est calculée sur le nombre de mois distincts présents dans le CSV.

#### 2. Simulation d'achat d'une voiture

Lorsque l'utilisateur choisit `Simulation achat d'une voiture`, demandez son revenu net mensuel et le prix de la voiture.

Calculez l'épargne mensuelle disponible ainsi :

`épargne mensuelle = revenu net mensuel - moyenne mensuelle des dépenses`

Si cette épargne est positive, affichez le nombre entier de mois nécessaires :

`nombre de mois = plafond(prix de la voiture / épargne mensuelle)`

Si l'épargne est nulle ou négative, indiquez que le projet ne peut pas être financé dans ces conditions.

#### 3. Simulation de prêt immobilier

Lorsque l'utilisateur choisit `Simulation prêt immobilier`, demandez son revenu net mensuel, le taux annuel en pourcentage et la durée du prêt en années.

Calculez d'abord :

- la dépense moyenne mensuelle de la catégorie `housing` ;
- l'épargne mensuelle disponible ;
- la mensualité théorique du prêt : `épargne mensuelle + dépense logement`.

La mensualité retenue ne doit jamais dépasser 35 % du revenu mensuel :

`mensualité retenue = min(mensualité théorique, revenu mensuel * 0,35)`

Pour `n = durée en années * 12` et `r = taux annuel / 100 / 12`, utilisez la formule suivante :

- si `r = 0` : `capital = mensualité retenue * n` ;
- sinon : `capital = mensualité retenue * (1 - (1 + r)^(-n)) / r`.

Affichez le montant empruntable. Vous pouvez également afficher le total payé et le coût du crédit si ces valeurs sont calculées.

### Points de vigilance

- Conservez le format CSV `date,category,description,amount`.
- Conservez le format de date `dd/MM/yyyy`.
- Utilisez `decimal` pour les montants financiers.
- Acceptez les montants saisis avec une virgule ou un point décimal.
- Vérifiez les cas de fichier vide, d'historique vide, d'épargne insuffisante, de taux nul et de saisie invalide.
- Ne transformez pas cette application console en API ou en application web.
- Gardez la branche `develop` après sa fusion dans `main`.

---

## Livrables

- Un dépôt Git complet contenant l'application console C# fonctionnelle.
- Un historique de commits lisible.
- Une branche `develop` créée, conservée et fusionnée dans `main`.
- Les fonctionnalités de statistiques, de simulation automobile et de simulation immobilière implémentées.
- Une démonstration live de l'IDE, du dépôt, du code et des résultats console.
- Une explication orale de la structure, des fonctionnalités ajoutées, des difficultés rencontrées et des corrections réalisées.
