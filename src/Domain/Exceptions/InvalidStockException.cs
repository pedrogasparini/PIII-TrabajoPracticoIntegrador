using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidStockException : Exception
    {
        public InvalidStockException(string message) : base(message)
        {
        }
    }
}
