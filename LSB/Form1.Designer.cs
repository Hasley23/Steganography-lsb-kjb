namespace LSB
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.encodedPic = new System.Windows.Forms.PictureBox();
            this.srcPic = new System.Windows.Forms.PictureBox();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.encBtn = new System.Windows.Forms.Button();
            this.decBtn = new System.Windows.Forms.Button();
            this.saveEncoded = new System.Windows.Forms.Button();
            this.clearText = new System.Windows.Forms.RichTextBox();
            this.decText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KDB_encode = new System.Windows.Forms.Button();
            this.KDB_decode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcPic)).BeginInit();
            this.SuspendLayout();
            // 
            // encodedPic
            // 
            this.encodedPic.BackColor = System.Drawing.SystemColors.Window;
            this.encodedPic.BackgroundImage = global::LSB.Properties.Resources.File;
            this.encodedPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.encodedPic.Location = new System.Drawing.Point(268, 32);
            this.encodedPic.Name = "encodedPic";
            this.encodedPic.Size = new System.Drawing.Size(250, 250);
            this.encodedPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.encodedPic.TabIndex = 0;
            this.encodedPic.TabStop = false;
            // 
            // srcPic
            // 
            this.srcPic.BackColor = System.Drawing.SystemColors.Window;
            this.srcPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("srcPic.BackgroundImage")));
            this.srcPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.srcPic.Location = new System.Drawing.Point(12, 32);
            this.srcPic.Name = "srcPic";
            this.srcPic.Size = new System.Drawing.Size(250, 250);
            this.srcPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.srcPic.TabIndex = 1;
            this.srcPic.TabStop = false;
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(12, 288);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 29);
            this.openFileBtn.TabIndex = 2;
            this.openFileBtn.Text = "Open file";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // encBtn
            // 
            this.encBtn.Location = new System.Drawing.Point(12, 319);
            this.encBtn.Name = "encBtn";
            this.encBtn.Size = new System.Drawing.Size(75, 28);
            this.encBtn.TabIndex = 3;
            this.encBtn.Text = "Encode";
            this.encBtn.UseVisualStyleBackColor = true;
            this.encBtn.Click += new System.EventHandler(this.encBtn_Click);
            // 
            // decBtn
            // 
            this.decBtn.Location = new System.Drawing.Point(12, 353);
            this.decBtn.Name = "decBtn";
            this.decBtn.Size = new System.Drawing.Size(75, 31);
            this.decBtn.TabIndex = 4;
            this.decBtn.Text = "Decode";
            this.decBtn.UseVisualStyleBackColor = true;
            this.decBtn.Click += new System.EventHandler(this.decBtn_Click);
            // 
            // saveEncoded
            // 
            this.saveEncoded.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.saveEncoded.Location = new System.Drawing.Point(12, 390);
            this.saveEncoded.Name = "saveEncoded";
            this.saveEncoded.Size = new System.Drawing.Size(75, 57);
            this.saveEncoded.TabIndex = 5;
            this.saveEncoded.Text = "Save encoded";
            this.saveEncoded.UseVisualStyleBackColor = true;
            this.saveEncoded.Click += new System.EventHandler(this.saveEncoded_Click);
            // 
            // clearText
            // 
            this.clearText.Location = new System.Drawing.Point(93, 308);
            this.clearText.Name = "clearText";
            this.clearText.Size = new System.Drawing.Size(169, 134);
            this.clearText.TabIndex = 6;
            this.clearText.Text = "";
            // 
            // decText
            // 
            this.decText.Location = new System.Drawing.Point(268, 308);
            this.decText.Name = "decText";
            this.decText.ReadOnly = true;
            this.decText.Size = new System.Drawing.Size(250, 134);
            this.decText.TabIndex = 7;
            this.decText.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Source image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Encoded image:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Text to encode:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Decoded text:";
            // 
            // KDB_encode
            // 
            this.KDB_encode.Location = new System.Drawing.Point(12, 453);
            this.KDB_encode.Name = "KDB_encode";
            this.KDB_encode.Size = new System.Drawing.Size(506, 28);
            this.KDB_encode.TabIndex = 12;
            this.KDB_encode.Text = "Encode (Cutter Jordan Bossen)";
            this.KDB_encode.UseVisualStyleBackColor = true;
            this.KDB_encode.Click += new System.EventHandler(this.KDB_encode_Click);
            // 
            // KDB_decode
            // 
            this.KDB_decode.Location = new System.Drawing.Point(12, 487);
            this.KDB_decode.Name = "KDB_decode";
            this.KDB_decode.Size = new System.Drawing.Size(506, 28);
            this.KDB_decode.TabIndex = 13;
            this.KDB_decode.Text = "Decode (Cutter Jordan Bossen)";
            this.KDB_decode.UseVisualStyleBackColor = true;
            this.KDB_decode.Click += new System.EventHandler(this.KDB_decode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 523);
            this.Controls.Add(this.KDB_decode);
            this.Controls.Add(this.KDB_encode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decText);
            this.Controls.Add(this.clearText);
            this.Controls.Add(this.saveEncoded);
            this.Controls.Add(this.decBtn);
            this.Controls.Add(this.encBtn);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.srcPic);
            this.Controls.Add(this.encodedPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(546, 570);
            this.MinimumSize = new System.Drawing.Size(546, 570);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSB/СJB (Steganography)";
            ((System.ComponentModel.ISupportInitialize)(this.encodedPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox encodedPic;
        private System.Windows.Forms.PictureBox srcPic;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Button encBtn;
        private System.Windows.Forms.Button decBtn;
        private System.Windows.Forms.Button saveEncoded;
        private System.Windows.Forms.RichTextBox clearText;
        private System.Windows.Forms.RichTextBox decText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button KDB_encode;
        private System.Windows.Forms.Button KDB_decode;
    }
}

