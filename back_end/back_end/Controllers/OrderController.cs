using back_end.Models;
using back_end.Modules.Constants;
using back_end.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using static back_end.ViewModels.OrderViewModel;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderInterface order_Interface;


        public OrderController(IOrderInterface orderInterface)
        {
            order_Interface = orderInterface;
        }



        /// <summary> Creates a new order.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpPost("Create"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OK, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Create([FromBody] CreateOrderViewModel create_Order_View_Model)
        {
            if (ModelState.IsValid) // Checks if the call contains an invalid model
            {
                int interface_Response = await order_Interface.Create(create_Order_View_Model);
                if (interface_Response == RepositoryConstant.Success_Task)
                { // Returns a ok status code if an order has been deleted
                    return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OK, true));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, ModelState));
        }



        /// <summary> Gets a list of orders.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpGet("Read"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OK, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Read()
        {
            List<OrderModel> interface_Response = await order_Interface.Read();
            if (interface_Response[0].Order_ID == 0)
            { // Returns a ok status code if an order has been deleted
                return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OK, true));
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseModel(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound));
            }
        }



        /// <summary> Updates an existing order model.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpPut("Update"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OK, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Update([FromBody] UpdateOrderViewModel update_Order_View_Model)
        {
            if (ModelState.IsValid) // Checks if the call contains an invalid model
            {
                int interface_Response = await order_Interface.Update(update_Order_View_Model);
                if (interface_Response == RepositoryConstant.Success_Task)
                { // Returns a ok status code if an order has been deleted
                    return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OK, true));
                }
                else
                { // Returns a not found status code if no order with that id was found
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseModel(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, false));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, ModelState));
        }




        /// <summary> Deletes an existing order model.</summary>
        /// <remarks> 
        /// 1) Logging: No. No logger has been configured for this method.<br/>
        /// 2) Cache: No. Calls to this method will not be cached.<br/>
        /// 3) Compression: No. No compression method is used for the response.<br/>
        /// </remarks>
        [HttpDelete("Delete"), ApiExplorerSettings(GroupName = "v1")]
        [Consumes("application/json"), Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, ControllerConstant.Status200OK, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, typeof(ResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, ControllerConstant.Status500InternalServerError, typeof(ResponseModel))]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderViewModel delete_Order_View_Model)
        {
            if (ModelState.IsValid) // Checks if the call contains an invalid model
            {
                int interface_Response = await order_Interface.Delete(delete_Order_View_Model.Order_ID);
                if (interface_Response == RepositoryConstant.Success_Task)
                { // Returns a ok status code if an order has been deleted
                    return StatusCode(StatusCodes.Status200OK, new ResponseModel(StatusCodes.Status200OK, ControllerConstant.Status200OK, true));
                }
                else
                { // Returns a not found status code if no order with that id was found
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseModel(StatusCodes.Status404NotFound, ControllerConstant.Status404NotFound, false));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel(StatusCodes.Status400BadRequest, ControllerConstant.Status400BadRequest, ModelState));
        }
    }
}
