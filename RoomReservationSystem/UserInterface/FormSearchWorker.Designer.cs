namespace RoomReservationSystem.UserInterface
{
    partial class FormSearchWorker
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewWorkers = new System.Windows.Forms.ListView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteWorker = new System.Windows.Forms.Button();
            this.comboBoxSearchWorker = new System.Windows.Forms.ComboBox();
            this.textBoxSearchWorker = new System.Windows.Forms.TextBox();
            this.buttonSearchWorker = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1127F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 344F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 695F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1651, 853);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listViewWorkers, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(106, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1121, 691);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listViewWorkers
            // 
            this.listViewWorkers.AccessibleName = "listViewWorkers";
            this.listViewWorkers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.listViewWorkers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewWorkers.ForeColor = System.Drawing.SystemColors.Menu;
            this.listViewWorkers.FullRowSelect = true;
            this.listViewWorkers.HideSelection = false;
            this.listViewWorkers.Location = new System.Drawing.Point(3, 97);
            this.listViewWorkers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewWorkers.Name = "listViewWorkers";
            this.listViewWorkers.Size = new System.Drawing.Size(1115, 592);
            this.listViewWorkers.TabIndex = 0;
            this.listViewWorkers.UseCompatibleStateImageBehavior = false;
            this.listViewWorkers.DoubleClick += new System.EventHandler(this.listViewWorkers_DoubleClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.59392F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.40608F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tableLayoutPanel3.Controls.Add(this.buttonDeleteWorker, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxSearchWorker, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxSearchWorker, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonSearchWorker, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1115, 69);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonDeleteWorker
            // 
            this.buttonDeleteWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDeleteWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.buttonDeleteWorker.FlatAppearance.BorderSize = 0;
            this.buttonDeleteWorker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.buttonDeleteWorker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.buttonDeleteWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteWorker.Font = new System.Drawing.Font("Calibri", 14F);
            this.buttonDeleteWorker.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonDeleteWorker.Location = new System.Drawing.Point(94, 15);
            this.buttonDeleteWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteWorker.Name = "buttonDeleteWorker";
            this.buttonDeleteWorker.Size = new System.Drawing.Size(179, 38);
            this.buttonDeleteWorker.TabIndex = 3;
            this.buttonDeleteWorker.Text = "Delete worker";
            this.buttonDeleteWorker.UseVisualStyleBackColor = false;
            this.buttonDeleteWorker.Click += new System.EventHandler(this.buttonDeleteWorker_Click);
            // 
            // comboBoxSearchWorker
            // 
            this.comboBoxSearchWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSearchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.comboBoxSearchWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSearchWorker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxSearchWorker.ForeColor = System.Drawing.Color.Gainsboro;
            this.comboBoxSearchWorker.FormattingEnabled = true;
            this.comboBoxSearchWorker.Location = new System.Drawing.Point(387, 18);
            this.comboBoxSearchWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSearchWorker.Name = "comboBoxSearchWorker";
            this.comboBoxSearchWorker.Size = new System.Drawing.Size(239, 32);
            this.comboBoxSearchWorker.TabIndex = 0;
            // 
            // textBoxSearchWorker
            // 
            this.textBoxSearchWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSearchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.textBoxSearchWorker.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchWorker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSearchWorker.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxSearchWorker.Location = new System.Drawing.Point(651, 22);
            this.textBoxSearchWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearchWorker.Name = "textBoxSearchWorker";
            this.textBoxSearchWorker.Size = new System.Drawing.Size(219, 25);
            this.textBoxSearchWorker.TabIndex = 1;
            // 
            // buttonSearchWorker
            // 
            this.buttonSearchWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSearchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.buttonSearchWorker.FlatAppearance.BorderSize = 0;
            this.buttonSearchWorker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.buttonSearchWorker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.buttonSearchWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchWorker.Font = new System.Drawing.Font("Calibri", 14F);
            this.buttonSearchWorker.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSearchWorker.Location = new System.Drawing.Point(904, 15);
            this.buttonSearchWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearchWorker.Name = "buttonSearchWorker";
            this.buttonSearchWorker.Size = new System.Drawing.Size(179, 38);
            this.buttonSearchWorker.TabIndex = 2;
            this.buttonSearchWorker.Text = "Search";
            this.buttonSearchWorker.UseVisualStyleBackColor = false;
            this.buttonSearchWorker.Click += new System.EventHandler(this.buttonSearchWorker_Click);
            // 
            // FormSearchWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1651, 853);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSearchWorker";
            this.Text = "SEARCH WORKERS";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView listViewWorkers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox comboBoxSearchWorker;
        private System.Windows.Forms.TextBox textBoxSearchWorker;
        private System.Windows.Forms.Button buttonSearchWorker;
        private System.Windows.Forms.Button buttonDeleteWorker;
    }
}