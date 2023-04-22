using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventory.models
{
    public class Item
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Group { get; set; }
        public List<Note>? Notes { get; set; } = new List<Note>();
    }
}
