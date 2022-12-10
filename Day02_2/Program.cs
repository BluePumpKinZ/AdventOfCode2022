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

List<string> loses = new List<string>()
{
    "A Z",
    "B X",
    "C Y"
};
for (int i = 0; i < lines.Count; i++) {

    int _score = 0;
    string answer = "";

    switch (lines[i].Split (' ')[1]) {
    case "X":
        answer = loses.Single(t => lines[i].First() == t.First());
        break;
    case "Y":
        answer = equals.Single(t => lines[i].First() == t.First());
        score += 3;
        break;
    case "Z":
        answer = wins.Single(t => lines[i].First() == t.First());
        score += 6;
        break;
    }

    _score += answer.Split(' ')[1] switch {
        "X" => 1,
        "Y" => 2,
        "Z" => 3,
        _ => throw new ArgumentException()
    };

    score += _score;

}

Console.WriteLine(score);