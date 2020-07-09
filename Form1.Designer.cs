namespace Explorer
{
    partial class Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.PathField = new System.Windows.Forms.TextBox();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.NewNameField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path: ";
            // 
            // PathField
            // 
            this.PathField.Location = new System.Drawing.Point(53, 6);
            this.PathField.Name = "PathField";
            this.PathField.ReadOnly = true;
            this.PathField.Size = new System.Drawing.Size(654, 20);
            this.PathField.TabIndex = 1;
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(713, 4);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpen.TabIndex = 2;
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(15, 59);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(773, 379);
            this.treeView.TabIndex = 3;
            this.treeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyUp);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // NewNameField
            // 
            this.NewNameField.Location = new System.Drawing.Point(15, 33);
            this.NewNameField.Name = "NewNameField";
            this.NewNameField.Size = new System.Drawing.Size(773, 20);
            this.NewNameField.TabIndex = 4;
            this.NewNameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewNameField_MouseClick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NewNameField);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.PathField);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form";
            this.Text = "File Explorer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathField;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox NewNameField;
    }
}

