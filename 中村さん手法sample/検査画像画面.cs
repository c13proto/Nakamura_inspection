using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
namespace 中村さん手法sample
{
    public partial class 検査画像画面 : Form
    {
        IplImage 編集前;
        IplImage 編集後;
        IplImage トップハット;
        private static 検査画像画面 _instance;

        public 検査画像画面()
        {
            
            InitializeComponent();
            if(編集前!=null)編集前.Dispose();
            編集前=メイン画面.検査画像.Clone();
            pictureBoxIpl1.Size = new System.Drawing.Size(編集前.Width, 編集前.Height);
            pictureBoxIpl1.ImageIpl = 編集前;
        }
        public static 検査画像画面 Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new 検査画像画面();
                return _instance;
            }
        }
        private void OnClickTopHat実行ボタン(object sender, EventArgs e)
        {
            トップハット処理();
        }

        private void TextChanged_回数(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_回数.Text, out isnumber))
                if (isnumber >= trackBar_回数.Minimum && isnumber <= trackBar_回数.Maximum)
                {
                    trackBar_回数.Value = (int)isnumber;
                    オープニング処理();
                }
        }
        private void Scroll_回数(object sender, EventArgs e)
        {
            textBox_回数.Text = "" + trackBar_回数.Value;
            オープニング処理();
        }
        
        private void TextChanged_サイズ(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_サイズ.Text, out isnumber))
                if (isnumber >= trackBar_サイズ.Minimum && isnumber <= trackBar_サイズ.Maximum)
                {
                    trackBar_サイズ.Value = (int)isnumber;
                    オープニング処理();
                }
        }

        private void Scroll_サイズ(object sender, EventArgs e)
        {
            textBox_サイズ.Text = "" + trackBar_サイズ.Value;
            オープニング処理();
        }

        private void TextChanged_元画像TH(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_元画像TH.Text, out isnumber))
                if (isnumber >= trackBar_元画像TH.Minimum && isnumber <= trackBar_元画像TH.Maximum)
                {
                    trackBar_元画像TH.Value = (int)isnumber;
                    二値化();
                }
        }
        private void Scroll_元画像TH(object sender, EventArgs e)
        {
            textBox_元画像TH.Text = "" + trackBar_元画像TH.Value;
            二値化();

        }
        private void TextChanged_TopHatTH(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_TopHatTH.Text, out isnumber))
                if (isnumber >= trackBar_TopHatTH.Minimum && isnumber <= trackBar_TopHatTH.Maximum)
                {
                    trackBar_TopHatTH.Value = (int)isnumber;
                    トップハットを二値化();
                }
        }
        private void Scroll_TopHatTH(object sender, EventArgs e)
        {
            textBox_TopHatTH.Text = "" + trackBar_TopHatTH.Value;
            トップハットを二値化();
        }

        private void トップハット処理()
        {
            IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_サイズ.Value, trackBar_サイズ.Value, (int)trackBar_サイズ.Value / 2, (int)trackBar_サイズ.Value / 2, ElementShape.Rect);
            IplImage sample = 編集前.Clone();
            IplImage temp = 編集前.Clone();
            Cv.MorphologyEx(sample, sample, temp, element, MorphologyOperation.TopHat, trackBar_回数.Value);
            if (トップハット != null) トップハット.Dispose();
            トップハット = sample.Clone();
            pictureBoxIpl1.ImageIpl = トップハット;
            sample.Dispose();
            temp.Dispose();
            element.Dispose();
        }
        private void オープニング処理()
        {
            IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_サイズ.Value, trackBar_サイズ.Value, (int)trackBar_サイズ.Value / 2, (int)trackBar_サイズ.Value / 2, ElementShape.Rect);
            IplImage sample = 編集前.Clone();
            IplImage temp = 編集前.Clone();
            Cv.MorphologyEx(sample, sample, temp, element, MorphologyOperation.Open, trackBar_回数.Value);
            pictureBoxIpl1.ImageIpl = sample;
            sample.Dispose();
            temp.Dispose();
            element.Dispose();
        }
        private void 二値化()
        {
            IplImage sample = 編集前.Clone();
            Cv.Threshold(sample, sample, trackBar_元画像TH.Value, 255, ThresholdType.Binary);
            pictureBoxIpl1.ImageIpl = sample;
            sample.Dispose();
        }
        private void トップハットを二値化()
        {
            IplImage sample = 編集前.Clone();
            if (トップハット != null)//トップハット作ってあったら
            {
                Cv.Threshold(トップハット, sample, trackBar_TopHatTH.Value, 255, ThresholdType.Binary);
                if (編集後 != null) 編集後.Dispose();
                編集後 = sample.Clone();
            }
            else //トップハット作ってなかったら
            {
                IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_サイズ.Value, trackBar_サイズ.Value, (int)trackBar_サイズ.Value / 2, (int)trackBar_サイズ.Value / 2, ElementShape.Rect);
                IplImage temp = 編集前.Clone();
                Cv.MorphologyEx(sample, sample, temp, element, MorphologyOperation.TopHat, trackBar_回数.Value);
                トップハット = sample.Clone();
                Cv.Threshold(トップハット, sample, trackBar_TopHatTH.Value, 255, ThresholdType.Binary);
                if (編集後 != null) 編集後.Dispose();
                編集後 = sample.Clone();
                temp.Dispose();
                element.Dispose();
            }
            sample.Dispose();
            pictureBoxIpl1.ImageIpl = 編集後;
        }







    }


}
