﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RibbonSplitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var teste = MainTabControl.ItemTemplate;
            //TabItem item = new TabItem();
            //item.Header = "TesteTabItem";
            //MainTabControl.Items.Add(item);
            //ServiceFacade service = ServiceFacade.Instance;
            //TreeView.ItemTemplate = (DataTemplate)service.Configures;
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
            var fsdfds = Directory.GetDirectories(@"./Configuration");
            //foreach (string path in Directory.GetDirectories(@"C:\Users\user\source\repos\Zylix\AppZylix\Configuration"))
            foreach (string path in Directory.GetDirectories(@"./Configuration"))
            {
                string[] name = path.Split('\\');
                Populate(name[name.Length - 1], path, TreeView, null, false);
            }
        }

        private void TreeView_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }
    }
}
