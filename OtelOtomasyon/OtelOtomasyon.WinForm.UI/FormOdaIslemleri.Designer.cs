namespace OtelOtomasyon.WinForm.UI
{
    partial class FormOdaIslemleri
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOdaAd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOdaTur = new System.Windows.Forms.ComboBox();
            this.cbOzellik = new System.Windows.Forms.ComboBox();
            this.cbKat = new System.Windows.Forms.ComboBox();
            this.cbAktif = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.bntGüncelle = new System.Windows.Forms.Button();
            this.dgvOdalar = new System.Windows.Forms.DataGridView();
            this.bntYeni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdalar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oda Ad";
            // 
            // txtOdaAd
            // 
            this.txtOdaAd.Location = new System.Drawing.Point(140, 62);
            this.txtOdaAd.Name = "txtOdaAd";
            this.txtOdaAd.Size = new System.Drawing.Size(121, 25);
            this.txtOdaAd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Oda Tür";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Oda Özellik";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Dolu/Boş";
            // 
            // cbOdaTur
            // 
            this.cbOdaTur.FormattingEnabled = true;
            this.cbOdaTur.Location = new System.Drawing.Point(140, 106);
            this.cbOdaTur.Name = "cbOdaTur";
            this.cbOdaTur.Size = new System.Drawing.Size(121, 25);
            this.cbOdaTur.TabIndex = 6;
            // 
            // cbOzellik
            // 
            this.cbOzellik.FormattingEnabled = true;
            this.cbOzellik.Location = new System.Drawing.Point(140, 150);
            this.cbOzellik.Name = "cbOzellik";
            this.cbOzellik.Size = new System.Drawing.Size(121, 25);
            this.cbOzellik.TabIndex = 7;
            // 
            // cbKat
            // 
            this.cbKat.FormattingEnabled = true;
            this.cbKat.Location = new System.Drawing.Point(140, 194);
            this.cbKat.Name = "cbKat";
            this.cbKat.Size = new System.Drawing.Size(121, 25);
            this.cbKat.TabIndex = 8;
            // 
            // cbAktif
            // 
            this.cbAktif.FormattingEnabled = true;
            this.cbAktif.Items.AddRange(new object[] {
            "Dolu",
            "Boş"});
            this.cbAktif.Location = new System.Drawing.Point(140, 238);
            this.cbAktif.Name = "cbAktif";
            this.cbAktif.Size = new System.Drawing.Size(121, 25);
            this.cbAktif.TabIndex = 9;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(140, 314);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 33);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Ekle";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(302, 314);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(77, 33);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // bntGüncelle
            // 
            this.bntGüncelle.Location = new System.Drawing.Point(221, 314);
            this.bntGüncelle.Name = "bntGüncelle";
            this.bntGüncelle.Size = new System.Drawing.Size(75, 33);
            this.bntGüncelle.TabIndex = 12;
            this.bntGüncelle.Text = "Güncelle";
            this.bntGüncelle.UseVisualStyleBackColor = true;
            this.bntGüncelle.Click += new System.EventHandler(this.bntGüncelle_Click);
            // 
            // dgvOdalar
            // 
            this.dgvOdalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdalar.Location = new System.Drawing.Point(352, 62);
            this.dgvOdalar.Name = "dgvOdalar";
            this.dgvOdalar.RowTemplate.Height = 24;
            this.dgvOdalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOdalar.Size = new System.Drawing.Size(490, 201);
            this.dgvOdalar.TabIndex = 13;
            this.dgvOdalar.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOdalar_CellMouseClick);
            // 
            // bntYeni
            // 
            this.bntYeni.Location = new System.Drawing.Point(56, 314);
            this.bntYeni.Name = "bntYeni";
            this.bntYeni.Size = new System.Drawing.Size(75, 33);
            this.bntYeni.TabIndex = 14;
            this.bntYeni.Text = "Yeni";
            this.bntYeni.UseVisualStyleBackColor = true;
            this.bntYeni.Click += new System.EventHandler(this.bntYeni_Click);
            // 
            // FormOdaIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 625);
            this.Controls.Add(this.bntYeni);
            this.Controls.Add(this.dgvOdalar);
            this.Controls.Add(this.bntGüncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.cbAktif);
            this.Controls.Add(this.cbKat);
            this.Controls.Add(this.cbOzellik);
            this.Controls.Add(this.cbOdaTur);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOdaAd);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOdaIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oda İşlemleri";
            this.Load += new System.EventHandler(this.FormOdaIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdalar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOdaAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbOdaTur;
        private System.Windows.Forms.ComboBox cbOzellik;
        private System.Windows.Forms.ComboBox cbKat;
        private System.Windows.Forms.ComboBox cbAktif;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button bntGüncelle;
        private System.Windows.Forms.DataGridView dgvOdalar;
        private System.Windows.Forms.Button bntYeni;
    }
}