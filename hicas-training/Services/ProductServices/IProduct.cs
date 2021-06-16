using hicas_training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.ProductServices
{
    public interface IProduct
    {
        public Task<List<Product>> GetListProduct();
        public Task<Product> GetProductByID(int idProduct);
    }
}
