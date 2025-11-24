public class FileOperations : IFileOperations
{

    private readonly string? _filePath;

    public FileOperations(string filePath)
    {
        _filePath = filePath;
    }

    // Basic utilites
    public string GetFileExtension()
    {
        return Path.GetExtension(_filePath!);
    }

    public int FileContentLength()
    {
        var content = File.ReadAllText(_filePath!);
        return content.Length;
    }

    public long GetSizeOfFile()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException($"File not found: {_filePath}");
        }
        var fileInfo = new FileInfo(_filePath);
        return fileInfo.Length;
    }

    // Read operations

    public void ReadAllContent()
    {
        Console.WriteLine($"Content in file: {_filePath}\n{File.ReadAllText(_filePath!)}");
    }

    public void ReadContentAnyFile(string filePath)
    {
        Console.WriteLine(File.ReadAllText(filePath));
    }

    public string ReadAllContentArr()
    {
        var fileContent = File.ReadAllLines(_filePath!);
        return string.Join(", ", fileContent);
    }

    // Write & Append operations

    public void WriteContent(string filePath, string content)
    {
        try
        {
            File.WriteAllText(filePath, content);
        }
        catch (FileLoadException e)
        {
            Console.WriteLine($"An error occured when trying to load the file: {e.Message}");
        }
    }

    public void AppendContent(string filePath, string content)
    {
        try
        {
            File.AppendAllText(filePath, content);
        }
        catch (FileLoadException e)
        {
            Console.WriteLine($"An error occured when trying to load the file: {e.Message}");
        }
    }
}