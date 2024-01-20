<Query Kind="Program">
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

void Main()
{
    // Create an instance of the Kata class
    var kataInstance = new Kata();

    // Call the BreakCamelCase method with a sample input
    var result = kataInstance.BreakCamelCase("camelCase");

    // Output the result to the console
    Console.WriteLine(result);
}

public class Kata
{
    // Method to break camel case by inserting spaces before uppercase letters
    public string BreakCamelCase(string str)
    {
        // Concatenate the characters of the input string
        // If a character is uppercase and not the first character, insert a space before it
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? " " + x.ToString() : x.ToString()));
    }
}
