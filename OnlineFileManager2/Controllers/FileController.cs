using OnlineFileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFileManager.Controllers
{
    public class FileController : ApiController
    {
        private FileManager _files = new FileManager(@"E:");

        //Get запрос возвращает все данные в стоковой директории
        [HttpGet]
        public FileManager GetFiles()
        {
            string Path = @"E:";
            StackPath.RemoveAllSegments();
            StackPath.AddSegment(Path);
            _files.UpdateCounts(Path);
            _files.UpdateLists(Path);
            return _files;
        }

        //Post возвращает все данные в зависимости от пути 
        [HttpPost]
        public FileManager ChangeFullPath([FromBody]string Name)
        {
            //проверка на возврат в предыдущую директорию
            if (Name == "goback")
            {
                StackPath.RemoveLastSegment();
                string Path = StackPath.GetFullPath();
                _files.UpdateCounts(Path);
                _files.UpdateLists(Path);
                return _files;
            }
            //для входа в папку
            else
            {
                StackPath.AddSegment(Name);
                string Path = StackPath.GetFullPath();
                _files.UpdateCounts(Path);
                _files.UpdateLists(Path);
                return _files;
            }
        }
    }
}
