using MiniShell.FileManager;

namespace MiniShell.Command.Commands;

public class ChangeDirCommand : Commands
{
    public static void execute(List<string> args, List<string> options)
    {
        if (args.Count == 0) args.Add("");
        try
        {
            string finalPath = PathFinder.getAboslutePath(args[0]);
            if (finalPath.EndsWith('\\'))
            {
                string testingpath = finalPath.Remove(finalPath.Length - 1, 1);
                if (testingpath.EndsWith(":")) finalPath = finalPath;
                else finalPath = testingpath;
            }
            
            Program.setCurrentDir(finalPath);
            
           
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void displayHelp()
    {
        throw new NotImplementedException();
    }
}