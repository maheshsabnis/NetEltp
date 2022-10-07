using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CS_SimleDataAccess.Models;

namespace CS_SimleDataAccess.DataAccess
{
    internal class CategoryDbAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public CategoryDbAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");
        }

        public IEnumerable<Category> GetRecords()
        {
            List<Category> records = new List<Category>();
            try
            {
                // 1. Open the onection
                Conn.Open();
                // 2. Creating ommand
                Cmd = new SqlCommand();
                // Set the COnnection object to COmmand
                Cmd.Connection = Conn;
                // 2.a. Setting the Command Properties for TExt 
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = "Select * from Category";
                // 3. Execute
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 3.a. STart REading Records
                while (Reader.Read())
                {
                    records.Add(new Category() 
                    {
                       CategoryId = Convert.ToInt32(Reader["CategoryId"]),
                       CategoryName = Reader["CategoryName"].ToString(),
                       BasePrice = Convert.ToDecimal(Reader["BasePrice"])
                    });
                }
                Reader.Close(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                Conn.Close();   
            }
            return records;
        }

        public Category CreateRecord(Category category)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = "Insert into Category values(@CategoryId,@CategoryName,@BasePrice)";
                // Set Parmeters
                Cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                Cmd.Parameters.AddWithValue("@CategoryName",category.CategoryName);
                Cmd.Parameters.AddWithValue("@BasePrice",category.BasePrice);
                // Execute
                int res = Cmd.ExecuteNonQuery();
                if (res == 0)
                    throw new Exception("No REcord Inserted");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return category;
        }

        public Category UpdateRecord(int id, Category category)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = "Update Category set CategoryName=@CategoryName,BasePrice=@BasePrice Where CategoryId=@CategoryId";
                // Set Parmeters
                Cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                Cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                Cmd.Parameters.AddWithValue("@BasePrice", category.BasePrice);
                // Execute
                int res = Cmd.ExecuteNonQuery();
                if (res == 0)
                    throw new Exception("No REcord Updated");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return category;
        }
        public bool DeleteRecord(int id)
        {
            bool isDeleted = false;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = "Delete Category Where CategoryId=@CategoryId";
                // Set Parmeters
                Cmd.Parameters.AddWithValue("@CategoryId", id);
                
                // Execute
                int res = Cmd.ExecuteNonQuery();
                if (res == 0)
                    throw new Exception("No REcord Deleted");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return isDeleted;
        }
    }
}
