using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Dtos
{
    public class OrderItemDto
    {
        public Guid MenuItemGuid { get; set; }
        public int Quantity { get; set; }
    }
}
