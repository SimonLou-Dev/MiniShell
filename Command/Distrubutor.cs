using MiniShell.Command.Commands;
using PPlus;

namespace MiniShell.Command;

public class Distrubutor
{
    private Program Program;
    private string command;
    private List<string> args;
    private List<string> options;

    public Distrubutor(Program program)
    {
        this.Program = program;
        args = new List<string>();
        options = new List<string>();
    }

    public void commandParser(string command)
    {
        List<string> separatedCommand = new List<string>(command.Split(" "));
        this.command = separatedCommand[0];
        separatedCommand.RemoveAt(0);

        for (int i = 0; i < separatedCommand.Count; i++)
        {
            string current = separatedCommand[i];
            
            if(current.StartsWith("--") || current.StartsWith('-')) options.Add(current);
            else args.Add(current);
        }
        this.commandFinder();
    }

    private void commandFinder()
    {
        switch (command)
        {
            
            case "exit":
                Program.running = false;
                break;
            case "help":
                HelpCommand.execute(args, options);
                break;
            case "pwd":
                PWDCommand.execute(args, options);
                break;
            case "ls":
                ListCommand.execute(args, options);
                break;
            case "cd":
                ChangeDirCommand.execute(args, options);
                break;
            case "git":
                GitCommand.execute(args, options);
                break;
            case "clear":
                ClearCommand.execute(args, options);
                break;
            default:
                PromptPlus.WriteLine(
                    "[RED] Cette commande n'éxiste pas ! Tappez [GREEN] help [/] pour avoir la liste des commande");
                break;
            
        }
        
        clearingClass();
    }

    private void clearingClass()
    {
        args = new List<string>();
        options = new List<string>();
    }


}