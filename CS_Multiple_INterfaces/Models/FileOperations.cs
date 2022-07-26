using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Multiple_INterfaces.Models
{
    public class FileOperations : ITextFile, IXmlFile
    {
        void ITextFile.CreateFile(string fileName)
        {
            Console.WriteLine($"Text File CReated  {fileName}");
        }

        void IXmlFile.CreateFile(string fileName)
        {
            Console.WriteLine($"XML File CReated  {fileName}");
        }

        void ITextFile.ReadFile(string fileName)
        {
            Console.WriteLine($"Read Text File   {fileName}");
        }

        void IXmlFile.ReadFile(string fileName)
        {
            Console.WriteLine($"Read XML File   {fileName}");
        }
    }
}
