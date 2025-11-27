/// <summary>
/// Basic implementation of the UNIX touch command
/// </summary>
public class TouchCommand
{
    public void Touch(string filePath, string extension = null!)
    {
        File.Create(filePath);
    }
}