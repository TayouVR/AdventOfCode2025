string input = File.ReadAllText("input.txt");


var invalidIds = new List<long>();
foreach (var range in input.Split(',')) {
    Console.WriteLine(range);
    var startEnd = range.Split('-').Select(long.Parse).ToArray();
    var min = startEnd[0];
    var max = startEnd[1];

    for (long id = min; id <= max; id++) {
        if (id.ToString().Length % 2 != 0) {
            continue;
        }

        var idHalfOne = id.ToString().Substring(0, id.ToString().Length / 2);
        var idHalfTwo = id.ToString().Substring(id.ToString().Length / 2);
        if (idHalfOne.Equals(idHalfTwo)) {
            invalidIds.Add(id);
        }
    }
}

Console.WriteLine("------------------");
Console.WriteLine(invalidIds.Sum());