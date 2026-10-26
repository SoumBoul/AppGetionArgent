namespace p2beadontnet_starter;

public sealed class BudgetApplication
{
    private readonly CsvExpenseRepository repository;
    static decimal Average= 0;
    public BudgetApplication(CsvExpenseRepository repository)
    {
        this.repository = repository;
    }


    private void Clear()
    {
        Console.Clear();


    }
    public void Run()
    {
        var expenses = repository.Load();
        Console.WriteLine("=== Emma Budget ===");
        Console.WriteLine($"{expenses.Count} dépense(s) chargée(s).\n");

        var running = true;

        DisplayMenu();
        while (running)
        {
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
                    CarSimulation(expenses);
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

            
            if (Input.ReadRequired("\n\nDo you want to return to the main menu? (y/n): ").ToLower() == "y")
            {
                Clear();
                DisplayMenu();
            }
            else
            {
                running = false;
            }



        }
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

       // Console.WriteLine("Retour au menu principal.");

    }

    private static void DisplayHistory(IReadOnlyCollection<Expense> expenses)
    {
        decimal totalAmount = 0;
        if (expenses.Count == 0)
        {
            Console.WriteLine("Aucune dépense enregistrée.");
            return;
        }

        Console.WriteLine($"\nDate       Category       Description                       Amount\n");
        foreach (var expense in expenses.OrderByDescending(expense => expense.Date))
        {
            Console.WriteLine($"{expense.Date:dd/MM/yyyy} | {expense.Category,-12} | {expense.Description,-30} | {expense.Amount,10:0.00}€");
             totalAmount = expenses.Sum(expense => expense.Amount);
        }
        Console.Write($"\n{"",30}Toal Amount : {totalAmount,28:0.00}");

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

        decimal total = expenses.Sum(expense => expense.Amount);
        var Months = expenses.Select(expense => new { expense.Date.Year, expense.Date.Month }).Distinct().Count();
        var Category = expenses.Select(expense => expense.Category).Distinct().Count();
        Average = expenses.Sum(total => total.Amount/Months)  ;

        Console.WriteLine("Total Of All Depenses.\n");

        Console.WriteLine($"\n   Expenses : {total} ");
        Console.WriteLine($"\n   Numbers of Months : {Months} ");
        Console.WriteLine($"\n   Category : {Category} ");
        Console.WriteLine($"\n   Average By Month: {Average} ");

    }


    private static void CarSimulation(IReadOnlyCollection<Expense> expenses)
    {
        Console.WriteLine("\n Simulation de l'Achat d'une voiture\n");

        decimal RevenuNetMensuel = Input.ReadDecimal("Le revenu net mensuel : ");
        decimal PriceOfCar = Input.ReadDecimal("Le prix de voiture : ");
        var Months = expenses.Select(expense => new { expense.Date.Year, expense.Date.Month }).Distinct().Count();
        decimal MoyenneMensuelleDesDepenses = expenses.Sum(total => total.Amount / Months);
        Console.WriteLine($"La moyenne mensuelle des dépenses :{MoyenneMensuelleDesDepenses}");
       
        decimal épargneMensuelle = RevenuNetMensuel - MoyenneMensuelleDesDepenses;
        try
        {

            if (épargneMensuelle <= 0)
            {
                throw new InvalidOperationException("\nVous ne pouvez pas épargner avec vos dépenses actuelles.");
            }
            decimal MonthsToSave = PriceOfCar / épargneMensuelle;

            Console.WriteLine($"\nIl vous faudgirra {Math.Ceiling(MonthsToSave)} mois pour économiser pour la voiture.");

        }
        catch (InvalidOperationException ex)
        {
            
            Console.WriteLine(" \nSorry,le projet ne peut pas être financé dans ces conditions.");

        }
        ;
    }
}