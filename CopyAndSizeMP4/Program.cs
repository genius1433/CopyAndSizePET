using System;
using System.IO;


class Program
{
    public static long CheckSize(string path, string extension)
    {
        long totalSize = 0;
        int bytestogb = 1000000000;
        foreach (string file in Directory.EnumerateFiles(path, extension, SearchOption.AllDirectories))
        {
            totalSize += new FileInfo(file).Length;
        }

        return totalSize / bytestogb;
    }
    static void Main()
    {
        string rootPath;
        string destinationPath;
        string checkpath;
        string extension;
        int move;
        Console.WriteLine("Insert number 1 or 2. 1 for reading size of catalog. 2 for copy files to another place");
        move = int.Parse(Console.ReadLine());
        if(move == 1)
        {
            Console.WriteLine("You chosed to know size of catalog, now insert full path to catalog and part of name like *.mp4");
            checkpath = Console.ReadLine();
            extension = Console.ReadLine();
            Console.WriteLine("Size of you catalog: " + CheckSize(checkpath, extension));
        }
        else if(move == 2)
        {
            Console.WriteLine("You chosed to copy files from rootPath to destinationPath, insert them and extension");
            rootPath = Console.ReadLine();
            destinationPath = Console.ReadLine();
            extension = Console.ReadLine();
            CopyFiles(rootPath, destinationPath, extension);
            Console.WriteLine("Files moved succesfully, maybe, pls check it");
        }
        else 
        {
            Console.WriteLine("Wrong number, please insert 1 or 2");
        }
    }

    static void CopyFiles(string rootPath, string destinationPath, string extension)
    {
        if (!Directory.Exists(destinationPath))
        {
            Directory.CreateDirectory(destinationPath);
        }

        foreach (string file in Directory.EnumerateFiles(rootPath, extension, SearchOption.AllDirectories))
        {
            string destFile = Path.Combine(destinationPath, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }
    }
}