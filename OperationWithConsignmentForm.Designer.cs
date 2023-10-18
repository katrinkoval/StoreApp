
namespace StoreApp_DB_
{
    partial class OperationWithConsignmentForm
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
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recipientIpnTextBox = new System.Windows.Forms.TextBox();
            this.supplierIpnTextBox = new System.Windows.Forms.TextBox();
            this.recipientIpnLabel = new System.Windows.Forms.Label();
            this.supplierIpnLabel = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.recipientSurnameTextBox = new System.Windows.Forms.TextBox();
            this.recipientNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierSurnameTextBox = new System.Windows.Forms.TextBox();
            this.supplierNameTextBox = new System.Windows.Forms.TextBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.useIdLabel = new System.Windows.Forms.Label();
            this.recipientSurnameLabel = new System.Windows.Forms.Label();
            this.recipientNameLabel = new System.Windows.Forms.Label();
            this.supplierSurnameLabel = new System.Windows.Forms.Label();
            this.supplierNameLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(411, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(31, 29);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.recipientIpnTextBox);
            this.panel1.Controls.Add(this.supplierIpnTextBox);
            this.panel1.Controls.Add(this.recipientIpnLabel);
            this.panel1.Controls.Add(this.supplierIpnLabel);
            this.panel1.Controls.Add(this.button);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.recipientSurnameTextBox);
            this.panel1.Controls.Add(this.recipientNameTextBox);
            this.panel1.Controls.Add(this.supplierSurnameTextBox);
            this.panel1.Controls.Add(this.supplierNameTextBox);
            this.panel1.Controls.Add(this.dateTextBox);
            this.panel1.Controls.Add(this.numberTextBox);
            this.panel1.Controls.Add(this.useIdLabel);
            this.panel1.Controls.Add(this.recipientSurnameLabel);
            this.panel1.Controls.Add(this.recipientNameLabel);
            this.panel1.Controls.Add(this.supplierSurnameLabel);
            this.panel1.Controls.Add(this.supplierNameLabel);
            this.panel1.Controls.Add(this.dateLabel);
            this.panel1.Controls.Add(this.numberLabel);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 320);
            this.panel1.TabIndex = 5;
            // 
            // recipientIpnTextBox
            // 
            this.recipientIpnTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recipientIpnTextBox.Location = new System.Drawing.Point(184, 148);
            this.recipientIpnTextBox.Name = "recipientIpnTextBox";
            this.recipientIpnTextBox.Size = new System.Drawing.Size(257, 27);
            this.recipientIpnTextBox.TabIndex = 23;
            // 
            // supplierIpnTextBox
            // 
            this.supplierIpnTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierIpnTextBox.Location = new System.Drawing.Point(184, 116);
            this.supplierIpnTextBox.Name = "supplierIpnTextBox";
            this.supplierIpnTextBox.Size = new System.Drawing.Size(257, 27);
            this.supplierIpnTextBox.TabIndex = 22;
            // 
            // recipientIpnLabel
            // 
            this.recipientIpnLabel.AutoSize = true;
            this.recipientIpnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recipientIpnLabel.Location = new System.Drawing.Point(12, 155);
            this.recipientIpnLabel.Name = "recipientIpnLabel";
            this.recipientIpnLabel.Size = new System.Drawing.Size(116, 20);
            this.recipientIpnLabel.TabIndex = 21;
            this.recipientIpnLabel.Text = "Recipient IPN:";
            // 
            // supplierIpnLabel
            // 
            this.supplierIpnLabel.AutoSize = true;
            this.supplierIpnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierIpnLabel.Location = new System.Drawing.Point(12, 123);
            this.supplierIpnLabel.Name = "supplierIpnLabel";
            this.supplierIpnLabel.Size = new System.Drawing.Size(107, 20);
            this.supplierIpnLabel.TabIndex = 20;
            this.supplierIpnLabel.Text = "Supplier IPN:";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.Chocolate;
            this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button.Location = new System.Drawing.Point(80, 266);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(124, 35);
            this.button.TabIndex = 19;
            this.button.Text = "button1";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(245, 266);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(122, 35);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // recipientSurnameTextBox
            // 
            this.recipientSurnameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recipientSurnameTextBox.Location = new System.Drawing.Point(184, 216);
            this.recipientSurnameTextBox.Name = "recipientSurnameTextBox";
            this.recipientSurnameTextBox.Size = new System.Drawing.Size(257, 27);
            this.recipientSurnameTextBox.TabIndex = 17;
            // 
            // recipientNameTextBox
            // 
            this.recipientNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recipientNameTextBox.Location = new System.Drawing.Point(184, 181);
            this.recipientNameTextBox.Name = "recipientNameTextBox";
            this.recipientNameTextBox.Size = new System.Drawing.Size(257, 27);
            this.recipientNameTextBox.TabIndex = 16;
            // 
            // supplierSurnameTextBox
            // 
            this.supplierSurnameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierSurnameTextBox.Location = new System.Drawing.Point(184, 149);
            this.supplierSurnameTextBox.Name = "supplierSurnameTextBox";
            this.supplierSurnameTextBox.Size = new System.Drawing.Size(257, 27);
            this.supplierSurnameTextBox.TabIndex = 15;
            // 
            // supplierNameTextBox
            // 
            this.supplierNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierNameTextBox.Location = new System.Drawing.Point(184, 116);
            this.supplierNameTextBox.Name = "supplierNameTextBox";
            this.supplierNameTextBox.Size = new System.Drawing.Size(257, 27);
            this.supplierNameTextBox.TabIndex = 14;
            // 
            // dateTextBox
            // 
            this.dateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTextBox.Location = new System.Drawing.Point(184, 80);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(257, 27);
            this.dateTextBox.TabIndex = 13;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberTextBox.Location = new System.Drawing.Point(184, 46);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(257, 27);
            this.numberTextBox.TabIndex = 12;
            // 
            // useIdLabel
            // 
            this.useIdLabel.AutoSize = true;
            this.useIdLabel.Location = new System.Drawing.Point(378, 246);
            this.useIdLabel.Name = "useIdLabel";
            this.useIdLabel.Size = new System.Drawing.Size(63, 17);
            this.useIdLabel.TabIndex = 11;
            this.useIdLabel.Text = "Use IPN ";
            this.useIdLabel.Click += new System.EventHandler(this.useIdLabel_Click);
            this.useIdLabel.MouseEnter += new System.EventHandler(this.useIdLabel_MouseEnter);
            this.useIdLabel.MouseLeave += new System.EventHandler(this.useIdLabel_MouseLeave);
            // 
            // recipientSurnameLabel
            // 
            this.recipientSurnameLabel.AutoSize = true;
            this.recipientSurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recipientSurnameLabel.Location = new System.Drawing.Point(12, 223);
            this.recipientSurnameLabel.Name = "recipientSurnameLabel";
            this.recipientSurnameLabel.Size = new System.Drawing.Size(156, 20);
            this.recipientSurnameLabel.TabIndex = 10;
            this.recipientSurnameLabel.Text = "Recipient Surname:";
            // 
            // recipientNameLabel
            // 
            this.recipientNameLabel.AutoSize = true;
            this.recipientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recipientNameLabel.Location = new System.Drawing.Point(12, 188);
            this.recipientNameLabel.Name = "recipientNameLabel";
            this.recipientNameLabel.Size = new System.Drawing.Size(133, 20);
            this.recipientNameLabel.TabIndex = 9;
            this.recipientNameLabel.Text = "Recipient Name:";
            // 
            // supplierSurnameLabel
            // 
            this.supplierSurnameLabel.AutoSize = true;
            this.supplierSurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierSurnameLabel.Location = new System.Drawing.Point(12, 156);
            this.supplierSurnameLabel.Name = "supplierSurnameLabel";
            this.supplierSurnameLabel.Size = new System.Drawing.Size(147, 20);
            this.supplierSurnameLabel.TabIndex = 8;
            this.supplierSurnameLabel.Text = "Supplier Surname:";
            // 
            // supplierNameLabel
            // 
            this.supplierNameLabel.AutoSize = true;
            this.supplierNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierNameLabel.Location = new System.Drawing.Point(12, 123);
            this.supplierNameLabel.Name = "supplierNameLabel";
            this.supplierNameLabel.Size = new System.Drawing.Size(124, 20);
            this.supplierNameLabel.TabIndex = 7;
            this.supplierNameLabel.Text = "Supplier Name:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.Location = new System.Drawing.Point(12, 87);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(50, 20);
            this.dateLabel.TabIndex = 6;
            this.dateLabel.Text = "Date:";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel.Location = new System.Drawing.Point(12, 53);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(73, 20);
            this.numberLabel.TabIndex = 5;
            this.numberLabel.Text = "Number:";
            // 
            // OperationWithConsignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(456, 329);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperationWithConsignmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsigmentAddForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.TextBox recipientSurnameTextBox;
        protected System.Windows.Forms.TextBox recipientNameTextBox;
        protected System.Windows.Forms.TextBox supplierSurnameTextBox;
        protected System.Windows.Forms.TextBox supplierNameTextBox;
        protected System.Windows.Forms.TextBox dateTextBox;
        protected System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Label useIdLabel;
        private System.Windows.Forms.Label recipientSurnameLabel;
        private System.Windows.Forms.Label recipientNameLabel;
        private System.Windows.Forms.Label supplierSurnameLabel;
        private System.Windows.Forms.Label supplierNameLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button button;
        protected System.Windows.Forms.TextBox recipientIpnTextBox;
        protected System.Windows.Forms.TextBox supplierIpnTextBox;
        private System.Windows.Forms.Label recipientIpnLabel;
        private System.Windows.Forms.Label supplierIpnLabel;
    }
}