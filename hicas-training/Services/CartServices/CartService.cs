using hicas_training.Data;
using hicas_training.Models;
using hicas_training.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.CartServices
{
    public class CartService : DbServices, ICartServices
    {
        public CartService(DbContextTraining context) : base(context)
        {
        }

        public async Task<bool> DeleteCart(int idCart, int idUser)
        {
            var cartItem = await _context.Carts.Where(x => x.IdCart == idCart && x.IdUser == idUser).FirstOrDefaultAsync();
            _context.Carts.Remove(cartItem);
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<int> GetAmoutCart(int idUser, int IdProduct)
        {
            return 1;
        }

        public async Task<List<CartDTO>> GetCartByID(int idUser)
        {
            var result = await _context.Carts.Where(x => x.IdUser == idUser).Join(
                _context.Products,
                ca => ca.IdProduct,
                p => p.IdProduct,
                (ca, p) => new { ca, p }
                ).Select(cp => new CartDTO()
                {
                    IdCart = cp.ca.IdCart,
                    IdUser = cp.ca.IdUser,
                    Name = cp.p.Name,
                    Amount = cp.ca.Amount,
                    IdProduct = cp.p.IdProduct,
                    Image = cp.p.Image,
                    Price = cp.p.Price * cp.ca.Amount,
                    Price_item = cp.p.Price
                }).ToListAsync();
            return result;
        }

        public async Task<bool> PostCart(Cart newItem)
        {
            var cart_item = _context.Carts.AsEnumerable<Cart>();
            var _cart =  cart_item.Where(x => x.IdProduct == newItem.IdProduct && x.IdUser == newItem.IdUser).FirstOrDefault();
            if (_cart == null)
            {
                _context.Add(newItem);
            }
            else
            {
                _cart.Amount += newItem.Amount;
            }
            //
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> UpdateCartByID(int idCart, int idUser,int Amount)
        {
            var cart_item = await _context.Carts.Where(x => x.IdCart == idCart && x.IdUser == idUser).FirstOrDefaultAsync();
            cart_item.Amount = Amount;
            return await _context.SaveChangesAsync() != 0;
        }
    }
}
