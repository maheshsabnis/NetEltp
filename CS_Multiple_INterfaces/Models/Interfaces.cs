using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Multiple_INterfaces.Models
{
    public interface ITextFile
    {
        void CreateFile(string fileName);
        void ReadFile(string fileName);
    }

    public interface IXmlFile
    {
        void CreateFile(string fileName);
        void ReadFile(string fileName);
    }
}
