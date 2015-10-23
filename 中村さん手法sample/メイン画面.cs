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
using System.Runtime.InteropServices;
using OpenCvSharp.Blob;
namespace 中村さん手法sample
{

    public partial class メイン画面 : Form
    {
        public static IplImage テンプレ画像;
        public static IplImage 検査対象画像;
        public static IplImage 検査結果画像;
        public static IplImage 検査結果画像_color;

        public static int[,] 正解座標;
        public const int 傷のMAXsize = 500;

        public static string csvファイル名 = "";

        public メイン画面()
        {
            InitializeComponent();
            //read_csv();
        }
        private void OnClickテンプレ参照(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ファイル名をタイトルバーに設定
                this.Text = dialog.SafeFileName;
                //OpenCV処理
                if (テンプレ画像 != null) テンプレ画像.Dispose();
                テンプレ画像 = new IplImage(dialog.FileName, LoadMode.GrayScale);
                テンプレート画像画面.Instance.Show();
                pictureBoxIpl1.ImageIpl = テンプレ画像;
            }
        }

        private void OnClick検査参照(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ファイル名をタイトルバーに設定
                this.Text = dialog.SafeFileName;
                //OpenCV処理
                if (検査対象画像 != null) 検査対象画像.Dispose();
                検査対象画像 = new IplImage(dialog.FileName, LoadMode.GrayScale);
                検査対象画像画面.Instance.Show();
                pictureBoxIpl1.ImageIpl = 検査対象画像;
            }
        }

        private void OnClick比較開始ボタン(object sender, EventArgs e)
        {


            
            if (検査対象画像画面.編集後 != null && テンプレート画像画面.編集後 != null)
            {
                IplImage target =検査対象画像画面.編集後.Clone();//この時点では輪郭が白
                IplImage mask = テンプレート画像画面.編集後.Clone();//この時点では輪郭が白
                //IplImage ng = 検査対象画像画面.編集後.Clone();
                //Cv.Not(検査対象画像画面.編集後, ng);
                
                Cv.Not(テンプレート画像画面.編集後, mask);//正解画像の輪郭を黒にする

                Cv.Zero(target);
                //target.Add(検査対象画像画面.編集後,target,mask);
                Cv.Copy(検査対象画像画面.編集後,target,mask);//mask(サンプルの白黒反転)の白と検査対象の白部分の重複部のみが映しだされる

                if (検査結果画像 != null) 検査結果画像.Dispose();
                検査結果画像 = target.Clone();
                pictureBoxIpl1.ImageIpl = 検査結果画像;
                target.Dispose();
                mask.Dispose();
            }

            ノイズ除去();

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

        private void ノイズ除去()
        {
            if (検査結果画像 != null)
            {
                CvMemStorage storage = new CvMemStorage();
                IplImage color = new IplImage(new CvSize(検査結果画像.Width, 検査結果画像.Height), BitDepth.U8,3);
                //IplImage forlabel = new IplImage(new CvSize(検査結果画像.Width, 検査結果画像.Height), BitDepth.U8, 1);
                IplImage sample = 検査結果画像.Clone();
                color.Zero();
                CvBlobs blobs = new CvBlobs(sample);
                CvFont font = new CvFont(FontFace.HersheyComplex, 0.5, 0.5);
                int score;

                blobs.FilterByArea(int.Parse(textBox_ノイズ除去.Text), 傷のMAXsize);

                //blobs.FilterLabels(forlabel);
                blobs.RenderBlobs(sample,color);//デバッグ用
                
                検査結果画像_color = color.Clone();
                var sample_color=color.Clone();
                Cv.CvtColor(テンプレート画像画面.編集後, sample_color, ColorConversion.GrayToBgr);
                Cv.Add(sample_color, color, 検査結果画像_color, テンプレート画像画面.編集後);//検査結果画像をテンプレート画像に合成させてわかり易く表示

                if (checkBox_点数表示.Checked)
                {
                    点数計算(blobs, ref 検査結果画像_color, out score);
                    Cv.PutText(検査結果画像_color, "score= " + score.ToString(), new CvPoint(10, 120), font, new CvColor(0, 0, 0));
                } 
               

                pictureBoxIpl1.ImageIpl = 検査結果画像_color;
                //foreach (KeyValuePair<int, CvBlob> item in blobs) System.Diagnostics.Debug.WriteLine("{0}:({1},{2})\n", item.Key, (int)item.Value.Centroid.X, (int)item.Value.Centroid.Y);
                
                storage.Dispose();
                font.Dispose();
                color.Dispose();
                //forlabel.Dispose();
                sample.Dispose();
                blobs.Clear();
            }
        }



        private void OnClick_評価画面(object sender, EventArgs e)
        {
            if (テンプレ画像 != null && 検査対象画像 != null)
            {
                評価画面.Instance.Show();
            }
        }
        public void read_csv(string path)
        {
            var csvRecords = new System.Collections.ArrayList();

            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(path))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                        csvRecords.Add(sr.ReadLine());
                }
                System.Diagnostics.Debug.WriteLine("csv読み込み開始");
                正解座標 = new int[csvRecords.Count, 2];
                //正解座標リスト = new List<int[]>();
                for (int i = 0; i < csvRecords.Count; i++)
                {
                    var values = csvRecords[i].ToString().Split(',');
                    正解座標[i, 0] = int.Parse(values[0]);
                    正解座標[i, 1] = int.Parse(values[1]);
                    //int[] xy = { int.Parse(values[0]), int.Parse(values[1]) };
                    //正解座標リスト.Add(xy);
                }
                for (int i = 0; i < 正解座標.Length / 2; i++) System.Diagnostics.Debug.WriteLine("{0}\t{1}", 正解座標[i, 0], 正解座標[i, 1]);
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

        }

        private void 点数計算(CvBlobs blobs,ref IplImage color,out int score)
        {
            int[,] 正解座標2 = (int[,])正解座標.Clone();
            int 正解数 = 0;
            int 不正回数 = 0;

            foreach (CvBlob item in blobs.Values)
            {
                //float r = 0;

                //if (item.Rect.Height >= item.Rect.Width) r = item.Rect.Height / 2;
                //else r = item.Rect.Width / 2;

                ////Cv.Circle(color, item.Centroid, (int)r, new CvColor(0, 255, 0));

                //for (int j = 0; j < 正解座標2.Length / 2; j++)
                //{
                //    if (正解座標2[j, 0] != 0 &&(Math.Pow(item.Centroid.X - 正解座標2[j, 0], 2) + Math.Pow(item.Centroid.Y - 正解座標2[j, 1], 2) < r * r))
                //    {//重心から半径横幅か高さの長い方/2の円に正解座標が入っているかを判定．（外接円描きたいけどむずい）
                //        Cv.Circle(color, item.Centroid, (int)r, new CvColor(0, 0, 255),2);
                //        正解数++;
                //        正解座標2[j, 0] = 正解座標2[j, 1] = 0;
                //        //CvPoint center=new CvPoint((int)item.Centroid.X,(int)item.Centroid.Y);
                //        j = 正解座標2.Length;//ひとつ照合確定したら，このfor文を抜けて次のラベルの検査に移動
                //    }
                //}

                //for (int j = 0; j < 正解座標2.Length / 2; j++)
                //{
                //    if (
                //        正解座標2[j, 0] != 0 &&
                //        ((item.Rect.Left <= 正解座標2[j, 0]) && item.Rect.Right >= 正解座標2[j, 0]) &&
                //        ((item.Rect.Top <= 正解座標2[j, 1]) && item.Rect.Bottom >= 正解座標2[j, 1])
                //        )
                //    {//ラベルした四角形内に正解座標がいたら
                //        正解数++;
                //        正解座標2[j, 0] = 正解座標2[j, 1] = 0;
                //        j = 正解座標2.Length;//ひとつ照合確定したら，このfor文を抜けて次のラベルの検査に移動
                //    }
                //}

                CvContourPolygon polygon = item.Contour.ConvertToPolygon();
                CvPoint2D32f circleCenter;
                float circleRadius;
                GetEnclosingCircle(polygon, out circleCenter, out circleRadius);
                for (int j = 0; j < 正解座標2.Length / 2; j++)
                {
                    if (正解座標2[j, 0] != 0 && (Math.Pow(circleCenter.X - 正解座標2[j, 0], 2) + Math.Pow(circleCenter.Y - 正解座標2[j, 1], 2) < circleRadius * circleRadius))
                    {//外接円内にあったら
                        Cv.Circle(color, item.Centroid, (int)circleRadius, new CvColor(0, 0, 255), 2);
                        正解数++;
                        正解座標2[j, 0] = 正解座標2[j, 1] = 0;
                        j = 正解座標2.Length;//ひとつ照合確定したら，このfor文を抜けて次のラベルの検査に移動
                    }
                }
            }
            for (int i = 0; i < 正解座標2.Length / 2; i++)
            {//検出されなかった座標が残る
                 System.Diagnostics.Debug.WriteLine(正解座標2[i, 0] + "," + 正解座標2[i, 1]);
            }

            不正回数 = blobs.Count - 正解数;

            score= (int)((float)(正解数 - 不正回数) * (10000.0f / (正解座標.Length/2)));
        }
        public static void GetEnclosingCircle(IEnumerable<CvPoint> points, out CvPoint2D32f center, out float radius)
        {
            var pointsArray = points.ToArray();
            using (var pointsMat = new CvMat(pointsArray.Length, 1, MatrixType.S32C2, pointsArray))
            {
                Cv.MinEnclosingCircle(pointsMat, out center, out radius);
            }
        }

        private void OnClick_csv参照(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "csvファイル|*.csv|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Text = dialog.SafeFileName;
                csvファイル名 = dialog.SafeFileName.Substring(0, dialog.SafeFileName.IndexOf("."));

                read_csv(dialog.FileName);
            }
        }

        private void TextChanged_ノイズ除去(object sender, EventArgs e)
        {
            label1.Text = "ノイズ除去:" + textBox_ノイズ除去.Text;
        }


    }
}
