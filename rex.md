# Retour d'expérience — CODEBASEFACTORY

## 2026-09-08 — Phase 0 : vérification initiale

- `project.md` existe à la racine et a été lu.
- `project.md` contient encore le gabarit de départ ; le brief pédagogique reste à renseigner.
- Le dossier `./example` est absent. Cette absence est recommandée mais non bloquante selon `agent-init.md`.
- Aucun code de projet ne doit être généré dans le dépôt `CODEBASEFACTORY`.

## 2026-09-08 — Phase 0.5 : en attente du nom du projet

- `PROJECT_NAME` choisi et validé : `p2beadontnet`.
- Le nom est en minuscules et ne contient pas d’espace.

## 2026-09-08 — Phases 1 et 2 : analyse initiale de la stack

- `project.md`, `stack.md` et `assets.md` ont été lus.
- Ces trois fichiers contiennent encore leurs gabarits ; aucune stack technique ni fonctionnalité exploitable n'est définie.
- Le dossier `./example` est absent, donc aucune architecture de référence n'est disponible.
- La définition de la stack est en attente des choix du Learning Designer.

## 2026-09-08 — Phase 1 : configuration cible fournie

- Projet source : scénario et cahier des charges communs aux codebases Python et Java de P2.
- Projet cible : application console .NET, sans API, MVC/Razor ni Blazor.
- Runtime et langage : .NET 10 avec C# 14.
- Persistance : fichier CSV en lecture/écriture ; aucune base de données et aucun ORM.
- Niveau : débutant back-end ; fondamentaux, lecture de code, petites modifications, manipulation de données et POO simple.
- Docker : non retenu.
- Fonctionnalités à implémenter : total, nombre de mois, totaux par catégorie, moyennes mensuelles, simulation d'achat d'une voiture et simulation de prêt immobilier avec la formule fournie.
- Éléments fournis dans le starter : accès CSV, classe dépense, saisie clavier robuste, menu CLI et boucle, affichage de l'historique et des statistiques.
- Aucun test automatisé préécrit ne sera inclus dans le starter.
- Les fichiers parasites et le code inutile, notamment `emmaPath`, devront être exclus de la version .NET.
- La génération de `stack.md` reste en attente de la codebase Python source à analyser.

## 2026-09-08 — Références externes et règle d'isolation

- Le dépôt Python fourni est public et accessible en lecture.
- Le dépôt Java fourni est privé et renvoie `404` sans authentification ; il ne sera pas consulté sans accès explicitement autorisé.
- Les codebases Python et Java sont des références uniquement : aucune modification ne doit y être effectuée.
- La migration .NET sera générée dans l'espace isolé prévu par CODEBASEFACTORY ; toute divergence ou information manquante sera signalée au Learning Designer.
- Accès en lecture au dépôt Java privé validé via Git et le trousseau macOS ; la branche `main` est accessible.
- Le dépôt Java reste strictement en lecture seule, conformément à la règle d'isolation.

## 2026-09-08 — Retour d'expert Java intégré aux contraintes .NET

- Une amélioration du starter source gère désormais le cas d'un montant saisi dans un format invalide ; la version .NET devra conserver une saisie robuste, notamment avec le séparateur décimal français.
- Aucun test automatisé préécrit ne sera inclus dans le starter .NET : à ce niveau, des tests portant sur des fonctionnalités encore à implémenter provoquent des erreurs de compilation et les étudiants n'ont pas encore étudié les tests.
- Les fichiers Python résiduels et les fichiers liés à l'IA devront être exclus du starter .NET.
- Le code inutile devra être supprimé ; un seul chemin CSV cohérent sera conservé, sans équivalent de `emmaPath` si celui-ci n'est pas utilisé.
- Ces points seront vérifiés lors de la génération et de la validation du starter.

## 2026-09-08 — Phase 1 : stack .NET produite

- Les dépôts Python et Java ont été clonés temporairement sous `/tmp` en lecture seule pour analyse ; aucun dépôt source n'a été modifié.
- Le dépôt Python contient `main.py`, `expenses.py` et deux fichiers CSV à la racine.
- Le dépôt Java contient un sous-projet Maven `p2-dfs-bea-java` ainsi que des artefacts Python et des fichiers de workflow à ne pas reproduire.
- `stack.md` a été remplacé par la spécification `.NET 10 + C# 14`.
- Le mapping couvre le modèle `Expense`, la lecture/écriture CSV, les montants `decimal`, les dates, la saisie CLI, les regroupements et les simulations.
- Le starter cible sera une application console native, sans API, web, BDD, ORM, Docker ni tests préécrits.
- Checkpoint Phase 1 : validé.

## 2026-09-08 — Phase 2 : lecture de l'énoncé fourni

- Le fichier RTF `/Users/peter.guekguezian/Documents/Développement/P2 DFS BEA/P2 énoncé.rtf` a été lu et converti en texte pour analyse.
- Le scénario est confirmé : développeur back-end junior dans une startup fintech, application console de gestion de budget, accompagnement par Mai.
- L'énoncé comporte deux exercices : mise en place de l'environnement et du dépôt, puis exploration du starter et implémentation des fonctionnalités.
- Les livrables confirmés sont le dépôt Git versionné, la branche `develop` fusionnée dans `main` et une démonstration orale.
- Le périmètre .NET est explicitement prévu dans l'énoncé : SDK .NET 10 et lancement avec `dotnet run`.
- L'énoncé renvoie à un cahier des charges joint pour les règles détaillées des statistiques, de l'achat automobile et du prêt immobilier ; ce document n'est pas présent dans le fichier fourni.
- La transposition complète de `project.md` est en attente de ce cahier des charges ou de la confirmation que les règles déjà communiquées sont la spécification exhaustive.

## 2026-09-08 — Phase 2 : cahier des charges et corrigé Python analysés

- Le cahier des charges fourni confirme trois évolutions : statistiques, simulation d'achat d'une voiture et simulation de prêt immobilier.
- Le corrigé Python privé est accessible en lecture seule via Git et a été cloné temporairement sous `/tmp/p2beadontnet-corrige-python`.
- Règle confirmée : `épargne mensuelle = revenu net mensuel - moyenne mensuelle des dépenses`.
- Règle confirmée : `mois voiture = plafond(prix / épargne mensuelle)` lorsque l'épargne est positive.
- Règle confirmée : la mensualité immobilière théorique est `épargne mensuelle + moyenne mensuelle du logement`, puis elle est plafonnée à 35 % du revenu.
- Formule confirmée : avec `n = années * 12` et `r = taux annuel / 100 / 12`, `capital = mensualité * (1 - (1 + r)^(-n)) / r`, ou `mensualité * n` si `r = 0`.
- `project.md` et `assets.md` ont été complétés pour la cible .NET 10 / C# 14.
- Les dépôts Python, Java et le corrigé Python ont été utilisés uniquement en lecture ; aucun n'a été modifié.
- Checkpoint Phase 2 : validé sous réserve de relecture finale avant génération du starter.

## 2026-09-08 — Phase 3 : prérequis d'exécution

- La tentative de vérification du SDK avec `dotnet --version` échoue : la commande `dotnet` n'est pas disponible dans l'environnement actuel.
- La génération et la validation exécutable du starter .NET sont bloquées jusqu'à la mise à disposition du SDK .NET 10.
- Aucun projet n'a été généré dans CODEBASEFACTORY et aucun dépôt de référence n'a été modifié.

## 2026-09-08 — Publication des artefacts de configuration

- Les artefacts `project.md`, `stack.md`, `assets.md` et `rex.md` ont été publiés dans le dépôt cible : https://github.com/OpenClassrooms-Student-Center/Codebase-P2-DFS-Back-end-avanc-NET
- Commit de publication initial : `5d9c526`.
- Le starter .NET n'est pas encore publié ; sa génération reste à effectuer dans Codespaces après mise à disposition du SDK .NET 10.
