public interface IFileOperations
{
    // basic utilities
    string GetFileExtension();
    int FileContentLength();
    long GetSizeOfFile();

    // read operations
    void ReadAllContent();
    string ReadAllContentArr();

    // write operations
    void WriteContent(string filePath, string content);

    // append/updating operations
    void AppendContent(string filePath, string content);
}