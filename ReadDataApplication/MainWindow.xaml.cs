using ReadDataApplication.ComponentManager;
using ReadDataApplication.Proxies;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Diagnostics;

namespace ReadDataApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Proxies.ComponentManagerClient componentManager;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ReadData_Click(object sender, RoutedEventArgs e)
        {
            this.componentManager = new Proxies.ComponentManagerClient();

            try
            {
                Debug.WriteLine("Data requested.");
                //this.componentManager.Open();
                var list = await this.componentManager.ReadData_Async();

                ShowData.ItemsSource = from p in list
                                           where p.Age >= 16
                                           orderby p.LastName
                                           select p;
               

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //this.componentManager.Close();
                
            }

        }
    }
}
