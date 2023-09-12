namespace MiniShell.FileManager;

public class DirectoryFinder
{

    public static string getCurrentDir()
    {
        string longPath = Program.getCurrentDir();
        
        string baseDiskTest = longPath;
        if (baseDiskTest.EndsWith("\\"))
        {
            baseDiskTest = baseDiskTest.Remove(baseDiskTest.Length - 1, 1);
            if (baseDiskTest.EndsWith(":")) return longPath;
            else longPath = baseDiskTest;
        }

        string[] splitedPath = longPath.Split("\\");

        return splitedPath[splitedPath.Length - 1];


    }
    
    
}