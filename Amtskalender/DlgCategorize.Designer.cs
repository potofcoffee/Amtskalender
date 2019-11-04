namespace Amtskalender
{
    partial class DlgCategorize
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMonthNext = new System.Windows.Forms.Button();
            this.btnMonthPrev = new System.Windows.Forms.Button();
            this.ReferenceDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.CalendarList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SourceItemsList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SourceItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourceItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMonthNext);
            this.groupBox2.Controls.Add(this.btnMonthPrev);
            this.groupBox2.Controls.Add(this.ReferenceDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CalendarList);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1009, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datenquelle";
            // 
            // btnMonthNext
            // 
            this.btnMonthNext.Location = new System.Drawing.Point(722, 19);
            this.btnMonthNext.Name = "btnMonthNext";
            this.btnMonthNext.Size = new System.Drawing.Size(16, 23);
            this.btnMonthNext.TabIndex = 10;
            this.btnMonthNext.Text = ">";
            this.btnMonthNext.UseVisualStyleBackColor = true;
            this.btnMonthNext.Click += new System.EventHandler(this.btnMonthNext_Click);
            // 
            // btnMonthPrev
            // 
            this.btnMonthPrev.Location = new System.Drawing.Point(494, 19);
            this.btnMonthPrev.Name = "btnMonthPrev";
            this.btnMonthPrev.Size = new System.Drawing.Size(16, 23);
            this.btnMonthPrev.TabIndex = 9;
            this.btnMonthPrev.Text = "<";
            this.btnMonthPrev.UseVisualStyleBackColor = true;
            this.btnMonthPrev.Click += new System.EventHandler(this.btnMonthPrev_Click);
            // 
            // ReferenceDate
            // 
            this.ReferenceDate.CustomFormat = "MMMM yyyy";
            this.ReferenceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ReferenceDate.Location = new System.Drawing.Point(516, 20);
            this.ReferenceDate.Name = "ReferenceDate";
            this.ReferenceDate.Size = new System.Drawing.Size(200, 20);
            this.ReferenceDate.TabIndex = 3;
            this.ReferenceDate.ValueChanged += new System.EventHandler(this.ReferenceDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monat";
            // 
            // CalendarList
            // 
            this.CalendarList.FormattingEnabled = true;
            this.CalendarList.Location = new System.Drawing.Point(63, 20);
            this.CalendarList.Name = "CalendarList";
            this.CalendarList.Size = new System.Drawing.Size(380, 21);
            this.CalendarList.Sorted = true;
            this.CalendarList.TabIndex = 1;
            this.CalendarList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kalender";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(946, 865);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox4);
            this.groupBox1.Controls.Add(this.listBox5);
            this.groupBox1.Controls.Add(this.listBox6);
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.SourceItemsList);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 784);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kategorien zuweisen";
            // 
            // listBox4
            // 
            this.listBox4.AllowDrop = true;
            this.listBox4.DisplayMember = "Subject";
            this.listBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 20;
            this.listBox4.Location = new System.Drawing.Point(669, 552);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(326, 204);
            this.listBox4.TabIndex = 19;
            // 
            // listBox5
            // 
            this.listBox5.AllowDrop = true;
            this.listBox5.DisplayMember = "Subject";
            this.listBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 20;
            this.listBox5.Location = new System.Drawing.Point(337, 552);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(326, 204);
            this.listBox5.TabIndex = 18;
            // 
            // listBox6
            // 
            this.listBox6.AllowDrop = true;
            this.listBox6.DisplayMember = "Subject";
            this.listBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox6.FormattingEnabled = true;
            this.listBox6.ItemHeight = 20;
            this.listBox6.Location = new System.Drawing.Point(5, 552);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(326, 204);
            this.listBox6.TabIndex = 17;
            // 
            // listBox3
            // 
            this.listBox3.AllowDrop = true;
            this.listBox3.DisplayMember = "Subject";
            this.listBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(669, 319);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(326, 204);
            this.listBox3.TabIndex = 16;
            // 
            // listBox2
            // 
            this.listBox2.AllowDrop = true;
            this.listBox2.DisplayMember = "Subject";
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(337, 319);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(326, 204);
            this.listBox2.TabIndex = 15;
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.DisplayMember = "Subject";
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(5, 319);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(326, 204);
            this.listBox1.TabIndex = 14;
            // 
            // SourceItemsList
            // 
            this.SourceItemsList.AllowDrop = true;
            this.SourceItemsList.DisplayMember = "Subject";
            this.SourceItemsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceItemsList.FormattingEnabled = true;
            this.SourceItemsList.ItemHeight = 20;
            this.SourceItemsList.Location = new System.Drawing.Point(7, 20);
            this.SourceItemsList.Name = "SourceItemsList";
            this.SourceItemsList.Size = new System.Drawing.Size(990, 264);
            this.SourceItemsList.TabIndex = 13;
            this.SourceItemsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppointmentItemDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(669, 536);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mitarbeiter/Gremien/Dienstbesprechung";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(337, 536);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Bibelarbeit/Erwachsenenbildung";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 536);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Unterricht/Jugendarbeit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(669, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Seelsorge/Diakonie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Amtshandlungen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gottesdienst/Taufe/Abendmahl";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // DlgCategorize
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1030, 900);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgCategorize";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Termine kategorisieren";
            this.Load += new System.EventHandler(this.DlgCategorize_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourceItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker ReferenceDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CalendarList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox SourceItemsList;
        private System.Windows.Forms.BindingSource SourceItemsBindingSource;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnMonthPrev;
        private System.Windows.Forms.Button btnMonthNext;
    }
}