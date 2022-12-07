﻿string input = System.IO.File.ReadAllText("data.txt");

string[] commands = input.Replace("\r", "").Split("\n$ ").Skip(1).ToArray ();

Dir root = new Dir("/");

string path = "";
for (int i = 0; i < commands.Length; i++) {

    string keyword = new string(commands[i].Take(2).ToArray());
    string _args = new string(commands[i].Skip(3).ToArray());
    switch (keyword) {
        case "cd":
        if (_args.StartsWith("/")) {
            path = _args;
        } else if (_args == "..") {
            path = new string(path.Take(path.LastIndexOf("/")).ToArray());
        } else {
            path = (path + "/" + _args).Replace ("//", "/");
        }
        break;
    case "ls":
        var entries = _args.Split("\n");
        foreach (var entry in entries) {
            if (entry == "") continue;
            if (entry.StartsWith("dir")) {
                root.GetFolder (path + "/" + entry.Split(" ")[1]);
            } else {
                string filename = entry.Split(" ")[1];
                long filesize = long.Parse(entry.Split(" ")[0]);
                root.AddFile(new File(filename, filesize), path);
            }
        }
        break;
    }

}

List<Dir> max100000 = new List<Dir>();

root.GetTotalFileSize (max100000);

Console.WriteLine(max100000.Sum (d => d.GetTotalFileSize(new List<Dir> ())));


class Dir {

    public string Path { get; set; } = "";
    public List<Dir> Dirs { get; set; } = new();
    public List<File> Files { get; set; } = new();

    public Dir (string path) {
        Path = path;
    }

    public long GetTotalFileSize (List<Dir> max100000) {
        long sum = Files.Sum(f => f.Size) + Dirs.Sum(d => d.GetTotalFileSize(max100000));
        if (sum <= 100000) max100000.Add(this);
        return sum;
    }

    public Dir GetFolder (string relativePath) {
        string[] folders = relativePath.Split("/");
        Dir currentDir = this;
        foreach (string folder in folders) {
            if (folder == "") continue;
            Dir? dir = currentDir.Dirs.FirstOrDefault(d => d.Path == folder);
            if (dir == null) {
                dir = new Dir(folder);
                currentDir.Dirs.Add(dir);
            }
            currentDir = dir;
        }
        return currentDir;
    }

    public void AddFile (File file, string path) {
        GetFolder(path).Files.Add(file);
    }

}

class File {

    public long Size { get; set; }
    public string Filename { get; set; } = "";

    public File (string filename, long size) {
        Filename = filename;
        Size = size;
    }

}