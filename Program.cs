using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Renamer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfNames = File.ReadAllLines(args[0]).ToList();

            DirectoryInfo d = new DirectoryInfo(args[1]);
            List<FileInfo> folder = d.GetFiles().ToList();

            folder = folder.Where(x => x.Extension == ".wav").ToList();
            folder.SortNatural(item => item.Name);

            if (folder.Count != listOfNames.Count)
            {
                Console.WriteLine("Different count of files and names. Exiting.");
                Thread.Sleep(1000);
            }
            else
            {
                for (int i = 0; i < listOfNames.Count(); i++)
                {
                    File.Move(folder[i].FullName, folder[i].FullName.Replace(folder[i].Name, listOfNames[i] + ".wav"));
                }
                Console.WriteLine("Success! Exiting.");
                Thread.Sleep(1000);
            }
        }
    }
}
