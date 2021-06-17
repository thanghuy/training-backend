using hicas_training.Models;
using hicas_training.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.ProductServices
{
    public interface IProduct
    {
        public Task<List<Product>> GetListProduct(FilterDTO filterDTO);
        public Task<Product> GetProductByID(int idProduct);
    }
}
