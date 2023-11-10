using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUser.Exceptions
{
    internal class UserUsernameInvalid : System.Exception
    {
        public UserUsernameInvalid()
        {
        }

        public UserUsernameInvalid(string? message) : base(message)
        {
        }
    }
}
