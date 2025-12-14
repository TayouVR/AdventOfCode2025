var input = File.ReadAllLines("input.txt");

var validRanges = input
    .Where(line => line
        .Contains('-')
    )
    .Select(line => line
        .Split('-')
        .Select(long.Parse)
        .ToArray()
    )
    .ToArray();
long validIdCount = 0;

List<long[]> MergeRanges(long[][] ranges)
{
    if (ranges == null || ranges.Length == 0) return new List<long[]>();

    // Normalize (ensure start <= end) and sort by start, probably overkill for my input data, but w/e
    var sorted = ranges
        .Select(r => new long[] { Math.Min(r[0], r[1]), Math.Max(r[0], r[1]) })
        .OrderBy(r => r[0])
        .ToArray();

    var result = new List<long[]>();
    long currentStart = sorted[0][0];
    long currentEnd = sorted[0][1];

    foreach (var r in sorted.Skip(1))
    {
        long start = r[0];
        long end = r[1];

        if (start <= currentEnd + 1) // overlap or adjacent -> merge
        {
            if (end > currentEnd) currentEnd = end;
        }
        else
        {
            result.Add(new long[] { currentStart, currentEnd });
            currentStart = start;
            currentEnd = end;
        }
    }

    result.Add(new long[] { currentStart, currentEnd });
    return result;
}

foreach (var validRange in MergeRanges(validRanges)) {
    long a = validRange[0];
    long b = validRange[1];
    validIdCount += b - a + 1;
}

Console.WriteLine(validIdCount);