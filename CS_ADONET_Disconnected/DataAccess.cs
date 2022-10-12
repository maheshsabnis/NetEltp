using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace CS_ADONET_Disconnected
{
    internal class DataAccess
    {
        SqlConnection Conn;
        SqlDataAdapter AdDept,AdEmp;
        DataSet Ds;
        DataRow DrFind;
        public DataAccess()
        {

            Conn = new SqlConnection("Data Source=.;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");
            Ds = new DataSet();
            LoadData();
        }

        private void LoadData()
        {
            AdDept = new SqlDataAdapter("Select * from Department", Conn);
           // AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
            // MAke sure that the Metadata of the Table is put in DataSet
        AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
          //  AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // Fill Data into DataSet
            AdDept.Fill(Ds, "Department");
           // AdEmp.Fill(Ds,"Employee");
            // Print XML Schema
          //  Console.WriteLine(Ds.GetXmlSchema());
            // Print Data FRom DataSet
           Console.WriteLine(Ds.GetXml());
        }

        public void CreateDept()
        {
            // 1. Create a space in Department Table in DataSet for Adding NEw Record
            DataRow DrNew = Ds.Tables["Department"].NewRow();
            DrNew["DeptNo"] = 80;
            DrNew["DeptName"] = "Kachara DEpt";
            DrNew["Location"] = "Mumbai";
            DrNew["Capacity"] = 900;
            Ds.Tables["Department"].Rows.Add(DrNew);
            // Console.WriteLine(Ds.GetXml());

            SqlCommandBuilder builder = new SqlCommandBuilder(AdDept);
            // Update
            AdDept.Update(Ds, "Department");
        }

        public void FindRecord(int dno)
        {
            // 1. Mark the COlumn that will be used as Primary Key
            // 1.a. MAke Unique
            //Ds.Tables["Department"].Columns["DeptNo"].Unique = true;
            ////1.b. Make the olumn as No Null
            //Ds.Tables["Department"].Columns["DeptNo"].AllowDBNull = false;
            ////1.c. Take an Array of all Such DeptNo Column
            //DataColumn[] dc = new DataColumn[] { Ds.Tables["Department"].Columns["DeptNo"] };
            //// 1.d. Set this Array as Primary Key
            //Ds.Tables["Department"].PrimaryKey = dc;

            DrFind = Ds.Tables["Department"].Rows.Find(dno);
            Console.WriteLine($"{DrFind["DeptNo"]} {DrFind["DeptName"]}");
        }

        public void Update(int dno)
        {
            DrFind = Ds.Tables["Department"].Rows.Find(dno);

           
            // The Row is Already Assoiated with the Table
            DrFind["DeptName"] = "New DEpt";
            DrFind["Location"] = "Pune";
            DrFind["Capacity"] = 9090;
            Console.WriteLine();
            Console.WriteLine("Update");
             Console.WriteLine(Ds.GetXml());
            Console.WriteLine();
             SqlCommandBuilder builder = new SqlCommandBuilder(AdDept);
            AdDept.ContinueUpdateOnError = true;
            // Update
            AdDept.Update(Ds, "Department");
            

        }

        public void Delete(int dno)
        {
            DrFind = Ds.Tables["Department"].Rows.Find(dno);
            // The Row is Already Assoiated with the Table
            DrFind.Delete(); 

            Console.WriteLine("Delete");
            Console.WriteLine(Ds.GetXml());
            Console.WriteLine();
            SqlCommandBuilder builder = new SqlCommandBuilder(AdDept);
            // Update
            AdDept.Update(Ds, "Department");

        }

        public DataRowCollection GetRows()
        {
            var rows = Ds.Tables["Department"].Rows;
            return rows;
        }
    }
}
