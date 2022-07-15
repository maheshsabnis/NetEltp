// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo Arrays");

// Array deffinition, an instance of Array class, in this case it in 'int'
int[] arr = new int[5];

Console.WriteLine("Enter ata in Array");
for (int i=0;i<arr.Length;i++)
{ 
    arr[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine();
// pass array to method
PrintArray(arr);

// Lets use Array Class Methods.
// From 0th index to last each number is compared
// if 1st index value is less than 0th index value then
// rearrange array
Array.Sort(arr); // The arr will self-be updated with sorting
Console.WriteLine("Array after Sort");
PrintArray(arr);
Array.Reverse(arr);
Console.WriteLine("Array after Reverse");
PrintArray(arr);
Console.WriteLine("Enter number to serach and get its index");
int numToSearch = Convert.ToInt32(Console.ReadLine());
// Search the numToSearch on arr and return its index (aka position) if found else -1
int index = Array.IndexOf(arr, numToSearch);
Console.WriteLine($"Index of {numToSearch} is = {index}");

static void PrintArray(int[] array)
{
    Console.WriteLine("Data in Array");
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine(array[i]);
    }
}



Console.ReadLine(); 
