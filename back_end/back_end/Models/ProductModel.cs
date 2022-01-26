using Swashbuckle.AspNetCore.Annotations;

namespace back_end.Models
{
    public class ProductModel
    {
        /// <summary> 
        /// Message model contructor with no custom variables.
        /// </summary>
        public ProductModel()
        {
            Product_ID = 0;
            Product_SKU = "";
            Product_Name = "";
            Product_Quantity = 0;
        }



        /// <summary> 
        /// Product model contructor with everything as custom variables.
        /// </summary>
        public ProductModel(int product_ID, string product_SKU, string product_Name, int product_Quantity)
        {
            Product_ID = product_ID;
            Product_SKU = product_SKU;
            Product_Name = product_Name;
            Product_Quantity = product_Quantity;
        }



        [SwaggerSchema("Product_ID")]
        public virtual int Product_ID { get; set; }


        [SwaggerSchema("Product_SKU")]
        public virtual string Product_SKU { get; set; }


        [SwaggerSchema("Product_Name")]
        public virtual string Product_Name { get; set; }


        [SwaggerSchema("Product_Quantity")]
        public virtual int Product_Quantity { get; set; }
    }
}
