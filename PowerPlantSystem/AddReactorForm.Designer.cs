namespace PowerPlantSystem
{
    partial class AddReactorForm
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
            this.ReactorTypeLabel = new System.Windows.Forms.Label();
            this.ReactorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ReactorNameLabel = new System.Windows.Forms.Label();
            this.ReactorNameTextBox = new System.Windows.Forms.TextBox();
            this.AddReactorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReactorTypeLabel
            // 
            this.ReactorTypeLabel.AutoSize = true;
            this.ReactorTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReactorTypeLabel.Location = new System.Drawing.Point(25, 13);
            this.ReactorTypeLabel.Name = "ReactorTypeLabel";
            this.ReactorTypeLabel.Size = new System.Drawing.Size(230, 33);
            this.ReactorTypeLabel.TabIndex = 0;
            this.ReactorTypeLabel.Text = "Type of Reactor:";
            // 
            // ReactorTypeComboBox
            // 
            this.ReactorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReactorTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReactorTypeComboBox.FormattingEnabled = true;
            this.ReactorTypeComboBox.Location = new System.Drawing.Point(31, 58);
            this.ReactorTypeComboBox.Name = "ReactorTypeComboBox";
            this.ReactorTypeComboBox.Size = new System.Drawing.Size(421, 41);
            this.ReactorTypeComboBox.TabIndex = 1;
            // 
            // ReactorNameLabel
            // 
            this.ReactorNameLabel.AutoSize = true;
            this.ReactorNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReactorNameLabel.Location = new System.Drawing.Point(31, 118);
            this.ReactorNameLabel.Name = "ReactorNameLabel";
            this.ReactorNameLabel.Size = new System.Drawing.Size(243, 33);
            this.ReactorNameLabel.TabIndex = 2;
            this.ReactorNameLabel.Text = "Name of Reactor:";
            // 
            // ReactorNameTextBox
            // 
            this.ReactorNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReactorNameTextBox.Location = new System.Drawing.Point(31, 164);
            this.ReactorNameTextBox.Name = "ReactorNameTextBox";
            this.ReactorNameTextBox.Size = new System.Drawing.Size(421, 40);
            this.ReactorNameTextBox.TabIndex = 3;
            // 
            // AddReactorButton
            // 
            this.AddReactorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddReactorButton.Location = new System.Drawing.Point(133, 230);
            this.AddReactorButton.Name = "AddReactorButton";
            this.AddReactorButton.Size = new System.Drawing.Size(215, 67);
            this.AddReactorButton.TabIndex = 4;
            this.AddReactorButton.Text = "Add Reactor";
            this.AddReactorButton.UseVisualStyleBackColor = true;
            this.AddReactorButton.Click += new System.EventHandler(this.AddReactorButton_Click);
            // 
            // AddReactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 320);
            this.Controls.Add(this.AddReactorButton);
            this.Controls.Add(this.ReactorNameTextBox);
            this.Controls.Add(this.ReactorNameLabel);
            this.Controls.Add(this.ReactorTypeComboBox);
            this.Controls.Add(this.ReactorTypeLabel);
            this.Name = "AddReactorForm";
            this.Text = "AddReactor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ReactorTypeLabel;
        private System.Windows.Forms.ComboBox ReactorTypeComboBox;
        private System.Windows.Forms.Label ReactorNameLabel;
        private System.Windows.Forms.TextBox ReactorNameTextBox;
        private System.Windows.Forms.Button AddReactorButton;
    }
}