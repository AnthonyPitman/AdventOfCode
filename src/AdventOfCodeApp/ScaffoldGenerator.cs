namespace AdventOfCodeApp;

public static class ScaffoldGenerator
{
    const string SolutionsDirectory = "Solutions";
    const string InputsDirectory = "Inputs";
    const string SamplesDirectory = "Samples";

    public static void GenerateDayScaffold(int year, int day)
    {
        // Ensure directories exist
        Directory.CreateDirectory(Path.Join("..", "..", "..", SolutionsDirectory, year.ToString()));
        Directory.CreateDirectory(Path.Join("..", "..", "..", InputsDirectory, year.ToString()));
        Directory.CreateDirectory(Path.Join("..", "..", "..", SamplesDirectory, year.ToString()));

        // Generate solution files
        var solutionFile = Path.Join("..", "..", "..", SolutionsDirectory, year.ToString(), $"Day{day}.cs");
        if (!File.Exists(solutionFile))
        {
            File.WriteAllText(solutionFile, GetSolutionTemplate(year, day));
            Console.WriteLine($"Created: {solutionFile}");
        }
        else
        {
            Console.WriteLine($"Solution file already exists: {solutionFile}");
        }

        // Generate input files.
        CreateEmptyFileIfNotExists(Path.Join("..", "..", "..", InputsDirectory, year.ToString(), $"Day{day}_Input.txt"));
        CreateEmptyFileIfNotExists(Path.Join("..", "..", "..", SamplesDirectory, year.ToString(), $"Day{day}_Sample.txt"));
    }

    static void CreateEmptyFileIfNotExists(string filePath)
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, string.Empty);
            Console.WriteLine($"Created: {filePath}");
        }
        else
        {
            Console.WriteLine($"File already exists: {filePath}");
        }
    }

    static string GetSolutionTemplate(int year, int day)
    {
        return $$"""
                 namespace AdventOfCodeApp.Solutions._{{year}};

                 public class Day{{day}} : IDaySolution
                 {
                     public string SolvePart1(string[] input)
                     {
                         return "Not implemented";
                     }

                     public string SolvePart2(string[] input)
                     {
                         return "Not implemented";
                     }
                 }

                 """;
    }
}