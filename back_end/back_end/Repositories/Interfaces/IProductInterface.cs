using back_end.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Repositories.Interfaces
{
    public interface IProductInterface
    {
        Task<int> Create(ProductModel product_Model);


        Task<List<ProductModel>> Read();


        Task<int> Update(ProductModel product_Model);


        Task<int> Delete(int product_ID);
    }
}
