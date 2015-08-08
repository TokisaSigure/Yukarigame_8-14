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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        int text_Num = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextClick(object sender, MouseButtonEventArgs e)
        {
            ++text_Num;
            this.name.Text = ("" + text_Num);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Title_Click(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            this.name.Visibility = Visibility.Visible;
            this.Yukari.Visibility = Visibility.Visible;
            this.Text_window.Visibility = Visibility.Visible;
            this.SaveButton.Visibility = Visibility.Visible;
            this.LoadButton.Visibility = Visibility.Visible;
            this.Start_Button.Visibility = Visibility.Hidden;
            this.Title_logo.Visibility = Visibility.Hidden;
        }
    }
}
