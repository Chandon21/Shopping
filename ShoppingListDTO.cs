using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShoppingListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } 
        public List<ShopDTO> Items { get; set; }
    }
}
