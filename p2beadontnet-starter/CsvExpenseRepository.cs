using System.Globalization;
using System.Text;

namespace p2beadontnet_starter;

public sealed class CsvExpenseRepository
{
    private const string Header = "date,category,description,amount";
    private const string DateFormat = "dd/MM/yyyy";
    private readonly string filePath;

    public CsvExpenseRepository(string filePath)
    {
        this.filePath = filePath;
    }

    public List<Expense> Load()
    {
        var expenses = new List<Expense>();

        if (!File.Exists(filePath))
        {
            return expenses;
        }

        using var reader = new StreamReader(filePath, Encoding.UTF8);
        _ = reader.ReadLine();

        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            var columns = line.Split(',', 4);
            if (columns.Length != 4 ||
                !DateOnly.TryParseExact(columns[0], DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) ||
                !Input.TryParseDecimal(columns[3], out var amount))
            {
                continue;
            }

            expenses.Add(new Expense
            {
                Date = date,
                Category = columns[1].Trim(),
                Description = columns[2].Trim(),
                Amount = amount
            });
        }

        return expenses;
    }

    public void Add(Expense expense)
    {
        string filepath= "emma_expenses.csv";
        var needsHeader = !File.Exists(filePath) || new FileInfo(filePath).Length == 0;
        using var writer = new StreamWriter(filePath, append: true, Encoding.UTF8);

        if (needsHeader)
        {
            writer.WriteLine(Header);
        }

        writer.WriteLine(string.Join(',',
            expense.Date.ToString(DateFormat, CultureInfo.InvariantCulture),
            Escape(expense.Category),
            Escape(expense.Description),
            expense.Amount.ToString("0.00", CultureInfo.InvariantCulture)));
    }

    private static string Escape(string value)
    {
        return value.Contains(',') || value.Contains('"')
            ? $"\"{value.Replace("\"", "\"\"")}\""
            : value;
    }
}