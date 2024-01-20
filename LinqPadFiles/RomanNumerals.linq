<Query Kind="Program">
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>


void Main()
{
    // Convert the integer 1666 to a Roman numeral using the Solution method from RomanConvert class
    var result = RomanConvert.Solution(1666);
    
    // Output the result to the console
    Console.WriteLine(result);
}

public static class RomanConvert
{
    // Dictionary mapping Roman numerals to their integer values
    private static Dictionary<string, int> RomanNumerals = new Dictionary<string, int>
    {
        {"I", 1},
        {"IV", 4},
        {"V", 5},
        {"IX", 9},
        {"X", 10},
        {"XL", 40},
        {"L", 50},
        {"XC", 90},
        {"C", 100},
        {"CD", 400},
        {"D", 500},
        {"CM", 900},
        {"M", 1000}
    };

    // Method to convert an integer to a Roman numeral using a recursive approach
    public static string Solution(int n) => SolutionRecursive(n, RomanNumerals.OrderByDescending(pair => pair.Value));

    // Recursive method to construct the Roman numeral representation of the given integer
    private static string SolutionRecursive(int n, IEnumerable<KeyValuePair<string, int>> romanNumerals)
    {
        return (n == 0 || !romanNumerals.Any())
        ? ""
        : (n >= romanNumerals.First().Value)
            ? romanNumerals.First().Key + SolutionRecursive(n - romanNumerals.First().Value, romanNumerals)
            : SolutionRecursive(n, romanNumerals.Skip(1));
    }
}
