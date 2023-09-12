using MiniShell.FileManager;
using PPlus;

namespace MiniShell.Command.Commands;

public class ListCommand : Commands
{
    public static void execute(List<string> args, List<string> options)
    {

        if (args.Count == 0) args.Add("");
        try
        {
            string finalPath = PathFinder.getAboslutePath(args[0]);
        
            display(listDir(finalPath), finalPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    private static List<string> listDir(string absolutePath)
    {
        List<string> list = new List<string>();

        string[] dirs = Directory.GetDirectories(absolutePath);
        foreach (var dir in dirs)
        {
            list.Add("#D " + dir);
        }
        
        string[] files = Directory.GetFiles(absolutePath);
        foreach (var file in files)
        {
            list.Add("#F " +file);
        }
        
        return list;
    }

    private static void display(List<string> content, string path)
    {
        PromptPlus.WriteLine("Affichage du dossier : " + path);
        foreach (var line in content)
        {
            string fline = line;
            fline = line.Replace("#D", "\ud83d\udcc1");
            fline = fline.Replace("#F", "\ud83e\uddfe");

            PromptPlus.WriteLine(fline);

        }
        
        
    }

    public static void displayHelp()
    {
        throw new NotImplementedException();
    }
}