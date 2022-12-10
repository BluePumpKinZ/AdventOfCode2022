List<char> chars = File.ReadAllLines("data.txt")[0].ToCharArray().ToList();

for (int i = 3; i < chars.Count; i++) {

    bool areDifferent = chars.Skip(i - 13).Take(14).Distinct().Count() == 14;
    if (areDifferent) {
        Console.WriteLine(i + 14);
        return;
    }

}

