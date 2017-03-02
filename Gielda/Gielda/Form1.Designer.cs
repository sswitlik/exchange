namespace Gielda
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Read = new System.Windows.Forms.Button();
            this.Display = new System.Windows.Forms.Button();
            this.Write = new System.Windows.Forms.Button();
            this.FileData = new System.Windows.Forms.RichTextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ListBox = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(12, 12);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 23);
            this.Read.TabIndex = 0;
            this.Read.Text = "Read";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(12, 43);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(75, 23);
            this.Display.TabIndex = 1;
            this.Display.Text = "Display";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Display_Click);
            // 
            // Write
            // 
            this.Write.Location = new System.Drawing.Point(12, 72);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(75, 23);
            this.Write.TabIndex = 2;
            this.Write.Text = "Write";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.Click += new System.EventHandler(this.Write_Click);
            // 
            // FileData
            // 
            this.FileData.Location = new System.Drawing.Point(94, 12);
            this.FileData.Name = "FileData";
            this.FileData.Size = new System.Drawing.Size(373, 285);
            this.FileData.TabIndex = 3;
            this.FileData.Text = "";
            // 
            // chart
            // 
            chartArea4.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart.Legends.Add(legend4);
            this.chart.Location = new System.Drawing.Point(94, 12);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(580, 285);
            this.chart.TabIndex = 4;
            this.chart.Text = "chart1";
            // 
            // ListBox
            // 
            this.ListBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Items.AddRange(new object[] {
            "candlestick",
            "mov_average"});
            this.ListBox.Location = new System.Drawing.Point(550, 80);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(100, 30);
            this.ListBox.TabIndex = 6;
            this.ListBox.Visible = false;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 307);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.FileData);
            this.Controls.Add(this.Write);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.Read);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.Button Display;
        private System.Windows.Forms.Button Write;
        private System.Windows.Forms.RichTextBox FileData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.CheckedListBox ListBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

