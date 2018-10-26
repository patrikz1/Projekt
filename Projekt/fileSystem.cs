using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class fileSystem
    {
        PodcastPlayer podcastplayer = new PodcastPlayer();
        fileSystem filesystem = new fileSystem();

        /* --- Directory.(Metoder) --- */
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        //Denna har string pathen men också en bool pga hur delete är uppbyggt
        //recursive = true så den kan ta bort även fast de är saker i den
        public void DeleteDirectory(string path, bool recursive = true)
        {
            Directory.Delete(path, recursive);
        }
        public void MoveDirectory(string srcPath, string newPath)
        {
            Directory.Move(srcPath, newPath);
        }

        /* --- Path.(Metoder) --- */
        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
        public string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }
        public char DirectorySeparatorChar
        {
            get { return Path.DirectorySeparatorChar; }
        }
        public string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }


        /* --- File.(Metoder) --- */
        public void WriteAllText(string path, string text)
        {
            File.WriteAllText(path, text);
        }
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
        public void WriteAllLines(string path, string[] text)
        {
            File.WriteAllLines(path, text);
        }
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
        public void CopyFile(string srcPath, string newPath)
        {
            File.Copy(srcPath, newPath);
        }
        public void MoveFile(string srcFile, string newDestination)
        {
            File.Move(srcFile, newDestination);
        }


        /* Använda inom projektet flytta ner hit */


    }
}
