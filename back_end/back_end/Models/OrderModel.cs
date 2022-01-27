using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace back_end.Models
{
    public class OrderModel
    {
        /// <summary> 
        /// Order model contructor with no custom variables.
        /// </summary>
        public OrderModel()
        {
            Order_ID = 0;
            Order_Status = -1;
            Order_Product_List = new List<ProductModel>();
        }



        /// <summary> 
        /// Order model contructor with everything as a custom variables.
        /// </summary>
        public OrderModel(int order_ID, int order_Status, List<ProductModel> order_Product_List)
        {
            Order_ID = order_ID;
            Order_Status = order_Status;
            Order_Product_List = order_Product_List;
        }



        [SwaggerSchema("Order_ID")]
        public virtual int Order_ID { get; set; }


        [SwaggerSchema("Order_Status")]
        public virtual int Order_Status { get; set; }


        [SwaggerSchema("Order_Product_List")]
        public virtual List<ProductModel> Order_Product_List { get; set; }
    }
}
