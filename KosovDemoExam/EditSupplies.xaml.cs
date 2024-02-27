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
using static KosovDemoExam.EditClient;

namespace KosovDemoExam
{
    /// <summary>
    /// Логика взаимодействия для EditSupplies.xaml
    /// </summary>
    public partial class EditSupplies : Window
    {
        public EditSupplies()
        {
            InitializeComponent();
            AgentIDSup.ItemsSource = db.agents.ToList();
            AgentIDSup.DisplayMemberPath = "Id";
            ClientIDSup.ItemsSource = db.clients.ToList();
            ClientIDSup.DisplayMemberPath = "Id";
        }

        public static class SupplyId { public static int Id; }

        private user32Entities1 db = user32Entities1.GetContext();
        supply supl = new supply();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            supl = db.supplies.Find(SupplyId.Id);
            PriceSup.Text = supl.Price.ToString();
            AgentIDSup.Text = supl.AgentId.ToString();
            ClientIDSup.Text = supl.ClientId.ToString();
            RealEstateSup.Text = supl.RealEstateId.ToString();
        }

        private void Canceling(object sender, RoutedEventArgs e)
        {
            supl.Price = Convert.ToInt32(PriceSup.Text);
            supl.AgentId = Convert.ToInt32(AgentIDSup.Text);
            supl.ClientId = Convert.ToInt32(ClientIDSup.Text);
            supl.RealEstateId = (RealEstateSup.Text);
            db.SaveChanges();
            this.Close();
        }
    }
}