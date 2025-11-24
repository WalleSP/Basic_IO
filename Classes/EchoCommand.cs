public class EchoCommand
{
    public void Echo(string[] args)
    {
        if (args.Length != 0)
        {
            Console.WriteLine(string.Join("", args));
        }
        else if (args.Length == 0)
        {
            return;
        }
    }
}