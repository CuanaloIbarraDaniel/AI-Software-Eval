using back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositories.Interfaces
{
    public interface IOrderInterface
    {
        Task<int> Create(OrderModel order_Model);


        Task<List<OrderModel>> Read();


        Task<int> Update(OrderModel order_Model);


        Task<int> Delete(int order_ID);
    }
}
