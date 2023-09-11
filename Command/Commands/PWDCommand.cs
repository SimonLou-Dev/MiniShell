using PPlus;

namespace MiniShell.Command.Commands;

public class PWDCommand : Commands
{
    public static void execute(List<string> args, List<string> options)
    {
        PromptPlus.WriteLine("\nChemin actuel : " + Environment.CurrentDirectory + "\n");
    }

    public static void displayHelp()
    {

    }
}

