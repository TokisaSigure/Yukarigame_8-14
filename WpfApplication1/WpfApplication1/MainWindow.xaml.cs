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
        CLass.SE BGM = new CLass.SE();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextClick(object sender, MouseButtonEventArgs e)
        {
            ++text_Num;
            this.name.Text = ("" + text_Num);
            BGMChange();
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
            BGM.playSE("snowsnow.mp3");
        }

        void BGMChange()
        {
            switch (text_Num)
            {
                case 20: BGM.playSE("cafe.mp3"); break;
                case 35: BGM.playSE("threedays.mp3"); break;
                case 50: BGM.playSE("towairo_goshoku.mp3"); break;
                default: break;
            }
        }
    }
}
