using System;

namespace ForecastApp
{
    partial class Form1
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
            this.cityNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.getResultsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cityNameBox
            // 
            this.cityNameBox.Location = new System.Drawing.Point(88, 25);
            this.cityNameBox.Name = "cityNameBox";
            this.cityNameBox.Size = new System.Drawing.Size(250, 20);
            this.cityNameBox.TabIndex = 0;
            this.cityNameBox.Text = "kiev";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your city name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(11, 81);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(386, 100);
            this.resultBox.TabIndex = 2;
            this.resultBox.Text = "Here you will see the result";
            // 
            // getResultsButton
            // 
            this.getResultsButton.Location = new System.Drawing.Point(164, 51);
            this.getResultsButton.Name = "getResultsButton";
            this.getResultsButton.Size = new System.Drawing.Size(95, 24);
            this.getResultsButton.TabIndex = 3;
            this.getResultsButton.Text = "Get the results";
            this.getResultsButton.UseVisualStyleBackColor = true;
            this.getResultsButton.Click += new System.EventHandler(this.GetResultsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 226);
            this.Controls.Add(this.getResultsButton);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cityNameBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox cityNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button getResultsButton;
    }
}

