namespace Day7;



public class Folder
{
    public Folder Parent { get; set; }
    public string Name { get; set; }
    public List<Folder> Folders = new List<Folder>();
    public List<SystemFile> Files = new List<SystemFile>();
    public long Size => Folders.Sum(f => f.Size) + Files.Sum(f => f.Size);
}

public class SystemFile
{
    public string Name { get; set; }
    public long Size { get; set; }
}

public partial class Day7_Part1
{
    const string LS = "$ ls";
    const string CD = "$ cd";
    internal void Run()
    {
        var rootFolder = new Folder() { Name = "/" };
        Folder current = rootFolder;
        var inputs = Input.input.Split(Environment.NewLine)
            .Skip(1) //skip first (root)
            .ToList();

        bool isLS = false;

        foreach (var line in inputs)
        {
            Console.WriteLine(line);
            if (line.StartsWith(LS))
            {
                isLS = true;
            }
            else if (line.StartsWith(CD))
            {
                if (line.Split(' ')[2] == "..")
                {
                    current = current.Parent;
                }
                else
                {
                    var f = new Folder() { Name = line.Split(' ')[2], Parent = current };
                    current.Folders.Add(f);
                    current = f;
                }
            }
            else if (isLS)
            {
                if (!line.StartsWith("dir"))
                {
                    var file = new SystemFile() { Name = line.Split(' ')[1], Size = long.Parse(line.Split(' ')[0]) };
                    current.Files.Add(file);
                }
            }

        }

        long sum = 0;
        foreach (var folder in rootFolder.Folders)
        {
            sum += FindAtMost100000(folder);
        }

        Console.WriteLine($"Sum is {sum}");

    }

    private long FindAtMost100000(Folder folder)
    {
        if (folder.Size > 100000)
        {
            long sum = 0;
            foreach (var f in folder.Folders)
            {
                sum += FindAtMost100000(f);
            }
            return sum;
        }
        else
        {
            long sum = 0;
            foreach (var f in folder.Folders)
            {
                sum += FindAtMost100000(f);
            }
            return sum + folder.Size;
        }
    }
}
