namespace UniversityManagementApp.UI
{
    partial class MenuUi
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
            this.studentButton = new System.Windows.Forms.Button();
            this.departmentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentButton
            // 
            this.studentButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.studentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentButton.Location = new System.Drawing.Point(28, 81);
            this.studentButton.Name = "studentButton";
            this.studentButton.Size = new System.Drawing.Size(170, 110);
            this.studentButton.TabIndex = 0;
            this.studentButton.Text = "Student Entry";
            this.studentButton.UseVisualStyleBackColor = false;
            this.studentButton.Click += new System.EventHandler(this.studentButton_Click);
            // 
            // departmentButton
            // 
            this.departmentButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.departmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentButton.Location = new System.Drawing.Point(235, 81);
            this.departmentButton.Name = "departmentButton";
            this.departmentButton.Size = new System.Drawing.Size(170, 110);
            this.departmentButton.TabIndex = 1;
            this.departmentButton.Text = "Department Entry";
            this.departmentButton.UseVisualStyleBackColor = false;
            this.departmentButton.Click += new System.EventHandler(this.departmentButton_Click);
            // 
            // MenuUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(442, 262);
            this.Controls.Add(this.departmentButton);
            this.Controls.Add(this.studentButton);
            this.Name = "MenuUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuUi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button studentButton;
        private System.Windows.Forms.Button departmentButton;
    }
}