List<char> chars = File.ReadAllLines("data.txt")[0].ToCharArray().ToList ();

for (int i = 3; i < chars.Count; i++) {
    
    bool areDifferent = chars.Skip(i - 3).Take(4).Distinct().Count() == 4;
    if (areDifferent) {
        Console.WriteLine(i + 1);
        return;
    }

}

