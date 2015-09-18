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
        ArrayList imageList;
        CLass.SE BGM = new CLass.SE();
        CLass.ImageClass image = new CLass.ImageClass();
        TextLoadClass textLoadClass = new TextLoadClass();
        Boolean BGMPlaying;
        ImageBrush Background = new ImageBrush();
        
        /// <summary>
        /// 画像切り替えよう変数
        /// </summary>
        BitmapImage bitmapImage = new BitmapImage();

        public MainWindow()
        {
            InitializeComponent();
            BGMPlaying = true;
            this.Text_window.Foreground = new SolidColorBrush(Colors.White); ;
            Background.ImageSource = image.InputImage(Properties.Resources.BACKGROUND);//背景設定要処理
            textLoadClass.TextRoad_Current(ref mainText,"Sample.txt","UTF-8");
            textLoadClass.TextRoad_Folder(ref imageList, Properties.Resources.IMAGELIST, Properties.Resources.ENCODE,Properties.Resources.FOLDER);
        }

        private void textView()
        {
           if (text_Num - 1 < mainText.Count && text_Num > 0)
                {
                    this.Text_window.Text = (string)mainText[text_Num - 1];
                }

        }

        void BGMChange()
        {
            /*-------------BGM変更新定義----------------*/
            //指定されてる配列がオーバーしていないかのチェック
            if (text_Num - 1 < mainText.Count && text_Num > 0)
            {
                string checkText = (string)mainText[text_Num - 1];
                //C#って"string.Equals"呼ばなくても比較してくれるんだぜすげー！！(実際は自動で呼び出しています)
                if (checkText == "（スノウ）" || checkText == "(snow)")
                {
                    BGM.playSE(Properties.Resources.SNOW);
                    ++text_Num;
                }
                else if (checkText == "（カフェ）" || checkText == "(cafe)")
                {
                    BGM.playSE(Properties.Resources.CAFE);
                    ++text_Num;
                }
                else if (checkText == "（三日後）" || checkText == "(three)")
                {
                    BGM.playSE(Properties.Resources.THREE);
                    ++text_Num;
                }
                else if (checkText == "（永久）" || checkText == "(towairo)")
                {
                    BGM.playSE(Properties.Resources.TOWA);
                    ++text_Num;
                }
            }
        }

        void BGMChange_Back()
        {
            /*-------------BGM変更新定義----------------*/
            //指定されてる配列がオーバーしていないかのチェック
            if (text_Num - 1 < mainText.Count && text_Num > 0)
            {
                string checkText = (string)mainText[text_Num - 1];
                //C#って"string.Equals"呼ばなくても比較してくれるんだぜすげー！！(実際は自動で呼び出しています)
                if (checkText == "（スノウ）" || checkText == "(snow)")
                {
                    BGM.playSE(Properties.Resources.SNOW);
                    --text_Num;
                }
                else if (checkText == "（カフェ）" || checkText == "(cafe)")
                {
                    BGM.playSE(Properties.Resources.CAFE);
                    --text_Num;
                }
                else if (checkText == "（三日後）" || checkText == "(three)")
                {
                    BGM.playSE(Properties.Resources.THREE);
                    --text_Num;
                }
                else if (checkText == "（永久）" || checkText == "(towairo)")
                {
                    BGM.playSE(Properties.Resources.TOWA);
                    --text_Num;
                }

            }

        }

        void ImageChange()
        {
            if (text_Num - 1 < mainText.Count && text_Num > 0)
            {
                string checkText = (string)mainText[text_Num - 1];
                for (int i = 9; i < imageList.Count; i+=2)
                {
                    if (checkText == (string)imageList[i])
                    {
                        this.Yukari.Source = image.InputImage((string)imageList[i+1]);
                        ++text_Num;
                    }
                }

            }
            
        }

        #region テキスト左クリック
        private void TextClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ++text_Num;
                BGMChange();
                ImageChange();
                this.name.Text = ("" + text_Num);
                textView();
            }
            catch
            {
                MessageBox.Show("なんかエラー出た！テキストデータの読み込み領域突破とかしてないかな？", "えらーめっせーじ", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        #endregion

        #region セーブボタン
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.NULL);
        }
        #endregion

        #region ロードボタン
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.NULL);
        }
        #endregion

        #region タイトルクリック(特に意味はないが関連付けられたので残しておくこと
        private void Title_Click(object sender, MouseButtonEventArgs e)
        {
           
        }
        #endregion

        #region スタートボタン
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
            BGM.playSE(Properties.Resources.SNOW);
            this.Yukari.Source = image.InputImage(Properties.Resources.NIKA_FUNNY_1);
        }
        #endregion

        #region BGM停止ボタン
        private void BGM停止_Click(object sender, RoutedEventArgs e)
        {
            if (BGMPlaying)
                BGM.pause();
            else
                BGM.play();
            BGMPlaying = !BGMPlaying;
        }
        #endregion

        #region テキスト右クリック
        /// <summary>
        /// テキストブロックが右クリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextClickRight(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (text_Num > 0)
                    --text_Num;
                this.name.Text = ("" + text_Num);
                BGMChange_Back();
                //ImageChange();
                textView();
            }
            catch
            {
                MessageBox.Show("なんかエラー出た！テキストデータの読み込み領域突破とかしてないかな？", "えらーめっせーじ", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        #endregion
    }
}
