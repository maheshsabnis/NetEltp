using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CS_FirstFile.Operations
{
    public class FileOperation
    {
        public void CreateFile(string fileName)
        {
            try
            {
                if (fileName == string.Empty)
                {
                    throw new Exception("File Name Cannot be Empty");
                }
               FileStream fs =   File.Create(fileName);
                Console.WriteLine("The File is created successfully");
                // Close the file so that the handle can be released
                // and the file is accessible fr other operations
                fs.Close();
                fs.Dispose();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteFile(string fileName, string contents)
        {
            try
            {
                if (fileName == string.Empty)
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.WriteAllText(fileName, contents);
                Console.WriteLine("Contents are written to the File");
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        public void WriteFile(string fileName, string[] contents)
        {
            try
            {
                if (fileName == string.Empty)
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.WriteAllLines(fileName, contents);
                Console.WriteLine("Contents are written to the File");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReadFile(string fileName)
        {
            try
            {
                string contents = string.Empty;
                if (fileName == string.Empty)
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                contents = File.ReadAllText(fileName);
                return contents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AppendFile(string fileName, string contents)
        {
            try
            {
                if (fileName == string.Empty)
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.AppendAllText(fileName, contents);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AppendFile(string fileName, string[] contents)
        {
            try
            {
                if (fileName == string.Empty)
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.AppendAllLines(fileName, contents);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void MakeCopy(string srcFileName, string destFileName)
        {
            if (srcFileName == string.Empty || destFileName == string.Empty)
            {
                throw new Exception("Source File Name or Destination File NAme Cannot be Empty");
            }
            File.Copy(srcFileName,destFileName);
        }
    }
}
