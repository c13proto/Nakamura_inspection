namespace 中村さん手法sample
{
    partial class テンプレート画像画面
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
            this.textBox_膨張 = new System.Windows.Forms.TextBox();
            this.textBox_二値化 = new System.Windows.Forms.TextBox();
            this.trackBar_二値化 = new System.Windows.Forms.TrackBar();
            this.trackBar_膨張 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.実行ボタン = new System.Windows.Forms.Button();
            this.label_座標 = new System.Windows.Forms.Label();
            this.色 = new System.Windows.Forms.Label();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_二値化)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_膨張)).BeginInit();
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
            // textBox_膨張
            // 
            this.textBox_膨張.Location = new System.Drawing.Point(47, 10);
            this.textBox_膨張.Name = "textBox_膨張";
            this.textBox_膨張.Size = new System.Drawing.Size(35, 19);
            this.textBox_膨張.TabIndex = 1;
            this.textBox_膨張.Text = "3";
            this.textBox_膨張.TextChanged += new System.EventHandler(this.TextChanged_膨張);
            // 
            // textBox_二値化
            // 
            this.textBox_二値化.Location = new System.Drawing.Point(59, 66);
            this.textBox_二値化.Name = "textBox_二値化";
            this.textBox_二値化.Size = new System.Drawing.Size(34, 19);
            this.textBox_二値化.TabIndex = 2;
            this.textBox_二値化.Text = "254";
            this.textBox_二値化.TextChanged += new System.EventHandler(this.TextChanged_二値化);
            // 
            // trackBar_二値化
            // 
            this.trackBar_二値化.AutoSize = false;
            this.trackBar_二値化.Location = new System.Drawing.Point(14, 91);
            this.trackBar_二値化.Maximum = 255;
            this.trackBar_二値化.Name = "trackBar_二値化";
            this.trackBar_二値化.Size = new System.Drawing.Size(79, 22);
            this.trackBar_二値化.TabIndex = 3;
            this.trackBar_二値化.Value = 254;
            this.trackBar_二値化.Scroll += new System.EventHandler(this.Scroll_二値化);
            // 
            // trackBar_膨張
            // 
            this.trackBar_膨張.AutoSize = false;
            this.trackBar_膨張.Location = new System.Drawing.Point(12, 38);
            this.trackBar_膨張.Maximum = 20;
            this.trackBar_膨張.Minimum = 1;
            this.trackBar_膨張.Name = "trackBar_膨張";
            this.trackBar_膨張.Size = new System.Drawing.Size(79, 20);
            this.trackBar_膨張.TabIndex = 4;
            this.trackBar_膨張.Value = 3;
            this.trackBar_膨張.Scroll += new System.EventHandler(this.Scroll_膨張);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "膨張";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "二値化";
            // 
            // 実行ボタン
            // 
            this.実行ボタン.Location = new System.Drawing.Point(14, 133);
            this.実行ボタン.Name = "実行ボタン";
            this.実行ボタン.Size = new System.Drawing.Size(75, 23);
            this.実行ボタン.TabIndex = 7;
            this.実行ボタン.Text = "実行";
            this.実行ボタン.UseVisualStyleBackColor = true;
            this.実行ボタン.Click += new System.EventHandler(this.OnClick実行ボタン);
            // 
            // label_座標
            // 
            this.label_座標.AutoSize = true;
            this.label_座標.Location = new System.Drawing.Point(12, 163);
            this.label_座標.Name = "label_座標";
            this.label_座標.Size = new System.Drawing.Size(27, 12);
            this.label_座標.TabIndex = 8;
            this.label_座標.Text = "(x,y)";
            // 
            // 色
            // 
            this.色.AutoSize = true;
            this.色.Location = new System.Drawing.Point(72, 181);
            this.色.Name = "色";
            this.色.Size = new System.Drawing.Size(10, 12);
            this.色.TabIndex = 9;
            this.色.Text = "?";
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(12, 178);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(27, 19);
            this.textBox_x.TabIndex = 10;
            this.textBox_x.Text = "x";
            this.textBox_x.TextChanged += new System.EventHandler(this.TextChanged_x);
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(45, 178);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(26, 19);
            this.textBox_y.TabIndex = 11;
            this.textBox_y.Text = "y";
            this.textBox_y.TextChanged += new System.EventHandler(this.TextChanged_y);
            // 
            // テンプレート画像画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(410, 322);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.色);
            this.Controls.Add(this.label_座標);
            this.Controls.Add(this.実行ボタン);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_膨張);
            this.Controls.Add(this.trackBar_二値化);
            this.Controls.Add(this.textBox_二値化);
            this.Controls.Add(this.textBox_膨張);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "テンプレート画像画面";
            this.Text = "テンプレート画像画面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_二値化)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_膨張)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.TextBox textBox_膨張;
        private System.Windows.Forms.TextBox textBox_二値化;
        private System.Windows.Forms.TrackBar trackBar_二値化;
        private System.Windows.Forms.TrackBar trackBar_膨張;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button 実行ボタン;
        private System.Windows.Forms.Label label_座標;
        private System.Windows.Forms.Label 色;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.TextBox textBox_y;
    }
}