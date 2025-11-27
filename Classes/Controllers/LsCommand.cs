public class LsCommand
{
    public void Ls(string[] args)
    {
        string? FilePath = Directory.GetCurrentDirectory();

        // flag handlers
        // example: ls -l -a (-l & -a are flags)

        bool showAll = args.Contains("--a");
        bool showLongOutput = args.Contains("--l");

        // For custom paths
        string? customPath = args.FirstOrDefault(arg => !arg.StartsWith("-"));
        if (string.IsNullOrWhiteSpace(customPath))
        {
            FilePath = customPath;
        }

        // error handling
        if (!Directory.Exists(FilePath))
        {
            Console.WriteLine($"Path not found: {FilePath}");
            return;
        }

        var entries = Directory.GetFileSystemEntries(FilePath);

        // traverse the entries
        foreach (var entry in entries)
        {
            var fileNames = Path.GetFileName(entry);

            // if the "all" flag "-a" is not called, we can skip hidden files
            if (!showAll && fileNames.StartsWith("."))
            {
                continue;
            }

            var attributes = File.GetAttributes(entry);
            bool isDirectory = attributes.HasFlag(FileAttributes.Directory);

            if (showLongOutput)
            {
                if (isDirectory)
                {
                    Console.WriteLine($"Directory: {"-",10} {fileNames}");
                }
                else
                {
                    var info = new FileInfo(entry);
                    Console.WriteLine($"File: {info.Length,10} bytes {fileNames}");
                }
            }
            else
            {
                Console.WriteLine(fileNames);
            }
        }
    }
}