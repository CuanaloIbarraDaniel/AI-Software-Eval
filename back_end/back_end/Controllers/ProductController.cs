using back_end.Models;
using back_end.Modules.Constants;
using back_end.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using static back_end.ViewModels.ProductViewModel;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface product_Interface;
        private readonly IOrderInterface order_Interface;


        public ProductController(IProductInterface productInterface, IOrderInterface orderInterface)
        {
            product_Interface = productInterface;
            order_Interface = orderInterface;
        }



        /// <summary> Creates a new product.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpPost("Create"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OKCreate, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel create_Product_View_Model)
        {
            if (ModelState.IsValid) // Checks if the call contains an invalid model
            {
                int interface_Response = await product_Interface.Create(create_Product_View_Model);
                if (interface_Response == RepositoryConstant.Success_Task)
                { // Returns a ok status code if an product has been deleted
                    return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OKCreate, true));
                }
                else if (interface_Response == RepositoryConstant.Error_Duplicated_SKU) // The value is duplicated
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequestDuplicatedSKU, false));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, ModelState));
        }



        /// <summary> Gets a list of products.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpGet("Read"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OKRead, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Read()
        {
            List<ProductModel> interface_Response = await product_Interface.Read();
            if (interface_Response.Count != 0)
            { // Returns a ok status code if an product has been deleted
                return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OKRead, interface_Response));
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseModel(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, false));
            }
        }



        /// <summary> Updates an existing product model.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpPut("Update"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OKUpdated, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status201Created, ControllerConstant.Status201Created, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Update([FromBody] UpdateProductViewModel update_Product_View_Model)
        {
            if (ModelState.IsValid) // Checks if the call contains an invalid model
            {
                int interface_Response = await product_Interface.Update(update_Product_View_Model);
                if (interface_Response == RepositoryConstant.Success_Task)
                { // Returns a ok status code if an product has been deleted
                    return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OKUpdated, true));
                }
                else if (interface_Response == RepositoryConstant.Warning_Create_Alert)
                {
                    OrderModel order_Model = new OrderModel();
                    order_Model.Order_Status = 0;
                    update_Product_View_Model.Product_Quantity = 25;
                    order_Model.Order_Product_List.Add(update_Product_View_Model);
                    await order_Interface.Create(order_Model);
                    return StatusCode(StatusCodes.Status201Created, new ResponseModel(StatusCodes.Status201Created, ControllerConstant.Status201Created, true));
                }
                else
                { // Returns a not found status code if no product with that id was found
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseModel(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, false));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, ModelState));
        }




        /// <summary> Deletes an existing product model.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpDelete("Delete"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OKDeleted, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Delete([FromBody] DeleteProductViewModel delete_Product_View_Model)
        {
            if (ModelState.IsValid) // Checks if the call contains an invalid model
            {
                int interface_Response = await product_Interface.Delete(delete_Product_View_Model.Product_ID);
                if (interface_Response == RepositoryConstant.Success_Task)
                { // Returns a ok status code if an product has been deleted
                    return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OKDeleted, true));
                }
                else
                { // Returns a not found status code if no product with that id was found
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseModel(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, false));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, ModelState));
        }
    }
}
