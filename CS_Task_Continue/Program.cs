// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Task COntinue DEMO");
FileOperations file = new FileOperations();

Task t = Task.Factory.StartNew(() => 
{
    Console.WriteLine("The First Task  is Fetched");
    file.ReadFileOne();
    Console.WriteLine("Data is Read From First File");
}).ContinueWith((t1)=>
{
    Console.WriteLine("The Other Task That is Fetched");
    file.ReadFileTwo();
    Console.WriteLine("Data is Read From Second File");
});

Console.WriteLine();
Console.WriteLine("Task COntinue With Return Data");
Tax tax = new Tax(400000);

Task<decimal> t2 = Task.Factory.StartNew<decimal>(() =>
{
    var tds = tax.GetTDS();
    Console.WriteLine($"TDS = {tds}");
    return tds;
}).ContinueWith<decimal>((t2) =>
{
    var gst = tax.GetGST(400000);
    Console.WriteLine($"Calculated GST = {gst}");
    return gst;
});

Console.WriteLine($"Result {t2.Result}");

Console.WriteLine();
Payment payment = new Payment();

Task<Payment> tResult = Task.Factory.StartNew<Payment>(() =>
{
    var tds = tax.GetTDS();
    payment.TDS = tds;
    Console.WriteLine($"TDS = {JsonSerializer.Serialize(payment)}");
    return payment;
}).ContinueWith<Payment>((t2) =>
{
    var gst = tax.GetGST(400000);
    Console.WriteLine($"Calculated GST = {gst}");
    payment.GST = gst;
    Console.WriteLine($"GST = {JsonSerializer.Serialize(payment)}");
    return payment;
}).ContinueWith<Payment>((t3) => {
     
    payment.NetPayment = tax.GetNetPayment(400000, t3.Result.TDS, t3.Result.GST);

    return payment;
});

var finalPay = tResult.Result;
Console.WriteLine(JsonSerializer.Serialize(finalPay));


Console.WriteLine("Ends Here");



 


Console.ReadLine();


class FileOperations
{
    public void ReadFileOne()
    {
        string contents = String.Empty;

        using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFile.txt"))
        {
            contents = reader.ReadToEnd();
        }

        Console.WriteLine($"File One COntents  - {contents}");
    }

    public void ReadFileTwo()
    {
        string contents = String.Empty;
        using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFileSync.txt"))
        {
            contents = reader.ReadToEnd();
        }
        Console.WriteLine($"File Two COntents  - {contents}");
    }
}



class AsyncFileOperations
{
    public async Task<string> ReadFileOneAsync()
    {
        string contents = String.Empty;

        using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFile.txt"))
        {
            contents = await reader.ReadToEndAsync();
        }

        return contents;
    }

    public async Task<string> ReadFileTwoAsync()
    {
        string contents = String.Empty;
        using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFileSync.txt"))
        {
            contents = await reader.ReadToEndAsync();
        }
        return contents;
    }
}


class Payment
{
    public decimal NetIncome { get; set; }
    public decimal TDS { get; set; }
    public decimal GST { get; set; }
    public decimal NetPayment { get; set; }
}

class Tax
{
    private decimal NetIncome = 0;
    private decimal tds;
    private decimal gst;
    public Tax(decimal netIncome)
    {
        NetIncome = netIncome;
    }

    public decimal GetTDS()
    {
       
        if (NetIncome > 100000)
            tds = NetIncome * Convert.ToDecimal(0.2);
        else
            tds = NetIncome * Convert.ToDecimal(0.1);

        return tds;
    }

    public decimal GetGST(decimal netIncome)
    {
       gst = netIncome * Convert.ToDecimal(0.18);
        return gst; 
    }

    public decimal GetNetPayment(decimal netIncome, decimal tds, decimal gst)
    { 
        return netIncome - tds + gst;
    }
}
