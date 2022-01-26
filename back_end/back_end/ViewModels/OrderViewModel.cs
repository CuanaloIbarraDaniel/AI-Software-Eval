using back_end.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.ViewModels
{
    public class OrderViewModel
    {
        /// <summary> 
        /// Used to support REST create operations on the multimedia view. 
        /// </summary>
        public class CreateOrderViewModel : OrderModel
        {
            [Required]
            [Range(0, int.MaxValue)]
            public override int Order_Status { get; set; }
        }



        /// <summary> 
        /// Used to support REST update operations on the multimedia view. 
        /// </summary>
        public class UpdateOrderViewModel : OrderModel
        {
            [Required]
            [Range(0, int.MaxValue)]
            public override int Order_ID { get; set; }

            [Required]
            [Range(0, int.MaxValue)]
            public override int Order_Status { get; set; }

            public override List<ProductModel> Order_Product_List { get; set; }
        }



        /// <summary> 
        /// Used to support REST delete operations on the multimedia view. 
        /// </summary>
        public class DeleteOrderViewModel : OrderModel
        {
            [Required]
            [Range(0, int.MaxValue)]
            public override int Order_ID { get; set; }
        }
    }
}
