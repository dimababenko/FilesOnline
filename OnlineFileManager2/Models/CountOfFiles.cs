using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFileManager.Models
{
    //класс для хранения информации о количестве файлов
    public class CountOfFiles
    {
        public int FilesLess10;         //количество файлов с размером больше 10 Мб
        public int FilesBetween10and50; //количество файлов с размером от 10 до 50 Мб
        public int FilesMore100;        //количество файлов с размером более 100 Мб
        public int FilesOther;          //количесвто оставшихся файлов 

        public CountOfFiles()
        {
            FilesBetween10and50 = 0;
            FilesLess10 = 0;
            FilesMore100 = 0;
            FilesOther = 0;
       }

        //почистить данные 
        public void ClearAll()
        {
            FilesBetween10and50 = 0;
            FilesLess10 = 0;
            FilesMore100 = 0;
            FilesOther = 0;
        }
    }
}