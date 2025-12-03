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
    List<long> joltDigits = [];
    int lastDigitPosition = 0;
    foreach (var i in Enumerable.Range(0, batteryCount)) {
        var startIndex = lastDigitPosition;
        var digitCount = digits.Count - (batteryCount - (i + 1)) - lastDigitPosition;
        var digitRange = digits.GetRange(startIndex, digitCount);
        var largestDigit = digitRange.Max();
        lastDigitPosition += digitRange.IndexOf(largestDigit) + 1;
        var digitWithPositionalOffset = Int64.Parse(largestDigit.ToString().PadRight(batteryCount - i, '0'));
        var formattedDigits = PrintWithHighlight(digits, startIndex, digitCount, ConsoleColor.Red);
        Console.WriteLine($"{formattedDigits}: {largestDigit}: {lastDigitPosition.ToString(),3}: {digitWithPositionalOffset.ToString().PadLeft(batteryCount, ' ')}");
        joltDigits.Add(digitWithPositionalOffset);
    }

    return joltDigits.Sum();
}    

static string PrintWithHighlight(List<int> digits, int startIndex, int count, ConsoleColor highlightColor) {
    // ANSI color codes (red) and reset
    const string red = "\u001b[31m";
    const string reset = "\u001b[0m";

    var outStr = "digits: ";
    for (int idx = 0; idx < digits.Count; idx++)
    {
        string s = digits[idx].ToString();
        if (idx == startIndex) s = $"{red}{s}";
        if (idx == startIndex+count-1) s = $"{s}{reset}";
        
        outStr += s;
    }

    return outStr;
}