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
    /// Логика взаимодействия для SuplpliesAdd.xaml
    /// </summary>
    public partial class SuplpliesAdd : Window
    {
        public SuplpliesAdd()
        {
            InitializeComponent();
            AgentIDSup.ItemsSource = db.agents.ToList();
            AgentIDSup.DisplayMemberPath = "Id";
            ClientIDSup.ItemsSource = db.clients.ToList();
            ClientIDSup.DisplayMemberPath = "Id";
        }

        private user32Entities1 db = user32Entities1.GetContext();

        private void Adding(object sender, RoutedEventArgs e)
        {
            supply supl = new supply();

            try
            {
                supl.Price = Convert.ToInt32(PriceSup.Text);
                supl.AgentId = Convert.ToInt32(AgentIDSup.Text);
                supl.ClientId = Convert.ToInt32(ClientIDSup.Text);
                supl.RealEstateId = RealEstateSup.Text;
                db.supplies.Add(supl);
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
