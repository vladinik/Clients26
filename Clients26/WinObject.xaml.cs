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
    /// Логика взаимодействия для WinObject.xaml
    /// </summary>
    public partial class WinObject : Window
    {
       
        List<RealEstateObjects> realEstateObjects = new List<RealEstateObjects>();
        public WinObject()
        {
            InitializeComponent();
            FillTable();
        }
        //string filter;
        //назад
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //добавление квартиры
        private void ButtonNewApartments_Click(object sender, RoutedEventArgs e)
        {
            NewObject newObject = new NewObject();
            newObject.LableTitle.Content = "Добавление квартиры";
            newObject.index = true;
            newObject.ButtonNewHouses.IsEnabled = false;
            newObject.ButtonNewLands.IsEnabled = false;
            newObject.ButtonSApartments.IsEnabled = false;
            newObject.ButtonSHouses.IsEnabled = false;
            newObject.ButtonSLands.IsEnabled = false;
            newObject.TextBoxTotalFloors.IsEnabled = false;
            newObject.Show();
            this.Hide();
        }
        //добавление дома
        private void ButtonNewHouses_Click(object sender, RoutedEventArgs e)
        {
            NewObject newObject = new NewObject();
            newObject.LableTitle.Content = "Добавление дома";
            newObject.index = true;
            newObject.ButtonNewApartments.IsEnabled = false;
            newObject.ButtonNewLands.IsEnabled = false;
            newObject.ButtonSApartments.IsEnabled = false;
            newObject.ButtonSHouses.IsEnabled = false;
            newObject.ButtonSLands.IsEnabled = false;
            newObject.TextBoxFloors.IsEnabled = false;
            newObject.Show();
            this.Hide();
        }
        //добавление земельного участка
        private void ButtonNewLands_Click(object sender, RoutedEventArgs e)
        {
            NewObject newObject = new NewObject();
            newObject.LableTitle.Content = "Добавление земельного участка";
            newObject.index = true;
            newObject.ButtonNewApartments.IsEnabled = false;
            newObject.ButtonNewHouses.IsEnabled = false;
            newObject.ButtonSApartments.IsEnabled = false;
            newObject.ButtonSHouses.IsEnabled = false;
            newObject.ButtonSLands.IsEnabled = false;
            newObject.TextBoxFloors.IsEnabled = false;
            newObject.TextBoxTotalFloors.IsEnabled = false;
            newObject.TextBoxRooms.IsEnabled = false;
            newObject.Show();
            this.Hide();
        }
        //фильтр
        private void ComboBoxFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch (ComboBoxFiltr.SelectedIndex)
            //{
            //    case 0: filter = null; break;
            //    case 1: filter = "квартира"; break;
            //    case 2: filter = "дом"; break;
            //    case 3: filter = "земельный участок"; break;
            //}
            //FillTable(filter);
        }

        //вывод данных
        public void FillTable()
        {
            //realEstateObjects.Clear();
            using (ClientsContainer db = new ClientsContainer())
            {
                foreach (RealEstateObjects u in db.RealEstateObjects)
                    realEstateObjects.Add(u);
                DataGridObject.ItemsSource = db.RealEstateObjects.Local.ToBindingList();

            }

        }
        //"Редактирование квартиры"
        private void ButtonApartments_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridObject.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите квартиру для редактирования");
            }
            if (index != null)
            {
                int Id = int.Parse((DataGridObject.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewObject newObject = new NewObject();
                newObject.LableTitle.Content = "Редактирование квартиры";
                newObject.index = true;
                newObject.TextBoxId.IsEnabled = false;
                newObject.ButtonNewHouses.IsEnabled = false;
                newObject.ButtonNewLands.IsEnabled = false;
                newObject.ButtonNewApartments.IsEnabled = false;
                newObject.ButtonSHouses.IsEnabled = false;
                newObject.ButtonSLands.IsEnabled = false;

                newObject.TextBoxTotalFloors.IsEnabled = false;

                using (ClientsContainer db = new ClientsContainer())
                {
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(Id);
                    Apartments apartments = db.Apartments.Find(Id);
                    newObject.TextBoxId.Text = apartments.Id.ToString();
                    newObject.TextBoxCity.Text = realEstateObjects.AddressCity;
                    newObject.TextBoxStreet.Text = realEstateObjects.AddressStreet;
                    newObject.TextBoxHouses.Text = realEstateObjects.AddressHouse;
                    newObject.TextBoxNumber.Text = realEstateObjects.AddressNumber;
                    newObject.TextBoxCoordinateLatitude.Text = realEstateObjects.CoordinateLatitude.ToString(); 
                    newObject.TextBoxCoordinateLongitude.Text = realEstateObjects.CoordinateLongitude.ToString();

                    newObject.TextBoxFloors.Text = apartments.Floor.ToString();
                    newObject.TextBoxRooms.Text = apartments.Rooms.ToString();
                    newObject.TextBoxTotalArea.Text = apartments.TotalArea.ToString();

                    newObject.index = false;

                    newObject.Show();
                    this.Hide();
                }
            }
        }
            //"Редактирование дома"
            private void ButtonHouses_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridObject.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите дом для редактирования");
            }
            if (index != null)
            {
                int Id = int.Parse((DataGridObject.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);

                NewObject newObject = new NewObject();
                newObject.LableTitle.Content = "Редактирование дома";
                newObject.index = true;
                newObject.TextBoxId.IsEnabled = false;
                newObject.ButtonNewHouses.IsEnabled = false;
                newObject.ButtonNewLands.IsEnabled = false;
                newObject.ButtonNewApartments.IsEnabled = false;
                newObject.ButtonSApartments.IsEnabled = false;

                newObject.TextBoxTotalFloors.IsEnabled = false;

                newObject.ButtonSLands.IsEnabled = false;
                using (ClientsContainer db = new ClientsContainer())
                {
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(Id);
                    Houses houses = db.Houses.Find(Id);
                    newObject.TextBoxId.Text = houses.Id.ToString();
                    newObject.TextBoxCity.Text = realEstateObjects.AddressCity;
                    newObject.TextBoxStreet.Text = realEstateObjects.AddressStreet;
                    newObject.TextBoxHouses.Text = realEstateObjects.AddressHouse;
                    newObject.TextBoxNumber.Text = realEstateObjects.AddressNumber;
                    newObject.TextBoxCoordinateLatitude.Text = realEstateObjects.CoordinateLatitude.ToString();
                    newObject.TextBoxCoordinateLongitude.Text = realEstateObjects.CoordinateLongitude.ToString();

                    newObject.TextBoxTotalFloors.Text = houses.TotalFloors.ToString();
                    newObject.TextBoxRooms.Text = houses.Rooms.ToString();
                    newObject.TextBoxTotalArea.Text = houses.TotalArea.ToString();
                    newObject.index = false;

                    newObject.Show();
                    this.Hide();
                }
            }
        }
        //"Редактирование земельного участка"
        private void ButtonLands_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridObject.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите  земельный участка для редактирования");
            }
            if (index != null)
            {
                int Id = int.Parse((DataGridObject.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewObject newObject = new NewObject();
                newObject.LableTitle.Content = "Редактирование земельного участка";
                newObject.index = true;
                newObject.TextBoxId.IsEnabled = false;
                newObject.ButtonNewHouses.IsEnabled = false;
                newObject.ButtonNewLands.IsEnabled = false;
                newObject.ButtonNewApartments.IsEnabled = false;
                newObject.ButtonSApartments.IsEnabled = false;
                newObject.ButtonSHouses.IsEnabled = false;

                newObject.TextBoxFloors.IsEnabled = false;
                newObject.TextBoxTotalFloors.IsEnabled = false;
                newObject.TextBoxRooms.IsEnabled = false;


                using (ClientsContainer db = new ClientsContainer())
                {
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(Id);
                    Lands lands = db.Lands.Find(Id);
                    newObject.TextBoxId.Text = lands.Id.ToString();
                    newObject.TextBoxCity.Text = realEstateObjects.AddressCity;
                    newObject.TextBoxStreet.Text = realEstateObjects.AddressStreet;
                    newObject.TextBoxHouses.Text = realEstateObjects.AddressHouse;
                    newObject.TextBoxNumber.Text = realEstateObjects.AddressNumber;
                    newObject.TextBoxCoordinateLatitude.Text = realEstateObjects.CoordinateLatitude.ToString();
                    newObject.TextBoxCoordinateLongitude.Text = realEstateObjects.CoordinateLongitude.ToString();

                    newObject.TextBoxTotalArea.Text = lands.TotalArea.ToString();
                    newObject.index = false;

                    newObject.Show();
                    this.Hide();
                }
            }
        }
        //удаление записи
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridObject.Items.Count > 0)
            {
                var index = DataGridObject.SelectedItem;
                if (index != null) ;
                int id = int.Parse((DataGridObject.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                using (ClientsContainer db = new ClientsContainer())
                {
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(id);
                    Apartments apartments = db.Apartments.Find(id);
                    Houses houses = db.Houses.Find(id);
                    Lands lands = db.Lands.Find(id);
                    if (apartments != null) db.Apartments.Remove(apartments);
                    if (houses != null) db.Houses.Remove(houses);
                    if (lands != null) db.Lands.Remove(lands);
                    
                    db.RealEstateObjects.Remove(realEstateObjects);
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    FillTable();

                }
            }
        }
    }
}
