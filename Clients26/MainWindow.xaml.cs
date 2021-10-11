using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clients26
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillTable();
        }

        //вывод данных
        public void FillTable()
        {
            
            using (ClientsContainer db = new ClientsContainer())
            {
                var result = (from p in db.Client
                              join c in db.Person
                              on p.id equals c.id

                              select new { 
                                  id = p.id, 
                                  FirstName = c.FirstName, 
                                  MiddleName = c.MiddleName, 
                                  LastName = c.LastName, 
                                  Phone = p.Phone, 
                                  Email = p.Email }).ToList();
                    
                DataGriClients.ItemsSource = result;

                var resultAgents = (from pe in db.Person
                                    join ag in db.Agents
                                    on pe.id equals ag.id
                                    select new
                                    {
                                        id = ag.id,
                                        FirstName = pe.FirstName,
                                        MiddleName = pe.MiddleName,
                                        LastName = pe.LastName,
                                        DealShare = ag.DealShare
                                    }).ToList();

                DataGridAgents.ItemsSource = resultAgents;
            }
        }

        //создание клиента
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NewClient newClient = new NewClient();
            newClient.LableTitle.Content = "Создание клиента";
            newClient.ButtonSaveS.IsEnabled = false;
            newClient.index = true;
            newClient.Show();
            this.Hide();
        }

        //выбор клиента для изменения
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGriClients.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите клиента");
            }
            if (index != null)
            {
                int id = int.Parse((DataGriClients.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewClient newClient = new NewClient();
                newClient.LableTitle.Content = "Редактирование клиента";
                newClient.ButtonSave.IsEnabled = false;
                newClient.TextBoxId.IsEnabled = false;
                newClient.LableTitle.IsEnabled = false;
                using (ClientsContainer db = new ClientsContainer())
                {
                    Client client = db.Client.Find(id);
                    Person person = db.Person.Find(id);
                    newClient.TextBoxId.Text = client.id.ToString();
                    newClient.TextBoxLastName.Text = person.LastName;
                    newClient.TextBoxFirstName.Text = person.FirstName;
                    newClient.TextBoxMiddleName.Text = person.MiddleName;
                    newClient.TextBoxPhone.Text = client.Phone;
                    newClient.TextBoxEmail.Text = client.Email;
                    newClient.index = false;

                    newClient.Show();
                    this.Hide();
                }
            }
        }

        //удаление клиента
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGriClients.Items.Count > 0)
            {
                var index = DataGriClients.SelectedItem;
                if (index != null) ;
                int id = int.Parse((DataGriClients.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                using (ClientsContainer db = new ClientsContainer())
                {
                    Client client = db.Client.Find(id);
                    Person person = db.Person.Find(id);
                    db.Person.Remove(person);
                    db.Client.Remove(client);
                    db.SaveChanges();
                    FillTable();
                    MessageBox.Show("клиент удален");
                }
            }
        }

        //добавление агента
        private void ButtonAddAgents_Click(object sender, RoutedEventArgs e)
        {
            NewAgents1 newAgents1 = new NewAgents1();
            newAgents1.LableTitle.Content = "Создание агента";
            newAgents1.ButtonSaveS.IsEnabled = false;
            newAgents1.index = true;
            newAgents1.Show();
            this.Hide();
        }

        //редактирование агента
        private void ButtonEditAgents_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridAgents.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите агента");
            }
            if (index != null)
            {
                int id = int.Parse((DataGridAgents.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewAgents1 newAgents1 = new NewAgents1();
                newAgents1.LableTitle.Content = "Редактирование агента";
                newAgents1.ButtonSave.IsEnabled = false;
                newAgents1.TextBoxId.IsEnabled = false;
                newAgents1.LableTitle.IsEnabled = false;
                using (ClientsContainer db = new ClientsContainer())
                {
                    Agents agents = db.Agents.Find(id);
                    Person person = db.Person.Find(id);
                    newAgents1.TextBoxId.Text = agents.id.ToString();
                    newAgents1.TextBoxLastName.Text = person.LastName;
                    newAgents1.TextBoxFirstName.Text = person.FirstName;
                    newAgents1.TextBoxMiddleName.Text = person.MiddleName;
                    newAgents1.TextBoxDealShare.Text = (agents.DealShare*100).ToString();
                    newAgents1.index = false;
                    newAgents1.Show();
                    this.Hide();
                }
            }
        }

        //удаление агента
        private void ButtonDeleteAgents_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAgents.Items.Count > 0)
            {
                var index = DataGridAgents.SelectedItem;
                if (index != null) ;
                int id = int.Parse((DataGridAgents.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                using (ClientsContainer db = new ClientsContainer())
                {
                    Agents agents = db.Agents.Find(id);
                    Person person = db.Person.Find(id);
                    db.Person.Remove(person);
                    db.Agents.Remove(agents);
                    db.SaveChanges();
                    FillTable();
                    MessageBox.Show("агент удален");
                }
            }
        }

        //object
        private void ButtonObject_Click(object sender, RoutedEventArgs e)
        {
            WinObject winObject = new WinObject();
            winObject.LableTitle.Content = "Недвижимость";
            winObject.Show();
            this.Hide();
        }

        private void ButtonOffer_Click(object sender, RoutedEventArgs e)
        {
            WinOffer winOffer = new WinOffer();
            winOffer.Show();
            this.Hide();
        }

        private void ButtonSupply_Click(object sender, RoutedEventArgs e)
        {
            WinSupply winSupply = new WinSupply();
            winSupply.Show();
            this.Hide();
        }
    }
}
