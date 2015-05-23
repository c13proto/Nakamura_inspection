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
    public partial class テンプレート画像画面 : Form
    {
        IplImage 編集前;
        public static IplImage 編集後;
        IplImage 表示中;
        private static テンプレート画像画面 _instance;

        public テンプレート画像画面()
        {

            InitializeComponent();
            if(編集前!=null)編集前.Dispose();
            編集前 = メイン画面.テンプレ画像.Clone();
            pictureBoxIpl1.Size = メイン画面.pictureBoxIplのサイズ調整(編集前);
            膨張と二値化();
        }
        public static テンプレート画像画面 Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new テンプレート画像画面();
                return _instance;
            }
        }

        private void TextChanged_膨張(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_膨張.Text, out isnumber))
                if (isnumber >= trackBar_膨張.Minimum && isnumber <= trackBar_膨張.Maximum)
                {
                    trackBar_膨張.Value = (int)isnumber;
                    膨張();
                }
        }

        private void Scroll_膨張(object sender, EventArgs e)
        {
            textBox_膨張.Text = "" + trackBar_膨張.Value;
            膨張();
        }

        private void TextChanged_二値化(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_二値化.Text, out isnumber))
                if (isnumber >= trackBar_二値化.Minimum && isnumber <=trackBar_二値化.Maximum) 
                {
                    trackBar_二値化.Value = (int)isnumber;
                    二値化();
                }
        }

        private void Scroll_二値化(object sender, EventArgs e)
        {
            textBox_二値化.Text = "" + trackBar_二値化.Value;
            二値化();
        }

        private void OnClick実行ボタン(object sender, EventArgs e)
        {
            膨張と二値化();
        }
        private void 膨張()
        {
            IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_膨張.Value, trackBar_膨張.Value, (int)trackBar_膨張.Value / 2, (int)trackBar_膨張.Value / 2, ElementShape.Rect);
            IplImage sample = 編集前.Clone();
            Cv.Dilate(sample, sample, element, 1);
            表示中 = sample.Clone();
            pictureBoxIpl1.ImageIpl = 表示中;
            sample.Dispose();
            element.Dispose();
        }
        private void 二値化()
        {
            IplImage sample = 編集前.Clone();
            Cv.Threshold(sample, sample, trackBar_二値化.Value, 255, ThresholdType.Binary);
            表示中 = sample.Clone();
            pictureBoxIpl1.ImageIpl = 表示中;
            sample.Dispose();
        }
        private void 膨張と二値化()
        {
            IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_膨張.Value, trackBar_膨張.Value, (int)trackBar_膨張.Value / 2, (int)trackBar_膨張.Value / 2, ElementShape.Rect);
            IplImage sample = 編集前.Clone();
            /*
            //膨張してから二値化
            Cv.Dilate(sample, sample, element, 1);
            Cv.Threshold(sample, sample, trackBar_二値化.Value, 255, ThresholdType.Binary);
            */
            //二値化してから膨張
            Cv.Threshold(sample, sample, trackBar_二値化.Value, 255, ThresholdType.Binary);
            Cv.Dilate(sample, sample, element, 1);
            
            編集後 = sample.Clone();
            pictureBoxIpl1.ImageIpl = 編集後;
            sample.Dispose();
            element.Dispose();
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
                色.Text = ""+ c.B;
                textBox_x.Text = "" + (cp.X - pictureBoxIpl1.Location.X);
                textBox_y.Text = "" + (cp.Y - pictureBoxIpl1.Location.Y);
            }
        }

        private void TextChanged_x(object sender, EventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                double isnumber_x,isnumber_y;
                if (double.TryParse(textBox_x.Text, out isnumber_x) && double.TryParse(textBox_y.Text, out isnumber_y))
                    if ((isnumber_x >= 0 && isnumber_x <= pictureBoxIpl1.ImageIpl.Width) && (isnumber_y >= 0 && isnumber_y <= pictureBoxIpl1.ImageIpl.Height))
                    {
                        CvColor  c = pictureBoxIpl1.ImageIpl[(int)isnumber_y,(int)isnumber_x];
                        色.Text = "" + c.B;
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y+pictureBoxIpl1.Location.Y));
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
                        CvColor c = pictureBoxIpl1.ImageIpl[(int)isnumber_y,(int)isnumber_x];
                        色.Text = "" + c.B;
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y + pictureBoxIpl1.Location.Y));
                        //マウスポインタの位置を設定する
                        System.Windows.Forms.Cursor.Position = mp;
                    }
            }
        }

    }


}
