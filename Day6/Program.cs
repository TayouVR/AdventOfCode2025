var input = File.ReadAllLines("input.txt");

var rows = input
    .Select(line => line
        .Split(' ')
        .Where(num => !string.IsNullOrEmpty(num))
        .ToArray()
    )
    .ToArray();

T[][] Transpose<T>(T[][] matrix)
{
    if (matrix == null || matrix.Length == 0) return Array.Empty<T[]>();
    int rows = matrix.Length;
    int cols = matrix[0].Length;
    return Enumerable.Range(0, cols)
        .Select(c => Enumerable.Range(0, rows).Select(r => matrix[r][c]).ToArray())
        .ToArray();
}

var transposedData = Transpose(rows)
    .Select(row => (
    nums: row[..^1].Select(long.Parse).ToArray(), 
    operation: row[^1]
));

long finalSum = 0;
foreach (var row in transposedData) {
    var operation = row.operation;
    Console.WriteLine(string.Join(row.operation, row.nums));
    switch (operation) {
        case "+": {
            finalSum += row.nums.Aggregate((a, b) => a + b);
            break;
        }
        case "-": {
            finalSum += row.nums.Aggregate((a, b) => a - b);
            break;
        }
        case "*": {
            finalSum += row.nums.Aggregate((a, b) => a * b);
            break;
        }
        case "/": {
            finalSum += row.nums.Aggregate((a, b) => a / b);
            break;
        }
            
    }
}

Console.WriteLine("------------------");
Console.WriteLine(finalSum);