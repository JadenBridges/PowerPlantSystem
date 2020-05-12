namespace PowerPlantSystem
{
    partial class AddComponentForm
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
            this.AddComponentButton = new System.Windows.Forms.Button();
            this.ComponentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ComponentTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddComponentButton
            // 
            this.AddComponentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddComponentButton.Location = new System.Drawing.Point(123, 156);
            this.AddComponentButton.Name = "AddComponentButton";
            this.AddComponentButton.Size = new System.Drawing.Size(251, 67);
            this.AddComponentButton.TabIndex = 9;
            this.AddComponentButton.Text = "Add Component";
            this.AddComponentButton.UseVisualStyleBackColor = true;
            this.AddComponentButton.Click += new System.EventHandler(this.AddComponentButton_Click);
            // 
            // ComponentTypeComboBox
            // 
            this.ComponentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComponentTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComponentTypeComboBox.FormattingEnabled = true;
            this.ComponentTypeComboBox.Location = new System.Drawing.Point(47, 80);
            this.ComponentTypeComboBox.Name = "ComponentTypeComboBox";
            this.ComponentTypeComboBox.Size = new System.Drawing.Size(421, 41);
            this.ComponentTypeComboBox.TabIndex = 6;
            // 
            // ComponentTypeLabel
            // 
            this.ComponentTypeLabel.AutoSize = true;
            this.ComponentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComponentTypeLabel.Location = new System.Drawing.Point(41, 35);
            this.ComponentTypeLabel.Name = "ComponentTypeLabel";
            this.ComponentTypeLabel.Size = new System.Drawing.Size(278, 33);
            this.ComponentTypeLabel.TabIndex = 5;
            this.ComponentTypeLabel.Text = "Type of Component:";
            // 
            // AddComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 256);
            this.Controls.Add(this.AddComponentButton);
            this.Controls.Add(this.ComponentTypeComboBox);
            this.Controls.Add(this.ComponentTypeLabel);
            this.Name = "AddComponentForm";
            this.Text = "Add Component";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddComponentButton;
        private System.Windows.Forms.ComboBox ComponentTypeComboBox;
        private System.Windows.Forms.Label ComponentTypeLabel;
    }
}