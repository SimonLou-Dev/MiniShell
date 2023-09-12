using MiniShell.Exceptions;
using PPlus;

namespace MiniShell.FileManager;

public class PathFinder
{
    public static string getAboslutePath(string path = "")
    {
        string finalPath = Program.getCurrentDir();
        
        if (path != "" && path.Contains(":\\"))
        {
            finalPath = Path.GetFullPath(path);
        }else if (path != "" && !path.Contains(":\\"))
        {
            finalPath = Path.GetFullPath(path, finalPath);
        }


        if (!Directory.Exists(finalPath))
        {
            throw new DirNotExistException(finalPath);
        }

        return finalPath;
    }
}