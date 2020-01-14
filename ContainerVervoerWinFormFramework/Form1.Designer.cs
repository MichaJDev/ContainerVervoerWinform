namespace ContainerVervoerWinFormFramework
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
            this.label1 = new System.Windows.Forms.Label();
            this.shipWidth = new System.Windows.Forms.Label();
            this.shipHeight = new System.Windows.Forms.Label();
            this.shipWidthTb = new System.Windows.Forms.TextBox();
            this.shipHeightTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.containerCapacityTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.containerTypeCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.containers = new System.Windows.Forms.ListBox();
            this.Submit = new System.Windows.Forms.Button();
            this.AddToList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ship";
            // 
            // shipWidth
            // 
            this.shipWidth.AutoSize = true;
            this.shipWidth.Location = new System.Drawing.Point(21, 50);
            this.shipWidth.Name = "shipWidth";
            this.shipWidth.Size = new System.Drawing.Size(35, 13);
            this.shipWidth.TabIndex = 1;
            this.shipWidth.Text = "Width";
            // 
            // shipHeight
            // 
            this.shipHeight.AutoSize = true;
            this.shipHeight.Location = new System.Drawing.Point(22, 76);
            this.shipHeight.Name = "shipHeight";
            this.shipHeight.Size = new System.Drawing.Size(38, 13);
            this.shipHeight.TabIndex = 2;
            this.shipHeight.Text = "Height";
            // 
            // shipWidthTb
            // 
            this.shipWidthTb.Location = new System.Drawing.Point(111, 47);
            this.shipWidthTb.Name = "shipWidthTb";
            this.shipWidthTb.Size = new System.Drawing.Size(72, 20);
            this.shipWidthTb.TabIndex = 3;
            this.shipWidthTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ForceNumeral);
            // 
            // shipHeightTb
            // 
            this.shipHeightTb.Location = new System.Drawing.Point(111, 73);
            this.shipHeightTb.Name = "shipHeightTb";
            this.shipHeightTb.Size = new System.Drawing.Size(72, 20);
            this.shipHeightTb.TabIndex = 4;
            this.shipHeightTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ForceNumeral);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Container";
            // 
            // containerCapacityTb
            // 
            this.containerCapacityTb.Location = new System.Drawing.Point(79, 151);
            this.containerCapacityTb.Name = "containerCapacityTb";
            this.containerCapacityTb.Size = new System.Drawing.Size(104, 20);
            this.containerCapacityTb.TabIndex = 6;
            this.containerCapacityTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ForceNumeral);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Capacity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "KG";
            // 
            // containerTypeCb
            // 
            this.containerTypeCb.FormattingEnabled = true;
            this.containerTypeCb.Items.AddRange(new object[] {
            "Normal",
            "Cooled",
            "Valuable",
            "CoolableAndValuable"});
            this.containerTypeCb.Location = new System.Drawing.Point(79, 177);
            this.containerTypeCb.Name = "containerTypeCb";
            this.containerTypeCb.Size = new System.Drawing.Size(104, 21);
            this.containerTypeCb.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Type";
            // 
            // containers
            // 
            this.containers.FormattingEnabled = true;
            this.containers.Location = new System.Drawing.Point(217, 12);
            this.containers.Name = "containers";
            this.containers.Size = new System.Drawing.Size(236, 186);
            this.containers.TabIndex = 11;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(378, 204);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 12;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // AddToList
            // 
            this.AddToList.Location = new System.Drawing.Point(131, 204);
            this.AddToList.Name = "AddToList";
            this.AddToList.Size = new System.Drawing.Size(75, 23);
            this.AddToList.TabIndex = 15;
            this.AddToList.Text = "Add To List";
            this.AddToList.UseVisualStyleBackColor = true;
            this.AddToList.Click += new System.EventHandler(this.AddToList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 233);
            this.Controls.Add(this.AddToList);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.containers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.containerTypeCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.containerCapacityTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shipHeightTb);
            this.Controls.Add(this.shipWidthTb);
            this.Controls.Add(this.shipHeight);
            this.Controls.Add(this.shipWidth);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Berend Bootje: Container Vervoer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label shipWidth;
        private System.Windows.Forms.Label shipHeight;
        private System.Windows.Forms.TextBox shipWidthTb;
        private System.Windows.Forms.TextBox shipHeightTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox containerCapacityTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox containerTypeCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox containers;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button AddToList;
    }
}

