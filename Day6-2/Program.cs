var input = File.ReadAllLines("input.txt");

static List<(List<string> numbers, char op)> SplitListIntoBlocks(char[][] rows) {
    List<(List<string> numbers, char op)> outputList = [];

    (List<string> numbers, char op) currentBlock = (numbers: [], op: ' ');
    foreach (char[] row in rows) {
        if (row.Length == 0 || string.IsNullOrWhiteSpace(new string(row))) continue;
        if (row[^1] == '+' || row[^1] == '*') {
            currentBlock = (numbers: [], op: row[^1]);
            currentBlock.numbers.Add(new string(row[..^1]));
            outputList.Add(currentBlock);
        } else {
            currentBlock.numbers.Add(new string(row[..^1]));
        }
    }

    return outputList;
}

T[][] Transpose<T>(T[][] matrix)
{
    if (matrix == null || matrix.Length == 0) return [];
    int rows = matrix.Length;
    int cols = matrix[0].Length;
    return Enumerable.Range(0, cols)
        .Select(c => Enumerable.Range(0, rows).Select(r => matrix[r][c]).ToArray())
        .ToArray();
}

var inputMap = input.Select(line => line.ToArray()).ToArray();

var data = SplitListIntoBlocks(Transpose(inputMap));

Int64 finalSum = 0;
foreach (var row in data) {
    var operation = row.op;
    Int64 result = 0;
    switch (operation) {
        case '+': {
            result = row.numbers.Select(a => Int64.Parse(a)).Aggregate((a, b) => a + b);
            break;
        }
        case '*': {
            result = row.numbers.Select(a => Int64.Parse(a)).Aggregate((a, b) => a * b);
            break;
        }
    }

    if (row.numbers.Count <= 0) {
        throw new Exception("No numbers in row");
    }
    Console.WriteLine($"{string.Join(row.op, row.numbers)} = {result}");
    finalSum += result;
}

Console.WriteLine("------------------");
Console.WriteLine(finalSum);
