using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICaller
{
    public class FileWriter
    {
        private string path;

        public FileWriter(string path)
        {
            this.path = path;
        }

        public void Write(string s)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            File.WriteAllText(path, s);

        }



    }
}
