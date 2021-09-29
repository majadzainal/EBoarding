namespace EBoarding
{
    partial class CustomDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDialog));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOke = new System.Windows.Forms.Button();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Turquoise;
            this.panel3.Controls.Add(this.btnOke);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 150);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(623, 46);
            this.panel3.TabIndex = 158;
            // 
            // btnOke
            // 
            this.btnOke.BackColor = System.Drawing.Color.Red;
            this.btnOke.FlatAppearance.BorderSize = 0;
            this.btnOke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOke.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.btnOke.ForeColor = System.Drawing.Color.Linen;
            this.btnOke.Location = new System.Drawing.Point(490, 6);
            this.btnOke.Margin = new System.Windows.Forms.Padding(0);
            this.btnOke.Name = "btnOke";
            this.btnOke.Size = new System.Drawing.Size(120, 35);
            this.btnOke.TabIndex = 157;
            this.btnOke.Text = "OKE";
            this.btnOke.UseVisualStyleBackColor = false;
            this.btnOke.Click += new System.EventHandler(this.btnOke_Click);
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.BackColor = System.Drawing.Color.LightSeaGreen;
            this.richTextBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMessage.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.richTextBoxMessage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxMessage.Location = new System.Drawing.Point(118, 22);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(493, 108);
            this.richTextBoxMessage.TabIndex = 158;
            this.richTextBoxMessage.Text = "Error Message !";
            // 
            // CustomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(623, 196);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error Message";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOke;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
    }
}