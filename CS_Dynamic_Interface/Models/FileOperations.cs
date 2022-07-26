using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Dynamic_Interface.Models
{
    public class FileOperations : ITextFile, IXmlFile
    {
        void ITextFile.WriteFile(string fileName)
        {
            Console.WriteLine($"Text File Written  {fileName}");
        }

        void IXmlFile.EncryptFile(string fileName)
        {
            Console.WriteLine($" File Encrypted  {fileName}");
        }

        void IFile.CreateFile(string fileName)
        {
            Console.WriteLine($"File Create Called {fileName}");
        }

        void IFile.ReadFile(string fileName)
        {
            Console.WriteLine($"File REad Called {fileName}");
        }
    }
}
