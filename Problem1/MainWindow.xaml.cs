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

namespace Problem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
        public partial class MainWindow : Window
        {
            //declare  fruit list and  initialize it with default values
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
                Flowers.ItemsSource = flowerList;
                Color.ItemsSource = colorList;
                listForFlowerGrid.CollectionChanged += flowerGridChange;
                listForColorGrid.CollectionChanged += colorGridChange;
            }

        private void colorGridChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// method is responsible to clear both combobox selection
        /// </summary>
        private void ClearComboBox()
            {
                Flowers.SelectedItem = null;
                Color.SelectedItem = null;
            }

            /// <summary>
            /// State Grid Refresh
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void stateGridChange(object sender, NotifyCollectionChangedEventArgs e)
            {
                //refresh grid item source
                gridColor.ItemsSource = listForColorGrid;
                //If no item in grid then clear combobox
                if (listForColorGrid.Count < 1)
                    ClearComboBox();
            }

            /// <summary>
            /// food grid refresh
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void flowerGridChange(object sender, NotifyCollectionChangedEventArgs e)
            {
                //refresh grid item source
                gridFlowers.ItemsSource = listForFlowerGrid;
                //If no item in grid then clear combobox
                if (listForColorGrid.Count < 1)
                    ClearComboBox();
            }

            /// <summary>
            /// Add to fruit grid on combbobox selection change
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CmbFruit_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (Flowers != null && Flowers.SelectedValue != null)
                    listForFlowerGrid.Add(Flowers.SelectedValue.ToString());

            }

            /// <summary>
            /// state combobox selection changed
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (Color != null && Color.SelectedValue != null)
                    listForColorGrid.Add(Color.SelectedItem.ToString());
            }

            /// <summary>
            /// clear button handler 
            /// clears grid and combobox selection as well
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BtnClear_Click(object sender, RoutedEventArgs e)
            {
                Flowers.SelectedItem = null;
                listForFlowerGrid.Clear();
                Color.SelectedItem = null;
                listForColorGrid.Clear();
            }

            /// <summary>
            /// Deletes selected rows
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BtnDeleteSelected_Click(object sender, RoutedEventArgs e)
            {
                foreach (var cal in gridFlowers.SelectedCells)
                    DeleteItems(cal.Item.ToString(), true, false);
                foreach (var cal in gridColor.SelectedCells)
                    DeleteItems(cal.Item.ToString(), false, true);

            }

            /// <summary>
            /// fruit grid selection handler
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void GridFlowers_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                gridColor.SelectedItem = null;
                
            }

            
            private void GridState_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                gridFlowers.SelectedItem = null;
                
            }

            
            private void DeleteItems(string value, bool isFromFlowers, bool isFromColor)
            {
                if (isFromFlowers)
                    listForFlowerGrid.Remove(value);
                if (isFromColor)
                    listForColorGrid.Remove(value);
            }
        }

        
    }
