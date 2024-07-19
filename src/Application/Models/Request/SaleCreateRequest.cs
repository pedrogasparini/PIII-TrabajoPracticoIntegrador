using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class SaleCreateRequest
    {
        public DateTime Date { get; set; }

        public ICollection<int> SaleDetailIds { get; set; }

        public decimal Total { get; set; }
    }
}
