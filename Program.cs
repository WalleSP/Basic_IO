namespace Basic_IO;

class Program
{
    static void Main(string[] args)
    {
        var fileOperations = new FileOperations("hello.txt");

        Console.WriteLine($"Size of file: {fileOperations.GetSizeOfFile()}");
        Console.WriteLine($"Content length: {fileOperations.FileContentLength()}");
        fileOperations.WriteContent("hello.txt", "something something");
        fileOperations.ReadAllContent();
        // fileOperations.ReadContentAnyFile("example2.txt");  
        fileOperations.WriteLogFiles("log.txt");

        // // basic recreation of the echo command
        // Console.WriteLine($"DEBUG::{args.Length}");
        // // halt the program
        // Console.ReadKey();

        EchoCommand echo = new EchoCommand();
        LsCommand lsCommand = new LsCommand();
        TouchCommand touch = new TouchCommand();
        PwdCommand pwd = new PwdCommand();

        switch (args[0])
        {
            case "ls":
                lsCommand.Ls(args);
                break;
            case "echo":
                echo.Echo(args[1]);
                break;
            case "touch":
                touch.Touch(args[1]);
                break;
            case "pwd":
                pwd.Pwd();
                break;
            default:
                return;
        }
    }
}