using System;
using System.IO;

//class Program
//{
//    static void Main()
//    {
//        string rootPath = @"D:\SteamLibrary\steamapps\workshop\content\431960";
//        long totalSize = 0;

//        CalculateTotalMp4Size(rootPath, ref totalSize);

//        Console.WriteLine($"Total size of mp4 files: {totalSize/1000000000} gb");
//    }

//    static void CalculateTotalMp4Size(string rootPath, ref long totalSize)
//    {
//        foreach (string file in Directory.EnumerateFiles(rootPath, "*.mp4", SearchOption.AllDirectories))
//        {
//            totalSize += new FileInfo(file).Length;
//        }
//    }
//}

class Program
{
    static void Main()
    {
        string rootPath = @"D:\SteamLibrary\steamapps\workshop\content\431960";
        string destinationPath = @"G:\Wallpaper";

        CopyMp4Files(rootPath, destinationPath);

        Console.WriteLine("Copying completed!");
    }

    static void CopyMp4Files(string rootPath, string destinationPath)
    {
        if (!Directory.Exists(destinationPath))
        {
            Directory.CreateDirectory(destinationPath);
        }

        foreach (string file in Directory.EnumerateFiles(rootPath, "*.mp4", SearchOption.AllDirectories))
        {
            string destFile = Path.Combine(destinationPath, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }
    }
}