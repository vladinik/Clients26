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
    /// Логика взаимодействия для NewOffer.xaml
    /// </summary>
    public partial class NewOffer : Window
    {
        public bool index;
        public NewOffer()
        {
            InitializeComponent();
            //using (ClientsContainer db = new ClientsContainer())
            //{
            //    var clientList = from c in db.Client
            //                     join p in db.Person on c.id equals p.id
            //                     select new
            //                     {
            //                         c.id
            //                     };
            //    ComboBoxClient.ItemsSource = clientList.ToList();
            //    ComboBoxClient.DisplayMemberPath = "FirstName";
            //    ComboBoxClient.SelectedValuePath = "id";
            //}
        }
        //НАЗАД
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        // новая потребность квартиры
        private void ButtonNewApartments_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text !="" && ComboBoxObject.Text !="")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    ApartmentOffer apartments = new ApartmentOffer();
                    Offer offer = new Offer();
                    RealEstateObjects objects = new RealEstateObjects();
                    TypeObject typeObject = new TypeObject();
                    apartments.Id = int.Parse(TextBoxId.Text);
                    offer.Id = int.Parse(TextBoxId.Text);
                    objects.Id = int.Parse(TextBoxId.Text);

                    apartments.MinArea = Convert.ToDecimal(TextBoxAreaMin.Text);
                    apartments.MaxArea = Convert.ToDecimal(TextBoxAreaMax.Text);
                    apartments.MinRooms = int.Parse(TextBoxRoomsMin.Text);
                    apartments.MaxRooms = int.Parse(TextBoxRoomsMax.Text);
                    apartments.MinFloor = int.Parse(TextBoxFloorMin.Text); 
                    apartments.MaxFloor = int.Parse(TextBoxFloorMax.Text);

                    offer.MinPrice = int.Parse(TextBoxPriceMin.Text); 
                    offer.MaxPrice = int.Parse(TextBoxPriceMax.Text);
                    offer.IdClient = int.Parse(ComboBoxClient.Text); 
                    offer.IdAgent = int.Parse(ComboBoxAgent.Text); 
                    offer.IdRealObject = int.Parse(ComboBoxObject.Text);
                    objects.AddressStreet = TextBoxStreet.Text;
                    objects.AddressNumber = TextBoxHouse.Text;
                 
                    db.ApartmentOffer.Add(apartments);
                    db.Offer.Add(offer);
                    db.RealEstateObjects.Add(objects);
                    db.SaveChanges();
                }
                MessageBox.Show("Квартира добавлена");
            }
            else MessageBox.Show("Вы не выбрали данные из обязательных полей");
        }

        //старая потребность квартиры
        private void ButtonSApartments_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text != "" && ComboBoxObject.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    ApartmentOffer apartments = db.ApartmentOffer.Find(int.Parse(TextBoxId.Text));
                    Offer offer = db.Offer.Find(int.Parse(TextBoxId.Text));
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(int.Parse(TextBoxId.Text));

                    apartments.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    offer.Id = int.Parse(TextBoxId.Text);
                    apartments.MinArea = Convert.ToDecimal(TextBoxAreaMin.Text); 
                    apartments.MaxArea = Convert.ToDecimal(TextBoxAreaMax.Text);
                    apartments.MinRooms = int.Parse(TextBoxRoomsMin.Text);
                    apartments.MaxRooms = int.Parse(TextBoxRoomsMax.Text);
                    apartments.MinFloor = int.Parse(TextBoxFloorMin.Text);
                    apartments.MaxFloor = int.Parse(TextBoxFloorMax.Text);
                    offer.IdClient = int.Parse(ComboBoxClient.Text);
                    offer.IdAgent = int.Parse(ComboBoxAgent.Text);
                    offer.IdRealObject = int.Parse(ComboBoxObject.Text);
                    offer.MinPrice = int.Parse(TextBoxPriceMin.Text);
                    offer.MaxPrice = int.Parse(TextBoxPriceMax.Text);
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressNumber = TextBoxHouse.Text;

                    db.SaveChanges();
                }
                MessageBox.Show("квартира отредактирован");
            }
            else MessageBox.Show("Вы не выбрали данные из обязательных полей");
        }

        //новая потребность дома
        private void ButtonNewHouses_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text != "" && ComboBoxObject.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    HouseOffer houseOffer = new HouseOffer();
                    Offer offer = new Offer();
                    RealEstateObjects objects = new RealEstateObjects();
                    TypeObject typeObject = new TypeObject();
                    houseOffer.Id = int.Parse(TextBoxId.Text);
                    offer.Id = int.Parse(TextBoxId.Text);
                    objects.Id = int.Parse(TextBoxId.Text);
                    houseOffer.MinArea = Convert.ToDecimal(TextBoxAreaMin.Text);
                    houseOffer.MaxArea = Convert.ToDecimal(TextBoxAreaMax.Text);
                    houseOffer.MinRooms = int.Parse(TextBoxRoomsMin.Text);
                    houseOffer.MaxRooms = int.Parse(TextBoxRoomsMax.Text);
                    houseOffer.MinFloors = int.Parse(TextBoxFloorsMin.Text);
                    houseOffer.MaxFloors = int.Parse(TextBoxFloorsMax.Text);

                    offer.MinPrice = int.Parse(TextBoxPriceMin.Text);
                    offer.MaxPrice = int.Parse(TextBoxPriceMax.Text);
                    offer.IdClient = int.Parse(ComboBoxClient.Text);
                    offer.IdAgent = int.Parse(ComboBoxAgent.Text);
                    offer.IdRealObject = int.Parse(ComboBoxObject.Text);
                    objects.AddressStreet = TextBoxStreet.Text;
                    objects.AddressNumber = TextBoxHouse.Text;


                    db.HouseOffer.Add(houseOffer);
                    db.Offer.Add(offer);
                    db.RealEstateObjects.Add(objects);
                    db.SaveChanges();
                }
                MessageBox.Show("дом добавлен");
            }
            else MessageBox.Show("Вы не выбрали данные из обязательных полей");
        }
        //старая потребность дома
        private void ButtonSHouses_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text != "" && ComboBoxObject.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    HouseOffer house = db.HouseOffer.Find(int.Parse(TextBoxId.Text));
                    Offer offer = db.Offer.Find(int.Parse(TextBoxId.Text));
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(int.Parse(TextBoxId.Text));

                    house.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    offer.Id = int.Parse(TextBoxId.Text);
                    house.MinArea = Convert.ToDecimal(TextBoxAreaMin.Text);
                    house.MaxArea = Convert.ToDecimal(TextBoxAreaMax.Text);
                    house.MinRooms = int.Parse(TextBoxRoomsMin.Text);
                    house.MaxRooms = int.Parse(TextBoxRoomsMax.Text);
                    house.MinFloors = int.Parse(TextBoxFloorsMin.Text);
                    house.MaxFloors = int.Parse(TextBoxFloorsMax.Text);
                    offer.MinPrice = int.Parse(TextBoxPriceMin.Text);
                    offer.MaxPrice = int.Parse(TextBoxPriceMax.Text); 
                    offer.IdClient = int.Parse(ComboBoxClient.Text);
                    offer.IdAgent = int.Parse(ComboBoxAgent.Text);
                    offer.IdRealObject = int.Parse(ComboBoxObject.Text);
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressNumber = TextBoxHouse.Text;

                    db.SaveChanges();
                }
                MessageBox.Show("дом отредактирован");
            }
            else MessageBox.Show("Вы не выбрали данные из обязательных полей");
        }
        //новая потребность участка
        private void ButtonNewLands_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text != "" && ComboBoxObject.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    LandOffer landOffer = new LandOffer();
                    Offer offer = new Offer();
                    RealEstateObjects objects = new RealEstateObjects();
                    TypeObject typeObject = new TypeObject();
                    landOffer.Id = int.Parse(TextBoxId.Text);
                    offer.Id = int.Parse(TextBoxId.Text);
                    objects.Id = int.Parse(TextBoxId.Text);
                    landOffer.MinArea = Convert.ToDecimal(TextBoxAreaMin.Text);
                    landOffer.MaxArea = Convert.ToDecimal(TextBoxAreaMax.Text);

                    offer.MinPrice = int.Parse(TextBoxPriceMin.Text);
                    offer.MaxPrice = int.Parse(TextBoxPriceMax.Text);
                    offer.IdClient = int.Parse(ComboBoxClient.Text);
                    offer.IdAgent = int.Parse(ComboBoxAgent.Text);
                    offer.IdRealObject = int.Parse(ComboBoxObject.Text);
                    objects.AddressStreet = TextBoxStreet.Text;
                    objects.AddressNumber = TextBoxHouse.Text;


                    db.LandOffer.Add(landOffer);
                    db.Offer.Add(offer);
                    db.RealEstateObjects.Add(objects);
                    db.SaveChanges();
                }
                MessageBox.Show("участok добавлен");
            }
            else MessageBox.Show("Вы не выбрали данные из обязательных полей");
        }
        //старая потребность земли
        private void ButtonSLands_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClient.Text != "" && ComboBoxAgent.Text != "" && ComboBoxObject.Text != "")
            {
                using (ClientsContainer db = new ClientsContainer())
                {
                    LandOffer land = db.LandOffer.Find(int.Parse(TextBoxId.Text));
                    Offer offer = db.Offer.Find(int.Parse(TextBoxId.Text));
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(int.Parse(TextBoxId.Text));

                    land.Id = int.Parse(TextBoxId.Text);
                    realEstateObjects.Id = int.Parse(TextBoxId.Text);
                    offer.Id = int.Parse(TextBoxId.Text);
                    land.MinArea = Convert.ToDecimal(TextBoxAreaMin.Text);
                    land.MaxArea = Convert.ToDecimal(TextBoxAreaMax.Text);
                    
                    offer.MinPrice = int.Parse(TextBoxPriceMin.Text);
                    offer.MaxPrice = int.Parse(TextBoxPriceMax.Text);
                    offer.IdClient = int.Parse(ComboBoxClient.Text);
                    offer.IdAgent = int.Parse(ComboBoxAgent.Text);
                    offer.IdRealObject = int.Parse(ComboBoxObject.Text);
                    realEstateObjects.AddressStreet = TextBoxStreet.Text;
                    realEstateObjects.AddressNumber = TextBoxHouse.Text;

                    db.SaveChanges();
                }
                MessageBox.Show("участok отредактирован");
            }
            else MessageBox.Show("Вы не выбрали данные из обязательных полей");
        }

        private void TextBoxRoomsMax_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxHouse_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxPriceMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxPriceMax_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxAreaMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // ограничение на ввод букв
            {
                if (char.IsDigit(e.Text, 0) || e.Text == ",")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBoxAreaMax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // ограничение на ввод букв
            {
                if (char.IsDigit(e.Text, 0) || e.Text == ",")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBoxFloorMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxFloorMax_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxFloorsMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxFloorsMax_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TextBoxRoomsMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
