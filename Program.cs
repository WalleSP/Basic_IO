namespace Basic_IO;

class Program
{
    static void Main(string[] args)
    {
        var fileOperations = new FileOperations("example.txt");

        Console.WriteLine($"Size of file: {fileOperations.GetSizeOfFile()}");
        Console.WriteLine($"Content length: {fileOperations.FileContentLength()}");
        fileOperations.ReadAllContent();

        // var content = fileOperations.ReadAllContentArr();
        // Console.WriteLine(content);

        // fileOperations.WriteContent("example2.txt", "Something something");

        // fileOperations.ReadContentAnyFile("example2.txt");

        // // basic recreation of the echo command
        // Console.WriteLine($"DEBUG::{args.Length}");
        // // halt the program
        // Console.ReadKey();

        EchoCommand echo = new EchoCommand();
        LsCommand lsCommand = new LsCommand();

        switch (args[0])
        {
            case "ls":
                lsCommand.Ls(args);
                break;
            case "echo":
                echo.Echo(args);
                break;
            default:
                return;
        }
    }
}
