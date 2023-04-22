using Inventory.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IMainWindow
    {
        IEnumerable<Item> Items { get; set; }
        event EventHandler<(Item, string)> NewNoteClicked;
    }
}
