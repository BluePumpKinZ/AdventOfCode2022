using AoC2022;

Day9.Solve();

List<string> lines = File.ReadAllLines("data.txt").ToList();

int[] tailPosXs = new int[10];
int[] tailPosYs = new int[10];
List<(int x, int y)> passedPositions = new() { (tailPosXs[0], tailPosYs[0]) };

for (int i = 0; i < lines.Count; i++) {

    // amount
    int amount = int.Parse(lines[i].Substring(1));

    // direction
    char direction = lines[i][0];

    // move
    for (int j = 0; j < amount; j++) {
        Move(direction);
        for (int k = 0; k < 9; k++) {
            TailFollow(k);
        }
        AddTailPosses(9);
    }

    


}

void Move (char direction) {
    switch (direction) {
    case 'U':
        tailPosYs[0]++;
        break;
    case 'D':
        tailPosYs[0]--;
        break;
    case 'L':
        tailPosXs[0]--;
        break;
    case 'R':
        tailPosXs[0]++;
        break;
    }
}

void TailFollow (int tailIndex) {

    int headPosX = tailPosXs[tailIndex];
    int headPosY = tailPosYs[tailIndex];
    int tailPosX = tailPosXs[tailIndex + 1];
    int tailPosY = tailPosYs[tailIndex + 1];

    // left
    if (headPosX + 1 < tailPosX) {
        tailPosX--;
        tailPosY = headPosY;
    }
    // right
    if (headPosX - 1 > tailPosX) {
        tailPosX++;
        tailPosY = headPosY;
    }
    // top
    if (headPosY + 1 < tailPosY) {
        tailPosY--;
        tailPosX = headPosX;
    }
    // bottom
    if (headPosY - 1 > tailPosY) {
        tailPosY++;
        tailPosX = headPosX;
    }

    tailPosXs[tailIndex + 1] = tailPosX;
    tailPosYs[tailIndex + 1] = tailPosY;
}

void AddTailPosses (int tailIndex) {
    // check if we have passed this position before
    if (!passedPositions.Contains((tailPosXs[tailIndex], tailPosYs[tailIndex]))) {
        // add position to list
        passedPositions.Add((tailPosXs[tailIndex], tailPosYs[tailIndex]));
    }
}

void PrintBoard () {
    int xMin = Math.Min(tailPosXs.Min(), passedPositions.Min(x => x.x)) - 2;
    int xMax = Math.Max(tailPosXs.Max(), passedPositions.Max(x => x.x)) + 2;
    int yMin = Math.Min(tailPosYs.Min(), passedPositions.Min(x => x.y)) - 2;
    int yMax = Math.Max(tailPosYs.Max(), passedPositions.Max(x => x.y)) + 2;

    for (int y = yMax; y >= yMin; y--) {
        for (int x = xMin; x <= xMax; x++) {
            bool wrote = false;
            for (int i = 0; i < tailPosXs.Length; i++) {
                if (x == tailPosXs[i] && y == tailPosYs[i]) {
                    Console.Write(i);
                    wrote = true;
                    break;
                }
            }
            if (wrote)
                continue;
            if (passedPositions.Contains((x, y))) {
                Console.Write("#");
            } else {
                Console.Write(".");
            }
        }
        Console.WriteLine();
    }
}

PrintBoard();

// count number of positions passed
Console.WriteLine(passedPositions.Count);