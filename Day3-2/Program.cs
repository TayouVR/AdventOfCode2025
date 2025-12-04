var jolts = new List<long>();
foreach (var bank in File.ReadLines("input.txt")) {
    var digits = bank.ToList().ConvertAll(c => Int32.Parse(c.ToString()));
    var jolt = GetHighestNJolts(digits, 12);
    
    Console.WriteLine($"{bank}: {jolt}");
    jolts.Add(jolt);
}

Console.WriteLine("------------------");
Console.WriteLine(jolts.Sum());

long GetHighestNJolts(List<int> digits, int batteryCount) {
    List<int> joltDigits = [];
    int offset = 0;
    
    foreach (var i in Enumerable.Range(0, batteryCount)) {
        // joltDigits.Add(digits[offset..^(12 - 1 - i)].Max()); 
        // offset = digits[offset..].IndexOf(joltDigits.Last()) + 1;
        var endOffset = batteryCount - 1 - i;
        var digitRange = digits[offset..^endOffset];
        joltDigits.Add(digitRange.Max());
        var formattedDigits = PrintWithHighlight(digits, offset, endOffset);
        offset += digitRange.IndexOf(joltDigits.Last()) + 1;
        Console.WriteLine($"{formattedDigits}: {joltDigits.Last()}: {offset.ToString(),3}");
    }

    return long.Parse(string.Concat(joltDigits));
}    

static string PrintWithHighlight(List<int> digits, int startIndex, int endOffset) {
    // ANSI color codes (red) and reset
    const string red = "\u001b[31m";
    const string reset = "\u001b[0m";

    var outStr = "digits: ";
    for (int idx = 0; idx < digits.Count; idx++)
    {
        string s = digits[idx].ToString();
        if (idx == startIndex) s = $"{red}{s}";
        if (idx == digits.Count - endOffset - 1) s = $"{s}{reset}";
        
        outStr += s;
    }

    return outStr;
}