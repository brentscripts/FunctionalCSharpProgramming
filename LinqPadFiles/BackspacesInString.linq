<Query Kind="Program" />

using System;
using System.Linq;
using System.Text;

public static class FunctionalExtensions
{
    // Function that processes a character with backspace logic
    public static Func<StringBuilder, char, StringBuilder> ProcessCharacterWithBackspace()
    {
        return (sb, c) => (c == '#' && sb.Length > 0) ? sb.Remove(sb.Length - 1, 1) : sb.Append(c);
    }
}

class Program
{
    static void Main()
    {
        // # represents a backspace
        Console.WriteLine(ProcessStringWithBackspace("abc#d##c"));      // Output: "ac"
        Console.WriteLine(ProcessStringWithBackspace("abc##d######"));  // Output: ""
        Console.WriteLine(ProcessStringWithBackspace("#######"));       // Output: ""
        Console.WriteLine(ProcessStringWithBackspace(""));              // Output: ""
    }

    // Function that processes a string with backspace logic
    static string ProcessStringWithBackspace(string s)
    {
		// Count consecutive backspaces at the beginning of the string
        int initialBackspaces = s.TakeWhile(c => c == '#').Count();

	    // Skip the initial backspaces and process the remaining string
	    var result = s.Skip(initialBackspaces)
	                  .Aggregate(new StringBuilder(), FunctionalExtensions.ProcessCharacterWithBackspace());

	    return result.ToString();
    }
}

