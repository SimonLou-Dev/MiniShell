namespace MiniShell.Command.Commands;

public interface Commands
{
     static abstract void execute(List<string> args, List<string> options);

     static abstract void displayHelp();

}