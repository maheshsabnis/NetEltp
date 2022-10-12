using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace CS_LINQ_TO_SQL.Models
{
    /// <summary>
    /// TableAttriute class used to map with the TAble
    /// </summary>
    [Table(Name = "NewCustomer")]
    internal class NewCustomer
    {
        private int _CustomerID;
        // The ColumnAttribute class used to define 
        // Mapping with Column
        // Storage: Mapping of Pubic Property with Private Data Member 
        [Column(IsPrimaryKey = true, Storage = "_CustomerID")]
        public int CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this._CustomerID = value;
            }

        }

        private string _City;
        [Column(Storage = "_City")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        private string _CustomerName;
        [Column(Storage = "_CustomerName")]
        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                this._CustomerName = value;
            }
        }


    }

}

 