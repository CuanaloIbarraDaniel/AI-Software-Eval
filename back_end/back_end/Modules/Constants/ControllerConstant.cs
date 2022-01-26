using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Modules.Constants
{
    public class ControllerConstant
    {
        public const string Status200OK = "A new object has been successfully created by the server on the database.";

        public const string Status400BadRequest = "The data sent to this method does not satisfy the required validations.";

        public const string Status401Unauthorized = "You do not count with the necessary permissions to access this resource.";

        public const string Status403Forbidden = "Access to this method was blocked by the server.";

        public const string Status404NotFound = "The request to the database has returned no data.";

        public const string Status500InternalServerError = "Serveral internal errors were encountered while completing the tasks";
    }
}
