using E_Commerce.Models;
using System.Threading.Tasks;

namespace E_Commerce.Repositories.IRepositories
{
    public interface IProductRepo : IGeneric<Product>
    {
        //  public IEnumerable<Product> GetFavedProductsForCustomerAsync(int Customerid);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int CategoryId);


    }
}
