# P2 DFS - Application de gestion de budget en C#

Application console de suivi des dépenses utilisée comme starter pour le projet P2 DFS.

L'application permet de consulter un historique de dépenses enregistré dans un fichier CSV et d'ajouter de nouvelles dépenses. Les fonctionnalités de calcul avancées sont à implémenter dans le cadre des exercices.

## Prérequis

- .NET SDK 10.0 ou une version ultérieure compatible ;
- un terminal ;
- Git ;
- un éditeur de code, par exemple Visual Studio Code ou Visual Studio.

Vérifiez l'installation du SDK avec :

```bash
dotnet --version
```

Le projet utilise .NET 10 et C# 14.

## Démarrer le projet

Depuis le dossier `p2beadontnet-starter`, restaurez les dépendances et compilez le projet :

```bash
dotnet restore
dotnet build
```

Lancez ensuite l'application :

```bash
dotnet run
```

L'application est une CLI interactive. Utilisez le menu affiché dans le terminal pour naviguer entre les fonctionnalités, puis choisissez `0` pour quitter.

## Fonctionnalités fournies

Le starter fournit :

- le modèle `Expense` ;
- la lecture du fichier CSV ;
- l'ajout d'une dépense dans le fichier CSV ;
- la création du fichier et de son en-tête lorsqu'ils sont absents ;
- la saisie contrôlée des dates, des catégories, des descriptions et des montants ;
- l'acceptation des montants avec une virgule ou un point décimal ;
- le menu et la boucle principale de l'application ;
- l'affichage de l'historique ;
- l'affichage de statistiques de base ;
- un fichier CSV d'exemple.

## Organisation du projet

| Fichier | Responsabilité |
| --- | --- |
| `Program.cs` | Point d'entrée de l'application. |
| `Expense.cs` | Modèle représentant une dépense. |
| `CsvExpenseRepository.cs` | Lecture et ajout des dépenses dans le CSV. |
| `Input.cs` | Saisie et conversion contrôlées des valeurs entrées au clavier. |
| `BudgetApplication.cs` | Menu, boucle CLI, historique et affichage. |
| `emma_expenses.csv` | Données d'exemple au format CSV. |
| `p2beadontnet-starter.csproj` | Configuration du projet .NET. |

## Fichier de données

Le fichier utilisé par l'application est :

```text
emma_expenses.csv
```

Son format est :

```text
date,category,description,amount
```

Les dates utilisent le format `dd/MM/yyyy`. Les montants sont stockés et calculés avec le type `decimal`.

Exemple :

```csv
date,category,description,amount
05/01/2025,housing,Loyer,850.00
07/01/2025,food,Courses,74.50
```

Le fichier est local au dossier de l'application. Il ne s'agit pas d'une base de données.

## Travail demandé à l'étudiant

Les choix suivants du menu sont volontairement laissés à l'étudiant :

### Statistiques complètes

Implémentez l'affichage :

- du total de toutes les dépenses ;
- du nombre de mois distincts couverts par l'historique ;
- du total dépensé pour chaque catégorie ;
- de la moyenne mensuelle de chaque catégorie ;
- de la moyenne mensuelle globale.

Les moyennes mensuelles doivent être calculées sur le nombre de mois distincts présents dans le CSV.

### Simulation d'achat d'une voiture

Demandez le revenu net mensuel et le prix de la voiture.

Calculez l'épargne mensuelle disponible :

```text
épargne mensuelle = revenu net mensuel - moyenne mensuelle des dépenses
```

Si l'épargne est positive, calculez le nombre entier de mois nécessaires avec un arrondi supérieur :

```text
nombre de mois = plafond(prix de la voiture / épargne mensuelle)
```

Si l'épargne est nulle ou négative, indiquez que le projet ne peut pas être financé dans ces conditions.

### Simulation de prêt immobilier

Demandez le revenu net mensuel, le taux annuel en pourcentage et la durée du prêt en années.

Calculez d'abord :

- la dépense moyenne mensuelle de la catégorie `housing` ;
- l'épargne mensuelle disponible ;
- la mensualité théorique : `épargne mensuelle + dépense logement`.

La mensualité retenue ne doit pas dépasser 35 % du revenu mensuel :

```text
mensualité retenue = min(mensualité théorique, revenu mensuel * 0,35)
```

Pour `n = durée en années * 12` et `r = taux annuel / 100 / 12` :

- si `r = 0`, `capital = mensualité retenue * n` ;
- sinon, `capital = mensualité retenue * (1 - (1 + r)^(-n)) / r`.

Gérez les valeurs invalides, le taux nul, l'historique vide, l'absence de catégorie `housing` et une capacité d'épargne insuffisante.

## Points de vigilance

- Conservez le schéma CSV `date,category,description,amount`.
- Conservez le format de date `dd/MM/yyyy`.
- Utilisez `decimal` pour tous les montants financiers.
- Acceptez les montants saisis avec `,` et `.` comme séparateur décimal.
- Utilisez les méthodes `TryParse` afin d'éviter les erreurs lors des saisies invalides.
- Gérez les fichiers absents ou vides et les historiques sans dépense.
- Gardez l'application sous forme de console CLI.
- N'ajoutez ni API, ni framework web, ni base de données, ni ORM, ni Docker.
- Aucun test automatisé n'est fourni dans le starter initial.

## Vérification

Après chaque évolution, vérifiez au minimum :

```bash
dotnet build
dotnet run
```

Testez également :

- l'affichage de l'historique ;
- l'ajout d'une dépense ;
- un montant avec virgule, par exemple `1234,56` ;
- un montant avec point, par exemple `1234.56` ;
- une saisie invalide ;
- un fichier CSV absent ou vide ;
- un historique vide ;
- un taux annuel nul pour la simulation immobilière.

## Git

Le workflow pédagogique utilise une branche `develop` pour les développements, puis une fusion dans `main` :

```bash
git switch -c develop
git add .
git commit -m "Implémente les fonctionnalités du budget"
git switch main
git merge develop
git push origin main
```

Conservez un historique de commits lisible et vérifiez l'état du dépôt avec :

```bash
git status
git log --oneline
```
