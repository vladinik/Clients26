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
    /// Логика взаимодействия для NewAgents1.xaml
    /// </summary>
    public partial class NewAgents1 : Window
    {
        public bool index;
        public NewAgents1()
        {
            InitializeComponent();
        }

        //сохранение измененной информации об агенте
        private void ButtonSaveS_Click(object sender, RoutedEventArgs e)
        {
           
                if (TextBoxFirstName.Text != "" && TextBoxMiddleName.Text != "" && TextBoxLastName.Text != "")
                {
                    using (ClientsContainer db = new ClientsContainer())
                    {
                        Agents agents = db.Agents.Find(int.Parse(TextBoxId.Text));
                        Person persons = db.Person.Find(int.Parse(TextBoxId.Text));
                        agents.id = int.Parse(TextBoxId.Text);
                        persons.id = int.Parse(TextBoxId.Text);
                        persons.FirstName = TextBoxFirstName.Text;
                        persons.LastName = TextBoxLastName.Text;
                        persons.MiddleName = TextBoxMiddleName.Text;
                        agents.DealShare = decimal.Parse(TextBoxDealShare.Text);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Клиент отредактирован");
                }
                else MessageBox.Show("Добавьте обязательные поля(Фамилия, Имя, Отчество)");
           
        }

        //создание нового агента
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            int num1 = int.Parse(TextBoxDealShare.Text);
            if (num1 > 100)
            {
                MessageBox.Show("Число больше возможного % доли от продажи");
            }
            else
            {
                if (TextBoxFirstName.Text != "" && TextBoxMiddleName.Text != "" && TextBoxLastName.Text != "")
                {
                    using (ClientsContainer db = new ClientsContainer())
                    {
                        Agents agents = new Agents();
                        Person person = new Person();
                        agents.id = int.Parse(TextBoxId.Text);
                        person.id = int.Parse(TextBoxId.Text);
                        person.LastName = TextBoxLastName.Text;
                        person.FirstName = TextBoxFirstName.Text;
                        person.MiddleName = TextBoxMiddleName.Text;
                        agents.DealShare = decimal.Parse(TextBoxDealShare.Text) / 100;
                        db.Agents.Add(agents);
                        db.Person.Add(person);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Агент добавлен");
                }
                else MessageBox.Show("Добавьте обязательные поля(Фамилия, Имя, Отчество)");
            }
        }

        //переход на начальное окно
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
