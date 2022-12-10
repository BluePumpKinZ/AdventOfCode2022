List<string> lines = File.ReadAllLines("data.txt").ToList();

List<int> sums = new List<int>();
int sum = 0;

for (int i = 0; i < lines.Count; i++) {
    if (int.TryParse(lines[i], out int number)) {
        sum += number;
    } else {
        sums.Add(sum);
        sum = 0;
    }

}

sums.Add(sum);

int totalSum = sums.OrderByDescending(s => s).Take (3).Sum ();
Console.WriteLine(totalSum);