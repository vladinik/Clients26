using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для WinSupply.xaml
    /// </summary>
    public partial class WinSupply : Window
    {
        List<Supplies> supplies = new List<Supplies>();

        public WinSupply()
        {
            InitializeComponent();
            FillTable();
        }
        //вывод данных
        public void FillTable()
        {
            //offer.Clear();
            using (ClientsContainer db = new ClientsContainer())
            {
                //foreach (Supplies u in db.Supplies)
                //    supplies.Add(u);
                //DataGridSupply.ItemsSource = db.Supplies.Local.ToBindingList();

                var supply = (from c in db.Supplies
                     select new
                     {
                       Id = c.Id,
                       Price = c.Price,
                       Agent = c.AgentId,
                       Clien = c.ClientId,
                       RealEstate = c.RealEstateId,
                       
                   }).OrderBy(c => c.Id).ToList();
                DataGridSupply.ItemsSource = supply;
            }
        }
        //переход на главное окно
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
        //новая запись
        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            NewSupply newSupply = new NewSupply();
            newSupply.LableTitle.Content = "Добавление предложения";
            newSupply.index = true;
            newSupply.ButtonSave.IsEnabled = false;
            newSupply.Show();
            this.Hide();
        }
        //редактирование предложения
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridSupply.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите предложение для редактирования");
            }
            if (index != null)
            {
                int Id = int.Parse((DataGridSupply.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewSupply newSupply = new NewSupply();
                newSupply.LableTitle.Content = "Редактирование предложения";
                newSupply.index = true;
                newSupply.TextBoxId.IsEnabled = false;
                newSupply.ButtonNewSave.IsEnabled = false;
                

                using (ClientsContainer db = new ClientsContainer())
                {
                    Supplies supplies = db.Supplies.Find(Id);
                    newSupply.TextBoxId.Text = supplies.Id.ToString();
                    newSupply.TextBoxPrice.Text = supplies.Price.ToString();
                    newSupply.TextBoxObject.Text = supplies.RealEstateId.ToString();
                    newSupply.ComboBoxClient.Text = supplies.ClientId.ToString();
                    newSupply.ComboBoxAgent.Text = supplies.AgentId.ToString();
                    newSupply.index = false;
                    newSupply.Show();
                    this.Hide();
                }
            }
        }

        //private void ButtonId_Click(object sender, RoutedEventArgs e)
        //{
        //    using (ClientsContainer db = new ClientsContainer())
        //    {
        //        var VY = db.Supplies.Where(p => p.AgentId == Id);
        //        DataGridSupplyId.ItemsSource = VY.ToList();

        //        var VY = db.Supplies.Where(p => p.ClientId == Id);
        //        DataGridSupplyId.ItemsSource = VY.ToList();
        //    }
        //}
    }
}
