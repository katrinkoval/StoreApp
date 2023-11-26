
namespace StoreApp_DB_
{
    partial class ChangeTotalPriceForm
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
            this.titleConsignmentLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.increaseCheckBox = new System.Windows.Forms.CheckBox();
            this.decreaseCheckBox = new System.Windows.Forms.CheckBox();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.percentageTextBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleConsignmentLabel
            // 
            this.titleConsignmentLabel.AutoSize = true;
            this.titleConsignmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleConsignmentLabel.Location = new System.Drawing.Point(141, 42);
            this.titleConsignmentLabel.Name = "titleConsignmentLabel";
            this.titleConsignmentLabel.Size = new System.Drawing.Size(0, 24);
            this.titleConsignmentLabel.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(442, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(31, 29);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // increaseCheckBox
            // 
            this.increaseCheckBox.AutoSize = true;
            this.increaseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.increaseCheckBox.Location = new System.Drawing.Point(43, 153);
            this.increaseCheckBox.Name = "increaseCheckBox";
            this.increaseCheckBox.Size = new System.Drawing.Size(174, 24);
            this.increaseCheckBox.TabIndex = 5;
            this.increaseCheckBox.Text = "Increase total price";
            this.increaseCheckBox.UseVisualStyleBackColor = true;
            this.increaseCheckBox.CheckedChanged += new System.EventHandler(this.increaseCheckBox_CheckedChanged);
            // 
            // decreaseCheckBox
            // 
            this.decreaseCheckBox.AutoSize = true;
            this.decreaseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decreaseCheckBox.Location = new System.Drawing.Point(258, 153);
            this.decreaseCheckBox.Name = "decreaseCheckBox";
            this.decreaseCheckBox.Size = new System.Drawing.Size(183, 24);
            this.decreaseCheckBox.TabIndex = 6;
            this.decreaseCheckBox.Text = "Decrease total price";
            this.decreaseCheckBox.UseVisualStyleBackColor = true;
            this.decreaseCheckBox.CheckedChanged += new System.EventHandler(this.decreaseCheckBox_CheckedChanged);
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.percentageLabel.Location = new System.Drawing.Point(30, 104);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(138, 20);
            this.percentageLabel.TabIndex = 7;
            this.percentageLabel.Text = "Input percentage:";
            // 
            // percentageTextBox
            // 
            this.percentageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.percentageTextBox.Location = new System.Drawing.Point(187, 97);
            this.percentageTextBox.Name = "percentageTextBox";
            this.percentageTextBox.Size = new System.Drawing.Size(181, 27);
            this.percentageTextBox.TabIndex = 8;
            this.percentageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.percentageTextBox_KeyPress);
            // 
            // applyButton
            // 
            this.applyButton.BackColor = System.Drawing.Color.Chocolate;
            this.applyButton.Location = new System.Drawing.Point(81, 188);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(124, 35);
            this.applyButton.TabIndex = 23;
            this.applyButton.Text = "Add";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(246, 188);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(122, 35);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ChangeTotalPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 235);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.percentageTextBox);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.decreaseCheckBox);
            this.Controls.Add(this.increaseCheckBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.titleConsignmentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeTotalPriceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeTotalPriceForm";
            this.Load += new System.EventHandler(this.ChangeTotalPriceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleConsignmentLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.CheckBox increaseCheckBox;
        private System.Windows.Forms.CheckBox decreaseCheckBox;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.TextBox percentageTextBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
    }
}