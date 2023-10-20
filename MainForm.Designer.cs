
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
            this.dgvConsignments = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dvgOrders = new System.Windows.Forms.DataGridView();
            this.exitButton = new System.Windows.Forms.Button();
            this.addConsignment = new System.Windows.Forms.Button();
            this.updateConsignment = new System.Windows.Forms.Button();
            this.removeConsignment = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.showOrdersComboBox = new System.Windows.Forms.ComboBox();
            this.deleteOrder = new System.Windows.Forms.Button();
            this.addOrderButton = new System.Windows.Forms.Button();
            this.updateOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignments)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgOrders)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConsignments
            // 
            this.dgvConsignments.AllowUserToAddRows = false;
            this.dgvConsignments.AllowUserToDeleteRows = false;
            this.dgvConsignments.AllowUserToResizeColumns = false;
            this.dgvConsignments.AllowUserToResizeRows = false;
            this.dgvConsignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsignments.Location = new System.Drawing.Point(-3, 32);
            this.dgvConsignments.Name = "dgvConsignments";
            this.dgvConsignments.ReadOnly = true;
            this.dgvConsignments.RowHeadersVisible = false;
            this.dgvConsignments.RowHeadersWidth = 51;
            this.dgvConsignments.RowTemplate.Height = 24;
            this.dgvConsignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsignments.Size = new System.Drawing.Size(510, 431);
            this.dgvConsignments.TabIndex = 0;
            this.dgvConsignments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsignments_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvConsignments);
            this.panel1.Location = new System.Drawing.Point(7, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 463);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consignments";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkOrange;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dvgOrders);
            this.panel2.Location = new System.Drawing.Point(516, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 462);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(321, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orders";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dvgOrders
            // 
            this.dvgOrders.AllowUserToAddRows = false;
            this.dvgOrders.AllowUserToDeleteRows = false;
            this.dvgOrders.AllowUserToResizeColumns = false;
            this.dvgOrders.AllowUserToResizeRows = false;
            this.dvgOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgOrders.Location = new System.Drawing.Point(0, 34);
            this.dvgOrders.Name = "dvgOrders";
            this.dvgOrders.ReadOnly = true;
            this.dvgOrders.RowHeadersVisible = false;
            this.dvgOrders.RowHeadersWidth = 51;
            this.dvgOrders.RowTemplate.Height = 24;
            this.dvgOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgOrders.Size = new System.Drawing.Size(676, 429);
            this.dvgOrders.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(1161, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(31, 29);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // addConsignment
            // 
            this.addConsignment.BackColor = System.Drawing.Color.White;
            this.addConsignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addConsignment.ForeColor = System.Drawing.Color.Black;
            this.addConsignment.Location = new System.Drawing.Point(7, 523);
            this.addConsignment.Name = "addConsignment";
            this.addConsignment.Size = new System.Drawing.Size(196, 35);
            this.addConsignment.TabIndex = 5;
            this.addConsignment.Text = "Add new consignment";
            this.addConsignment.UseVisualStyleBackColor = false;
            this.addConsignment.Click += new System.EventHandler(this.addConsignment_Click);
            // 
            // updateConsignment
            // 
            this.updateConsignment.BackColor = System.Drawing.Color.White;
            this.updateConsignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateConsignment.ForeColor = System.Drawing.Color.Black;
            this.updateConsignment.Location = new System.Drawing.Point(209, 523);
            this.updateConsignment.Name = "updateConsignment";
            this.updateConsignment.Size = new System.Drawing.Size(186, 35);
            this.updateConsignment.TabIndex = 6;
            this.updateConsignment.Text = "Update consignment";
            this.updateConsignment.UseVisualStyleBackColor = false;
            this.updateConsignment.Click += new System.EventHandler(this.updateConsignment_Click);
            // 
            // removeConsignment
            // 
            this.removeConsignment.BackColor = System.Drawing.Color.White;
            this.removeConsignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeConsignment.ForeColor = System.Drawing.Color.Black;
            this.removeConsignment.Location = new System.Drawing.Point(401, 523);
            this.removeConsignment.Name = "removeConsignment";
            this.removeConsignment.Size = new System.Drawing.Size(194, 35);
            this.removeConsignment.TabIndex = 7;
            this.removeConsignment.Text = "Delete consignment";
            this.removeConsignment.UseVisualStyleBackColor = false;
            this.removeConsignment.Click += new System.EventHandler(this.removeConsignment_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.White;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.ForeColor = System.Drawing.Color.Chocolate;
            this.name.Location = new System.Drawing.Point(7, 4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(59, 25);
            this.name.TabIndex = 8;
            this.name.Text = "Store";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.updateOrder);
            this.panel3.Controls.Add(this.deleteOrder);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.showOrdersComboBox);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.addOrderButton);
            this.panel3.Controls.Add(this.exitButton);
            this.panel3.Controls.Add(this.updateConsignment);
            this.panel3.Controls.Add(this.name);
            this.panel3.Controls.Add(this.removeConsignment);
            this.panel3.Controls.Add(this.addConsignment);
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1198, 566);
            this.panel3.TabIndex = 9;
            // 
            // showOrdersComboBox
            // 
            this.showOrdersComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showOrdersComboBox.FormattingEnabled = true;
            this.showOrdersComboBox.Items.AddRange(new object[] {
            "Only consignment\'s orders",
            "All orders"});
            this.showOrdersComboBox.Location = new System.Drawing.Point(72, 4);
            this.showOrdersComboBox.Name = "showOrdersComboBox";
            this.showOrdersComboBox.Size = new System.Drawing.Size(241, 28);
            this.showOrdersComboBox.TabIndex = 12;
            this.showOrdersComboBox.SelectedIndexChanged += new System.EventHandler(this.showOrdersComboBox_SelectedIndexChanged);
            // 
            // deleteOrder
            // 
            this.deleteOrder.BackColor = System.Drawing.Color.White;
            this.deleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteOrder.ForeColor = System.Drawing.Color.Black;
            this.deleteOrder.Location = new System.Drawing.Point(1000, 523);
            this.deleteOrder.Name = "deleteOrder";
            this.deleteOrder.Size = new System.Drawing.Size(192, 35);
            this.deleteOrder.TabIndex = 11;
            this.deleteOrder.Text = "Delete order";
            this.deleteOrder.UseVisualStyleBackColor = false;
            this.deleteOrder.Click += new System.EventHandler(this.deleteOrder_Click);
            // 
            // addOrderButton
            // 
            this.addOrderButton.BackColor = System.Drawing.Color.White;
            this.addOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addOrderButton.ForeColor = System.Drawing.Color.Black;
            this.addOrderButton.Location = new System.Drawing.Point(601, 523);
            this.addOrderButton.Name = "addOrderButton";
            this.addOrderButton.Size = new System.Drawing.Size(201, 35);
            this.addOrderButton.TabIndex = 10;
            this.addOrderButton.Text = "Add order";
            this.addOrderButton.UseVisualStyleBackColor = false;
            this.addOrderButton.Click += new System.EventHandler(this.addOrderButton_Click);
            // 
            // updateOrder
            // 
            this.updateOrder.BackColor = System.Drawing.Color.White;
            this.updateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateOrder.ForeColor = System.Drawing.Color.Black;
            this.updateOrder.Location = new System.Drawing.Point(808, 523);
            this.updateOrder.Name = "updateOrder";
            this.updateOrder.Size = new System.Drawing.Size(186, 35);
            this.updateOrder.TabIndex = 13;
            this.updateOrder.Text = "Update order";
            this.updateOrder.UseVisualStyleBackColor = false;
            this.updateOrder.Click += new System.EventHandler(this.updateOrder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(1209, 577);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignments)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgOrders)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsignments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dvgOrders;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button addConsignment;
        private System.Windows.Forms.Button updateConsignment;
        private System.Windows.Forms.Button removeConsignment;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button addOrderButton;
        private System.Windows.Forms.Button deleteOrder;
        private System.Windows.Forms.ComboBox showOrdersComboBox;
        private System.Windows.Forms.Button updateOrder;
    }
}

