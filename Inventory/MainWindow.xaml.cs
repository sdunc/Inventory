using Inventory.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        private readonly Presenter presenter;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new(this);

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvItems.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Group");
            view.GroupDescriptions.Add(groupDescription);
            lvItems.SelectedItem = lvItems.ItemsSource.Cast<object>().ToList().First();
        }

        public IEnumerable<Item> Items
        {
            get { return (IEnumerable<Item>)lvItems.ItemsSource; }
            set { Dispatcher.Invoke(() => lvItems.ItemsSource = value); }
        }

        public event EventHandler<(Item, string)> NewNoteClicked;

        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            NewNoteClicked?.Invoke(this, ((Item)lvItems.SelectedItem, tbNewNote.Text));
            lvNotes.ItemsSource = new List<Item>();
            lvNotes.ItemsSource = ((Item)lvItems.SelectedItem).Notes;
        }

        private void lvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                tbCost.Text = ((Item)e?.AddedItems[e.AddedItems.Count - 1]).Price.ToString();
                tbName.Text = ((Item)e?.AddedItems[e.AddedItems.Count - 1]).Name;
                tbDesc.Text = ((Item)e?.AddedItems[e.AddedItems.Count - 1]).Description;
                lvNotes.ItemsSource = ((Item)e?.AddedItems[e.AddedItems.Count - 1]).Notes;
            }
        }
    }
}
