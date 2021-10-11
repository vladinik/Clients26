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
    /// Логика взаимодействия для NewObject.xaml
    /// </summary>
    public partial class NewObject : Window
    {
        public bool index;
        public NewObject()
        {
            InitializeComponent();
        }
        //новая квартира
        private void ButtonNewApartments_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxTotalArea.Text != "" )
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Apartments apartments = new Apartments();
                    RealEstateObjects realEstateObjects = new RealEstateObjects();
                    apartments.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    apartments.Floor = int.Parse(TextBoxFloors.Text);
                    apartments.Rooms = int.Parse(TextBoxRooms.Text);
                    apartments.TotalArea = int.Parse(TextBoxTotalArea.Text);

                    realEstateObjects.AddressCity = TextBoxCity.Text;
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressHouse = TextBoxHouses.Text;
                    realEstateObjects.AddressNumber = TextBoxNumber.Text;
                    realEstateObjects.CoordinateLatitude = int.Parse(TextBoxCoordinateLatitude.Text);
                    realEstateObjects.CoordinateLongitude = int.Parse(TextBoxCoordinateLongitude.Text);


                    db.Apartments.Add(apartments);
                    db.RealEstateObjects.Add(realEstateObjects); 
                    db.SaveChanges();
                }MessageBox.Show("Квартира добавлена");
            }else MessageBox.Show("Добавьте обязательное поле");
        }
        //новый дом
        private void ButtonNewHouses_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxTotalArea.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Houses houses = new Houses();
                    RealEstateObjects realEstateObjects = new RealEstateObjects();
                    houses.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    houses.TotalFloors = int.Parse(TextBoxTotalFloors.Text);
                    houses.Rooms = int.Parse(TextBoxRooms.Text);
                    houses.TotalArea = int.Parse(TextBoxTotalArea.Text);

                    realEstateObjects.AddressCity = TextBoxCity.Text;
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressHouse = TextBoxHouses.Text;
                    realEstateObjects.AddressNumber = TextBoxNumber.Text;
                    realEstateObjects.CoordinateLatitude = int.Parse(TextBoxCoordinateLatitude.Text);
                    realEstateObjects.CoordinateLongitude = int.Parse(TextBoxCoordinateLongitude.Text);


                    db.Houses.Add(houses);
                    db.RealEstateObjects.Add(realEstateObjects);
                    db.SaveChanges();
                }
                MessageBox.Show("Дом добавлен");
            }
            else MessageBox.Show("Добавьте обязательнок поле");
        }
        //новый участок
        private void ButtonNewLands_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxTotalArea.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Lands lands = new Lands();
                    RealEstateObjects realEstateObjects = new RealEstateObjects();
                    lands.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    lands.TotalArea = int.Parse(TextBoxTotalArea.Text);

                    realEstateObjects.AddressCity = TextBoxCity.Text;
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressHouse = TextBoxHouses.Text;
                    realEstateObjects.AddressNumber = TextBoxNumber.Text;
                    realEstateObjects.CoordinateLatitude = int.Parse(TextBoxCoordinateLatitude.Text);
                    realEstateObjects.CoordinateLongitude = int.Parse(TextBoxCoordinateLongitude.Text);


                    db.Lands.Add(lands);
                    db.RealEstateObjects.Add(realEstateObjects);
                    db.SaveChanges();
                }
                MessageBox.Show("Земельный участок добавлен");
            }
            else MessageBox.Show("Добавьте обязательнок поле");
        }
        //назад
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //изменение данных о квартире
        private void ButtonSApartments_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxTotalArea.Text != "" )
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Apartments apartments =db.Apartments.Find(int.Parse(TextBoxId.Text));
                    RealEstateObjects realEstateObjects =db.RealEstateObjects.Find(int.Parse(TextBoxId.Text));

                    apartments.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    apartments.Floor = int.Parse(TextBoxFloors.Text);
                    apartments.Rooms = int.Parse(TextBoxRooms.Text);
                    apartments.TotalArea = Convert.ToDecimal(TextBoxTotalArea.Text);
                    realEstateObjects.AddressCity = TextBoxCity.Text;
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressHouse = TextBoxHouses.Text;
                    realEstateObjects.AddressNumber = TextBoxNumber.Text;
                    realEstateObjects.CoordinateLatitude = float.Parse(TextBoxCoordinateLatitude.Text);
                    realEstateObjects.CoordinateLongitude = float.Parse(TextBoxCoordinateLongitude.Text);

                    db.SaveChanges();
                }
                MessageBox.Show("квартира отредактирован");
            }
            else MessageBox.Show("Добавьте обязательное поле");
        }

        private void ButtonSHouses_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxTotalArea.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Houses houses = db.Houses.Find(int.Parse(TextBoxId.Text));
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(int.Parse(TextBoxId.Text));

                    houses.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    houses.TotalFloors = int.Parse(TextBoxTotalFloors.Text);
                    houses.Rooms = int.Parse(TextBoxRooms.Text);
                    houses.TotalArea = Convert.ToDecimal(TextBoxTotalArea.Text);
                    realEstateObjects.AddressCity = TextBoxCity.Text;
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressHouse = TextBoxHouses.Text;
                    realEstateObjects.AddressNumber = TextBoxNumber.Text;
                    realEstateObjects.CoordinateLatitude = float.Parse(TextBoxCoordinateLatitude.Text);
                    realEstateObjects.CoordinateLongitude = float.Parse(TextBoxCoordinateLongitude.Text);

                    db.SaveChanges();
                }
                MessageBox.Show("дом отредактирован");
            }
            else MessageBox.Show("Добавьте обязательное поле");
        }

        private void ButtonSLands_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxTotalArea.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    Lands lands = db.Lands.Find(int.Parse(TextBoxId.Text));
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(int.Parse(TextBoxId.Text));

                    lands.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    lands.TotalArea = Convert.ToDecimal(TextBoxTotalArea.Text);
                    realEstateObjects.AddressCity = TextBoxCity.Text;
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressHouse = TextBoxHouses.Text;
                    realEstateObjects.AddressNumber = TextBoxNumber.Text;
                    realEstateObjects.CoordinateLatitude = float.Parse(TextBoxCoordinateLatitude.Text);
                    realEstateObjects.CoordinateLongitude = float.Parse(TextBoxCoordinateLongitude.Text);

                    db.SaveChanges();
                }
                MessageBox.Show("участок отредактирован");
            }
            else MessageBox.Show("Добавьте обязательное поле");
        }
    }
}
