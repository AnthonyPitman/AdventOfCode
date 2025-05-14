namespace AdventOfCodeApp.Utils;

public static class InputReader
{
    public static string[] ReadInput(int year, int day, bool useSample = false)
    {
        var path = useSample
            ? Path.Join("..", "..", "..", "Samples", year.ToString(), $"Day{day}_Sample.txt")
            : Path.Join("..", "..", "..", "Inputs", year.ToString(), $"Day{day}_Input.txt");

        string[] contents;
        if (File.Exists(path))
        {
            contents = File.ReadAllLines(path);
        }
        else
        {
            throw new FileNotFoundException();
        }

        if (contents.Length < 1)
        {
            throw new InvalidOperationException($"No contents were found in the file at `{path}`.");
        }

        return contents;
    }
}