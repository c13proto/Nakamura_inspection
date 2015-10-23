namespace 中村さん手法sample
{
    partial class メイン画面
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.テンプレ参照ボタン = new System.Windows.Forms.Button();
            this.検査画像参照ボタン = new System.Windows.Forms.Button();
            this.比較開始ボタン = new System.Windows.Forms.Button();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.label_座標 = new System.Windows.Forms.Label();
            this.色 = new System.Windows.Forms.Label();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.評価画面ボタン = new System.Windows.Forms.Button();
            this.checkBox_点数表示 = new System.Windows.Forms.CheckBox();
            this.button_csv = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox_ノイズ除去 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // テンプレ参照ボタン
            // 
            this.テンプレ参照ボタン.Location = new System.Drawing.Point(12, 66);
            this.テンプレ参照ボタン.Name = "テンプレ参照ボタン";
            this.テンプレ参照ボタン.Size = new System.Drawing.Size(75, 23);
            this.テンプレ参照ボタン.TabIndex = 0;
            this.テンプレ参照ボタン.Text = "テンプレ参照";
            this.テンプレ参照ボタン.UseVisualStyleBackColor = true;
            this.テンプレ参照ボタン.Click += new System.EventHandler(this.OnClickテンプレ参照);
            // 
            // 検査画像参照ボタン
            // 
            this.検査画像参照ボタン.Location = new System.Drawing.Point(12, 96);
            this.検査画像参照ボタン.Name = "検査画像参照ボタン";
            this.検査画像参照ボタン.Size = new System.Drawing.Size(75, 23);
            this.検査画像参照ボタン.TabIndex = 1;
            this.検査画像参照ボタン.Text = "検査参照";
            this.検査画像参照ボタン.UseVisualStyleBackColor = true;
            this.検査画像参照ボタン.Click += new System.EventHandler(this.OnClick検査参照);
            // 
            // 比較開始ボタン
            // 
            this.比較開始ボタン.Location = new System.Drawing.Point(12, 126);
            this.比較開始ボタン.Name = "比較開始ボタン";
            this.比較開始ボタン.Size = new System.Drawing.Size(75, 23);
            this.比較開始ボタン.TabIndex = 2;
            this.比較開始ボタン.Text = "比較開始";
            this.比較開始ボタン.UseVisualStyleBackColor = true;
            this.比較開始ボタン.Click += new System.EventHandler(this.OnClick比較開始ボタン);
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(94, 11);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(295, 293);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 3;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.Click += new System.EventHandler(this.OnClick_pictureBoxIpl1);
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_pictureBoxIpl1);
            // 
            // label_座標
            // 
            this.label_座標.AutoSize = true;
            this.label_座標.Location = new System.Drawing.Point(10, 223);
            this.label_座標.Name = "label_座標";
            this.label_座標.Size = new System.Drawing.Size(27, 12);
            this.label_座標.TabIndex = 4;
            this.label_座標.Text = "(x,y)";
            // 
            // 色
            // 
            this.色.AutoSize = true;
            this.色.Location = new System.Drawing.Point(74, 241);
            this.色.Name = "色";
            this.色.Size = new System.Drawing.Size(10, 12);
            this.色.TabIndex = 5;
            this.色.Text = "?";
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(42, 238);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(26, 19);
            this.textBox_y.TabIndex = 13;
            this.textBox_y.Text = "y";
            this.textBox_y.TextChanged += new System.EventHandler(this.TextChanged_y);
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(9, 238);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(27, 19);
            this.textBox_x.TabIndex = 12;
            this.textBox_x.Text = "x";
            this.textBox_x.TextChanged += new System.EventHandler(this.TextChanged_x);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "ノイズ除去:9";
            // 
            // 評価画面ボタン
            // 
            this.評価画面ボタン.Location = new System.Drawing.Point(12, 264);
            this.評価画面ボタン.Name = "評価画面ボタン";
            this.評価画面ボタン.Size = new System.Drawing.Size(75, 23);
            this.評価画面ボタン.TabIndex = 17;
            this.評価画面ボタン.Text = "評価画面";
            this.評価画面ボタン.UseVisualStyleBackColor = true;
            this.評価画面ボタン.Click += new System.EventHandler(this.OnClick_評価画面);
            // 
            // checkBox_点数表示
            // 
            this.checkBox_点数表示.AutoSize = true;
            this.checkBox_点数表示.Checked = true;
            this.checkBox_点数表示.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_点数表示.Location = new System.Drawing.Point(12, 156);
            this.checkBox_点数表示.Name = "checkBox_点数表示";
            this.checkBox_点数表示.Size = new System.Drawing.Size(72, 16);
            this.checkBox_点数表示.TabIndex = 18;
            this.checkBox_点数表示.Text = "点数表示";
            this.checkBox_点数表示.UseVisualStyleBackColor = true;
            // 
            // button_csv
            // 
            this.button_csv.Location = new System.Drawing.Point(13, 12);
            this.button_csv.Name = "button_csv";
            this.button_csv.Size = new System.Drawing.Size(75, 23);
            this.button_csv.TabIndex = 19;
            this.button_csv.Text = "csv参照";
            this.button_csv.UseVisualStyleBackColor = true;
            this.button_csv.Click += new System.EventHandler(this.OnClick_csv参照);
            // 
            // textBox_ノイズ除去
            // 
            this.textBox_ノイズ除去.Location = new System.Drawing.Point(12, 192);
            this.textBox_ノイズ除去.Name = "textBox_ノイズ除去";
            this.textBox_ノイズ除去.Size = new System.Drawing.Size(27, 19);
            this.textBox_ノイズ除去.TabIndex = 20;
            this.textBox_ノイズ除去.Text = "9";
            this.textBox_ノイズ除去.TextChanged += new System.EventHandler(this.TextChanged_ノイズ除去);
            // 
            // メイン画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(405, 316);
            this.Controls.Add(this.textBox_ノイズ除去);
            this.Controls.Add(this.button_csv);
            this.Controls.Add(this.checkBox_点数表示);
            this.Controls.Add(this.評価画面ボタン);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.色);
            this.Controls.Add(this.label_座標);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Controls.Add(this.比較開始ボタン);
            this.Controls.Add(this.検査画像参照ボタン);
            this.Controls.Add(this.テンプレ参照ボタン);
            this.Name = "メイン画面";
            this.Text = "メイン画面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button テンプレ参照ボタン;
        private System.Windows.Forms.Button 検査画像参照ボタン;
        private System.Windows.Forms.Button 比較開始ボタン;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Label label_座標;
        private System.Windows.Forms.Label 色;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 評価画面ボタン;
        private System.Windows.Forms.CheckBox checkBox_点数表示;
        private System.Windows.Forms.Button button_csv;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBox_ノイズ除去;
    }
}

