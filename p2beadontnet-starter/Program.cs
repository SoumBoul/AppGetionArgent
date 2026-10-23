namespace p2beadontnet_starter;

internal static class Program
{
    private static void Main()
    {
        var repository = new CsvExpenseRepository(@"C:\Users\soumboul\AppGestionRecuperee\p2beadontnet-starter\emma_expenses.csv");
        var application = new BudgetApplication(repository);
        application.Run();
    }
}
