string input = File.ReadAllText("input.txt");


var invalidIds = new List<long>();
foreach (var range in input.Split(',')) {
    Console.WriteLine(range);
    var startEnd = range.Split('-').Select(long.Parse).ToArray();
    var min = startEnd[0];
    var max = startEnd[1];

    for (long id = min; id <= max; id++) {
        if (IdIsInvalid(id)) {
            invalidIds.Add(id);
        }
    }
}

Console.WriteLine("------------------");
Console.WriteLine(invalidIds.Sum());

bool IdIsInvalid(long id) {
    string idStr = id.ToString();
    // id is invalid if it consists only of any number of identical patterns of any length, e.g. 123123123, or 1212, or 4545454545.
    for (int len = 1; len < (idStr.Length / 2) + 1; len++) {
        if (idStr.Length % len != 0) continue;
        
        string pattern = idStr.Substring(0, len);
        string stringAsPattern = string.Concat(Enumerable.Repeat(pattern, idStr.Length / len));
        if (idStr.Equals(stringAsPattern)) {
            Console.WriteLine($"{id} has pattern {pattern}");
            return true;
        }
    }

    // Console.WriteLine($"{id} doesn't have any patterns");
    return false;
}