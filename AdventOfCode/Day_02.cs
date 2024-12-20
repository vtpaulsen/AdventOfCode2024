namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly string[] _input;

    public Day_02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public int Solve_2_part_1()
    {
        var safe = 0;

        var rows = _input.Select(row => row.Split(' ').Select(int.Parse).ToList());

        foreach (var row in rows)
        {
            if (IsSafe(row)) safe++;
        }

        return safe;
    }

    public int Solve_2_part_2()
    {
        var safe = 0;

        var rows = _input.Select(row => row.Split(' ').Select(int.Parse).ToList());

        foreach (var row in rows)
        {
            if (IsSafe(row)) safe++;
            else {
                for (var i = 0; i < row.Count(); i++)
                {
                    var rowCopy = new List<int>(row);
                    rowCopy.RemoveAt(i);

                    if (IsSafe(rowCopy))
                    {
                        safe++;
                        break;
                    }
                }
            }
        }

        return safe;
    }

    public static bool IsSafe(List<int> row)
    {
        var diff = false;
        var inc = false;
        var dec = false;

        for (var i = 0; i < row.Count() - 1; i++)
        {
            if (0 == Math.Abs(row[i] - row[i + 1]) || Math.Abs(row[i] - row[i + 1]) > 3) diff = true;

            if (row[i] > row[i + 1]) dec = true;
            if (row[i] < row[i + 1]) inc = true;

            if (diff || (inc && dec)) break;
        }

        if (!diff && ((!inc && dec) || (inc && !dec))) return true;
        else return false;
    }

    public override ValueTask<string> Solve_1() => new($"{Solve_2_part_1()}");

    public override ValueTask<string> Solve_2() => new($"{Solve_2_part_2()}");
}
