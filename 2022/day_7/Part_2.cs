namespace Day7;

public partial class Day7_Part2
{
    const string LS = "$ ls";
    const string CD = "$ cd";

    long totalDiskSpace = 70000000;
    long unusedSpaceNeeded = 30000000;

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

        long toBeDeletedSpace = 30000000 - (totalDiskSpace - rootFolder.Size);

        List<Folder> deleteCandidates = new List<Folder>();
        foreach (var folder in rootFolder.Folders)
        {
            SearchTobeDeleted(folder, toBeDeletedSpace, deleteCandidates);
        }

        Console.WriteLine($"Sum is {deleteCandidates.OrderBy(s => s.Size).First().Size}");

    }

    private void SearchTobeDeleted(Folder folder, long toBeDeletedSpace, List<Folder> deleteCandidates)
    {
        if (folder.Size >= toBeDeletedSpace)
        {
            deleteCandidates.Add(folder);
            foreach (var f in folder.Folders)
            {
                SearchTobeDeleted(f, toBeDeletedSpace, deleteCandidates);
            }
        }
        else
        {
            foreach (var f in folder.Folders)
            {
                SearchTobeDeleted(f, toBeDeletedSpace, deleteCandidates);
            }
        }
    }
}

//          2940614
// too high 4421844
// 20129825
// 17436694