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
    /// Логика взаимодействия для AgentEdit.xaml
    /// </summary>
    public partial class AgentEdit : Window
    {
        public AgentEdit()
        {
            InitializeComponent();
        }
        public static class AgentData { public static int Id; }

        user32Entities1 db = user32Entities1.GetContext();
        agent agent;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            agent = db.agents.Find(AgentData.Id);
            AgentNameTB.Text = agent.FirstName;
            AgentFamTB.Text = agent.MiddleName;
            AgentOtchTB.Text = agent.LastName;
            AgentPhoneTB.Text = agent.DealShare.ToString();
        }

        private void Canceling(object sender, RoutedEventArgs e)
        {
            try
            {
                agent.FirstName = AgentNameTB.Text;
                agent.MiddleName = AgentFamTB.Text;
                agent.LastName = AgentOtchTB.Text;
                agent.DealShare = Convert.ToByte(AgentPhoneTB.Text);
                db.SaveChanges();
                this.Close();
            }
            catch { MessageBox.Show("Данные ведены неправильно!", "Ошибка!"); }
        }
    }
}
