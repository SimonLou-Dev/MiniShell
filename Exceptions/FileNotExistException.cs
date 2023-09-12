namespace MiniShell.Exceptions;

[Serializable]
public class FileNotExistException : Exception
{
    
    public FileNotExistException(string path)
        : base(path) { }

    
}