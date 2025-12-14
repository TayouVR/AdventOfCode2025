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

var availableIds = input
    .Where(line => !line.Contains('-') && !string.IsNullOrEmpty(line));

bool IsInRange(long id, long[] range) {
    return id >= range[0] && id <= range[1];
}

bool IsInAnyRange(long id, long[][] ranges) {
    return ranges.Any(range => IsInRange(id, range));
}

var availableIdIsFresh = 0;
foreach (var id in availableIds) {
    availableIdIsFresh += IsInAnyRange(long.Parse(id), validRanges) ? 1 : 0;
}

Console.WriteLine(availableIdIsFresh);
