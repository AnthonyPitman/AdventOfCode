using System.CommandLine;
using AdventOfCodeApp.Utils;

namespace AdventOfCodeApp;

internal static class Program
{
    static void Main(string[] args)
    {
        RootCommand rootCommand = new("Advent of Code CLI App")
        {
            CreateSolveCommand(),
            CreateScaffoldCommand()
        };

        rootCommand.InvokeAsync(args).Wait();
    }

    private static Command CreateSolveCommand()
    {
        Option<int> yearOption = new("--year", "The year of the puzzle (e.g., 2022).")
        {
            IsRequired = true
        };

        Option<int> dayOption = new("--day", "The day of the puzzle (1-25).")
        {
            IsRequired = true
        };

        Option<int> partOption = new("--part", "The part of the puzzle (1 or 2).")
        {
            IsRequired = true
        };

        Option<bool> useSample = new("--sample", "Indicate to use the sample text instead of the input.");

        var solveCommand = new Command("solve", "Solve a specific puzzle.")
        {
            yearOption, dayOption, partOption, useSample
        };

        solveCommand.SetHandler((int year, int day, int part, bool sample) => {
            try {
                Console.WriteLine($"Running AoC {year}, Day {day}, Part {part}");
                var solution = SolutionManager.GetSolution(year, day);
                var input = InputReader.ReadInput(year, day, sample);
                var result = (part == 1) ? solution.SolvePart1(input) : solution.SolvePart2(input);
                Console.WriteLine($"AoC {year} Day {day} Part {part}: {result}");
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }, yearOption, dayOption, partOption, useSample);

        return solveCommand;
    }

    private static Command CreateScaffoldCommand() {
        var yearOption = new Option<int>(
                "--year",
                "The year to scaffold (e.g., 2024).")
            { IsRequired = true };

        var dayOption = new Option<int>(
                "--day",
                "The day to scaffold (1-25).")
            { IsRequired = true };

        var scaffoldCommand = new Command("scaffold", "Generate a scaffold for a specific day.") {
            yearOption, dayOption
        };

        scaffoldCommand.SetHandler((int year, int day) => {
            Console.WriteLine($"Scaffolding AoC {year}, Day {day}...");
            ScaffoldGenerator.GenerateDayScaffold(year, day);
            Console.WriteLine("Scaffold generation completed.");
        }, yearOption, dayOption);

        return scaffoldCommand;
    }
}