using PPlus;

namespace MiniShell.Command.Commands;

public class ClearCommand : Commands
{
    public static void execute(List<string> args, List<string> options)
    {
        PromptPlus.Reset();
        PromptPlus.Clear();
        PromptPlus.WriteLine("[#700cf2]\n------------------------------------------------------------------------------");
        PromptPlus.WriteLine("[#700cf2] Bienvenue sur le mini shell de Simon Lou : \n\t[GREEN] help [/] pour la liste des commandes, \n\t[GREEN] exit [/] ou  [GREEN]CTRL + C[/] pour quitter ");
        PromptPlus.WriteLine("[#700cf2]------------------------------------------------------------------------------\n");
    }

    public static void displayHelp()
    {
        throw new NotImplementedException();
    }
}