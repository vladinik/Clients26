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
    /// Логика взаимодействия для WinOffer.xaml
    /// </summary>
    public partial class WinOffer : Window
    {
        List<Offer> offers = new List<Offer>();
        public WinOffer()
        {
            InitializeComponent();
            FillTable();
        }
       //назад
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
       
        //вывод данных
        public void FillTable()
        {
            //offer.Clear();
            using (ClientsContainer db = new ClientsContainer())
            {
                foreach (Offer u in db.Offer)
                    offers.Add(u);
                DataGridOffer.ItemsSource = db.Offer.Local.ToBindingList();
            }
        }
        //удаление
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridOffer.Items.Count > 0)
            {
                var index = DataGridOffer.SelectedItem;
                if(index != null);
                int Id = int.Parse((DataGridOffer.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                using (ClientsContainer db = new ClientsContainer())
                {
                    Offer offer = db.Offer.Find(Id);
                    ApartmentOffer apartmentOffer = db.ApartmentOffer.Find(Id);
                    HouseOffer houseOffer = db.HouseOffer.Find(Id);
                    LandOffer landOffer = db.LandOffer.Find(Id);
                    if (apartmentOffer != null) db.ApartmentOffer.Remove(apartmentOffer);
                    if (houseOffer != null) db.HouseOffer.Remove(houseOffer);
                    if (landOffer != null) db.LandOffer.Remove(landOffer);
                    db.Offer.Remove(offer);
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    FillTable();

                }
            }
        }
        //добавление потребности квартиры
        private void ButtonNewApartments_Click(object sender, RoutedEventArgs e)
        {
            NewOffer newOffer = new NewOffer();
            newOffer.LableTitle.Content = "Добавление потребность для квартиры";
            newOffer.index = true;
            newOffer.ButtonNewHouses.IsEnabled = false;
            newOffer.ButtonNewLands.IsEnabled = false;
            newOffer.ButtonSApartments.IsEnabled = false;
            newOffer.ButtonSHouses.IsEnabled = false;
            newOffer.ButtonSLands.IsEnabled = false;
            newOffer.TextBoxFloorsMin.IsEnabled = false;
            newOffer.TextBoxFloorsMax.IsEnabled = false;
            newOffer.ComboBoxObject.Text = 1.ToString();
            newOffer.Show();
            this.Hide();
        }
        //"Редактирование потребности  квартиры"
        private void ButtonApartments_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridOffer.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите потребность для редактирования квартиры ");
            }
            if (index != null)
            {
                int Id = int.Parse((DataGridOffer.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewOffer newOffer = new NewOffer();
                newOffer.LableTitle.Content = "Редактирование потребности квартиры";
                newOffer.index = true;
                newOffer.TextBoxId.IsEnabled = false;
                newOffer.ButtonNewHouses.IsEnabled = false;
                newOffer.ButtonNewLands.IsEnabled = false;
                newOffer.ButtonNewApartments.IsEnabled = false;
                newOffer.ButtonSHouses.IsEnabled = false;
                newOffer.ButtonSLands.IsEnabled = false;
                newOffer.TextBoxFloorsMin.IsEnabled = false;
                newOffer.TextBoxFloorsMax.IsEnabled = false;

                using (ClientsContainer db = new ClientsContainer())
                {
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(Id);
                    ApartmentOffer apartments = db.ApartmentOffer.Find(Id);
                    Offer offer = db.Offer.Find(Id);
                    newOffer.TextBoxId.Text = apartments.Id.ToString();
                    newOffer.TextBoxStreet.Text = realEstateObjects.AddressStreet;
                    newOffer.TextBoxHouse.Text = realEstateObjects.AddressHouse;
                    newOffer.TextBoxPriceMin.Text = offer.MinPrice.ToString();
                    newOffer.TextBoxPriceMax.Text = offer.MaxPrice.ToString();
                    newOffer.TextBoxRoomsMin.Text = apartments.MinRooms.ToString();
                    newOffer.TextBoxRoomsMax.Text = apartments.MaxRooms.ToString();
                    newOffer.TextBoxAreaMin.Text = (apartments.MinArea*100).ToString(); 
                    newOffer.TextBoxAreaMax.Text = (apartments.MaxArea*100).ToString();
                    newOffer.TextBoxFloorMax.Text = apartments.MaxFloor.ToString();
                    newOffer.TextBoxFloorMin.Text = apartments.MinFloor.ToString();
                    newOffer.ComboBoxObject.Text = offer.IdRealObject.ToString();
                    newOffer.ComboBoxClient.Text = offer.IdClient.ToString();
                    newOffer.ComboBoxAgent.Text = offer.IdAgent.ToString();
                    newOffer.index = false;
                    newOffer.Show();
                    this.Hide();
                }
            }
        }
        //добавление потребности дома
        private void ButtonNewHouses_Click(object sender, RoutedEventArgs e)
        {
            NewOffer newOffer = new NewOffer();
            newOffer.LableTitle.Content = "Добавление потребности дома";
            newOffer.index = true;
            newOffer.ButtonNewApartments.IsEnabled = false;
            newOffer.ButtonNewLands.IsEnabled = false;
            newOffer.ButtonSApartments.IsEnabled = false;
            newOffer.ButtonSHouses.IsEnabled = false;
            newOffer.ButtonSLands.IsEnabled = false;
            newOffer.TextBoxFloorMin.IsEnabled = false;
            newOffer.TextBoxFloorMax.IsEnabled = false;
            newOffer.ComboBoxObject.Text = 2.ToString();
            newOffer.Show();
            this.Hide();
        }
        //редактирование потребности  дома
        private void ButtonHouses_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridOffer.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите потребность для редактирования дома ");
            }
            if (index != null)
            {
                int Id = int.Parse((DataGridOffer.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewOffer newOffer = new NewOffer();
                newOffer.LableTitle.Content = "Редактирование потребности дома";
                newOffer.index = true;
                newOffer.TextBoxId.IsEnabled = false;
                newOffer.ButtonNewHouses.IsEnabled = false;
                newOffer.ButtonNewLands.IsEnabled = false;
                newOffer.ButtonNewApartments.IsEnabled = false;
                newOffer.ButtonSLands.IsEnabled = false;
                newOffer.TextBoxFloorMin.IsEnabled = false;
                newOffer.TextBoxFloorMax.IsEnabled = false;
                newOffer.ButtonSApartments.IsEnabled = false;

                using (ClientsContainer db = new ClientsContainer())
                {
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(Id);
                    HouseOffer houseOffer = db.HouseOffer.Find(Id);
                    Offer offer = db.Offer.Find(Id);
                    newOffer.TextBoxId.Text = houseOffer.Id.ToString();
                    newOffer.TextBoxStreet.Text = realEstateObjects.AddressStreet;
                    newOffer.TextBoxHouse.Text = realEstateObjects.AddressHouse;
                    newOffer.TextBoxPriceMin.Text = offer.MinPrice.ToString();
                    newOffer.TextBoxPriceMax.Text = offer.MaxPrice.ToString();
                    newOffer.TextBoxRoomsMin.Text = houseOffer.MinRooms.ToString();
                    newOffer.TextBoxRoomsMax.Text = houseOffer.MaxRooms.ToString();
                    newOffer.TextBoxAreaMin.Text = (houseOffer.MinArea * 100).ToString();
                    newOffer.TextBoxAreaMax.Text = (houseOffer.MaxArea * 100).ToString();
                    newOffer.TextBoxFloorsMax.Text = houseOffer.MaxFloors.ToString();
                    newOffer.TextBoxFloorsMin.Text = houseOffer.MinFloors.ToString();
                    newOffer.ComboBoxObject.Text = offer.IdRealObject.ToString();
                    newOffer.ComboBoxClient.Text = offer.IdClient.ToString();
                    newOffer.ComboBoxAgent.Text = offer.IdAgent.ToString();
                    newOffer.index = false;
                    newOffer.Show();
                    this.Hide();
                }
            }
        }
        //добавление потребности земельного участка
        private void ButtonNewLands_Click(object sender, RoutedEventArgs e)
        {
            NewOffer newOffer = new NewOffer();
            newOffer.LableTitle.Content = "добавление потребности земли";
            newOffer.index = true;
            newOffer.ButtonNewApartments.IsEnabled = false;
            newOffer.ButtonNewHouses.IsEnabled = false;
            newOffer.ButtonSApartments.IsEnabled = false;
            newOffer.ButtonSHouses.IsEnabled = false;
            newOffer.ButtonSLands.IsEnabled = false;
            newOffer.TextBoxFloorMin.IsEnabled = false;
            newOffer.TextBoxFloorMax.IsEnabled = false;
            newOffer.TextBoxFloorsMin.IsEnabled = false; 
            newOffer.TextBoxFloorsMax.IsEnabled = false;
            newOffer.TextBoxRoomsMin.IsEnabled = false; 
            newOffer.TextBoxRoomsMax.IsEnabled = false;
            newOffer.ComboBoxObject.Text = 3.ToString();
            newOffer.Show();
            this.Hide();
        }
        //редактирование потребности земли
        private void ButtonLands_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridOffer.SelectedItem;
            if (index == null)
            {
                MessageBox.Show("Выберите потребность для редактирования земли ");
            }
            if (index != null)
            {
                int Id = int.Parse((DataGridOffer.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                NewOffer newOffer = new NewOffer();
                newOffer.LableTitle.Content = "Редактирование потребности земли";
                newOffer.index = true;
                newOffer.TextBoxId.IsEnabled = false;
                newOffer.ButtonNewHouses.IsEnabled = false;
                newOffer.ButtonNewLands.IsEnabled = false;
                newOffer.ButtonNewApartments.IsEnabled = false;
                newOffer.ButtonSHouses.IsEnabled = false;
                newOffer.TextBoxFloorMin.IsEnabled = false;
                newOffer.TextBoxFloorMax.IsEnabled = false;
                newOffer.ButtonSApartments.IsEnabled = false;
                newOffer.TextBoxRoomsMin.IsEnabled = false;
                newOffer.TextBoxRoomsMax.IsEnabled = false; 
                newOffer.TextBoxFloorsMax.IsEnabled = false; 
                newOffer.TextBoxFloorsMin.IsEnabled = false;


                using (ClientsContainer db = new ClientsContainer())
                {
                    RealEstateObjects realEstateObjects = db.RealEstateObjects.Find(Id);
                    LandOffer landOffer = db.LandOffer.Find(Id);
                    Offer offer = db.Offer.Find(Id);
                    newOffer.TextBoxId.Text = landOffer.Id.ToString();
                    newOffer.TextBoxStreet.Text = realEstateObjects.AddressStreet;
                    newOffer.TextBoxHouse.Text = realEstateObjects.AddressHouse;
                    newOffer.TextBoxPriceMin.Text = offer.MinPrice.ToString();
                    newOffer.TextBoxPriceMax.Text = offer.MaxPrice.ToString();
                    newOffer.TextBoxAreaMin.Text = (landOffer.MinArea * 100).ToString();
                    newOffer.TextBoxAreaMax.Text = (landOffer.MaxArea * 100).ToString();
                    newOffer.ComboBoxObject.Text = offer.IdRealObject.ToString();
                    newOffer.ComboBoxClient.Text = offer.IdClient.ToString();
                    newOffer.ComboBoxAgent.Text = offer.IdAgent.ToString();
                    newOffer.index = false;
                    newOffer.Show();
                    this.Hide();
                }
            }
        }
    }
}
