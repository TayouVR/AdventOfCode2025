int matches = 0;
int runningNumber = 50;
string currentSequence = "";
int sequenceIncrease = 0;
foreach (string rotation in File.ReadLines("input.txt")) {
    if (string.IsNullOrEmpty(rotation)) {
        continue;
    }
    int rotationNumber = int.Parse(
        rotation
            .Replace("L", "-")
            .Replace("R", "")
    );
    
    sequenceIncrease += rotationNumber;
    currentSequence += rotation;
    Rotate(rotationNumber);
    
    if (runningNumber % 100 == 0) {
        currentSequence = "";
        sequenceIncrease = 0;
    }

    void Rotate(int rotations) {
        for (int i = 0; i < Math.Abs(rotations); i++) {
            runningNumber += rotations > 0 ? -1 : 1;
            
            if (runningNumber % 100 == 0) {
                matches++;
                Console.WriteLine($"curr: {runningNumber}, count: {matches}, {sequenceIncrease:0000}, sequence: {currentSequence}");
            }
        }
    }
}