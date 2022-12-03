List<string> lines = File.ReadAllLines("data.txt").ToList();

long sum = 0;

for (int i = 0; i < lines.Count; i++) {

    string firstHalf = lines[i].Substring(0, lines[i].Length / 2);
    string secondHalf = lines[i].Substring(lines[i].Length / 2);

    char letterInCommon = FindLetterInCommom(firstHalf, secondHalf);

    sum += GetScore(letterInCommon);

}

Console.WriteLine(sum);

char FindLetterInCommom (string firstHalf, string secondHalf) {

    for (int i = 0; i < firstHalf.Length; i++) {

        if (secondHalf.Contains(firstHalf[i])) {

            return firstHalf[i];

        }
    }

    throw new Exception();

}

int GetScore (char c) {
    // To help prioritize item rearrangement, every item type can be converted to a priority:

    // Lowercase item types a through z have priorities 1 through 26.
    // Uppercase item types A through Z have priorities 27 through 52.

    // In the above example, the priority of the item type that appears in both compartments of each rucksack is 16(p), 38(L), 42(P), 22(v), 20(t), and 19(s); the sum of these is 157.

    if (c is >= 'a' and <= 'z') {
        return c - 'a' + 1;
    } else if (c is >= 'A' and <= 'Z') {
        return c - 'A' + 27;
    } else {
        throw new Exception();
    }
}