using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using WMPLib;

namespace WpfApplication1.CLass
{
    /// <summary>
    /// SE再生用、playSoundを呼び出すときに、uri指定でSE再生
    /// mp3にも対応、要Windows Media Playerの参照設定
    /// </summary>
    class SE
    {
        WindowsMediaPlayer Player = new WindowsMediaPlayer();

        public void playSE(string se)
        {
            Player.settings.setMode("loop",true);//loop再生化
            Player.settings.volume = 70;
            Player.URL = (@"data\" + se);
            Player.controls.play();
        }

        public void play()
        {
            Player.controls.play();
        }

        public void stopSE()
        {
            Player.controls.stop();
        }

        public void pause()
        {
            Player.controls.pause();
        }

    }
}
