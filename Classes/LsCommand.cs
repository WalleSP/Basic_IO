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

            if (showLongOutput)
            {
                var furtherFileInformation = new FileInfo(entry);
                string type = furtherFileInformation.Attributes.HasFlag(FileAttributes.Directory) ? "DIR" : "FILE";
                Console.WriteLine($"{type} {furtherFileInformation.Length,10} bytes {fileNames}");
            }
            else
            {
                Console.WriteLine(fileNames);
            }
        }
    }
}