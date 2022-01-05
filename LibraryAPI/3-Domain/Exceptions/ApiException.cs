using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Exceptions
{
    public class ApiException : Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }

        public string ErrorMessage { get; set; }


        public ApiException(string message) : base(message)
        {
        }

    }

}
