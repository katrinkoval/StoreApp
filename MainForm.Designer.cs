
namespace StoreApp_DB_
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.allwindowButton = new System.Windows.Forms.Button();
            this.showOrdersComboBox = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvConsignments = new System.Windows.Forms.DataGridView();
            this.addConsignment = new System.Windows.Forms.Button();
            this.removeConsignment = new System.Windows.Forms.Button();
            this.updateConsignment = new System.Windows.Forms.Button();
            this.addOrderButton = new System.Windows.Forms.Button();
            this.deleteOrder = new System.Windows.Forms.Button();
            this.updateOrder = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dvgOrders = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignments)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgOrders)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.allwindowButton);
            this.panel4.Controls.Add(this.showOrdersComboBox);
            this.panel4.Controls.Add(this.name);
            this.panel4.Controls.Add(this.exitButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1205, 40);
            this.panel4.TabIndex = 15;
            // 
            // allwindowButton
            // 
            this.allwindowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.allwindowButton.BackColor = System.Drawing.Color.White;
            this.allwindowButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("allwindowButton.BackgroundImage")));
            this.allwindowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.allwindowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allwindowButton.ForeColor = System.Drawing.Color.Black;
            this.allwindowButton.Location = new System.Drawing.Point(1132, 8);
            this.allwindowButton.Name = "allwindowButton";
            this.allwindowButton.Size = new System.Drawing.Size(33, 29);
            this.allwindowButton.TabIndex = 16;
            this.allwindowButton.UseVisualStyleBackColor = false;
            this.allwindowButton.Click += new System.EventHandler(this.allwindowButton_Click);
            // 
            // showOrdersComboBox
            // 
            this.showOrdersComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showOrdersComboBox.FormattingEnabled = true;
            this.showOrdersComboBox.Items.AddRange(new object[] {
            "Only consignment\'s orders",
            "All orders"});
            this.showOrdersComboBox.Location = new System.Drawing.Point(71, 9);
            this.showOrdersComboBox.Name = "showOrdersComboBox";
            this.showOrdersComboBox.Size = new System.Drawing.Size(241, 28);
            this.showOrdersComboBox.TabIndex = 12;
            this.showOrdersComboBox.SelectedIndexChanged += new System.EventHandler(this.showOrdersComboBox_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.White;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.ForeColor = System.Drawing.Color.Chocolate;
            this.name.Location = new System.Drawing.Point(6, 12);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(59, 25);
            this.name.TabIndex = 8;
            this.name.Text = "Store";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(1171, 8);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(31, 29);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.dgvConsignments);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 562);
            this.panel1.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(338, 44);
            this.panel7.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consignments";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvConsignments
            // 
            this.dgvConsignments.AllowUserToAddRows = false;
            this.dgvConsignments.AllowUserToDeleteRows = false;
            this.dgvConsignments.AllowUserToResizeColumns = false;
            this.dgvConsignments.AllowUserToResizeRows = false;
            this.dgvConsignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsignments.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsignments.Location = new System.Drawing.Point(0, 44);
            this.dgvConsignments.Name = "dgvConsignments";
            this.dgvConsignments.ReadOnly = true;
            this.dgvConsignments.RowHeadersVisible = false;
            this.dgvConsignments.RowHeadersWidth = 51;
            this.dgvConsignments.RowTemplate.Height = 24;
            this.dgvConsignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsignments.Size = new System.Drawing.Size(338, 518);
            this.dgvConsignments.TabIndex = 0;
            this.dgvConsignments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsignments_CellClick);
            // 
            // addConsignment
            // 
            this.addConsignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addConsignment.BackColor = System.Drawing.Color.White;
            this.addConsignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addConsignment.ForeColor = System.Drawing.Color.Black;
            this.addConsignment.Location = new System.Drawing.Point(14, 8);
            this.addConsignment.Name = "addConsignment";
            this.addConsignment.Size = new System.Drawing.Size(196, 35);
            this.addConsignment.TabIndex = 5;
            this.addConsignment.Text = "Add new consignment";
            this.addConsignment.UseVisualStyleBackColor = false;
            this.addConsignment.Click += new System.EventHandler(this.addConsignment_Click);
            // 
            // removeConsignment
            // 
            this.removeConsignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.removeConsignment.BackColor = System.Drawing.Color.White;
            this.removeConsignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeConsignment.ForeColor = System.Drawing.Color.Black;
            this.removeConsignment.Location = new System.Drawing.Point(404, 8);
            this.removeConsignment.Name = "removeConsignment";
            this.removeConsignment.Size = new System.Drawing.Size(194, 35);
            this.removeConsignment.TabIndex = 7;
            this.removeConsignment.Text = "Delete consignment";
            this.removeConsignment.UseVisualStyleBackColor = false;
            this.removeConsignment.Click += new System.EventHandler(this.removeConsignment_Click);
            // 
            // updateConsignment
            // 
            this.updateConsignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.updateConsignment.BackColor = System.Drawing.Color.White;
            this.updateConsignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateConsignment.ForeColor = System.Drawing.Color.Black;
            this.updateConsignment.Location = new System.Drawing.Point(212, 8);
            this.updateConsignment.Name = "updateConsignment";
            this.updateConsignment.Size = new System.Drawing.Size(186, 35);
            this.updateConsignment.TabIndex = 6;
            this.updateConsignment.Text = "Update consignment";
            this.updateConsignment.UseVisualStyleBackColor = false;
            this.updateConsignment.Click += new System.EventHandler(this.updateConsignment_Click);
            // 
            // addOrderButton
            // 
            this.addOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addOrderButton.BackColor = System.Drawing.Color.White;
            this.addOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addOrderButton.ForeColor = System.Drawing.Color.Black;
            this.addOrderButton.Location = new System.Drawing.Point(604, 8);
            this.addOrderButton.Name = "addOrderButton";
            this.addOrderButton.Size = new System.Drawing.Size(201, 35);
            this.addOrderButton.TabIndex = 10;
            this.addOrderButton.Text = "Add order";
            this.addOrderButton.UseVisualStyleBackColor = false;
            this.addOrderButton.Click += new System.EventHandler(this.addOrderButton_Click);
            // 
            // deleteOrder
            // 
            this.deleteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteOrder.AutoSize = true;
            this.deleteOrder.BackColor = System.Drawing.Color.White;
            this.deleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteOrder.ForeColor = System.Drawing.Color.Black;
            this.deleteOrder.Location = new System.Drawing.Point(1003, 8);
            this.deleteOrder.Name = "deleteOrder";
            this.deleteOrder.Size = new System.Drawing.Size(192, 35);
            this.deleteOrder.TabIndex = 11;
            this.deleteOrder.Text = "Delete order";
            this.deleteOrder.UseVisualStyleBackColor = false;
            this.deleteOrder.Click += new System.EventHandler(this.deleteOrder_Click);
            // 
            // updateOrder
            // 
            this.updateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateOrder.BackColor = System.Drawing.Color.White;
            this.updateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateOrder.ForeColor = System.Drawing.Color.Black;
            this.updateOrder.Location = new System.Drawing.Point(811, 8);
            this.updateOrder.Name = "updateOrder";
            this.updateOrder.Size = new System.Drawing.Size(186, 35);
            this.updateOrder.TabIndex = 13;
            this.updateOrder.Text = "Update order";
            this.updateOrder.UseVisualStyleBackColor = false;
            this.updateOrder.Click += new System.EventHandler(this.updateOrder_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1209, 652);
            this.panel3.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.splitter1);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1205, 562);
            this.panel6.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.removeConsignment);
            this.panel5.Controls.Add(this.updateOrder);
            this.panel5.Controls.Add(this.addConsignment);
            this.panel5.Controls.Add(this.deleteOrder);
            this.panel5.Controls.Add(this.updateConsignment);
            this.panel5.Controls.Add(this.addOrderButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 602);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1205, 46);
            this.panel5.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.DarkOrange;
            this.panel2.Controls.Add(this.dvgOrders);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(348, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 562);
            this.panel2.TabIndex = 2;
            // 
            // dvgOrders
            // 
            this.dvgOrders.AllowUserToAddRows = false;
            this.dvgOrders.AllowUserToDeleteRows = false;
            this.dvgOrders.AllowUserToResizeColumns = false;
            this.dvgOrders.AllowUserToResizeRows = false;
            this.dvgOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgOrders.BackgroundColor = System.Drawing.Color.White;
            this.dvgOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgOrders.Location = new System.Drawing.Point(0, 44);
            this.dvgOrders.Name = "dvgOrders";
            this.dvgOrders.ReadOnly = true;
            this.dvgOrders.RowHeadersVisible = false;
            this.dvgOrders.RowHeadersWidth = 51;
            this.dvgOrders.RowTemplate.Height = 24;
            this.dvgOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgOrders.Size = new System.Drawing.Size(857, 518);
            this.dvgOrders.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(857, 44);
            this.panel8.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(407, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orders";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(338, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 562);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(1209, 652);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignments)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgOrders)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvConsignments;
        private System.Windows.Forms.Button addConsignment;
        private System.Windows.Forms.Button removeConsignment;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button updateConsignment;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button addOrderButton;
        private System.Windows.Forms.ComboBox showOrdersComboBox;
        private System.Windows.Forms.Button deleteOrder;
        private System.Windows.Forms.Button updateOrder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button allwindowButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dvgOrders;
    }
}

