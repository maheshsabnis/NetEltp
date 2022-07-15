// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo String Array");
// Initialize the array
string[] arr = new string[] { "Mahesh", "Tejas", "Mukesh", "Satish", "Vivek", "Vinay","Sandeep", "Nandu", "Anil", "Abhay", "Jaywant", "Shyam", "Tushar", "Sanjay", "Sharad", "Vijay","Abhay", "Vilas" };

string continueExecution = "y";
do
{
    Console.WriteLine("1. Sort Array");
    Console.WriteLine("2. Reverse Array");
    Console.WriteLine("3. Print Array");
    Console.WriteLine("4. Search a Record in  Array");
    Console.WriteLine("Enter your choice to perform operation");

    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Array.Sort(arr);
            PrintArray(arr);
            break;
        case 2:
            Array.Reverse(arr);
            PrintArray(arr);
            break;
        case 3:
            PrintArray(arr);
            break;
        case 4:
            Console.WriteLine("Enter value to search from Array");
            string? valueToSearch = Console.ReadLine();
            int index = 0;
            if (valueToSearch != null)
            {
                index = Array.IndexOf(arr, valueToSearch);
                if (index != -1)
                    Console.WriteLine($"{valueToSearch} exist at {index} position");
                else
                    Console.WriteLine($"{valueToSearch} is not present");
            }
            break;
    }
    Console.WriteLine("Please enter y or Y to continue");
    continueExecution = Console.ReadLine();
    Console.Clear();
} while (continueExecution == "y" || continueExecution == "Y");

Console.ReadLine();

static void PrintArray(string[] array)
{
    // Use foreach..loop
    foreach (string str in array)
    {
        Console.WriteLine(str);
    }

}