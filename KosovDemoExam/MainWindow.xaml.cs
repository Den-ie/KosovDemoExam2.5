using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Shell;
using static KosovDemoExam.AgentEdit;
using static KosovDemoExam.EditClient;
using static KosovDemoExam.EditSupplies;

namespace KosovDemoExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public user32Entities1 entities = user32Entities1.GetContext();

        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;

            entities.clients.Load();
            ClientsTable.ItemsSource = entities.clients.Local.ToBindingList();

            entities.agents.Load();
            AgentsTable.ItemsSource = entities.agents.Local.ToBindingList();

            entities.ddds.Load();
            Houses.ItemsSource = entities.ddds.Local.ToBindingList();

            entities.supplies.Load();
            SuppliesTable.ItemsSource = entities.supplies.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddClient add = new AddClient();
            add.Owner = this;
            add.ShowDialog();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = ClientsTable.SelectedIndex;
            if (indexRow != -1)
            {
                client row = (client)ClientsTable.Items[indexRow];
                Data.Id = row.Id;
                EditClient edit = new EditClient();
                edit.ShowDialog();
                ClientsTable.Items.Refresh();
                ClientsTable.Focus();
            }
        }

        private void AgentEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = AgentsTable.SelectedIndex;
            if (indexRow != -1)
            {
                agent row = (agent)AgentsTable.Items[indexRow];
                AgentData.Id = row.Id;
                AgentEdit Aedit = new AgentEdit();
                Aedit.ShowDialog();
                AgentsTable.Items.Refresh();
                AgentsTable.Focus();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client row = (client)ClientsTable.SelectedItems[0];
                entities.clients.Remove(row);
                entities.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Укажите существующее поле для удаления", "Ошибка!");
            }
        }

        private void AgentDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                agent row = (agent)AgentsTable.SelectedItems[0];
                entities.agents.Remove(row);
                entities.SaveChanges();
            }
            catch
            { 
                MessageBox.Show("Укажите существующее поле для удаления", "Ошибка!");
            }
        }

        private void AgentAdd_Click(object sender, RoutedEventArgs e)
        {
            AgentAdd add = new AgentAdd();
            add.Owner = this;
            add.ShowDialog();
        }

        List<client> _client;
        private void ClientsSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _client = entities.clients.ToList();

            var filtered = _client.Where(_client => _client.FirstName.ToLower().Contains(ClientsSearch.Text) ||
            _client.MiddleName.ToLower().Contains(ClientsSearch.Text) ||
            _client.LastName.ToString().ToLower().Contains(ClientsSearch.Text)).ToList();

            ClientsTable.ItemsSource = filtered;
        }

        List<agent> _agent;
        private void AgentsSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _agent = entities.agents.ToList();

            var Afiltered = _agent.Where(_agent => _agent.FirstName.ToLower().Contains(AgentsSearch.Text) ||
            _agent.MiddleName.ToLower().Contains(AgentsSearch.Text) ||
            _agent.LastName.ToLower().Contains(AgentsSearch.Text) ||
            _agent.DealShare.ToString().Contains(AgentsSearch.Text)).ToList();

            AgentsTable.ItemsSource = Afiltered;
        }

        private void SuppliesAdd_Click(object sender, RoutedEventArgs e)
        {
            SuplpliesAdd add = new SuplpliesAdd();
            add.Owner = this;
            add.ShowDialog();
        }

        private void SuppliesEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = SuppliesTable.SelectedIndex;
            if (indexRow != -1)
            {
                supply row = (supply)SuppliesTable.Items[indexRow];
                SupplyId.Id = row.Id;
                EditSupplies Aedit = new EditSupplies();
                Aedit.ShowDialog();
                SuppliesTable.Items.Refresh();
                SuppliesTable.Focus();
            }
        }

        private void SuppliesDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                supply sup = (supply)SuppliesTable.SelectedItems[0];
                entities.supplies.Remove(sup);
                entities.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Укажите существующее поле для удаления", "Ошибка!");
            }
        }
    }
}
