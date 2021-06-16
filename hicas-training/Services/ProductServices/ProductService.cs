using hicas_training.Data;
using hicas_training.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.ProductServices
{
    public class ProductService : DbServices, IProduct
    {
        public ProductService(DbContextTraining context) : base(context)
        {
        }

        public async Task<List<Product>> GetListProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByID(int idProduct)
        {
            return await _context.Products.FindAsync(idProduct);
        }
    }
}
