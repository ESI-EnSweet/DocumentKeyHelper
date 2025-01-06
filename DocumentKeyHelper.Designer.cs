namespace DocumentKeyHelper
{
    partial class DocumentKeyHelper
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
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateKeys
            // 
            this.btnGenerateKeys.Location = new System.Drawing.Point(583, 348);
            this.btnGenerateKeys.Name = "btnGenerateKeys";
            this.btnGenerateKeys.Size = new System.Drawing.Size(151, 43);
            this.btnGenerateKeys.TabIndex = 0;
            this.btnGenerateKeys.Text = "Generate Keys";
            this.btnGenerateKeys.UseVisualStyleBackColor = true;
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Document Key File:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(131, 13);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(566, 20);
            this.tbFileName.TabIndex = 2;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(131, 54);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerateKeys);
            this.Name = "Form1";
            this.Text = "Generate Document Keys";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnSelectFile;
    }
}

