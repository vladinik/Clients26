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

namespace Clients26
{
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        public bool index;
        public NewClient()
        {
            InitializeComponent();
        }

        //переход на начальное окно
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //создание нового клиента
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPhone.Text != "" || TextBoxEmail.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {

                    Client client = new Client();
                    Person person = new Person();
                    client.id = int.Parse(TextBoxId.Text);
                    person.id = int.Parse(TextBoxId.Text);
                    person.LastName = TextBoxLastName.Text;
                    person.FirstName = TextBoxFirstName.Text;
                    person.MiddleName = TextBoxMiddleName.Text;
                    client.Phone = TextBoxPhone.Text;
                    client.Email = TextBoxEmail.Text;
                    db.Client.Add(client);
                    db.Person.Add(person);
                    db.SaveChanges();

                }
                MessageBox.Show("Клиент добавлен");

            }
            else MessageBox.Show("Добавьте телефон или Email");

            
        }

        //сохранение изменений данных клиента
        private void ButtonSaveS_Click(object sender, RoutedEventArgs e)
        {
            using (ClientsContainer db = new ClientsContainer())
            {
                Client clients = new Client();
                Person persons = new Person();
                persons.FirstName = TextBoxFirstName.Text;
                persons.LastName = TextBoxLastName.Text;
                persons.MiddleName = TextBoxMiddleName.Text;
                clients.Phone = TextBoxPhone.Text;
                clients.Email = TextBoxEmail.Text;
                db.SaveChanges();
                
            }MessageBox.Show("Клиент отредактирован");
        }
    }
}
