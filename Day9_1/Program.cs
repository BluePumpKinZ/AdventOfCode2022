List<string> lines = File.ReadAllLines("data.txt").ToList();

int headPosX = 0;
int headPosY = 0;

int tailPosX = 0;
int tailPosY = 0;
List<(int x, int y)> passedPositions = new() { (headPosX, headPosY) };

for (int i = 0; i < lines.Count; i++) {

    // amount
    int amount = int.Parse(lines[i].Substring(1));

    // direction
    char direction = lines[i][0];

    // move
    for (int j = 0; j < amount; j++) {
        Move(direction);
        TailFollow();
        AddTailPos();
    }


}

void Move (char direction) {
    switch (direction) {
    case 'U':
        headPosY++;
        break;
    case 'D':
        headPosY--;
        break;
    case 'L':
        headPosX--;
        break;
    case 'R':
        headPosX++;
        break;
    }
}

void TailFollow () {
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
}

void AddTailPos () {
    // check if we have passed this position before
    if (!passedPositions.Contains((tailPosX, tailPosY))) {
        // add position to list
        passedPositions.Add((tailPosX, tailPosY));
    }
}

void PrintBoard () {
    int xMin = passedPositions.Min(x => x.x) - 2;
    int xMax = passedPositions.Max(x => x.x) + 2;
    int yMin = passedPositions.Min(x => x.y) - 2;
    int yMax = passedPositions.Max(x => x.y) + 2;

    for (int y = yMax; y >= yMin; y--) {
        for (int x = xMin; x <= xMax; x++) {
            if (x == headPosX && y == headPosY) {
                Console.Write("H");
            } else if (x == tailPosX && y == tailPosY) {
                Console.Write("T");
            } else if (passedPositions.Contains((x, y))) {
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