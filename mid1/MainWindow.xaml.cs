using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mid1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private List<string> flowerList = new List<string>()
        {
            "MARIGOLD",
            "SUNFLOWER",
            "LILY",
            "ROSE",


        };

        //declare  state list and  initialize it with default values
        private List<string> colorList = new List<string>()
        {
            "RED",
            "BLACK",
            "PINK",
            "BROWN",


        };

        public static ObservableCollection<string> listForFlowerGrid = new ObservableCollection<string>();
        public static ObservableCollection<string> listForColorGrid = new ObservableCollection<string>();

       

        public MainWindow()
        {
            InitializeComponent();
            cmbFlower.ItemsSource = flowerList;
            cmbColor.ItemsSource = colorList;
            listForFlowerGrid.CollectionChanged += flowerGridChange;
            listForColorGrid.CollectionChanged += colorGridChange;
        }

      

      
        private void ClearComboBox()
        {
            cmbFlower.SelectedItem = null;
            cmbColor.SelectedItem = null;
        }

       
        private void ColorGridChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            //refresh grid item source
            gridColor.ItemsSource = listForColorGrid;
            //If no item in grid then clear combobox
            if (listForColorGrid.Count < 1)
                ClearComboBox();
        }

      
        private void flowerGridChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            //refresh grid item source
            gridFlower.ItemsSource = listForFlowerGrid;
            //If no item in grid then clear combobox
            if (listForColorGrid.Count < 1)
                ClearComboBox();
        }

       
        private void CmbFlower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFlower != null && cmbFlower.SelectedValue != null)
                listForFlowerGrid.Add(cmbFlower.SelectedValue.ToString());

        }

       
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            cmbFlower.SelectedItem = null;
            listForFlowerGrid.Clear();
            cmbColor.SelectedItem = null;
            listForColorGrid.Clear();
        }

      
        private void BtnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            foreach (var cal in gridFlower.SelectedCells)
                DeleteItems(cal.Item.ToString(), true, false);
            foreach (var cal in gridColor.SelectedCells)
                DeleteItems(cal.Item.ToString(), false, true);

        }

       
        private void GridFlowers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridColor.SelectedItem = null;
            OpenThirdGrid();

        }


        private void GridColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridFlower.SelectedItem = null;
            OpenThirdGrid();

        }


        private void DeleteItems(string value, bool isFromFlowers, bool isFromColor)
        {
            if (isFromFlowers)
                listForFlowerGrid.Remove(value);
            if (isFromColor)
                listForColorGrid.Remove(value);
        }
      


        private void CmbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbColor != null && cmbColor.SelectedValue != null)
                listForColorGrid.Add(cmbColor.SelectedItem.ToString());
        }

        private void OpenThirdGrid()
        {
            if (listForColorGrid.Intersect(listForFlowerGrid).Any())
            {
                Window win = new Window();
                win.Show();
            }
        }












    }
}
