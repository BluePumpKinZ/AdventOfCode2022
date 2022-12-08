List<List<int>> trees = new List<List<int>>();

string[] lines = File.ReadAllLines("data.txt");
for (int i = 0; i < lines.Length; i++) {
    trees.Add(new List<int>());
    for (int j = 0; j < lines[i].Length; j++) {
        trees[i].Add(int.Parse(lines[i][j].ToString()));
    }
}

long max = 0;
for (int i = 0; i < trees.Count; i++) {
    for (int j = 0; j < trees[i].Count; j++) {
        long score = GetScenicScore(i, j);
        if (score > max) {
            max = score;
        }
    }
}
Console.WriteLine(max);

long GetScenicScore (int x, int y) {

    int right = 0;
    for (int i = x + 1; i < trees[y].Count; i++) {
        right++;
        if (trees[y][i] >= trees[y][x]) {
            break;
        }
    }

    int left = 0;
    for (int i = x - 1; i >= 0; i--) {
        left++;
        if (trees[y][i] >= trees[y][x]) {
            break;
        }
    }

    int bottom = 0;
    for (int i = y + 1; i < trees.Count; i++) {
        bottom++;
        if (trees[i][x] >= trees[y][x]) {
            break;
        }
    }
    
    int top = 0;
    for (int i = y - 1; i >= 0; i--) {
        top++;
        if (trees[i][x] >= trees[y][x]) {
            break;
        }
  
    }

    /*
    Console.WriteLine("left: " + left);
    Console.WriteLine("right: " + right);
    Console.WriteLine("top: " + top);
    Console.WriteLine("bottom: " + bottom);
    */
    
    return left * right * bottom * top;

}