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
            this.comboBoxSearchWorker = new System.Windows.Forms.ComboBox();
            this.textBoxSearchWorker = new System.Windows.Forms.TextBox();
            this.buttonSearchWorker = new System.Windows.Forms.Button();
            this.buttonDeleteWorker = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 845F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 565F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1238, 693);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listViewWorkers, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(79, 17);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(841, 561);
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
            this.listViewWorkers.Location = new System.Drawing.Point(2, 79);
            this.listViewWorkers.Margin = new System.Windows.Forms.Padding(2);
            this.listViewWorkers.Name = "listViewWorkers";
            this.listViewWorkers.Size = new System.Drawing.Size(837, 480);
            this.listViewWorkers.TabIndex = 0;
            this.listViewWorkers.UseCompatibleStateImageBehavior = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.46421F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.53579F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel3.Controls.Add(this.buttonDeleteWorker, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxSearchWorker, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxSearchWorker, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonSearchWorker, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(837, 55);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // comboBoxSearchWorker
            // 
            this.comboBoxSearchWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSearchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.comboBoxSearchWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSearchWorker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxSearchWorker.ForeColor = System.Drawing.Color.Gainsboro;
            this.comboBoxSearchWorker.FormattingEnabled = true;
            this.comboBoxSearchWorker.Location = new System.Drawing.Point(283, 14);
            this.comboBoxSearchWorker.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSearchWorker.Name = "comboBoxSearchWorker";
            this.comboBoxSearchWorker.Size = new System.Drawing.Size(180, 27);
            this.comboBoxSearchWorker.TabIndex = 0;
            // 
            // textBoxSearchWorker
            // 
            this.textBoxSearchWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSearchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.textBoxSearchWorker.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchWorker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSearchWorker.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxSearchWorker.Location = new System.Drawing.Point(491, 17);
            this.textBoxSearchWorker.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearchWorker.Name = "textBoxSearchWorker";
            this.textBoxSearchWorker.Size = new System.Drawing.Size(164, 20);
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
            this.buttonSearchWorker.Location = new System.Drawing.Point(681, 12);
            this.buttonSearchWorker.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearchWorker.Name = "buttonSearchWorker";
            this.buttonSearchWorker.Size = new System.Drawing.Size(134, 31);
            this.buttonSearchWorker.TabIndex = 2;
            this.buttonSearchWorker.Text = "Search";
            this.buttonSearchWorker.UseVisualStyleBackColor = false;
            this.buttonSearchWorker.Click += new System.EventHandler(this.buttonSearchWorker_Click);
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
            this.buttonDeleteWorker.Location = new System.Drawing.Point(2, 12);
            this.buttonDeleteWorker.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteWorker.Name = "buttonDeleteWorker";
            this.buttonDeleteWorker.Size = new System.Drawing.Size(134, 31);
            this.buttonDeleteWorker.TabIndex = 3;
            this.buttonDeleteWorker.Text = "DeleteWorker";
            this.buttonDeleteWorker.UseVisualStyleBackColor = false;
            this.buttonDeleteWorker.Click += new System.EventHandler(this.buttonDeleteWorker_Click);
            // 
            // FormSearchWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1238, 693);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
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