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
    /// Логика взаимодействия для AgentAdd.xaml
    /// </summary>
    public partial class AgentAdd : Window
    {
        public AgentAdd()
        {
            InitializeComponent();
        }

        private user32Entities1 db = user32Entities1.GetContext();


        private void Adding(object sender, RoutedEventArgs e)
        {
            agent agent = new agent();

            try
            {
                agent.FirstName = ClientNameTB.Text;
                agent.MiddleName = ClientFamTB.Text;
                agent.LastName = ClientOtchTB.Text;
                agent.DealShare = Convert.ToByte(ClientPhoneTB.Text);

                db.agents.Add(agent);
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