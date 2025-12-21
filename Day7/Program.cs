var input = File.ReadAllLines("input.txt");
var inputMap = input.Select(line => line.ToArray()).ToArray();

Int64 finalSum = 0;
for (int i = 1; i < inputMap.Length; i++) {
    for (int j = 0; j < inputMap[i].Length; j++) {
        var current = inputMap[i][j];
        var above = inputMap[i - 1][j];
        if (above is '|' or 'S' && current == '.') {
            inputMap[i][j] = '|';
            continue;
        }
        if (current == '^' && above == '|') {
            if (j < inputMap[i].Length && inputMap[i][j+1] == '.') {
                inputMap[i][j+1] = '|';
            }
            if (j > 0 && inputMap[i][j-1] == '.') {
                inputMap[i][j-1] = '|';
            }
            
            finalSum++;
            continue;
        }

        if (current == '^' && above != '|') {
            inputMap[i][j] = 'x';
        }
    }
    Console.WriteLine($"{new string(inputMap[i])}");
}

Console.WriteLine("------------------");
Console.WriteLine(finalSum);
