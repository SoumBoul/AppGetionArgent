# Stack : .NET 10 + C# 14

> Standard technique — 2026

## 1. Stack technique

- **Type de projet** : application console CLI autonome.
- **Framework / Core** : .NET 10, projet `Microsoft.NET.Sdk` de type `Exe`.
- **Langage** : C# 14 avec nullable reference types activés et implicit usings activés.
- **Build / Runtime** : .NET 10 SDK et runtime .NET 10.
- **Persistance** : fichier CSV local UTF-8, lu et écrit avec les API natives .NET.
- **Bibliothèques externes** : aucune bibliothèque nécessaire ; pas de framework web ni de package CSV obligatoire.
- **Tests du starter** : aucun test automatisé préécrit. Les tests ne doivent pas empêcher la compilation d'un starter dont les fonctionnalités restent à implémenter.
- **Docker / CI-CD** : aucun fichier Docker et aucun pipeline CI/CD.
- **Frontend / API / BDD / ORM** : aucun frontend, aucune API, aucune base de données et aucun ORM.

## 2. Règles d'implémentation (Do's)

- Conserver une application console simple, lisible et adaptée à un niveau débutant.
- Reprendre le scénario et les fonctionnalités communes aux codebases Python et Java, sans reproduire leurs artefacts ou leurs défauts de traduction.
- Utiliser une classe `Expense` fortement typée pour représenter une dépense.
- Utiliser `decimal` pour les montants financiers ; ne pas utiliser `float` ou `double` pour les calculs monétaires.
- Utiliser `DateTime` ou `DateOnly` selon le besoin, avec le format d'affichage et de stockage `dd/MM/yyyy`.
- Utiliser `CultureInfo` et `decimal.TryParse` pour accepter les formats décimaux pertinents, notamment le séparateur `,` français et le séparateur `.`.
- Conserver le schéma CSV `date,category,description,amount` et l'encodage UTF-8.
- Utiliser les API natives `File.Exists`, `StreamReader`, `StreamWriter` et `Path` pour la persistance locale.
- Séparer simplement les responsabilités : modèle de dépense, dépôt CSV, calculs métier et interaction avec le menu console.
- Utiliser `TryParse` pour les choix de menu, les montants et les valeurs numériques saisies au clavier.
- Préserver l'ouverture/fermeture correcte des fichiers avec `using` ou des blocs `using`.
- Garder un seul chemin CSV configuré et réellement utilisé ; ne pas conserver de variable ou de fichier de données inutilisé.
- Fournir dans le starter les éléments de base : lecture et ajout CSV, modèle `Expense`, saisie robuste, menu et boucle CLI, historique et affichage des statistiques.
- Laisser à l'étudiant les calculs demandés : total, nombre de mois, totaux par catégorie, moyennes mensuelles, simulation d'achat d'une voiture et simulation de prêt immobilier.
- Exclure du starter les fichiers Python, les fichiers spécifiques à l'IA, les notes de correction et tout code parasite.

## 3. Pratiques interdites (Legacy / hors périmètre)

- Ne pas transformer l'application en API REST, MVC/Razor, Blazor ou application web.
- Ne pas introduire SQL Server, SQLite, une autre base de données ou Entity Framework Core.
- Ne pas ajouter Spring, Maven, Java, Python ou des fichiers issus des codebases sources dans le projet .NET.
- Ne pas utiliser `float`, `double` ou des conversions monétaires non contrôlées.
- Ne pas utiliser de chemin CSV secondaire non exploité, notamment un équivalent inutile de `emmaPath`.
- Ne pas ajouter de tests préécrits dans le starter pour des fonctionnalités que l'étudiant doit encore implémenter.
- Ne pas inclure de fichiers Python résiduels, de prompts ou de fichiers d'agent non prévus dans le starter.
- Ne pas ajouter de framework, de package ou de pattern avancé sans nécessité pédagogique.
- Ne pas exposer de stack trace ou de détails internes lors d'une erreur de saisie ou de fichier.
- Ne pas modifier les codebases Python ou Java de référence.

## 4. Mapping de migration (Python / Java -> C#)

| Concept source | Concept C# | Implémentation cible |
| :--- | :--- | :--- |
| Script `main.py` / classe de démarrage Java | `Program.cs` | Point d'entrée d'une application console .NET 10 |
| Fonctions globales / méthodes Java | Méthodes et classes C# | Responsabilités simples réparties entre modèle, dépôt, calculs et menu |
| Classe `Expense` Python / Java | Classe `Expense` | Propriétés fortement typées : date, catégorie, description et `decimal amount` |
| `list` Python / `List<Expense>` Java | `List<Expense>` | Collection des dépenses chargées depuis le CSV |
| Dictionnaire Python / `Map<String, BigDecimal>` Java | `Dictionary<string, decimal>` | Totaux regroupés par catégorie ou par mois |
| `csv.DictReader` / lecture Java CSV | `StreamReader` | Lecture UTF-8, validation de l'en-tête et conversion des colonnes |
| `csv.writer` / écriture Java CSV | `StreamWriter` | Ajout d'une ligne et création de l'en-tête si nécessaire |
| `float` Python / `BigDecimal` Java | `decimal` | Calculs financiers exacts et formatage à deux décimales |
| `datetime` Python / `LocalDate` Java | `DateOnly` ou `DateTime` | Stockage et affichage au format `dd/MM/yyyy` |
| `input()` / `Scanner` ou `BufferedReader` | `Console.ReadLine()` | Saisie utilisateur contrôlée avec valeurs de repli explicites |
| `print()` / `System.out.println()` | `Console.WriteLine()` | Affichage du menu, de l'historique et des résultats |
| `float()` / `BigDecimal` | `decimal.TryParse` | Parsing robuste avec cultures française et invariant |
| `math.ceil()` / `Math.ceil()` | `Math.Ceiling()` | Arrondi supérieur du nombre de mois nécessaire |
| `set` / `Set<String>` | `HashSet<string>` | Décompte des mois distincts |
| Exceptions Python / exceptions Java | Exceptions .NET | Gestion locale des erreurs de fichier et de format |
| Tests Python / JUnit 5 | Tests .NET ultérieurs | Hors starter initial ; ajoutables dans une étape dédiée après introduction des tests |

## 5. Périmètre fonctionnel cible

### Fourni dans le starter

- Lecture du fichier CSV existant.
- Ajout d'une dépense dans le CSV.
- Classe représentant une dépense, avec montant déjà converti en `decimal`.
- Saisie clavier robuste, y compris pour les montants invalides.
- Menu CLI et boucle principale.
- Affichage de l'historique et des statistiques de base.

### À implémenter par l'étudiant

- Calcul du total des dépenses.
- Calcul du nombre de mois couverts par les données.
- Totaux par catégorie.
- Moyennes mensuelles.
- Simulation du nombre de mois nécessaires à l'achat d'une voiture.
- Simulation d'un prêt immobilier selon la formule fournie et la limite d'endettement de 35 %.
