using System.Diagnostics;
using System.Text;
using PPlus;

namespace MiniShell.Command.Commands;

public class GitCommand : Commands
{
    public static void execute(List<string> args, List<string> options)
    {
        //PromptPlus.WriteLine();
        PromptPlus.WriteLine("\n");
        string completeCommand = "git";

        foreach (var arg in args)
        {
            completeCommand += " " + arg;
        }
        
        foreach (var option in options)
        {
            completeCommand +=  " " +  option;
        }

        PromptPlus.WriteLine(completeCommand);
        CommandOutput(completeCommand);
    }

    public static void displayHelp()
    {
        throw new NotImplementedException();
    }
    
    public static string CommandOutput(string command,
        string workingDirectory = null)
    {
        try
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

            procStartInfo.RedirectStandardError = procStartInfo.RedirectStandardInput = procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            if (null != workingDirectory)
            {
                procStartInfo.WorkingDirectory = workingDirectory;
            }

            Process proc = new Process();
            proc.StartInfo = procStartInfo;

            StringBuilder sb = new StringBuilder();
            proc.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                sb.AppendLine(e.Data);
                PromptPlus.WriteLine(e.Data + "\n");
            };
            proc.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                sb.AppendLine(e.Data);
                PromptPlus.WriteLine("[RED]" + e.Data + "[/] \n");
            };

            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            //proc.WaitForExit();
            return sb.ToString();
        }
        catch (Exception objException)
        {
            return $"Error in command: {command}, {objException.Message}";
        }
    }
}