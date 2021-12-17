namespace RoomReservationSystem.UserInterface
{
    partial class FormSearchClient
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
            this.listViewClients = new System.Windows.Forms.ListView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxSearchClient = new System.Windows.Forms.ComboBox();
            this.textBoxSearchClient = new System.Windows.Forms.TextBox();
            this.buttonSearchClient = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1061, 693);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listViewClients, 0, 2);
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
            // listViewClients
            // 
            this.listViewClients.AccessibleName = "listViewClients";
            this.listViewClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.listViewClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClients.HideSelection = false;
            this.listViewClients.Location = new System.Drawing.Point(2, 79);
            this.listViewClients.Margin = new System.Windows.Forms.Padding(2);
            this.listViewClients.Name = "listViewClients";
            this.listViewClients.Size = new System.Drawing.Size(837, 480);
            this.listViewClients.TabIndex = 0;
            this.listViewClients.UseCompatibleStateImageBehavior = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.54362F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.45638F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel3.Controls.Add(this.comboBoxSearchClient, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxSearchClient, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonSearchClient, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(837, 55);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // comboBoxSearchClient
            // 
            this.comboBoxSearchClient.AccessibleName = "comboBoxSearchClient";
            this.comboBoxSearchClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSearchClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.comboBoxSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSearchClient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxSearchClient.ForeColor = System.Drawing.Color.Gainsboro;
            this.comboBoxSearchClient.FormattingEnabled = true;
            this.comboBoxSearchClient.Location = new System.Drawing.Point(113, 14);
            this.comboBoxSearchClient.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSearchClient.Name = "comboBoxSearchClient";
            this.comboBoxSearchClient.Size = new System.Drawing.Size(180, 27);
            this.comboBoxSearchClient.TabIndex = 0;
            // 
            // textBoxSearchClient
            // 
            this.textBoxSearchClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSearchClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.textBoxSearchClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchClient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSearchClient.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxSearchClient.Location = new System.Drawing.Point(356, 17);
            this.textBoxSearchClient.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearchClient.Name = "textBoxSearchClient";
            this.textBoxSearchClient.Size = new System.Drawing.Size(164, 20);
            this.textBoxSearchClient.TabIndex = 1;
            // 
            // buttonSearchClient
            // 
            this.buttonSearchClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSearchClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))));
            this.buttonSearchClient.FlatAppearance.BorderSize = 0;
            this.buttonSearchClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.buttonSearchClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(108)))));
            this.buttonSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchClient.Font = new System.Drawing.Font("Calibri", 14F);
            this.buttonSearchClient.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSearchClient.Location = new System.Drawing.Point(574, 7);
            this.buttonSearchClient.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearchClient.Name = "buttonSearchClient";
            this.buttonSearchClient.Size = new System.Drawing.Size(174, 41);
            this.buttonSearchClient.TabIndex = 2;
            this.buttonSearchClient.Text = "Search";
            this.buttonSearchClient.UseVisualStyleBackColor = false;
            this.buttonSearchClient.Click += new System.EventHandler(this.buttonSearchClient_Click);
            // 
            // FormSearchClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1061, 693);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSearchClient";
            this.Text = "SEARCH CLIENTS";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView listViewClients;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox comboBoxSearchClient;
        private System.Windows.Forms.TextBox textBoxSearchClient;
        private System.Windows.Forms.Button buttonSearchClient;
    }
}