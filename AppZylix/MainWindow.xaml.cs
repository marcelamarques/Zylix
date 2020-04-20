using System;
using System.Collections.Generic;
using System.IO;
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

namespace AppZylix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Configure> TabItems;
        public MainWindow()
        {
            InitializeComponent();
            TabItems = new List<Configure>();
        }

        private void RibbonSplitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TabItems.Add(new Configure { Title = "Test_1", Name = "Config" });
            TabZylix.ItemsSource = TabItems;
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Populate(string header, string tag, TreeView _root, TreeViewItem _child, bool isfile)
        {
            TreeViewItem _driitem = new TreeViewItem();
            _driitem.Tag = tag;
            _driitem.Header = header;
            _driitem.Expanded += new RoutedEventHandler(Expanded_Item);
            if (!isfile)
            {
                _driitem.Items.Add(new TreeViewItem());
            }
                

            if (_root != null)
            {
                _root.Items.Add(_driitem);
            }
            else
            {
                _driitem.MouseLeftButtonUp += _driitem_MouseDown;
                _child.Items.Add(_driitem);
            }
        }

        private void _driitem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is TreeViewItem && ((TreeViewItem)e.Source).IsSelected)
            {

            }
        }

        private void Expanded_Item(object sender, RoutedEventArgs e)
        {
            TreeViewItem _item = (TreeViewItem)sender;
            if (_item.Items.Count == 1 && ((TreeViewItem)_item.Items[0]).Header == null)
            {
                _item.Items.Clear();

                foreach (string dir in Directory.GetFiles(_item.Tag.ToString()))
                {
                    FileInfo _dirinfo = new FileInfo(dir);
                    Populate(_dirinfo.Name, _dirinfo.FullName, null, _item, true);
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TabItem item = new TabItem();
            //item.Header = "TesteTabIem";
            //item.Name = "tabOne";
            //item.HeaderTemplate = TabZylix.FindResource("HeaderTab") as DataTemplate;

            //////var fsdfds = Directory.GetDirectories(@"./Configuration");
            //TreeView treeView = new TreeView();
            //treeView.Name = "TesteA";

            //foreach (string path in Directory.GetDirectories(@"C:\Users\user\source\repos\Zylix\AppZylix\Configuration"))
            ////foreach (string path in Directory.GetDirectories(@"./Configuration"))
            //{
            //    string[] name = path.Split('\\');
            //    //Populate(name[name.Length - 1], path, TreeView, null, false);
            //    Populate(name[name.Length - 1], path, treeView, null, false);
            //}
            //item.DataContext = treeView;

            
        }

    }
}
