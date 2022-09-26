namespace CS_Utilities
{
    public interface IStringUtilities
    {
        IEnumerable<char> Reverse(string str);
        int GetLength(string str);
    }

    public class StringOperations : IStringUtilities
    {
        int IStringUtilities.GetLength(string str)
        {
            return str.Length;
        }

        IEnumerable<char> IStringUtilities.Reverse(string str)
        {
            return str.Reverse();
        }

        protected void PrintMessage(string msg)
        {
            Console.WriteLine($"The Message = {msg}" );
        }

        protected internal void PrintMessageNew(string msg)
        {
            Console.WriteLine($"The New Message = {msg}");
        }
    }
}