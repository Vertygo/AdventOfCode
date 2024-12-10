using System.Text;

namespace Day9;

public partial class Day9_Part2
{

    internal void Run()
    {
        var diskMap = Input.input.ToCharArray().Chunk(2).ToArray();
        var wholeFiles = CreateWholeFiles(diskMap);

        MoveWholeFiles(wholeFiles);
        PrintRepresentation(wholeFiles);

        var sum = wholeFiles
            .SelectMany(ConvertWholeFilesToBlocks)
            .Select((fileBlock, index) => (fileBlock, index))
            .Sum(s => s.fileBlock.DiskID * s.index);

        Console.WriteLine(sum);
    }

    private static IEnumerable<FileBlock> ConvertWholeFilesToBlocks(WholeFile wholeFile)
    {
        return Enumerable.Repeat(new FileBlock(wholeFile.IsFreeSpace ? 0 : wholeFile.DiskID, wholeFile.Size), wholeFile.Size);
    }

    private void MoveWholeFiles(List<WholeFile> wholeFiles)
    {
        for (int i = wholeFiles.Count - 1; i > 0; i--)
        {
            var wholeFile = wholeFiles[i];
            if (!wholeFile.IsFreeSpace)
            {
                var freeSpaceIndex = wholeFiles.FindIndex(s => s.IsFreeSpace && s.Size >= wholeFile.Size);
                if (freeSpaceIndex > -1 && freeSpaceIndex < i)
                {
                    var freeSpaceWholeFile = wholeFiles[freeSpaceIndex];
                    var rest = freeSpaceWholeFile.Size - wholeFile.Size;

                    wholeFiles[i] = freeSpaceWholeFile with { Size = wholeFile.Size };
                    wholeFiles[freeSpaceIndex] = wholeFile;

                    if (rest > 0)
                    {
                        wholeFiles.Insert(freeSpaceIndex + 1, new WholeFile(freeSpaceWholeFile.DiskID, rest, true));
                    }
                }
            }
        }
    }

    private static List<WholeFile> CreateWholeFiles(char[][] diskMap)
    {
        List<WholeFile> wholeFiles = new();

        for (int i = 0; i < diskMap.Length; i++)
        {
            var files = int.Parse($"{diskMap[i][0]}");
            var freeSpace = diskMap[i].Length > 1 ? int.Parse($"{diskMap[i][1]}") : 0;

            wholeFiles.AddRange(new WholeFile(i, files, false));
            wholeFiles.AddRange(new WholeFile(i, freeSpace, true));
        }

        return wholeFiles;
    }

    private void PrintRepresentation(List<WholeFile> wholeFiles)
    {
        var sb = new StringBuilder();

        foreach (var file in wholeFiles)
        {
            var repeatVal = file.IsFreeSpace ? "." : file.DiskID.ToString();
            sb.Append(string.Join("", Enumerable.Repeat(repeatVal, file.Size)));
        }

        Console.WriteLine(sb.ToString());
    }

    record FileBlock(long DiskID, int Size);
    record WholeFile(long DiskID, int Size, bool IsFreeSpace);
}