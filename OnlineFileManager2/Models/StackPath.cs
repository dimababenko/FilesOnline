using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFileManager.Models
{
    //Статический класс для хранения текущего пути по папкам. 
    //Реализует возвращение в предыдущую папку.
    public static class StackPath
    {
        private static Stack<string> _segmentsPath;

        static StackPath()
        {
            _segmentsPath = new Stack<string>();
            _segmentsPath.Push(@"E:");
        }

        //Вернуть полный путь в одной строке
        public static string GetFullPath()
        {
            return string.Join(@"\", _segmentsPath.Reverse());
        }

        //добавить новый сегмент (папку)
        public static void AddSegment(string segment)
        {
            _segmentsPath.Push(segment);
        }

        //удалить последний элемент стека (последнюю папку)
        public static void RemoveLastSegment()
        {
            if (_segmentsPath.Count > 1)
            {
                _segmentsPath.Pop();
            }
        }

        //удалить все элементы в стеке
        public static void RemoveAllSegments()
        {
            _segmentsPath.Clear();
        }
    }
}