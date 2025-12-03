var jolts = new List<int>();
foreach (var bank in File.ReadLines("input.txt")) {
    var digits = bank.ToList().ConvertAll(c => Int32.Parse(c.ToString()));
    var largestDigit = digits.GetRange(0, digits.Count - 1).Max();
    var largestDigitPosition = digits.IndexOf(largestDigit);
    var secondDigit = digits.GetRange(largestDigitPosition + 1, digits.Count - (largestDigitPosition + 1)).Max();
    
    Console.WriteLine($"{bank}: {largestDigit}{secondDigit}");
    jolts.Add((largestDigit * 10) + secondDigit);
}

Console.WriteLine("------------------");
Console.WriteLine(jolts.Sum());