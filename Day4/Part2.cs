var paperRollsRaw = File.ReadAllLines("input.txt");

var paperRollsMap = paperRollsRaw.Select(row => row.ToCharArray()).ToArray();


int paperRollsThatCanBeAccessed = 0;

int storageRow = 0;
int storageColumn = 0;
int rollsRemovedInThisLoop = -1;
while (rollsRemovedInThisLoop != 0) {
    rollsRemovedInThisLoop = 0;
    foreach (var paperRollRow in paperRollsRaw) {
        foreach (var paperRoll in paperRollRow) {
            if (paperRoll == '@') {
                if (CheckRollAccessibility(storageRow, storageColumn)) {
                    paperRollsThatCanBeAccessed++;
                    rollsRemovedInThisLoop++;
                    paperRollsMap[storageRow][storageColumn] = 'x';
                }
            }
            storageColumn++;
        }
        storageRow++;
        storageColumn = 0;
    }
    
} 

Console.WriteLine("------------------");
Console.WriteLine(paperRollsThatCanBeAccessed);

bool CheckRollAccessibility(int row, int col) {
    int rows = paperRollsMap.Length;
    int cols = paperRollsMap[0].Length;

    int minRow = Math.Max(0, row - 1);
    int maxRowExclusive = Math.Min(rows, row + 2); // +2 because end is exclusive

    int minCol = Math.Max(0, col - 1);
    int maxColExclusive = Math.Min(cols, col + 2);

    Console.WriteLine($"{row},{col}: {minRow},{maxRowExclusive - 1},{minCol},{maxColExclusive - 1}");

    var rollsInProximity = paperRollsMap[minRow..maxRowExclusive]
        .Select(r => r[minCol..maxColExclusive])
        .ToArray();

    int centerRowInSlice = row - minRow;
    int centerColInSlice = col - minCol;
    rollsInProximity[centerRowInSlice][centerColInSlice] = ' ';
    
    var rollCountInProx = rollsInProximity.SelectMany(r => r).Count(c => c == '@');

    return rollCountInProx < 4;
}
