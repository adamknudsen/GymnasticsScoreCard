namespace GymnasticsScoreCardPrinter
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
            this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.inputFilePath = new System.Windows.Forms.ComboBox();
            this.browseInput = new System.Windows.Forms.Button();
            this.merge = new System.Windows.Forms.Button();
            this.browseTemplate = new System.Windows.Forms.Button();
            this.templateFilePath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.templateFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sessionFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usagFilter = new System.Windows.Forms.TextBox();
            this.proScoreNumberFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.includeIncomplete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // inputFilePath
            // 
            this.inputFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFilePath.FormattingEnabled = true;
            this.inputFilePath.Location = new System.Drawing.Point(27, 31);
            this.inputFilePath.Name = "inputFilePath";
            this.inputFilePath.Size = new System.Drawing.Size(560, 21);
            this.inputFilePath.TabIndex = 0;
            // 
            // browseInput
            // 
            this.browseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseInput.Location = new System.Drawing.Point(593, 29);
            this.browseInput.Name = "browseInput";
            this.browseInput.Size = new System.Drawing.Size(75, 23);
            this.browseInput.TabIndex = 1;
            this.browseInput.Text = "browse ...";
            this.browseInput.UseVisualStyleBackColor = true;
            this.browseInput.Click += new System.EventHandler(this.browseInput_Click);
            // 
            // merge
            // 
            this.merge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.merge.Location = new System.Drawing.Point(593, 256);
            this.merge.Name = "merge";
            this.merge.Size = new System.Drawing.Size(75, 23);
            this.merge.TabIndex = 2;
            this.merge.Text = "Merge";
            this.merge.UseVisualStyleBackColor = true;
            this.merge.Click += new System.EventHandler(this.merge_Click);
            // 
            // browseTemplate
            // 
            this.browseTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseTemplate.Location = new System.Drawing.Point(593, 92);
            this.browseTemplate.Name = "browseTemplate";
            this.browseTemplate.Size = new System.Drawing.Size(75, 23);
            this.browseTemplate.TabIndex = 4;
            this.browseTemplate.Text = "browse ...";
            this.browseTemplate.UseVisualStyleBackColor = true;
            this.browseTemplate.Click += new System.EventHandler(this.browseTemplate_Click);
            // 
            // templateFilePath
            // 
            this.templateFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateFilePath.FormattingEnabled = true;
            this.templateFilePath.Location = new System.Drawing.Point(27, 94);
            this.templateFilePath.Name = "templateFilePath";
            this.templateFilePath.Size = new System.Drawing.Size(560, 21);
            this.templateFilePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input File from ProScore";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Word Document Template";
            // 
            // sessionFilter
            // 
            this.sessionFilter.FormattingEnabled = true;
            this.sessionFilter.Items.AddRange(new object[] {
            "1A",
            "1B",
            "1C",
            "1D",
            "1E",
            "2A",
            "2B",
            "2C",
            "2D",
            "2E",
            "3A",
            "3B",
            "3C",
            "3D",
            "3E",
            "4A",
            "4B",
            "4C",
            "4D",
            "4E"});
            this.sessionFilter.Location = new System.Drawing.Point(27, 154);
            this.sessionFilter.Name = "sessionFilter";
            this.sessionFilter.Size = new System.Drawing.Size(95, 21);
            this.sessionFilter.TabIndex = 7;
            this.sessionFilter.SelectedIndexChanged += new System.EventHandler(this.sessionFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Session Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "USAG Filter";
            // 
            // usagFilter
            // 
            this.usagFilter.Location = new System.Drawing.Point(186, 154);
            this.usagFilter.Name = "usagFilter";
            this.usagFilter.Size = new System.Drawing.Size(100, 20);
            this.usagFilter.TabIndex = 10;
            this.usagFilter.TextChanged += new System.EventHandler(this.usagFilter_TextChanged);
            // 
            // proScoreNumberFilter
            // 
            this.proScoreNumberFilter.Location = new System.Drawing.Point(330, 154);
            this.proScoreNumberFilter.Name = "proScoreNumberFilter";
            this.proScoreNumberFilter.Size = new System.Drawing.Size(100, 20);
            this.proScoreNumberFilter.TabIndex = 12;
            this.proScoreNumberFilter.TextChanged += new System.EventHandler(this.proScoreFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ProScore Filter";
            // 
            // version
            // 
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(1, 359);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(40, 13);
            this.version.TabIndex = 13;
            this.version.Text = "0.0.0.0";
            // 
            // includeIncomplete
            // 
            this.includeIncomplete.Location = new System.Drawing.Point(30, 317);
            this.includeIncomplete.Name = "includeIncomplete";
            this.includeIncomplete.Size = new System.Drawing.Size(129, 24);
            this.includeIncomplete.TabIndex = 14;
            this.includeIncomplete.Text = "Include Incomplete?";
            this.includeIncomplete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 381);
            this.Controls.Add(this.includeIncomplete);
            this.Controls.Add(this.version);
            this.Controls.Add(this.proScoreNumberFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.usagFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sessionFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseTemplate);
            this.Controls.Add(this.templateFilePath);
            this.Controls.Add(this.merge);
            this.Controls.Add(this.browseInput);
            this.Controls.Add(this.inputFilePath);
            this.Name = "Form1";
            this.Text = "Print Score Cards";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog inputFileDialog;
        private System.Windows.Forms.ComboBox inputFilePath;
        private System.Windows.Forms.Button browseInput;
        private System.Windows.Forms.Button merge;
        private System.Windows.Forms.Button browseTemplate;
        private System.Windows.Forms.ComboBox templateFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog templateFileDialog;
        private System.Windows.Forms.ComboBox sessionFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usagFilter;
        private System.Windows.Forms.TextBox proScoreNumberFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.CheckBox includeIncomplete;
    }
}

