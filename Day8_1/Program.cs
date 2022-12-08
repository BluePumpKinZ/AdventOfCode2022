List<List<int>> trees = new List<List<int>>();

string[] lines = File.ReadAllLines("data.txt");
for (int i = 0; i < lines.Length; i++) {
    trees.Add(new List<int>());
    for (int j = 0; j < lines[i].Length; j++) {
        trees[i].Add(int.Parse(lines[i][j].ToString ()));
    }
}

List<List<bool>> visible = new List<List<bool>>();
// init visible
for (int i = 0; i < trees.Count; i++) {
    visible.Add(new bool[trees[i].Count].ToList ());
}

// find all visible trees from every side
// left
for (int i = 0; i < trees.Count; i++) {
    int max = -1;
    for (int j = 0; j < trees[i].Count; j++) {
        if (trees[i][j] > max) {
            visible[i][j] = true;
            max = trees[i][j];
        }
    }
}

// right
for (int i = 0; i < trees.Count; i++) {
    int max = -1;
    for (int j = trees[i].Count - 1; j >= 0; j--) {
        if (trees[i][j] > max) {
            visible[i][j] = true;
            max = trees[i][j];
        }
    }
}

// top
for (int i = 0; i < trees[0].Count; i++) {
    int max = -1;
    for (int j = 0; j < trees.Count; j++) {
        if (trees[j][i] > max) {
            visible[j][i] = true;
            max = trees[j][i];
        }
    }
}

// bottom
for (int i = 0; i < trees[0].Count; i++) {
    int max = -1;
    for (int j = trees.Count - 1; j >= 0; j--) {
        if (trees[j][i] > max) {
            visible[j][i] = true;
            max = trees[j][i];
        }
    }
}

// count the visibles
int count = 0;
for (int i = 0; i < visible.Count; i++) {
    for (int j = 0; j < visible[i].Count; j++) {
        count += visible[i][j] ? 1 : 0;
    }
}

Console.WriteLine(count);