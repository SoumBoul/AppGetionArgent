namespace p2beadontnet_starter;

public sealed class BudgetApplication
{
    private readonly CsvExpenseRepository repository;

    public BudgetApplication(CsvExpenseRepository repository)
    {
        this.repository = repository;
    }

    public void Run()
    {
        var expenses = repository.Load();
        Console.WriteLine("=== Emma Budget ===");
        Console.WriteLine($"{expenses.Count} dépense(s) chargée(s).\n");

        var running = true;
        while (running)
        {
            DisplayMenu();
            switch (Input.ReadMenuChoice())
            {
                case 1:
                    DisplayHistory(expenses);
                    break;
                case 2:
                    AddExpense(expenses);
                    break;
                case 3:
                    DisplayBasicStatistics(expenses);
                    break;
                case 4:
                    DisplayDetailsStatistics(expenses);
                    
                    break;
                case 5:
                    Console.WriteLine("Simulation voiture : à implémenter par l'étudiant.");
                    break;
                case 6:
                    Console.WriteLine("Simulation prêt immobilier : à implémenter par l'étudiant.");
                    break;
                case 0:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Choix inconnu.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("À bientôt.");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("1. Afficher l'historique");
        Console.WriteLine("2. Ajouter une dépense");
        Console.WriteLine("3. Statistiques de base");
        Console.WriteLine("4. Statistiques complètes (à implémenter)");
        Console.WriteLine("5. Simulation achat d'une voiture (à implémenter)");
        Console.WriteLine("6. Simulation prêt immobilier (à implémenter)");
        Console.WriteLine("0. Quitter");
    }

    private static void DisplayHistory(IReadOnlyCollection<Expense> expenses)
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("Aucune dépense enregistrée.");
            return;
        }

        Console.WriteLine($"\nDate       Category       Description                       Amount\n");
        foreach (var expense in expenses.OrderByDescending(expense => expense.Date))
        {
            Console.WriteLine($"{expense.Date:dd/MM/yyyy} | {expense.Category,-12} | {expense.Description,-30} | {expense.Amount,10:0.00} €");
        }
       
    }

    private void AddExpense(List<Expense> expenses)
    {
        var expense = new Expense
        {
            Date = ReadDate(),
            Category = Input.ReadRequired("Catégorie : "),
            Description = Input.ReadRequired("Description : "),
            Amount = Input.ReadDecimal("Montant : ")
        };

        repository.Add(expense);
        expenses.Add(expense);
        Console.WriteLine("Dépense enregistrée.");
    }

    private static DateOnly ReadDate()
    {
        while (true)
        {
            Console.Write("Date (dd/MM/yyyy) : ");
            if (DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out var date))
            {
                return date;
            }

            Console.WriteLine("Saisissez une date valide au format dd/MM/yyyy.");
        }
    }

    private static void DisplayBasicStatistics(IReadOnlyCollection<Expense> expenses)
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("Aucune statistique disponible.");
            return;
        }

        Console.WriteLine($"Nombre de dépenses : {expenses.Count}");
        Console.WriteLine($"Période : {expenses.Min(expense => expense.Date):dd/MM/yyyy} - {expenses.Max(expense => expense.Date):dd/MM/yyyy}");
        Console.WriteLine("Les statistiques détaillées sont à implémenter dans le cadre de l'exercice.");
    }

    private static void DisplayDetailsStatistics(IReadOnlyCollection<Expense> expenses)
    {
       
        if (expenses.Count == 0)
        {
            Console.WriteLine("Aucune statistique disponible.");
            return;
        }

        foreach (var statistiques in expenses.Select(expense => expense.Category).Distinct())
        {
            var categoryExpenses = expenses.Where(expense => expense.Category == statistiques);
            var totalAmount = categoryExpenses.Sum(expense => expense.Amount);
            var NumberOfMonths = categoryExpenses.Select(expense => new { expense.Date.Year, expense.Date.Month }).Distinct().Count();
            var AverageAmount = categoryExpenses.Average(expense => expense.Amount);

            Console.WriteLine($"\n  category Expenses : {statistiques} ");
            Console.WriteLine($"  total Amount      : {totalAmount}");
            Console.WriteLine($"  NumberOfMonths    : {NumberOfMonths} ");
            Console.WriteLine($"  AverageAmount     : {AverageAmount:0.00} €");
           
        }

        var total = expenses.Sum(expense => expense.Amount);
        var Months = expenses.Select(expense => new { expense.Date.Year, expense.Date.Month }).Distinct().Count();
        var Category = expenses.Select(expense => expense.Category).Distinct().Count();
        var Average = expenses.Average(total => total.Amount);

        Console.WriteLine("Total Of All Depenses.\n");

        Console.WriteLine($"\n   Expenses : {total} ");
        Console.WriteLine($"\n   Numbers of Months : {Months} ");
        Console.WriteLine($"\n   Category : {Category} ");
        Console.WriteLine($"\n   Average : {Average} ");

    }
}