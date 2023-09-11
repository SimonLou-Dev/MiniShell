using PPlus;

namespace MiniShell.Command.Commands;

public class HelpCommand : Commands
{
    public HelpCommand()
    {
        
    }
    

    public void execute()
    {
        PromptPlus.WriteLine("J'affiche l'aide ...");
    }

    public static void execute(List<string> args, List<string> options)
    {
        
    }

    public static void displayHelp()
    {
        
    }
}