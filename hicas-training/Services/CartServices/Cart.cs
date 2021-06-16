using hicas_training.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.CartServices
{
    public class Cart : DbServices, ICartServices
    {
        public Cart(DbContextTraining context) : base(context)
        {
        }

        public Task<bool> DeleteCart(int idCart)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAmoutCart(int idUser, int IdProduct)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetCartByID(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCartByID(int Amount)
        {
            throw new NotImplementedException();
        }
    }
}
