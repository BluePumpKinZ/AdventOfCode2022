List<string> lines = File.ReadAllLines("data.txt").ToList();

int x = 1;
int cycle = 0;

List<(int cycle, int s)> cycleStrengths = new ();

for (int i = 0; i < lines.Count; i++) {
    ExecuteLine(lines[i]);
}

void TickUpCycle() {
    cycle++;

    CheckCycle();
}

void CheckCycle () {
    if ((cycle + 20) % 40 == 0) {
        cycleStrengths.Add((cycle, cycle * x));
        Console.WriteLine($"Cycle: {cycle}, X: {x}, SignalStrength: {cycle * x}");
    }
}

void ExecuteLine (string line) {
    if (line.Equals("noop"))
    {
        TickUpCycle();
        return;
    }
    TickUpCycle();
    TickUpCycle();
    int value = int.Parse(line.Substring(5));
    x += value;
    
}

Console.WriteLine(cycleStrengths.Where(v => v.cycle is >= 20 and <= 220).Sum(v => v.s));