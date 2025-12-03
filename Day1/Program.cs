int matches = 0;
int runningNumber = 50;
string currentSequence = "";
foreach (var rotation in File.ReadLines("input.txt")) {
    if (string.IsNullOrEmpty(rotation)) {
        continue;
    }
    int rotationNumber = int.Parse(
        rotation
            .Replace("L", "-")
            .Replace("R", "")
        );
    
    runningNumber += rotationNumber;
    currentSequence += rotation;

    if (runningNumber % 100 == 0) {
        matches++;
        Console.WriteLine($"curr: {runningNumber}, count: {matches}, sequence: {currentSequence}");
        currentSequence = "";
    }
}