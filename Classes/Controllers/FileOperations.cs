using Basic_IO.Models;
public class FileOperations : IFileOperations
{

    /// <summary>
    /// Private readonly field for a filepath given to the constructor
    /// </summary>
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

    /// <summary>
    /// Ignores the file given as an argument to the constructor
    /// </summary>
    /// <param name="filePath">any given file in cwd</param>
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

    /// <summary>
    /// Helper method that returns the creation time of any file passed as an argument to it
    /// </summary>
    /// <param name="file">the path to the file</param>
    /// <returns>DateTime object</returns>
    private DateTime GetCreationDate(string file)
    {
        return File.GetCreationTimeUtc(file);
    }
    private Log GetContentsInLogs()
    {
        var logs = new Log
        {
            Filename = Path.GetFileName("log.txt"),
            CreationDate = GetCreationDate("log.txt"),
            eventStatus = EventStatus.CONNECTED,
            TimeStamp = DateTime.Now,
            LoggedEvents = "192.168.0.1 connected to the server.."
        };
        return logs;
    }

    private List<Log> logs = new List<Log>()
    {
        new Log {Filename = "log.txt", CreationDate = File.GetCreationTimeUtc("log.txt"), eventStatus = EventStatus.CONNECTED}
    };

    /// <summary>
    /// Writes a new logfile with content
    /// </summary>
    /// <param name="logFile"></param>
    public void WriteLogFiles(string logFile)
    {
        if (!File.Exists("log.txt"))
        {
            File.Create("log.txt");
        }
        else
        {
            var log = GetContentsInLogs();
            var content = $"Created log file: {log.Filename} in {Directory.GetCurrentDirectory()}\nCREATION DATE:{log.CreationDate}\nSTATUS:{log.eventStatus}\nEVENTS:{log.LoggedEvents}\nTIMESTAMP:{log.TimeStamp}";
            File.WriteAllText(logFile, content);
        }
    }

    public void ReadLogFile()
    {

    }
}