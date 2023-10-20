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

namespace Image_Practice.MyPages
{
    /// <summary>
    /// Логика взаимодействия для ViewPage.xaml
    /// </summary>
    
    public partial class ViewPage : Page
    {
        public static List<DB.Image> images {  get; set; } 
        public ViewPage()
        {
            InitializeComponent();
            images = DB.Connection.FotoEntities.Image.ToList();
            ImageList.ItemsSource = images;
        }


        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SortCb.SelectedIndex == 0)
            {
                images = images.OrderBy(x => x.Name).ToList();
                ImageList.ItemsSource = images;
            }
            if (SortCb.SelectedIndex == 1)
            {
                images = images.OrderByDescending(x => x.Date).ToList();
                ImageList.ItemsSource = images;
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

            images = images.Where(x => x.Name.ToLower().StartsWith(SearchTb.Text.ToLower())).ToList();
            if (SearchTb.Text == "")
            {
                images = DB.Connection.FotoEntities.Image.ToList();
                SortCb.SelectedIndex = -1;
            }
            
            ImageList.ItemsSource = images;
        }

        private void GoAddPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyPages.AddPage());
        }
    }
}
