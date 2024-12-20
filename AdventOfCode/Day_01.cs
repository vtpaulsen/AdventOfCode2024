namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly string _input;

    public Day_01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public IEnumerable<(int, int)> ParseInputToPairs()
    {
        return _input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                return (int.Parse(parts[0]), int.Parse(parts[1]));
            });
    }

    public int Solve_1_part_1()
    {
        var pairs = ParseInputToPairs().ToArray();
        int n = pairs.Length;

        int[] left = new int[n];
        int[] right = new int[n];

        for (int i = 0; i < n; i++)
        {
            (left[i], right[i]) = pairs[i];
        }

        Array.Sort(left);
        Array.Sort(right);

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += Math.Abs(left[i] - right[i]);
        }

        return sum;
    }

    public int Solve_1_part_2()
    {
        var pairs = ParseInputToPairs().ToArray();
        int n = pairs.Length;

        Dictionary<int, int> leftMap = new();
        int[] left = new int[n];
        int[] right = new int[n];

        for (int i = 0; i < n; i++)
        {
            (left[i], right[i]) = pairs[i];
            if (!leftMap.ContainsKey(left[i]))
                leftMap[left[i]] = 0;
        }

        foreach (int num in right)
        {
            if (leftMap.ContainsKey(num))
                leftMap[num]++;
        }

        int sum = 0;
        foreach (int num in left)
        {
            if (leftMap.TryGetValue(num, out int count))
                sum += num * count;
        }

        return sum;
    }


    public override ValueTask<string> Solve_1() => new($"{Solve_1_part_1()}");

    public override ValueTask<string> Solve_2() => new($"{Solve_1_part_2()}");
}
