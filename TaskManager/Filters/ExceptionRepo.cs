using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Filters
{
    public class ExceptionRepo : Exception
    {
        public ExceptionRepo(string message) : base(message)
        {

        }
    }
}