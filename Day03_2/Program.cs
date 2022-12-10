List<string> lines = File.ReadAllLines("data.txt").ToList();

long sum = 0;

for (int i = 0; i < lines.Count - 2; i += 3) {

    char c = FindLettersInCommon3(lines[i], lines[i + 1], lines[i + 2])[0];

    sum += GetScore(c);

}

Console.WriteLine(sum);

string FindLettersInCommon2 (string firstHalf, string secondHalf) {

    string inCommon = "";

    for (int i = 0; i < firstHalf.Length; i++) {

        if (secondHalf.ToLower().Contains(char.ToLower (firstHalf[i]))) {

            inCommon += firstHalf[i];

        }
    }

    return inCommon;

}

string FindLettersInCommon3 (string first, string second, string third) {

    string inCommon = "";

    for (int i = 0; i < first.Length; i++) {

        if (second.Contains(first[i]) && third.Contains(first[i])) {

            inCommon += first[i];

        }
    }

    return inCommon;

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