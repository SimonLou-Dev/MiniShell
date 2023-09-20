using System.Diagnostics;
using System.Text;
using PPlus;

namespace MiniShell.Command.Commands;

public class GitCommand : Commands
{
    public static void execute(List<string> args, List<string> options)
    {
        PromptPlus.WriteLine(CommandOutput("git status"));
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
            };
            proc.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                sb.AppendLine(e.Data);
            };

            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();
            return sb.ToString();
        }
        catch (Exception objException)
        {
            return $"Error in command: {command}, {objException.Message}";
        }
    }
}