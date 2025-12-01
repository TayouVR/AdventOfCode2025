
string rotationString = File.ReadAllText("input.txt");

List<string> rotationList = rotationString.Split('\n').ToList();

int matches = 0;
int runningNumber = 50;
string currentSequence = "";
foreach (string rotation in rotationList) {
    if (string.IsNullOrEmpty(rotation)) {
        continue;
    }
    int rotationNumber = rotation.StartsWith("L") ? -int.Parse(rotation.Substring(1)) : int.Parse(rotation.Substring(1));
    
    runningNumber += rotationNumber;
    currentSequence += rotation;

    if (runningNumber % 100 == 0) {
        matches++;
        Console.WriteLine($"curr: {runningNumber}, count: {matches}, sequence: {currentSequence}");
        currentSequence = "";
    }
}