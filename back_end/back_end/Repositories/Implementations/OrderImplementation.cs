using back_end.Models;
using back_end.Modules.Constants;
using back_end.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositories.Implementations
{
    public class OrderImplementation : IOrderInterface
    {
        private static List<OrderModel> order_Model_List = new List<OrderModel>();



        /// <summary>
        /// Creates a new order model on the database using required parameters.
        /// </summary>
        public async Task<int> Create(OrderModel order_Model)
        {
            if (order_Model_List.Count == 0)
            { // Sets the ID number 1 if there is no data on the list
                order_Model.Order_ID = 1;
            }
            else
            { // Sets the last ID of the table
                order_Model.Order_ID = order_Model_List.Last().Order_ID + 1;
            }
            order_Model_List.Add(order_Model);
            // Success
            return RepositoryConstant.Success_Task;
        }



        /// <summary>
        /// Gets a list of products models by accessing the database.
        /// </summary>
        public async Task<List<OrderModel>> Read()
        {
            List<OrderModel> current_Model_List = new List<OrderModel>();
            for (int A1 = 0; A1 < order_Model_List.Count; A1++)
            {
                OrderModel order_Model = new OrderModel();
                order_Model.Order_ID = order_Model_List[A1].Order_ID;
                order_Model.Order_Product_List = order_Model_List[A1].Order_Product_List;
                order_Model.Order_Status = order_Model_List[A1].Order_Status;
                current_Model_List.Add(order_Model);
            }
            order_Model_List.FindAll(x => x.Order_Status == 0).ForEach(x => x.Order_Status = 1);
            return current_Model_List;
        }



        /// <summary>
        ///  Updates a order model by accessing the database using required parameters.
        /// </summary>
        public async Task<int> Update(OrderModel order_Model)
        {
            int database_Model = order_Model_List.FindIndex(x => x.Order_ID == order_Model.Order_ID);
            if (database_Model == -1)
            { // Not Found
                return RepositoryConstant.Warning_Not_Found;
            }
            order_Model_List[database_Model].Order_Status = order_Model.Order_Status;
            if (order_Model.Order_Product_List.Count > 0)
            { // Checks if there is a list on the update model
                if (order_Model.Order_Product_List[0].Product_ID == 0)
                { // Checks if it is a valid list
                    order_Model_List[database_Model].Order_Product_List = order_Model.Order_Product_List;
                }
            }
            // Success
            return RepositoryConstant.Success_Task;
        }



        /// <summary>
        /// Deletes a order model from the database using its ID.
        /// </summary>
        public async Task<int> Delete(int order_ID)
        {
            int database_Model = order_Model_List.FindIndex(x => x.Order_ID == order_ID);
            if (database_Model == -1)
            { // Not Found
                return RepositoryConstant.Warning_Not_Found;
            }
            order_Model_List.RemoveAt(database_Model);
            // Success
            return RepositoryConstant.Success_Task;
        }
    }
}
