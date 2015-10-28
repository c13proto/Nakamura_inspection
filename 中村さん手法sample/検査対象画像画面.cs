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
        IplImage 明るさ調整後;
        private static 検査対象画像画面 _instance;

        public 検査対象画像画面()
        {
            
            InitializeComponent();
            if(編集前!=null)編集前.Dispose();
            編集前=メイン画面.検査対象画像.Clone();
            明るさ調整後 = 明るさ調整(編集前);
            編集後 = トップハットを二値化(明るさ調整後);
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
            pictureBoxIpl1.ImageIpl = トップハット処理(明るさ調整後);
        }
        private void OnClick_全て実行(object sender, EventArgs e)
        {
            if (編集後 != null) 編集後.Dispose();
            明るさ調整後 = 明るさ調整(編集前);
            編集後 = トップハットを二値化(明るさ調整後);
        }

        IplImage 明るさ調整(IplImage src)
        {
            IplImage sample = src.Clone();
            sample = コントラスト調整(sample, double.Parse(textBox_cont.Text));
            if (textBox_bright.Text != "0") sample=brightness(sample, double.Parse(textBox_bright.Text));
            
            明るさ調整後 = sample;
            return sample;
        }
        IplImage コントラスト調整(IplImage src, double 倍率)
        {
            IplImage sample = src.Clone();
            int width = src.Width;
            int height = src.Height;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    double val;
                    CvScalar cs = Cv.Get2D(src, y, x);
                    val = cs.Val0 * 倍率;
                    if (val > 255) cs.Val0 = 255;
                    else cs.Val0 = val;
                    Cv.Set2D(sample, y, x, cs);
                }
            //for (int num = 0; num < 4; num++)images[num].Dispose();元のものに影響するっぽい
            return sample;
        }
        IplImage brightness(IplImage src, double 目標)
        {//中心近くの9ピクセルから輝度調整
            IplImage sample = src.Clone();
            int width = src.Width;
            int height = src.Height;
            int center_x = 640 / 2;
            int center_y = 480 / 2;
            CvSize roiSize = new CvSize(640,480);


            for (int roi = 0; roi < 4;roi++ )
            {
                double[] vals = new double[9];
                double average = 0;
                double diff = 0;

                CvPoint roiPoint;
                if (roi == 1)      roiPoint = new CvPoint(640, 0);
                else if (roi == 2) roiPoint = new CvPoint(0, 480);
                else if (roi == 3) roiPoint = new CvPoint(640, 480);
                else               roiPoint = new CvPoint(0, 0);

                Cv.SetImageROI(src, new CvRect(roiPoint, roiSize));

                vals[0] = Cv.Get2D(src, center_y - 10, center_x - 10); vals[3] = Cv.Get2D(src, center_y - 10, center_x); vals[6] = Cv.Get2D(src, center_y - 10, center_x + 10);
                vals[1] = Cv.Get2D(src, center_y, center_x - 10); vals[4] = Cv.Get2D(src, center_y, center_x); vals[7] = Cv.Get2D(src, center_y, center_x + 10);
                vals[2] = Cv.Get2D(src, center_y + 10, center_x - 10); vals[5] = Cv.Get2D(src, center_y + 10, center_x); vals[8] = Cv.Get2D(src, center_y + 10, center_x + 10);

                for (int num = 0; num < 9; num++) average += vals[num];
                average = average / 9.0;
                diff = 目標 - average;

                for (int x = 0; x < 640; x++)
                    for (int y = 0; y < 480; y++)
                    {
                        CvScalar cs = Cv.Get2D(src, y, x);
                        double val = cs.Val0 + diff;
                        if (val > 255) cs.Val0 = 255;
                        else cs.Val0 = val;
                        Cv.Set2D(sample, roiPoint.Y + y, roiPoint.X+x, cs);
                    }
                Cv.ResetImageROI(src);
                if (width == 640) break;
            }
            //if (width == 640 * 4)
            //{
            //    CvPoint roiPoint = new CvPoint(int.Parse(roi1[0]), int.Parse(roi1[1]));
            //    CvSize roiSize = new CvSize(int.Parse(roi2[0]) - int.Parse(roi1[0]), int.Parse(roi2[1]) - int.Parse(roi1[1]));

            //    Cv.SetImageROI(背景, new CvRect(roiPoint, roiSize));
            //    Cv.ResetImageROI(背景);
            //}
            return sample;
        }
        IplImage トップハット処理(IplImage src)
        {
            IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_サイズ.Value, trackBar_サイズ.Value, (int)trackBar_サイズ.Value / 2, (int)trackBar_サイズ.Value / 2, ElementShape.Rect);
            IplImage sample = src.Clone();
            IplImage temp = src.Clone();
            Cv.MorphologyEx(sample, sample, temp, element, MorphologyOperation.TopHat, trackBar_回数.Value);
            pictureBoxIpl1.ImageIpl = sample;
            temp.Dispose();
            element.Dispose();
            return sample;
        }
        IplImage オープニング処理(IplImage src)
        {
            IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_サイズ.Value, trackBar_サイズ.Value, (int)trackBar_サイズ.Value / 2, (int)trackBar_サイズ.Value / 2, ElementShape.Rect);
            IplImage sample = src.Clone();
            IplImage temp = src.Clone();
            Cv.MorphologyEx(sample, sample, temp, element, MorphologyOperation.Open, trackBar_回数.Value);

            pictureBoxIpl1.ImageIpl = sample.Clone();
            temp.Dispose();
            element.Dispose();

            return sample;
        }
        IplImage 二値化(IplImage src)
        {
            IplImage sample = src.Clone();
            Cv.Threshold(sample, sample, trackBar_元画像TH.Value, 255, ThresholdType.Binary);
            pictureBoxIpl1.ImageIpl = sample.Clone();
            return sample;
        }
        IplImage トップハットを二値化(IplImage src)
        {
            IplImage sample = src.Clone();
            IplConvKernel element = Cv.CreateStructuringElementEx(trackBar_サイズ.Value, trackBar_サイズ.Value, (int)trackBar_サイズ.Value / 2, (int)trackBar_サイズ.Value / 2, ElementShape.Rect);
            IplImage temp = src.Clone();
            Cv.MorphologyEx(sample, sample, temp, element, MorphologyOperation.TopHat, trackBar_回数.Value);

            Cv.Threshold(sample, sample, trackBar_TopHatTH.Value, 255, ThresholdType.Binary);
            temp.Dispose();
            element.Dispose();
            pictureBoxIpl1.ImageIpl = sample;
        return sample;
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


        private void ValueChanged_cont(object sender, EventArgs e)
        {
            textBox_cont.Text = (trackBar_cont.Value / 10.0).ToString();
            pictureBoxIpl1.ImageIpl = 明るさ調整(編集前);
        }
        private void TextChanged_cont(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_cont.Text, out isnumber))
                if (isnumber*10 >= trackBar_cont.Minimum&& isnumber*10 <= trackBar_cont.Maximum)
                    trackBar_cont.Value = (int)(isnumber * 10);
        }
        private void ValueChanged_bright(object sender, EventArgs e)
        {
            textBox_bright.Text = trackBar_bright.Value.ToString();
            pictureBoxIpl1.ImageIpl = 明るさ調整(編集前);
        }
        private void TextChanged_bright(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_bright.Text, out isnumber))
                if (isnumber >= trackBar_bright.Minimum && isnumber <= trackBar_bright.Maximum)
                    trackBar_bright.Value = (int)isnumber;
        }
        private void ValueChanged_サイズ(object sender, EventArgs e)
        {
            textBox_サイズ.Text = "" + trackBar_サイズ.Value;
            pictureBoxIpl1.ImageIpl = オープニング処理(明るさ調整後);
        }
        private void TextChanged_サイズ(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_サイズ.Text, out isnumber))
                if (isnumber >= trackBar_サイズ.Minimum && isnumber <= trackBar_サイズ.Maximum)
                    trackBar_サイズ.Value = (int)isnumber;
        }
        private void ValueChanged_回数(object sender, EventArgs e)
        {
            textBox_回数.Text = "" + trackBar_回数.Value;
            pictureBoxIpl1.ImageIpl = オープニング処理(明るさ調整後);
        }
        private void TextChanged_回数(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_回数.Text, out isnumber))
                if (isnumber >= trackBar_回数.Minimum && isnumber <= trackBar_回数.Maximum)
                    trackBar_回数.Value = (int)isnumber;
        }
        private void ValueChanged_元画像TH(object sender, EventArgs e)
        {
            textBox_元画像TH.Text = "" + trackBar_元画像TH.Value;
            pictureBoxIpl1.ImageIpl = 二値化(明るさ調整後);
        }
        private void TextChanged_元画像TH(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_元画像TH.Text, out isnumber))
                if (isnumber >= trackBar_元画像TH.Minimum && isnumber <= trackBar_元画像TH.Maximum)
                    trackBar_元画像TH.Value = (int)isnumber;
        }
        private void ValueChange_TopHatTH(object sender, EventArgs e)
        {
            textBox_TopHatTH.Text = "" + trackBar_TopHatTH.Value;
            pictureBoxIpl1.ImageIpl = トップハットを二値化(明るさ調整後);
            
        }
        private void TextChanged_TopHatTH(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_TopHatTH.Text, out isnumber))
                if (isnumber >= trackBar_TopHatTH.Minimum && isnumber <= trackBar_TopHatTH.Maximum)
                    trackBar_TopHatTH.Value = (int)isnumber;
        }

        private void OnClick_保存(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();//SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = textBox_cont.Text + "_" + textBox_bright.Text;//はじめのファイル名を指定する
            sfd.InitialDirectory = @"result\";//はじめに表示されるフォルダを指定する
            sfd.Filter = "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*";//[ファイルの種類]に表示される選択肢を指定する
            sfd.FilterIndex = 1;//[ファイルの種類]ではじめに「画像ファイル」が選択されているようにする
            sfd.Title = "保存先のファイルを選択してください";//タイトルを設定する
            sfd.RestoreDirectory = true;//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.OverwritePrompt = true;//既に存在するファイル名を指定したとき警告する．デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;//存在しないパスが指定されたとき警告を表示する．デフォルトでTrueなので指定する必要はない

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                System.Diagnostics.Debug.WriteLine(sfd.FileName);
                pictureBoxIpl1.ImageIpl.SaveImage(sfd.FileName);
            }
        }

    }


}
