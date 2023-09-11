using PPlus;

namespace MiniShell.Command.Commands;

public class ListCommand : Commands
{
    public static void execute(List<string> args, List<string> options)
    {

        string finalPath = Program.getCurrentDir();
        
        PromptPlus.WriteLine("[GREY] " + finalPath);

        if (args.Count != 0)
        {
            string searchDir = args[0];
            string[] firstFile = searchDir.Split("\\");
            if (searchDir.StartsWith("\\") || firstFile[0].EndsWith(":\\"))
            {
                finalPath = searchDir;
            }
            else
            {
                searchDir = searchDir.Replace("/", "\\");
                if (searchDir.StartsWith(".\\")) searchDir = searchDir.Substring(2);
                finalPath += searchDir;
                
                
                /*
                 * TODO ./ ../ ../../
                 */
            }
        }

        if (File.Exists(finalPath))
        {
            PromptPlus.WriteLine("[RED] " + finalPath + " est un fichier, ls permet de lister le contenue d'un répertoire. \n [GREEN] help [/] pour plus d'informations");
            return;
        }else if (!Directory.Exists(finalPath))
        {
            PromptPlus.WriteLine("[RED] " + finalPath + " le répertoire n'éxiste pas");
            return;
        }
       
        
        display(listDir(finalPath), finalPath);
        
        return;
        
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