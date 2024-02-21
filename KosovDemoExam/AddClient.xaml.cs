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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
            this.Height += 25;
        }

        private user32Entities1 db = user32Entities1.GetContext();


        private void Adding(object sender, RoutedEventArgs e)
        {
            client client = new client();

            try
            {
                client.FirstName = ClientNameTB.Text;
                client.MiddleName = ClientFamTB.Text;
                client.LastName = ClientOtchTB.Text;
                client.Phone = ClientPhoneTB.Text;
                client.Email = ClientMailTB.Text;

                db.clients.Add(client);
                db.SaveChanges();
                MessageBox.Show("Че то добавилось!", "Крута!");
            }
            catch { MessageBox.Show("Че то не так!", "Ошибка!"); }
        }

        private void Canceling(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
