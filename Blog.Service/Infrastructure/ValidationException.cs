using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Service.Infrastructure
{
    public class ValidationException:Exception
    {
        public string Property { get; set; }
        public ValidationException(string message, string property):base(message)
        {
            Property = property;
        }

    }
}
