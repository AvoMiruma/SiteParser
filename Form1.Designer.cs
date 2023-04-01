
namespace WorkParser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Start = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.GroupBox();
            this.Sort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(808, 314);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(12, 442);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(174, 49);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(12, 332);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(90, 41);
            this.Log.TabIndex = 3;
            this.Log.TabStop = false;
            this.Log.Text = "Count";
            this.Log.Enter += new System.EventHandler(this.Log_Enter);
            // 
            // Sort
            // 
            this.Sort.Location = new System.Drawing.Point(267, 442);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(203, 49);
            this.Sort.TabIndex = 4;
            this.Sort.Text = "Not full work day";
            this.Sort.UseVisualStyleBackColor = true;
            this.Sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.Sort);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Work Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.GroupBox Log;
        private System.Windows.Forms.Button Sort;
    }
}

