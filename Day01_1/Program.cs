List<string> lines = File.ReadAllLines("data.txt").ToList();

int max = 0;
int sum = 0;

for (int i = 0; i < lines.Count; i++) {
    if (int.TryParse(lines[i], out int number)) {
        sum += number;
    } else {
        if (sum > max) {
            max = sum;
        }
        sum = 0;
    }

}

if (sum > max) {
    max = sum;
}
sum = 0;

Console.WriteLine(max);