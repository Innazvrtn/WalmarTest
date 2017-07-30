using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmar.BLL.DTO
{
    public class GoodDTO
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
