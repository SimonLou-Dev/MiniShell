using MiniShell.Exceptions;
using PPlus;

namespace MiniShell.FileManager;

public class PathFinder
{
    public static string getAboslutePath(string path = "")
    {
        string finalPath = Program.getCurrentDir();
        
        if (path != "")
        {
            finalPath = Path.GetFullPath(path);
        }


        if (File.Exists(finalPath))
        {
            throw new IsNotDirException(finalPath);
        }else if (!Directory.Exists(finalPath))
        {
            throw new DirNotExistException(finalPath);
        }

        return finalPath;
    }
}