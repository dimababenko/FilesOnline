using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineFileManager.Models
{
    //класс, который реализует подсчет данных и директории
    public class FileManager
    {
        public PathInfo Lists;
        public CountOfFiles Counts;

        public FileManager(string Path)
        {
            Lists = new PathInfo(Path);
            Counts = new CountOfFiles();
        }

        //расчитать количество файлов, в зависимости от их размера по пути Path
        private void CalcCountOfFiles(string Path)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(Path);

            try
            {                
                foreach (var file in DirInfo.GetFiles())
                {
                    //файлы меньше 10 Мб
                    if (file.Length <= 10485760)
                    {
                        Counts.FilesLess10++;
                    }
                    //файлы меньше 50 Мб и больше 10 Мб
                    else if (file.Length <= 52428800)
                    {
                        Counts.FilesBetween10and50++;
                    }
                    //файлы больше 100 Мб
                    else if (file.Length >= 104857600)
                    {
                        Counts.FilesMore100++;
                    }
                    //оставшиеся файлы
                    else
                    {
                        Counts.FilesOther++;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                foreach (var dir in DirInfo.GetDirectories())
                {
                    CalcCountOfFiles(dir.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //обновить количество файлов по пути Path
        public void UpdateCounts(string Path)
        {
            Counts.ClearAll();
            CalcCountOfFiles(Path);
        }

        //обновить данные о директориях по пути Path
        public void UpdateLists(string Path)
        {
            try
            {
                Lists.ClearAll();
                Lists.FullPath = Path;
                DirectoryInfo DirInfo = new DirectoryInfo(Path);

                foreach (var file in DirInfo.GetFiles())
                {
                    Lists.Files.Add(file.Name);
                }

                foreach (var dir in DirInfo.GetDirectories())
                {
                    Lists.Directories.Add(dir.Name);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
            }
        }
    }
}