using System;
using System.Collections.Generic;
using System.Collections;
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
using YukariGames;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        int text_Num = 0;
        ArrayList mainText;
        Brush fontColor;//文字色を変えるための一時的なもの・・・かも？
        CLass.SE BGM = new CLass.SE();
        CLass.ImageClass image = new CLass.ImageClass();
        TextLoadClass textLoadClass = new TextLoadClass();
        Boolean BGMPlaying;
        ImageBrush Background = new ImageBrush();

        public MainWindow()
        {
            InitializeComponent();
            BGMPlaying = true;
            this.Text_window.Foreground = new SolidColorBrush(Colors.White); ;
            Background.ImageSource = image.InputImage("BaxkGround-beta.jpg");//背景設定要処理
            textLoadClass.TextRoad_Current(ref mainText,"Sample.txt","UTF-8");
        }

        private void textView()
        {
           if (text_Num - 1 < mainText.Count && text_Num > 0)
                {
                    this.Text_window.Text = (string)mainText[text_Num - 1];
                }

        }

        private void TextClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ++text_Num;
                this.name.Text = ("" + text_Num);
                textView();
                BGMChange();
            }
            catch
            {
                MessageBox.Show("なんかエラー出た！テキストデータの読み込み領域突破とかしてないかな？", "えらーめっせーじ", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
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
            this.BGMStop.Visibility = Visibility.Visible;
            this.mainGrid.Background = Background;//背景設定
            this.Start_Button.Visibility = Visibility.Hidden;
            this.Title_logo.Visibility = Visibility.Hidden;
            BGM.playSE("snowsnow.mp3");
        }

        void BGMChange()
        {
            switch (text_Num)
            {
                case 0: BGM.playSE("snowsnow.mp3"); break;
                case 20: BGM.playSE("cafe.mp3"); break;
                case 35: BGM.playSE("threedays.mp3"); break;
                case 50: BGM.playSE("towairo_goshoku.mp3"); break;
                default: break;
            }
        }

        private void BGM停止_Click(object sender, RoutedEventArgs e)
        {
            if (BGMPlaying)
                BGM.pause();
            else
                BGM.play();
            BGMPlaying = !BGMPlaying;
        }

        private void TextClickRight(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (text_Num > 0)
                    --text_Num;
                this.name.Text = ("" + text_Num);
                textView();
                BGMChange();
            }
            catch
            {
                MessageBox.Show("なんかエラー出た！テキストデータの読み込み領域突破とかしてないかな？", "えらーめっせーじ", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}
