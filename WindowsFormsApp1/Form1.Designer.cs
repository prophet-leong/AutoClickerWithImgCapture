namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.topX = new System.Windows.Forms.Label();
            this.topY = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetSSButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bottomY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bottomX = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.timeStep = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(55, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "PositionUp X:";
            // 
            // topX
            // 
            this.topX.AutoSize = true;
            this.topX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.topX.Location = new System.Drawing.Point(160, 74);
            this.topX.Name = "topX";
            this.topX.Size = new System.Drawing.Size(18, 18);
            this.topX.TabIndex = 1;
            this.topX.Text = "X";
            // 
            // topY
            // 
            this.topY.AutoSize = true;
            this.topY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.topY.Location = new System.Drawing.Point(330, 74);
            this.topY.Name = "topY";
            this.topY.Size = new System.Drawing.Size(17, 18);
            this.topY.TabIndex = 3;
            this.topY.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(226, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "PositionUp Y:";
            // 
            // GetSSButton
            // 
            this.GetSSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GetSSButton.Location = new System.Drawing.Point(380, 74);
            this.GetSSButton.Name = "GetSSButton";
            this.GetSSButton.Padding = new System.Windows.Forms.Padding(1);
            this.GetSSButton.Size = new System.Drawing.Size(109, 35);
            this.GetSSButton.TabIndex = 4;
            this.GetSSButton.Text = "ScreenShot";
            this.GetSSButton.UseVisualStyleBackColor = true;
            this.GetSSButton.Click += new System.EventHandler(this.GetSSButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(38, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 222);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // bottomY
            // 
            this.bottomY.AutoSize = true;
            this.bottomY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bottomY.Location = new System.Drawing.Point(330, 92);
            this.bottomY.Name = "bottomY";
            this.bottomY.Size = new System.Drawing.Size(17, 18);
            this.bottomY.TabIndex = 9;
            this.bottomY.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(206, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "PositionDown Y:";
            // 
            // bottomX
            // 
            this.bottomX.AutoSize = true;
            this.bottomX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bottomX.Location = new System.Drawing.Point(160, 92);
            this.bottomX.Name = "bottomX";
            this.bottomX.Size = new System.Drawing.Size(18, 18);
            this.bottomX.TabIndex = 7;
            this.bottomX.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(35, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "PositionDown X:";
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Save.Location = new System.Drawing.Point(903, 356);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(94, 36);
            this.Save.TabIndex = 10;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // timeStep
            // 
            this.timeStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timeStep.Location = new System.Drawing.Point(506, 79);
            this.timeStep.Name = "timeStep";
            this.timeStep.Size = new System.Drawing.Size(150, 24);
            this.timeStep.TabIndex = 11;
            this.timeStep.Text = "1000";
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addButton.Location = new System.Drawing.Point(675, 74);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 35);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(506, 131);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 222);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Position,
            this.ImageName,
            this.Time});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 23);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(485, 196);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Position
            // 
            this.Position.Text = "Position";
            this.Position.Width = 150;
            // 
            // ImageName
            // 
            this.ImageName.Text = "ImgName";
            // 
            // Time
            // 
            this.Time.Text = "Time";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartButton.Location = new System.Drawing.Point(423, 395);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(105, 49);
            this.StartButton.TabIndex = 14;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 456);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.timeStep);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.bottomY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bottomX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GetSSButton);
            this.Controls.Add(this.topY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topX);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label topX;
        private System.Windows.Forms.Label topY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetSSButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label bottomY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label bottomX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox timeStep;
        private System.Windows.Forms.Button addButton;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Position;
        private System.Windows.Forms.ColumnHeader ImageName;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer timer1;
    }
}

