using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_task
{
    class Folder
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
        public DateTime CreationDataTime { get; set; }
        public List<Folder> Subfolders { get; set; }
        public List<FileProperty> Subfiles { get; set; }

        public Folder(string path)
        {
            FullPath = path;

            GetFolderName(path);

            CreationDataTime = Directory.GetCreationTime(path);

            GetFolders(path);

            GetFiles(path);
        }

        private void GetFolderName(string path)
        {
            string[] tmp = path.Split(new char[] { '\\' });
            Name = tmp[tmp.Length - 1];
        }

        private void GetFolders(string path)
        {
            string[] subfoldersNames = Directory.GetDirectories(path);
            if (subfoldersNames.Length > 0)
            {
                Subfolders = new List<Folder>();
                foreach (var pathOfSubfolder in subfoldersNames)
                {
                    Subfolders.Add(new Folder(pathOfSubfolder));
                }
            }
        }

        private void GetFiles(string path)
        {
            string[] subfilesNames = Directory.GetFiles(path);
            if (subfilesNames.Length > 0)
            {
                Subfiles = new List<FileProperty>();
                foreach (var fileName in subfilesNames)
                {
                    Subfiles.Add(new FileProperty(fileName));
                }
            }
        }

        #region ShowInformation

        public void ShowInformation()
        {
            Console.WriteLine(
                $"Full Path: {FullPath}\n" +
                $"Name: {Name}\n" +
                $"Creation Date: {CreationDataTime}\n");
            ShowSubfolders("");
            ShowSubfiles("");
        }

        private void ShowSubfolders(string tabs)
        {
            if (Subfolders != null)
            {
                string t = tabs + "\t";
                Console.WriteLine($"{t}Subfolders:");
                foreach (var item in Subfolders)
                {
                    Console.WriteLine(
                    $"{t}Full Path: {item.FullPath}\n" +
                    $"{t}Name: {item.Name}\n" +
                    $"{t}Creation Date: {item.CreationDataTime}\n");
                    item.ShowSubfolders(t);
                    item.ShowSubfiles(t);
                }
            }
        }

        private void ShowSubfiles(string tabs)
        {
            if (Subfiles != null)
            {
                string t = tabs + "\t";
                Console.WriteLine($"{t}Subfiles:");
                foreach (var item in Subfiles)
                {
                    Console.WriteLine(
                        $"{t}Full Path: {item.FullPath}\n" +
                        $"{t}Name: {item.Name}\n" +
                        $"{t}Size: {item.Size}\n");
                }
            }
        }
        #endregion
    }
}
