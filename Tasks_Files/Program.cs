
// See https://aka.ms/new-console-template for more information
	
Console.WriteLine("USing Single File REad/Write using Multiple Tasks");

//Task t1 = Task.Factory.StartNew(() => 
//{
//	ReadFile();
//});
//Task t2 = Task.Factory.StartNew(() => { 
// WriteFile();
//});

//Parallel.Invoke(() => 
//{
//	ReadFile();
//	WriteFile();	
//	ReadFile();
//});

Parallel.Invoke(() => 
{
	Task t1 = new Task(ReadFile);
	Task t2 = new Task(WriteFile);
	t1.Start();
	t2.Start();
});

Console.ReadLine();

static void ReadFile()
{
	using (StreamReader reader = new StreamReader(@"c:\Coditas\jb.txt"))
	{
		Console.WriteLine(reader.ReadToEnd());
		reader.Close();
	}
}

static void WriteFile()
{
	using (StreamWriter writer = new StreamWriter (@"c:\Coditas\jb.txt",true))
	{
		writer.WriteLine("I am new Data from TAsk");
		writer.Close();
	}
}