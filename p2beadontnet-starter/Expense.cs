namespace p2beadontnet_starter;

public sealed class Expense
{
    public DateOnly Date { get; init; }
    public string Category { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal Amount { get; init; }
}