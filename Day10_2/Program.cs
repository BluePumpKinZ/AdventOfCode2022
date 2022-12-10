List<string> lines = File.ReadAllLines("data.txt").ToList();

int x = 1;
int cycle = 1;

List<(int cycle, int s)> cycleStrengths = new();

for (int i = 0; i < lines.Count; i++) {
    ExecuteLine(lines[i]);
}

void TickUpCycle () {

    bool contained = Math.Abs(cycle % 40 - x) <= 1;
    Console.Write(contained ? "#" : ".");

    CheckLine();

    cycle++;
}

void CheckLine () {
    if (cycle % 40 == 0) {
        Console.WriteLine();
    }
}

void ExecuteLine (string line) {
    if (line.Equals("noop")) {
        TickUpCycle();
        return;
    }
    TickUpCycle();
    
    int value = int.Parse(line.Substring(5));
    x += value;
    TickUpCycle();
}