using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.CartServices
{
    public interface ICartServices
    {
        public Task<List<Cart>> GetCartByID(int idUser);
        public Task<int> GetAmoutCart(int idUser, int IdProduct);
        public Task<Boolean> UpdateCartByID(int Amount);
        public Task<Boolean> PostCart(Cart cart);
        public Task<Boolean> DeleteCart(int idCart);
    }
}
