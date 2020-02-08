namespace DecryptUsingLSB
{
    partial class FormDecrypt
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
            this.pictureBoxInput = new System.Windows.Forms.PictureBox();
            this.buttonTranslate = new System.Windows.Forms.Button();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.buttonR = new System.Windows.Forms.Button();
            this.buttonG = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxInput
            // 
            this.pictureBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxInput.Location = new System.Drawing.Point(54, 188);
            this.pictureBoxInput.Name = "pictureBoxInput";
            this.pictureBoxInput.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxInput.TabIndex = 0;
            this.pictureBoxInput.TabStop = false;
            this.pictureBoxInput.Click += new System.EventHandler(this.Open);
            // 
            // buttonTranslate
            // 
            this.buttonTranslate.Location = new System.Drawing.Point(372, 324);
            this.buttonTranslate.Name = "buttonTranslate";
            this.buttonTranslate.Size = new System.Drawing.Size(120, 44);
            this.buttonTranslate.TabIndex = 1;
            this.buttonTranslate.Text = "Translate";
            this.buttonTranslate.UseVisualStyleBackColor = true;
            this.buttonTranslate.Click += new System.EventHandler(this.Decrypt);
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Location = new System.Drawing.Point(515, 41);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxMessage.Size = new System.Drawing.Size(545, 569);
            this.richTextBoxMessage.TabIndex = 2;
            this.richTextBoxMessage.Text = "";
            // 
            // buttonR
            // 
            this.buttonR.BackColor = System.Drawing.Color.White;
            this.buttonR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonR.ForeColor = System.Drawing.Color.Red;
            this.buttonR.Location = new System.Drawing.Point(515, 20);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(75, 23);
            this.buttonR.TabIndex = 5;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = false;
            this.buttonR.Click += new System.EventHandler(this.View_R);
            // 
            // buttonG
            // 
            this.buttonG.BackColor = System.Drawing.Color.White;
            this.buttonG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonG.Location = new System.Drawing.Point(589, 20);
            this.buttonG.Name = "buttonG";
            this.buttonG.Size = new System.Drawing.Size(75, 23);
            this.buttonG.TabIndex = 6;
            this.buttonG.Text = "G";
            this.buttonG.UseVisualStyleBackColor = false;
            this.buttonG.Click += new System.EventHandler(this.View_G);
            // 
            // buttonB
            // 
            this.buttonB.BackColor = System.Drawing.Color.White;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonB.ForeColor = System.Drawing.Color.Blue;
            this.buttonB.Location = new System.Drawing.Point(663, 20);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(75, 23);
            this.buttonB.TabIndex = 7;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = false;
            this.buttonB.Click += new System.EventHandler(this.View_B);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(954, 613);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "By: Tran Quang Vinh";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Dỉrect);
            // 
            // FormDecrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 630);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonG);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.buttonTranslate);
            this.Controls.Add(this.pictureBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDecrypt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get something from your image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxInput;
        private System.Windows.Forms.Button buttonTranslate;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.Button buttonG;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

