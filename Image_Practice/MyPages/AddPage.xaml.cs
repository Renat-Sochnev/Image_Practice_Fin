using Image_Practice.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace Image_Practice.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public static DB.Image image = new DB.Image();
        public AddPage()
        {
            InitializeComponent();
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg|*.JPG|*.JPG"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                image.ImageBin = File.ReadAllBytes(openFileDialog.FileName);
                NewImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (NewImage.Source == null)
                {
                    error.AppendLine("Загрузите изображение");
                }
                if (string.IsNullOrWhiteSpace(NameTb.Text))
                {
                    error.AppendLine("Напишите название");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    image.Name = NameTb.Text;
                    image.Date = DateTime.Now;
                    Connection.FotoEntities.Image.Add(image);
                    Connection.FotoEntities.SaveChanges();

                    MessageBox.Show("Ваше изображение добавлено");
                    NewImage.Source = null;
                    NameTb.Text = null;
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }

        private void GoViewPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyPages.ViewPage());
        }
    }
}
