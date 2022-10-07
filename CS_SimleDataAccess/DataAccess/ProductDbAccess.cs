using CS_SimleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SimleDataAccess.DataAccess
{
    internal class ProductDbAccess : IDbAccess<Product, int>
    {
        Product IDbAccess<Product, int>.Create(Product entity)
        {
            throw new NotImplementedException();
        }

        Product IDbAccess<Product, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Product IDbAccess<Product, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IDbAccess<Product, int>.GetAll()
        {
            throw new NotImplementedException();
        }

        Product IDbAccess<Product, int>.Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
