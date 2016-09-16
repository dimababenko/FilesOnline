using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFileManager.Models
{
    //класс для хранения файлов и папок 
    public class PathInfo
    {
        public List<string> Files;          //список файлов в текущей директории
        public List<string> Directories;    //список папок в текущей диектории
        public string FullPath;             //текущий путь
                
        public PathInfo(string Path)
        {
            Files = new List<string>();
            Directories = new List<string>();
            FullPath = Path;
        }
        
        //почистить все данные        
        public void ClearAll()
        {
            Files.Clear();
            Directories.Clear();
            FullPath = null;
        }
    }
}