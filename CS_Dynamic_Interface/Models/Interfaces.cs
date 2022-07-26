using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Dynamic_Interface.Models
{
    /// <summary>
    /// Base Standard for Interfaces
    /// </summary>
    public interface IFile 
    {
        void CreateFile(string fileName);
        void ReadFile(string fileName);
    }

    /// <summary>
    /// Interface Implementing base Interface
    /// </summary>
    public interface ITextFile : IFile
    {
        void WriteFile(string fileName);
    }

    public interface IXmlFile : IFile
    {
        void EncryptFile(string fileName);
    }
}
