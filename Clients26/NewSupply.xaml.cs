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
    /// Логика взаимодействия для NewSupply.xaml
    /// </summary>
    public partial class NewSupply : Window
    {
        public bool index;
        public NewSupply()
        {
            InitializeComponent();
        }

        private void TextBoxId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // ограничение на ввод букв
            {
                if (char.IsDigit(e.Text, 0))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // ограничение на ввод букв
            {
                if (char.IsDigit(e.Text, 0))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        //назад на окно предложения
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            WinSupply winSupply = new WinSupply();
            winSupply.Show();
            this.Hide();
        }
        //сохранение нового предложения
        private void ButtonNewApartments_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text != "" && TextBoxObject.Text != "" && TextBoxPrice.Text != "" && TextBoxId.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Supplies supplies = new Supplies();

                    supplies.Id = int.Parse(TextBoxId.Text);
                    supplies.Price = int.Parse(TextBoxPrice.Text);
                    supplies.ClientId = int.Parse(ComboBoxClient.Text);
                    supplies.AgentId = int.Parse(ComboBoxAgent.Text);
                    supplies.RealEstateId = int.Parse(TextBoxObject.Text);

                    db.Supplies.Add(supplies);
                    db.SaveChanges();
                   
                }
                MessageBox.Show("Предложение добавлено");
            }
            else MessageBox.Show("Вы не заполнили обязательные поля");
        }

        //сохранение отредактированной информациии
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text != "" && TextBoxObject.Text != "" && TextBoxPrice.Text != "" && TextBoxId.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Supplies supplies = db.Supplies.Find(int.Parse(TextBoxId.Text));

                    supplies.Id = int.Parse(TextBoxId.Text);
                    supplies.ClientId = int.Parse(ComboBoxClient.Text);
                    supplies.AgentId = int.Parse(ComboBoxAgent.Text);
                    supplies.RealEstateId = int.Parse(TextBoxObject.Text);
                    supplies.Price = int.Parse(TextBoxPrice.Text);

                    db.SaveChanges();
                }
                MessageBox.Show("Предложение отредактировано");
            }
            else MessageBox.Show("Вы не заполнили обязательные поля");
        }

        private void TextBoxObject_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // ограничение на ввод букв
            {
                if (char.IsDigit(e.Text, 0))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
