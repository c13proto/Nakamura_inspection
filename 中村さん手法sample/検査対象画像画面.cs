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
    public partial class 検査対象画像画面 : Form
    {
        IplImage 編集前;
        public static IplImage 編集後;
        IplImage トップハット;
        IplImage 表示中;
        private static 検査対象画像画面 _instance;

        public 検査対象画像画面()
        {
            
            InitializeComponent();
            if(編集前!=null)編集前.Dispose();
            編集前=メイン画面.検査対象画像.Clone();
            pictureBoxIpl1.Size = メイン画面.pictureBoxIplのサイズ調整(編集前);
            トップハットを二値化();
        }
        public static 検査対象画像画面 Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new 検査対象画像画面();
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
            表示中 = sample.Clone();
            pictureBoxIpl1.ImageIpl = 表示中;
            sample.Dispose();
            temp.Dispose();
            element.Dispose();
        }
        private void 二値化()
        {
            IplImage sample = 編集前.Clone();
            Cv.Threshold(sample, sample, trackBar_元画像TH.Value, 255, ThresholdType.Binary);
            表示中 = sample.Clone();
            pictureBoxIpl1.ImageIpl = 表示中;
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

        private void MouseMove_pictureBoxIpl1(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            label_座標.Text = "(" + (cp.X - pictureBoxIpl1.Location.X) + "," + (cp.Y - pictureBoxIpl1.Location.Y) + ")";
        }

        private void OnClick_pictureBoxIpl1(object sender, EventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                System.Drawing.Point cp = this.PointToClient(sp);
                CvColor c = pictureBoxIpl1.ImageIpl[cp.Y - pictureBoxIpl1.Location.Y, cp.X - pictureBoxIpl1.Location.X];
                色.Text = "" + c.B;
                textBox_x.Text = "" + (cp.X - pictureBoxIpl1.Location.X);
                textBox_y.Text = "" + (cp.Y - pictureBoxIpl1.Location.Y);
            }
        }

        private void TextChanged_x(object sender, EventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                double isnumber_x, isnumber_y;
                if (double.TryParse(textBox_x.Text, out isnumber_x) && double.TryParse(textBox_y.Text, out isnumber_y))
                    if ((isnumber_x >= 0 && isnumber_x <= pictureBoxIpl1.ImageIpl.Width) && (isnumber_y >= 0 && isnumber_y <= pictureBoxIpl1.ImageIpl.Height))
                    {
                        CvColor c = pictureBoxIpl1.ImageIpl[(int)isnumber_y, (int)isnumber_x];
                        色.Text = "" + c.B;
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y + pictureBoxIpl1.Location.Y));
                        //マウスポインタの位置を設定する
                        System.Windows.Forms.Cursor.Position = mp;
                    }
            }
        }

        private void TextChanged_y(object sender, EventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                double isnumber_x, isnumber_y;
                if (double.TryParse(textBox_x.Text, out isnumber_x) && double.TryParse(textBox_y.Text, out isnumber_y))
                    if ((isnumber_x >= 0 && isnumber_x <= pictureBoxIpl1.ImageIpl.Width) && (isnumber_y >= 0 && isnumber_y <= pictureBoxIpl1.ImageIpl.Height))
                    {
                        CvColor c = pictureBoxIpl1.ImageIpl[(int)isnumber_y, (int)isnumber_x];
                        色.Text = "" + c.B;
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y + pictureBoxIpl1.Location.Y));
                        //マウスポインタの位置を設定する
                        System.Windows.Forms.Cursor.Position = mp;
                    }
            }
        }

        private void OnClick_全て実行(object sender, EventArgs e)
        {
            トップハットを二値化();
        }



    }


}
