using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coditas.EComm.Entities;
using Coditas.EComm.DataAccess;
using Coditas.EComm.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Coditas.EComm.Repositories
{
    public class ProductRepository : IDbRepository<Product,int>
    {
        eShoppingCodiContext _context;
        public ProductRepository(eShoppingCodiContext context)
        {
            _context = context;
        }

        async Task<Product> IDbRepository<Product, int>.CreateAsync(Product entity)
        {
            try
            {
                var result = await _context.Products.AddAsync(entity); 
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Product> IDbRepository<Product, int>.DeleteAsync(int id)
        {
            try
            {
                var record = await _context.Products.FindAsync(id);
                if (record == null)
                    throw new Exception($"The Record with Product Unique Id {id} is Missing");
                _context.Products.Remove(record);
                await _context.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<IEnumerable<Product>> IDbRepository<Product, int>.GetAsync()
        {
            return await _context.Products.ToListAsync();
        }

        async Task<Product> IDbRepository<Product, int>.GetAsync(int id)
        {
            try
            {
                var record = await _context.Products.FindAsync(id);
                if (record == null)
                    throw new Exception($"The Record with Product Unique Id {id} is Missing");
                return record;  

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Product> IDbRepository<Product, int>.UpdateAsync(int id, Product entity)
        {
            try
            {
                var record = await _context.Products.FindAsync(id);
                if (record == null)
                    throw new Exception($"The Record with Product Unique Id {id} is Missing");
                record.ProductName = entity.ProductName;
                record.ProductId = entity.ProductId;
                record.Manufacturer = entity.Manufacturer;
                record.Description = entity.Description;
                record.CategoryId = entity.CategoryId;
                record.Price = entity.Price;
                await _context.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
