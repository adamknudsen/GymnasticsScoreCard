using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GymnasticsScoreCardPrinter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void browseInput_Click(object sender, EventArgs e)
		{
			var result = inputFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				inputFilePath.Text = inputFileDialog.FileName;
			}
		}
		
		private void browseTemplate_Click(object sender, EventArgs e)
		{
			var result =  templateFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				templateFilePath.Text = templateFileDialog.FileName;
			}
		}

		private void browseSavedFile_Click(object sender, EventArgs e)
		{
			var result = saveFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				savedFilePath.Text = saveFileDialog.FileName;
			}
		}

		private void merge_Click(object sender, EventArgs e)
		{
			try
			{
				var filteredInputPath = FilterInput();

				if (string.IsNullOrWhiteSpace(filteredInputPath))
				{
					MessageBox.Show(@"No Results");
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
					if (MessageBox.Show(@"Add Scores to Saved Meet File?", @"Save Scores?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						SaveScores(filteredInputPath);
					}
				}
			
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + @" " + ex.StackTrace, @"Likely Scores were not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

		private string FilterInput()
		{
			string uniqueFileName = "FilteredSession_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
			string filteredInput = Path.Combine(Environment.CurrentDirectory, uniqueFileName);
			string exclusionFilePath = (excludeAlreadySaved.Checked && File.Exists(savedFilePath.Text)) ? savedFilePath.Text : string.Empty;
			var proScoreFilter = new ProScoreFilter.FileFilter(inputFilePath.Text, filteredInput, exclusionFilePath, Properties.Settings.Default.IncludeScratched, includeIncomplete.Checked);

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

		private void SaveScores(string pathToNewResults)
		{
			if (!File.Exists(savedFilePath.Text))
			{
				File.Copy(pathToNewResults, savedFilePath.Text);
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				using (StreamReader sr = new StreamReader(pathToNewResults))
				{
					sr.ReadLine(); // Discard header line
					while (!sr.EndOfStream)
						sb.AppendLine(sr.ReadLine());
				}
				File.AppendAllText(savedFilePath.Text, sb.ToString());
			}

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

		private void Form1_Load(object sender, EventArgs e)
		{
			version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			SetDefaults();
		}

		private void defaults_Click(object sender, EventArgs e)
		{
			SetDefaults();
		}

		private void SetDefaults()
		{
			var workingDirectory = Properties.Settings.Default.workingDirectoryPath;
			if (string.IsNullOrWhiteSpace(workingDirectory)) workingDirectory = Environment.CurrentDirectory;

			inputFilePath.Text = Path.Combine(workingDirectory, Properties.Settings.Default.inputFileDefault);
			templateFilePath.Text = Path.Combine(workingDirectory, Properties.Settings.Default.scoreCardTemplateDefault);
			includeIncomplete.Checked = Properties.Settings.Default.IncludeIncompleteDefault;

			string existingMeetFilePath;
			if (TryFindExistingMeetFile(workingDirectory, out existingMeetFilePath))
			{
				savedFilePath.Text = existingMeetFilePath;
			}
			else
			{
				savedFilePath.Text = GenerateNewMeetFilePath(workingDirectory);
			}
		}

		private string GenerateNewMeetFilePath(string workingDirectory)
		{
			var savedFilePathFormat = Path.Combine(workingDirectory, Properties.Settings.Default.savedFileDefaultFormat);
			return string.Format(savedFilePathFormat, DateTime.Now.ToString(Properties.Settings.Default.savedFileDateFormat));
		}

		private bool TryFindExistingMeetFile(string workingDirectory, out string existingMeetFilePath)
		{
			var potentialFilePathFormat = Path.Combine( workingDirectory, Properties.Settings.Default.savedFileDefaultFormat);

			for (int i = 0; i <= Properties.Settings.Default.daysBackToCheckForSavedFile; i++)
			{
				var potentialFilePath = string.Format(potentialFilePathFormat, 
													  DateTime.Now.AddDays(-i).ToString(Properties.Settings.Default.savedFileDateFormat));

				if (File.Exists(potentialFilePath))
				{
					existingMeetFilePath = potentialFilePath;
					return true;
				}
			}
			existingMeetFilePath = null;
			return false;
			
		}

	}
}
