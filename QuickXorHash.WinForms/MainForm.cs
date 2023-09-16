namespace QuickXorHash
{
    public partial class MainForm : Form
    {
        private string selectedFile;
        private bool isCalculating;
        private CancellationTokenSource cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += MainForm_DragEnter;
            this.DragDrop += MainForm_DragDrop;
        }

        #region Form Events

        // Event handler for DragEnter to allow dropping files
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null)
                return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Event handler for DragDrop to handle dropped files
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                selectedFile = files[0]; // Select the first dropped file
                txtOpenedFile.Text = selectedFile;
                _ = CalculateHashAsync(); // Calculate the hash for the dropped file
            }
        }

        private async void btnSelectFile_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    selectedFile = openFileDialog1.FileName;
                    txtOpenedFile.Text = selectedFile;
                    await CalculateHashAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to select file: " + ex);
            }
        }

        private void txtHashToCompare_TextChanged(object sender, EventArgs e)
        {
            UpdateComparisonResult();
        }


        private void txtHashResult_TextChanged(object sender, EventArgs e)
        {
            UpdateComparisonResult();
        }

        #endregion

        private void UpdateComparisonResult()
        {
            try
            {
                if (isCalculating)
                    return;

                if (txtHashResult.Text == txtHashToCompare.Text)
                {
                    lblCompResult.Text = "Same";
                    lblCompResult.ForeColor = Color.Green;
                }
                else
                {
                    lblCompResult.Text = "Different";
                    lblCompResult.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to compare hash: " + ex);
            }
        }

        private async Task CalculateHashAsync()
        {
            try
            {
                string hashString = "";
                try
                {
                    // Disable UI controls while hashing
                    isCalculating = true;
                    btnSelectFile.Enabled = false;
                    txtHashResult.Clear();
                    lblCompResult.Text = "";
                    lblProcessing.Visible = true;

                    // Create a CancellationTokenSource for cancelling the task
                    cancellationTokenSource = new CancellationTokenSource();

                    // Calculate the hash asynchronously
                    hashString = await Task.Run(() => CalculateHash(cancellationTokenSource.Token), cancellationTokenSource.Token);
                }
                finally
                {
                    cancellationTokenSource.Dispose();
                    isCalculating = false;
                    // Enable UI controls
                    btnSelectFile.Enabled = true;
                    lblProcessing.Visible = false;
                }
                //display the hash result
                txtHashResult.Text = hashString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to calculate hash: " + ex);
            }
        }

        private string CalculateHash(CancellationToken cancellationToken)
        {
            // Periodically update the lblProcessing label
            Task.Run(async () =>
            {
                try
                {
                    int processingIndex = 0;
                    var msgText = lblProcessing.Text;
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var txtToUpdate = msgText;
                        for (int i = 0; i < processingIndex; i++)
                        {
                            txtToUpdate += ".";
                        }
                        lblProcessing.Invoke((Action)(() =>
                        {
                            lblProcessing.Text = txtToUpdate;
                        }));
                        processingIndex = (processingIndex + 1) % 5;
                        await Task.Delay(200);
                    }
                    lblProcessing.Invoke((Action)(() =>
                    {
                        lblProcessing.Text = msgText;
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in lblProcessing loop!" + ex);
                }
            }, cancellationToken);

            return HashHelper.CalculateQuickXorHash(selectedFile);
        }
    }
}