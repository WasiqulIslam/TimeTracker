using System.Collections.Generic;
using System.Windows.Forms;

//Development started by Wasiqul Islam on 12/07/2024

namespace TimeTracker
{
    public partial class MainUI : Form
    {

        bool shouldClose = false;

        private string fileName = "time.txt";

        private string? _filePath = null;
        public string FilePath
        {
            get
            {
                if (_filePath == null)
                {
                    string? appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    if (appPath == null)
                    {
                        throw new Exception("Could not get application parent directory.");
                    }
                    _filePath = Path.Combine(appPath, fileName);
                }
                return _filePath;
            }
        }

        public MainUI()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            try
            {
                lblSummary.Text = "";
                CalculateTime();
                var task = new Task(UpdateTime);
                task.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTime()
        {

            while (true)
            {

                if (shouldClose)
                {
                    break;
                }

                try
                {
                    CalculateTime();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occured: " + ex.Message, 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Thread.Sleep(1000 * 60);
                if (shouldClose)
                {
                    break;
                }

            }

        }

        private void CalculateTime()
        {

            List<DateTime> times = ReadTime();

            //calculate total time
            TimeSpan total = new TimeSpan();
            for (int i = 0; i < times.Count; i += 2)
            {
                DateTime endTime = DateTime.Now;
                if (i + 1 < times.Count)
                {
                    endTime = times[i + 1];
                }
                TimeSpan span = endTime - times[i];
                total += span;
            }
            string summary = $"{(int)Math.Floor(total.TotalHours)}:{total:mm}";

            //time details
            string details = "";
            foreach (DateTime time in times)
            {
                details += time.ToString() + Environment.NewLine;
            }

            //update UI
            this.Invoke((MethodInvoker)delegate {
                if (times.Count % 2 == 0)
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
                else
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                }
                lblSummary.Text = summary;
                txtDetails.Text = details;
            });

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                WriteTime();
                CalculateTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteTime()
        {
            using (StreamWriter sw = new StreamWriter(FilePath, true))
            {
                sw.WriteLine(DateTime.Now.ToString());
            }
        }

        private void ClearTime()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }

        private List<DateTime> ReadTime()
        {
            List<DateTime> times = new List<DateTime>();
            if (File.Exists(FilePath))
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (DateTime.TryParse(line, out DateTime time))
                        {
                            times.Add(time);
                        }
                    }
                }
            }
            return times;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                WriteTime();
                CalculateTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result =
                    MessageBox.Show("Are you sure you want to reset the time?",
                    "Reset Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ClearTime();
                    CalculateTime();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblQuery_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Click Start to start tracking time, 
click Stop to stop tracking time, 
click Reset to reset the time.
- Developed by Wasiqul Islam
Email: islam.wasiqul@gmail.com
Last updated: 12/07/2024",
                "Time Tracker",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string? directory = Path.GetDirectoryName(FilePath);
            try
            {
                //For systems those are not Windows operating system this command may not work.
                //In that case user will be able to see the folder name from the error message.
                System.Diagnostics.Process.Start("explorer.exe", directory); //ignoring nullability warning as exception is handled already
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the folder {directory}. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.shouldClose = true;
        }

    }
}
