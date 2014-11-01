using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GymnasticsScoreCardPrinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            inputFilePath.Text = Path.Combine(Environment.CurrentDirectory, "SampleSession.csv");
            templateFilePath.Text = Path.Combine(Environment.CurrentDirectory, "HugKissScoreCard.doc");
        }

        private void browseInput_Click(object sender, EventArgs e)
        {
            var result = inputFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.inputFilePath.Text = inputFileDialog.FileName;
            }
        }
        
        private void browseTemplate_Click(object sender, EventArgs e)
        {
            var result =  templateFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.templateFilePath.Text = templateFileDialog.FileName;
            }
        }

        private void merge_Click(object sender, EventArgs e)
        {
            try
            {
                var filteredInputPath = FilterInput();

                if (string.IsNullOrWhiteSpace(filteredInputPath))
                {
                    MessageBox.Show("No Results");
                }
                else
                {
                    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    wordApp.Visible = true;
                    var document = wordApp.Documents.Open(templateFilePath.Text);

                    document.MailMerge.OpenDataSource(filteredInputPath);
                    const bool showTroubleshootingOnError = true;
                    document.MailMerge.Execute(showTroubleshootingOnError);

                    document.Close(false);
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            
        }

        private string FilterInput()
        {
            string uniqueFileName = "FilteredSession_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            string filteredInput = Path.Combine(Environment.CurrentDirectory, uniqueFileName);
            var proScoreFilter = new ProScoreFilter.FileFilter(inputFilePath.Text, filteredInput);

            if(!string.IsNullOrWhiteSpace(sessionFilter.Text) && proScoreFilter.FilterForSession(sessionFilter.Text))
                return filteredInput;
            int proScoreNumber;
            if (!string.IsNullOrWhiteSpace(proScoreNumberFilter.Text) && int.TryParse(proScoreNumberFilter.Text, out proScoreNumber))
            {
                if (proScoreFilter.FilterForProScore(proScoreNumber))
                    return filteredInput;
            }
            int usagNumber;
            if (!string.IsNullOrWhiteSpace(usagFilter.Text) && int.TryParse(usagFilter.Text,out usagNumber))
            {
                 if (proScoreFilter.FilterForUSAG(usagNumber))
                     return filteredInput;
            }
            
            return null;

        }

        private void sessionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sessionFilter.Text != string.Empty)
            {
                proScoreNumberFilter.Text = string.Empty;
                usagFilter.Text = string.Empty;
            }
        }

        private void usagFilter_TextChanged(object sender, EventArgs e)
        {
            if (usagFilter.Text != string.Empty)
            {
                proScoreNumberFilter.Text = string.Empty;
                sessionFilter.Text = string.Empty;
            }
        }

        private void proScoreFilter_TextChanged(object sender, EventArgs e)
        {
            if (proScoreNumberFilter.Text != string.Empty)
            {
                usagFilter.Text = string.Empty;
                sessionFilter.Text = string.Empty;
            }
        }
    }
}
