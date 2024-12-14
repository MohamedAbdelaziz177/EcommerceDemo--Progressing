
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.MRepositories
{
    public class FavoriteRepo : IFavoriteRepo
    {
        private readonly AppDbContext con;

        public FavoriteRepo(AppDbContext con)
        {
            this.con = con;
        }
        public async Task deleteAsync(int id)
        {
            var Favorite = await con.Favorites.FindAsync(id);

            if (Favorite != null)
                con.Favorites.Remove(Favorite);

            await con.SaveChangesAsync();

        }

        public async Task<List<Favorite>> GetAllAsync()
        {
            var lstOfFavorites = await con.Favorites.ToListAsync();

            return lstOfFavorites;
        }

        public async Task<Favorite> GetByIdAsync(int id)
        {
            var Favorite = await con.Favorites.FindAsync(id);

           // await con.SaveChangesAsync();

            return Favorite;
        }

        public async Task insertAsync(Favorite entity)
        {
            await con.Favorites.AddAsync(entity);

            await con.SaveChangesAsync();

        }

        public async Task updateAsync(Favorite entity)
        {
            con.Favorites.Update(entity);


            await con.SaveChangesAsync();
        }



        //-----------------------------------------------------
        public async Task<IEnumerable<Favorite>> GetFavoritesForCustomerAsync(int customerId)
        {

            IEnumerable<Favorite> FavedItems = 
                await con.Favorites.Where(x  => x.CustomerId == customerId).ToListAsync();

           return FavedItems;
        }

        public async Task<bool> IsProductInFavoritesAsync(int customerId, int productId)
        {
            Favorite faved = await con.Favorites
                    .FirstOrDefaultAsync(x => x.CustomerId == customerId && x.ProductId == productId);
                    
                                           
            return (faved != null);
        }
    }
}

