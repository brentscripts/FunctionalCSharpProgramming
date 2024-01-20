<Query Kind="Program" />

void Main()
{
    // Create a list of integers
    List<int> numbers = new List<int> { 1, 3, 5, 9, 11 };

    // Call the FindMissing method to identify the missing term in the list
    var missingTerm = FindMissing(numbers);

    // Output the missing term to the console
    Console.WriteLine($"The missing term is: {missingTerm}");
}

// Function to find the missing term in a list of consecutive integers
public static int FindMissing(List<int> list)
{
    // Ensure the list has at least three elements
    if (list.Count < 3)
    {
        throw new ArgumentException("List should have at least three elements.");
    }

    // Step 1: Determine the common difference between consecutive elements
    int commonDifference = list[2] - list[1];

    // Step 2: Use LINQ to find the missing term
    int? missingTerm = Enumerable.Range(0, list.Count - 1)
                                   .Where(i => list[i + 1] != list[i] + commonDifference)
                                   .Select(i => list[i] + commonDifference)
                                   .FirstOrDefault();

    // Check if a missing term was found
    if (missingTerm.HasValue)
    {
        return missingTerm.Value;
    }

    // This should not be reached in a valid arithmetic progression
    throw new InvalidOperationException("No missing term found.");
}



