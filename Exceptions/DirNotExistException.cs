using PPlus;

namespace MiniShell.Exceptions;

public class DirNotExistException : Exception
{
    public DirNotExistException(string path) : base(path)
    {
        PromptPlus.WriteLine("[RED] " + path + " le répertoire n'éxiste pas");
    }
    
}