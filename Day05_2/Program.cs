
/*
    [H]         [D]     [P]        
[W] [B]         [C] [Z] [D]        
[T] [J]     [T] [J] [D] [J]      
[H] [Z]     [H] [H] [W] [S]     [M]
[P] [F] [R] [P] [Z] [F] [W]     [F]
[J] [V] [T] [N] [F] [G] [Z] [S] [S]
[C] [R] [P] [S] [V] [M] [V] [D] [Z]
[F] [G] [H] [Z] [N] [P] [M] [N] [D]
 1   2   3   4   5   6   7   8   9 
*/

using System.Text.RegularExpressions;

List<List<char>> stacks = new List<List<char>> {
    new List<char> {
        'F', 'C', 'J', 'P', 'H', 'T', 'W'
    },
    new List<char> {
        'G', 'R', 'V', 'F', 'Z', 'J', 'B', 'H'
    },
    new List<char> {
        'H', 'P', 'T', 'R'
    },
    new List<char> {
        'Z', 'S', 'N', 'P', 'H', 'T'
    },
    new List<char> {
        'N', 'V', 'F', 'Z', 'H', 'J', 'C', 'D'
    },
    new List<char> {
        'P', 'M', 'G', 'F', 'W', 'D', 'Z'
    },
    new List<char> {
        'M', 'V', 'Z', 'W', 'S', 'J', 'D', 'P'
    },
    new List<char> {
        'N', 'D', 'S'
    },
    new List<char> {
        'D', 'Z', 'S', 'F', 'M'
    }
};

List<string> lines = File.ReadAllLines("data.txt").ToList();

for (int i = 0; i < lines.Count; i++) {

    // ge the numbers from the following format with a regex: move 2 from 8 to 2
    Match match = Regex.Match(lines[i], @"(\d+) from (\d+) to (\d+)");
    int amount = int.Parse(match.Groups[1].Value);
    int from = int.Parse(match.Groups[2].Value);
    int to = int.Parse(match.Groups[3].Value);

    // move the disks as a whole
    List<char> disks = stacks[from - 1].GetRange(stacks[from - 1].Count - amount, amount);
    stacks[from - 1].RemoveRange(stacks[from - 1].Count - amount, amount);
    stacks[to - 1].AddRange(disks);

}

// print the top disks
for (int i = 0; i < stacks.Count; i++) {
    Console.Write(stacks[i][stacks[i].Count - 1]);
}
