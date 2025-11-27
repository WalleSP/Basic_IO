/// <summary>
/// 
/// </summary>
public class PwdCommand
{
    public void Pwd()
    {
        var currentWorkingDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine(currentWorkingDirectory);
    }
}