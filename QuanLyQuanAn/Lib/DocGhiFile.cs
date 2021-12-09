using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Lib
{
    class DocGhiFile
    {

        public static string[] DocFile(string address)
        {
            string[] result = new string[2];
            // tao instance cua StreamReader de doc mot file.
            // lenh using cung duoc su dung de dong StreamReader.
            using (StreamReader sr = new StreamReader(address))
            {
                int i = 0;
                // doc va hien thi cac dong trong file cho toi
                // khi tien toi cuoi file. 
                while ((result[i] = sr.ReadLine()) != null) { i++; } ;
            }
            return result;
        }
        public static void GhiFile(string address,string[] value)
        {
            using (StreamWriter sw = new StreamWriter(address))
            {
                foreach (string s in value)
                {
                    sw.WriteLine(s);
                }
            }
        }
    }
}
