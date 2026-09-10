using System.Globalization;

namespace p2beadontnet_starter;

public static class Input
{
    public static string ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var value = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            Console.WriteLine("La valeur est obligatoire.");
        }
    }

    public static int ReadMenuChoice()
    {
        while (true)
        {
            Console.Write("Votre choix : ");
            if (int.TryParse(Console.ReadLine(), out var choice))
            {
                return choice;
            }

            Console.WriteLine("Choisissez un numéro valide.");
        }
    }

    public static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (TryParseDecimal(Console.ReadLine(), out var value))
            {
                return value;
            }

            Console.WriteLine("Saisissez un nombre valide, par exemple 1234,56 ou 1234.56.");
        }
    }

    public static bool TryParseDecimal(string? text, out decimal value)
    {
        var normalized = text?.Trim().Replace(',', '.') ?? string.Empty;
        if (decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
        {
            return true;
        }

        return decimal.TryParse(text, NumberStyles.Number, CultureInfo.GetCultureInfo("fr-FR"), out value);
    }
}