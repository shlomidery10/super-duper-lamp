using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top5GoogleSearch.FileReader
{
    public class TextReader : IFileReader
    {
        public string ReadFile(string pathToFile)
        {
            try
            {
                return System.IO.File.ReadAllText(@"C:\Users\shlomi.dery\OneDrive - 888Holdings\Desktop\top5.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
