namespace AdventOfCodeApp;

public static class ScaffoldGenerator
{
    const string SolutionPath = "./Solutions";
    const string InputsPath = "./Inputs";
    const string SamplesPath = "./Sample";

    public static void GenerateDayScaffold(int year, int day)
    {
        // Ensure directories exist
        Directory.CreateDirectory(Path.Combine(SolutionPath, $"Year{year}"));
        Directory.CreateDirectory(Path.Combine(InputsPath, $"{year}"));
        Directory.CreateDirectory(Path.Combine(SamplesPath, $"{year}"));

        // Generate solution files
        var solutionFile = Path.Combine(SolutionPath, $"Year{year}", $"Day{day}.cs");
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
        CreateEmptyFileIfNotExists(Path.Combine(InputsPath, $"{year}", $"{year}_Day{day}_Input.txt"));
        CreateEmptyFileIfNotExists(Path.Combine(SamplesPath, $"{year}", $"{year}_Day{day}_Sample.txt"));
    }

    private static void CreateEmptyFileIfNotExists(string filePath) {
        if (!File.Exists(filePath)) {
            File.WriteAllText(filePath, string.Empty);
            Console.WriteLine($"Created: {filePath}");
        } else {
            Console.WriteLine($"File already exists: {filePath}");
        }
    }

    private static string GetSolutionTemplate(int year, int day) {
        return $@"
using System;

namespace AdventOfCode.Solutions.Year{year} {{
    public class Day{day} : IDaySolution {{
        public string SolvePart1(string input) {{
            // TODO: Implement Part 1
            return ""Not implemented"";
        }}

        public string SolvePart2(string input) {{
            // TODO: Implement Part 2
            return ""Not implemented"";
        }}
    }}
}}
";
    }
}