List<string> lines = File.ReadAllLines("data.txt").ToList();

long sum = 0;

for (int i = 0; i < lines.Count; i++) {

    string firstHalf = lines[i].Split(",")[0];
    string secondHalf = lines[i].Split(",")[1];

    var nums1 = GetMinMax(firstHalf);
    var nums2 = GetMinMax(secondHalf);

    if (CheckForOverlap(nums1, nums2)) {
        sum++;
    }

}

Console.WriteLine(sum);

(int min, int max) GetMinMax (string input) {

    int min = int.Parse(input.Split("-")[0]);
    int max = int.Parse(input.Split("-")[1]);

    return (min, max);

}

// if the 2 ranges overlap at all, return true
bool CheckForOverlap ((int min, int max) v1, (int min, int max) v2) {

    if (v1.min <= v2.min && v1.max >= v2.min) {
        return true;
    }

    if (v1.min <= v2.max && v1.max >= v2.max) {
        return true;
    }

    if (v2.min <= v1.min && v2.max >= v1.min) {
        return true;
    }

    if (v2.min <= v1.max && v2.max >= v1.max) {
        return true;
    }

    return false;

}
