using back_end.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace back_end.ViewModels
{
    public class ProductViewModel
    {
        /// <summary> 
        /// Used to support REST create operations on the multimedia view. 
        /// </summary>
        public class CreateProductViewModel : ProductModel
        {
            [Required]
            public override string Product_SKU { get; set; }

            [Required]
            public override string Product_Name { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public override int Product_Quantity { get; set; }
        }



        /// <summary> 
        /// Used to support REST update operations on the multimedia view. 
        /// </summary>
        public class UpdateProductViewModel : ProductModel
        {
            [Required]
            [Range(1, int.MaxValue)]
            public override int Product_ID { get; set; }

            [Required]
            public override string Product_SKU { get; set; }

            [Required]
            public override string Product_Name { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public override int Product_Quantity { get; set; }
        }



        /// <summary> 
        /// Used to support REST delete operations on the multimedia view. 
        /// </summary>
        public class DeleteProductViewModel : ProductModel
        {
            [Required]
            [Range(1, int.MaxValue)]
            public override int Product_ID { get; set; }
        }
    }
}
