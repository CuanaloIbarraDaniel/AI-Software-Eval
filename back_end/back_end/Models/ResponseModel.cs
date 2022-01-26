using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class ResponseModel
    {
        /// <summary> 	
        /// Response model contructor with no custom variables.	
        /// </summary>	
        public ResponseModel()
        {
            Code = 0;
            Description = null;
            Model = null;
        }



        /// <summary> 	
        /// Response model contructor with almost everything as a custom variable except the model.	
        /// </summary>	
        public ResponseModel(int code, string description)
        {
            Code = code;
            Description = description;
            Model = null;
        }



        /// <summary> 	
        /// Response model contructor with everything as a custom variables.	
        /// </summary>	
        public ResponseModel(int code, string description, object model)
        {
            Code = code;
            Description = description;
            Model = model;
        }



        [SwaggerSchema("Code")]
        public int Code { get; set; }

        [SwaggerSchema("Description")]
        public string Description { get; set; }

        [SwaggerSchema("Model")]
        public object Model { get; set; }
    }
}
