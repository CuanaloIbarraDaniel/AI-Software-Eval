﻿using back_end.Models;
using back_end.Modules.Constants;
using back_end.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositories.Implementations
{
    public class OrderImplementation : IOrderInterface
    {
        private List<OrderModel> order_Model_List = new List<OrderModel>();



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

        public async Task<List<OrderModel>> Read()
        {
            return order_Model_List;
        }



        public async Task<int> Update(OrderModel order_Model)
        {
            ProductModel database_Model = order_Model_List.Find(x => x.Order_ID == order_Model.Order_ID);
            if (database_Model.Product_ID == 0)
            { // Not Found
                return RepositoryConstant.Warning_Not_Found;
            }
            order_Model_List[database_Model.Product_ID].Order_Status = order_Model.Order_Status;
            if (order_Model.Order_Product_List.Count > 0)
            { // Checks if there is a list on the update model
                if (order_Model.Order_Product_List[0].Product_ID == 0)
                { // Checks if it is a valid list
                    order_Model_List[database_Model.Product_ID].Order_Product_List = order_Model.Order_Product_List;
                }
            }
            // Success
            return RepositoryConstant.Success_Task;
        }



        public async Task<int> Delete(int order_ID)
        {
            OrderModel database_Model = order_Model_List.Find(x => x.Order_ID == order_ID);
            if (database_Model.Order_ID == 0)
            { // Not Found
                return RepositoryConstant.Warning_Not_Found;
            }
            product_Model_List.RemoveAt(product_ID);
            // Success
            return RepositoryConstant.Success_Task;
        }
    }
}