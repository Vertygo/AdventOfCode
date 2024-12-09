
using System.Text;

namespace Day9;

public partial class Day9_Part1
{

    internal void Run()
    {
        var diskMap = Input.input.ToCharArray().Chunk(2).ToArray();
        var diskRepresentation = CreateDiskRepresentation(diskMap);
        MoveBlocks(diskRepresentation);
        PrintRepresentation(diskRepresentation);

        var sum = diskRepresentation.Where(d => d is DiskFile)
            .Select((d, index) => (DiskID: d.DiskID, index: index))
            .Sum(s => s.DiskID * s.index);
        Console.WriteLine(sum);
    }

    private void MoveBlocks(List<DiskRepresentation> diskRepresentation)
    {
        for (int i = diskRepresentation.Count - 1; i > 0; i--)
        {
            var diskRep = diskRepresentation[i];
            if (diskRep is DiskFile)
            {
                var freeSpaceIndex = diskRepresentation.FindIndex(s => s is DiskFreeSpace);
                if (freeSpaceIndex < i)
                {
                    diskRepresentation[i] = diskRepresentation[freeSpaceIndex];
                    diskRepresentation[freeSpaceIndex] = diskRep;
                }
            }
        }
    }

    private static List<DiskRepresentation> CreateDiskRepresentation(char[][] diskMap)
    {
        List<DiskRepresentation> diskRepresentation = new();

        for (int i = 0; i < diskMap.Length; i++)
        {
            var files = int.Parse($"{diskMap[i][0]}");
            var freeSpace = diskMap[i].Length > 1 ? int.Parse($"{diskMap[i][1]}") : 0;

            diskRepresentation.AddRange(Enumerable.Repeat(new DiskFile(i), files));
            diskRepresentation.AddRange(Enumerable.Repeat(new DiskFreeSpace(i), freeSpace));
        }

        return diskRepresentation;
    }

    private void PrintRepresentation(List<DiskRepresentation> diskRepresentation)
    {
        var sb = new StringBuilder();
        foreach (var rep in diskRepresentation)
        {
            if (rep is DiskFile)
            {
                sb.Append(rep.DiskID);
            }
            else
            {
                sb.Append(".");
            }
        }
        Console.WriteLine(sb.ToString());
    }

    record DiskFile(long DiskID) : DiskRepresentation(DiskID);
    record DiskFreeSpace(long DiskID) : DiskRepresentation(DiskID);
    record DiskRepresentation(long DiskID);
}