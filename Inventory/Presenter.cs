using Inventory.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Presenter
    {
        private readonly IMainWindow mainWindow;

        private List<Item> Items = new List<Item>();

        public Presenter(IMainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            Items.Add(new Item() { Name = "Toyota Corolla", Description = "2002 beige.", Group = "Cars", Price = 2000 });
            Items.Add(new Item() { Name = "Honda Civic", Description = "idk year silver.", Group = "Cars", Price = 2000 });
            Items.Add(new Item() { Name = "Beard on Bread", Description = "make bread", Group = "Books", Price = 0});
            Items.Add(new Item() { Name = "Basic Bicycle Repair", Description = "repair bike", Group = "Books", Price = 0});
            mainWindow.Items = Items;
            mainWindow.NewNoteClicked += MainWindow_NewNoteClicked;
        }

        private void MainWindow_NewNoteClicked(object? sender, (Item, string) e)
        {
            if (e.Item1 is null) return;
            e.Item1.Notes?.Add(new Note() { Date = DateTime.Now, Description = e.Item2 });
        }
    }
}
