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
using System.Windows.Shapes;

namespace KosovDemoExam
{
    /// <summary>
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    /// 

    public partial class EditClient : Window
    {
        public EditClient()
        {
            InitializeComponent();
        }

        public static class Data { public static int Id; }

        user32Entities1 db = user32Entities1.GetContext();
        client client;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = db.clients.Find(Data.Id);
            ClientNameTB.Text = client.FirstName;
            ClientFamTB.Text = client.MiddleName;
            ClientOtchTB.Text = client.LastName;
            ClientPhoneTB.Text = client.Phone;
            ClientMailTB.Text = client.Email;
        }

        private void Canceling(object sender, RoutedEventArgs e)
        {
            client.FirstName = ClientNameTB.Text;
            client.MiddleName = ClientFamTB.Text;
            client.LastName = ClientOtchTB.Text;
            client.Phone = ClientPhoneTB.Text;
            client.Email = ClientMailTB.Text;

            db.SaveChanges();
            this.Close();
        }
    }
}
