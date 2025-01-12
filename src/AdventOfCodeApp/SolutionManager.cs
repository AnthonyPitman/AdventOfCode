namespace AdventOfCodeApp;

public static class SolutionManager
{
    const string SolutionsNamespace = "AdventOfCodeApp.Solutions";

    /// <summary>
    /// Dynamically retrieves a solution for the specified year and day.
    /// </summary>
    public static IDaySolution GetSolution(int year, int day) {
        var typeName = $"{SolutionsNamespace}.Year{year}.Day{day}";
        var type = Type.GetType(typeName);

        if (type == null) {
            throw new InvalidOperationException($"No solution found for AoC {year} Day {day}. Did you scaffold it?");
        }

        if (!typeof(IDaySolution).IsAssignableFrom(type)) {
            throw new InvalidOperationException($"Solution for AoC {year} Day {day} does not implement IDaySolution.");
        }

        return (IDaySolution)Activator.CreateInstance(type)!;
    }
}