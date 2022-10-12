using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.SqlClient;
using CS_LINQ_TO_SQL.Models;

namespace CS_LINQ_TO_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection Conn = new SqlConnection ("Data Source=.;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");
                DataContext db = new DataContext(Conn);
               
                Table<NewCustomer> Customers = db.GetTable<NewCustomer>();
                db.Log = Console.Out;
               Console.WriteLine($"Query {db.Log}");

                IQueryable<NewCustomer> custQuery =
                        from cust in Customers
                        where cust.City == "Pune"
                        select cust;

                //var custQuery =
                //         (from cust in Customers
                //         where cust.City == "Pune"
                //         select cust).ToList();



                foreach (var item in custQuery)
                {
                    Console.WriteLine($"{item.CustomerID} {item.CustomerName}");
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {

                throw;
            }
            Console.ReadLine();   
        }
    }
}
