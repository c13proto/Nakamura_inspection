namespace 中村さん手法sample
{
    partial class 検査対象画像画面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.textBox_サイズ = new System.Windows.Forms.TextBox();
            this.textBox_元画像TH = new System.Windows.Forms.TextBox();
            this.trackBar_元画像TH = new System.Windows.Forms.TrackBar();
            this.trackBar_サイズ = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TopHat実行ボタン = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar_回数 = new System.Windows.Forms.TrackBar();
            this.textBox_回数 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar_TopHatTH = new System.Windows.Forms.TrackBar();
            this.textBox_TopHatTH = new System.Windows.Forms.TextBox();
            this.label_座標 = new System.Windows.Forms.Label();
            this.色 = new System.Windows.Forms.Label();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.button_全て実行 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_元画像TH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_サイズ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_回数)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TopHatTH)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(99, 10);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(295, 293);
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.Click += new System.EventHandler(this.OnClick_pictureBoxIpl1);
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_pictureBoxIpl1);
            // 
            // textBox_サイズ
            // 
            this.textBox_サイズ.Location = new System.Drawing.Point(50, 25);
            this.textBox_サイズ.Name = "textBox_サイズ";
            this.textBox_サイズ.Size = new System.Drawing.Size(16, 19);
            this.textBox_サイズ.TabIndex = 1;
            this.textBox_サイズ.Text = "10";
            this.textBox_サイズ.TextChanged += new System.EventHandler(this.TextChanged_サイズ);
            // 
            // textBox_元画像TH
            // 
            this.textBox_元画像TH.Location = new System.Drawing.Point(57, 169);
            this.textBox_元画像TH.Name = "textBox_元画像TH";
            this.textBox_元画像TH.Size = new System.Drawing.Size(25, 19);
            this.textBox_元画像TH.TabIndex = 2;
            this.textBox_元画像TH.Text = "20";
            this.textBox_元画像TH.TextChanged += new System.EventHandler(this.TextChanged_元画像TH);
            // 
            // trackBar_元画像TH
            // 
            this.trackBar_元画像TH.AutoSize = false;
            this.trackBar_元画像TH.Location = new System.Drawing.Point(5, 189);
            this.trackBar_元画像TH.Maximum = 255;
            this.trackBar_元画像TH.Name = "trackBar_元画像TH";
            this.trackBar_元画像TH.Size = new System.Drawing.Size(79, 22);
            this.trackBar_元画像TH.TabIndex = 3;
            this.trackBar_元画像TH.Value = 20;
            this.trackBar_元画像TH.Scroll += new System.EventHandler(this.Scroll_元画像TH);
            // 
            // trackBar_サイズ
            // 
            this.trackBar_サイズ.AutoSize = false;
            this.trackBar_サイズ.Location = new System.Drawing.Point(5, 46);
            this.trackBar_サイズ.Maximum = 20;
            this.trackBar_サイズ.Minimum = 1;
            this.trackBar_サイズ.Name = "trackBar_サイズ";
            this.trackBar_サイズ.Size = new System.Drawing.Size(79, 20);
            this.trackBar_サイズ.TabIndex = 4;
            this.trackBar_サイズ.Value = 10;
            this.trackBar_サイズ.Scroll += new System.EventHandler(this.Scroll_サイズ);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "<オープン処理>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "<二値化>";
            // 
            // TopHat実行ボタン
            // 
            this.TopHat実行ボタン.Location = new System.Drawing.Point(5, 113);
            this.TopHat実行ボタン.Name = "TopHat実行ボタン";
            this.TopHat実行ボタン.Size = new System.Drawing.Size(75, 23);
            this.TopHat実行ボタン.TabIndex = 7;
            this.TopHat実行ボタン.Text = "TopHat実行";
            this.TopHat実行ボタン.UseVisualStyleBackColor = true;
            this.TopHat実行ボタン.Click += new System.EventHandler(this.OnClickTopHat実行ボタン);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "サイズ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "回数";
            // 
            // trackBar_回数
            // 
            this.trackBar_回数.AutoSize = false;
            this.trackBar_回数.Location = new System.Drawing.Point(5, 87);
            this.trackBar_回数.Maximum = 20;
            this.trackBar_回数.Minimum = 1;
            this.trackBar_回数.Name = "trackBar_回数";
            this.trackBar_回数.Size = new System.Drawing.Size(79, 20);
            this.trackBar_回数.TabIndex = 10;
            this.trackBar_回数.Value = 1;
            this.trackBar_回数.Scroll += new System.EventHandler(this.Scroll_回数);
            // 
            // textBox_回数
            // 
            this.textBox_回数.Location = new System.Drawing.Point(50, 66);
            this.textBox_回数.Name = "textBox_回数";
            this.textBox_回数.Size = new System.Drawing.Size(16, 19);
            this.textBox_回数.TabIndex = 9;
            this.textBox_回数.Text = "1";
            this.textBox_回数.TextChanged += new System.EventHandler(this.TextChanged_回数);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "元画像";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "TopHat";
            // 
            // trackBar_TopHatTH
            // 
            this.trackBar_TopHatTH.AutoSize = false;
            this.trackBar_TopHatTH.Location = new System.Drawing.Point(5, 231);
            this.trackBar_TopHatTH.Maximum = 255;
            this.trackBar_TopHatTH.Name = "trackBar_TopHatTH";
            this.trackBar_TopHatTH.Size = new System.Drawing.Size(79, 22);
            this.trackBar_TopHatTH.TabIndex = 14;
            this.trackBar_TopHatTH.Value = 20;
            this.trackBar_TopHatTH.Scroll += new System.EventHandler(this.Scroll_TopHatTH);
            // 
            // textBox_TopHatTH
            // 
            this.textBox_TopHatTH.Location = new System.Drawing.Point(57, 211);
            this.textBox_TopHatTH.Name = "textBox_TopHatTH";
            this.textBox_TopHatTH.Size = new System.Drawing.Size(25, 19);
            this.textBox_TopHatTH.TabIndex = 13;
            this.textBox_TopHatTH.Text = "20";
            this.textBox_TopHatTH.TextChanged += new System.EventHandler(this.TextChanged_TopHatTH);
            // 
            // label_座標
            // 
            this.label_座標.AutoSize = true;
            this.label_座標.Location = new System.Drawing.Point(7, 291);
            this.label_座標.Name = "label_座標";
            this.label_座標.Size = new System.Drawing.Size(27, 12);
            this.label_座標.TabIndex = 16;
            this.label_座標.Text = "(x,y)";
            // 
            // 色
            // 
            this.色.AutoSize = true;
            this.色.Location = new System.Drawing.Point(72, 312);
            this.色.Name = "色";
            this.色.Size = new System.Drawing.Size(10, 12);
            this.色.TabIndex = 17;
            this.色.Text = "?";
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(40, 309);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(26, 19);
            this.textBox_y.TabIndex = 19;
            this.textBox_y.Text = "y";
            this.textBox_y.TextChanged += new System.EventHandler(this.TextChanged_y);
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(7, 309);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(27, 19);
            this.textBox_x.TabIndex = 18;
            this.textBox_x.Text = "x";
            this.textBox_x.TextChanged += new System.EventHandler(this.TextChanged_x);
            // 
            // button_全て実行
            // 
            this.button_全て実行.Location = new System.Drawing.Point(5, 259);
            this.button_全て実行.Name = "button_全て実行";
            this.button_全て実行.Size = new System.Drawing.Size(75, 23);
            this.button_全て実行.TabIndex = 20;
            this.button_全て実行.Text = "全て実行";
            this.button_全て実行.UseVisualStyleBackColor = true;
            this.button_全て実行.Click += new System.EventHandler(this.OnClick_全て実行);
            // 
            // 検査対象画像画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(415, 351);
            this.Controls.Add(this.button_全て実行);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.色);
            this.Controls.Add(this.label_座標);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar_TopHatTH);
            this.Controls.Add(this.textBox_TopHatTH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar_回数);
            this.Controls.Add(this.textBox_回数);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TopHat実行ボタン);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_サイズ);
            this.Controls.Add(this.trackBar_元画像TH);
            this.Controls.Add(this.textBox_元画像TH);
            this.Controls.Add(this.textBox_サイズ);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "検査対象画像画面";
            this.Text = "検査画像画面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_元画像TH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_サイズ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_回数)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TopHatTH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.TextBox textBox_サイズ;
        private System.Windows.Forms.TextBox textBox_元画像TH;
        private System.Windows.Forms.TrackBar trackBar_元画像TH;
        private System.Windows.Forms.TrackBar trackBar_サイズ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TopHat実行ボタン;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar_回数;
        private System.Windows.Forms.TextBox textBox_回数;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar_TopHatTH;
        private System.Windows.Forms.TextBox textBox_TopHatTH;
        private System.Windows.Forms.Label label_座標;
        private System.Windows.Forms.Label 色;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Button button_全て実行;
    }
}