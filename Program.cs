// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Security.Principal;
using MiniShell.Command;
using PPlus;
using PPlus.Controls;

namespace MiniShell;

public class Program
{

    public bool running = true;
    
    private string machineName;
    private string userName;
    private bool elevated;
    private static string currentDir;

    private Distrubutor Distrubutor;
    
    static void Main(string[] args)
    {
        new Program().runner();

    }

    private void initaliser()
    {

        Distrubutor = new Distrubutor(this);
        
        machineName = Environment.MachineName;
        userName = Environment.UserName;
        elevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        currentDir = Environment.CurrentDirectory;
        
        PromptPlus.Reset();
        PromptPlus.Clear();
        PromptPlus.Config.DefaultCulture = new CultureInfo("fr-fr");

        PromptPlus.WriteLine("[#700cf2]\n------------------------------------------------------------------------------");
        PromptPlus.WriteLine("[#700cf2] Bienvenue sur le mini shell de Simon Lou : \n\t[GREEN] help [/] pour la liste des commandes, \n\t[GREEN] exit [/] ou  [GREEN]CTRL + C[/] pour quitter ");
        PromptPlus.WriteLine("[#700cf2]------------------------------------------------------------------------------\n");
        
    }

    private void runner()
    {
        
        initaliser();

        
        
       
        while (running){
            string[] dirs = Environment.CurrentDirectory.Split("\\");
            string currentDir = dirs[dirs.Length - 1];
            var inputCommand = PromptPlus.Input((this.elevated ? "\u26a1" : "\ud83d\udd12" ) +   " [#700cf2]" + userName + "@" + machineName + "[/] [#fc5203]"  + currentDir + "[/]>").Run();
            
            this.Distrubutor.commandParser(inputCommand.Value);
            
        } 
    }

    public static string getCurrentDir()
    {
        return currentDir;
    }
    
}