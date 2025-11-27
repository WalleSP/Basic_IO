namespace Basic_IO.Models;
/// <summary>
/// A model for generic Log files
/// </summary>
public class Log
{
    public string? Filename { get; set; }
    public DateTime CreationDate { get; set; }
    public EventStatus eventStatus { get; set; }
    public DateTime TimeStamp { get; set; }
    public string LoggedEvents { get; set; } = string.Empty;
}