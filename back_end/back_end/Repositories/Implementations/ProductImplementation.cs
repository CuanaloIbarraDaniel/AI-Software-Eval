using back_end.Models;
using back_end.Modules.Constants;
using back_end.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositories.Implementations
{
    public class ProductImplementation : IProductInterface
    {
        private static List<ProductModel> product_Model_List = new List<ProductModel>();



        /// <summary>
        /// Creates a new product model on the database using required parameters.
        /// </summary>
        public async Task<int> Create(ProductModel product_Model)
        {
            ProductModel database_Model = product_Model_List.Find(x => x.Product_SKU == product_Model.Product_SKU);
            if (database_Model != null)
            { // Duplicate SKU
                return RepositoryConstant.Error_Duplicated_SKU;
            }
            if (product_Model_List.Count == 0)
            { // Sets the ID number 1 if there is no data on the list
                product_Model.Product_ID = 1;
            }
            else
            { // Sets the last ID of the table
                product_Model.Product_ID = product_Model_List.Last().Product_ID + 1;
            }
            product_Model_List.Add(product_Model);
            // Success
            return RepositoryConstant.Success_Task;
        }



        /// <summary>
        /// Gets a list of products models by accessing the database.
        /// </summary>
        public async Task<List<ProductModel>> Read()
        {
            return product_Model_List;
        }



        /// <summary>
        ///  Updates a product model by accessing the database using required parameters.
        /// </summary>
        public async Task<int> Update(ProductModel product_Model)
        {
            int database_Model = product_Model_List.FindIndex(x => x.Product_ID == product_Model.Product_ID);
            if (database_Model == -1)
            { // Not Found
                return RepositoryConstant.Warning_Not_Found;
            }
            product_Model_List[database_Model].Product_Name = product_Model.Product_Name;
            product_Model_List[database_Model].Product_SKU = product_Model.Product_SKU;
            product_Model_List[database_Model].Product_Quantity = product_Model.Product_Quantity;
            if (product_Model_List[database_Model].Product_Quantity <= 5)
            {
                return RepositoryConstant.Warning_Create_Alert;
            }
            // Success
            return RepositoryConstant.Success_Task;
        }



        /// <summary>
        /// Deletes a product model from the database using its ID.
        /// </summary>
        public async Task<int> Delete(int product_ID)
        {
            int database_Model = product_Model_List.FindIndex(x => x.Product_ID == product_ID);
            if (database_Model == -1)
            { // Not Found
                return RepositoryConstant.Warning_Not_Found;
            }
            product_Model_List.RemoveAt(database_Model);
            // Success
            return RepositoryConstant.Success_Task;
        }
    }
}
