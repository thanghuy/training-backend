using hicas_training.Data;
using hicas_training.Models;
using hicas_training.Models.DTOs;
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

        public async Task<List<Product>> GetListProduct(FilterDTO filterDTO)
        {
            var product = _context.Products.AsEnumerable<Product>();
            if(filterDTO.KeyWord != "" && filterDTO.KeyWord != "null")
            {
                product = product.Where(x => x.Name.ToLower().Contains(filterDTO.KeyWord));
            }
            if(filterDTO.PriceFrom != 0 || filterDTO.PriceTo != 0)
            {
                product = product.Where(x => x.Price >= filterDTO.PriceFrom && x.Price <= filterDTO.PriceTo);
            }
            if(filterDTO.RateFrom != 0 && filterDTO.RateTo != 0){
                product = product.Where(x => x.Rate >= filterDTO.RateFrom && x.Rate <= filterDTO.RateTo);
            }
            return product.ToList();
        }

        public async Task<Product> GetProductByID(int idProduct)
        {
            return await _context.Products.FindAsync(idProduct);
        }
    }
}
