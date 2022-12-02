List<string> lines = File.ReadAllLines("data.txt").ToList();

long score = 0;

List<string> wins = new List<string>()
{
    "A Y",
    "B Z",
    "C X"
};

List<string> equals = new List<string>()
{
    "A X",
    "B Y",
    "C Z"
};
for (int i = 0; i < lines.Count; i++) {
    int _score = lines[i].Split(' ')[1] switch {
        "X" => 1,
        "Y" => 2,
        "Z" => 3,
        _ => throw new ArgumentException()
    };
    if (wins.Contains(lines[i])) {
        _score += 6;
    }
    if (equals.Contains(lines[i])) {
        _score += 3;
    }
    score += _score;
}

Console.WriteLine(score);