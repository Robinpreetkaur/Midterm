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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyLife = "HAPPY";
        }
        public string MyLife
        {
            get { return (string)GetValue(MyLifeProperty); }
            set { SetValue(MyLifeProperty, value); }
        }

        public static readonly DependencyProperty MyLifeProperty =
            DependencyProperty.Register("MyLife", typeof(string), typeof(MainWindow),new PropertyMetadata(string.Empty));

    }
}

