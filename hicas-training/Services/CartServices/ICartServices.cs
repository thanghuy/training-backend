using hicas_training.Models;
using hicas_training.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.CartServices
{
    public interface ICartServices
    {
        public Task<List<CartDTO>> GetCartByID(int idUser);
        public Task<int> GetAmoutCart(int idUser, int IdProduct);
        public Task<Boolean> UpdateCartByID(int idCart, int idUser,int Amount);
        public Task<Boolean> PostCart(Cart cart);
        public Task<Boolean> DeleteCart(int idCart,int idUser);
    }
}
