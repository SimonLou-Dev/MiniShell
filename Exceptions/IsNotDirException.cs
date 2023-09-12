using PPlus;

namespace MiniShell.Exceptions;

public class IsNotDirException: Exception
{
    public IsNotDirException(string path) : base(path)
    {
        PromptPlus.WriteLine("[RED] " + path +
                             " est un fichier, ls permet de lister le contenue d'un répertoire. \n [GREEN] help [/] pour plus d'informations");
    }


}