namespace QuickXorHash
{
    partial class MainForm
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
            openFileDialog1 = new OpenFileDialog();
            btnSelectFile = new Button();
            txtOpenedFile = new TextBox();
            groupBox1 = new GroupBox();
            lblProcessing = new Label();
            groupBox2 = new GroupBox();
            txtHashResult = new TextBox();
            groupBox3 = new GroupBox();
            txtHashToCompare = new TextBox();
            label1 = new Label();
            lblCompResult = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSelectFile
            // 
            btnSelectFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFile.Location = new Point(407, 51);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(75, 23);
            btnSelectFile.TabIndex = 0;
            btnSelectFile.Text = "Select file";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_ClickAsync;
            // 
            // txtOpenedFile
            // 
            txtOpenedFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOpenedFile.Location = new Point(6, 22);
            txtOpenedFile.Name = "txtOpenedFile";
            txtOpenedFile.ReadOnly = true;
            txtOpenedFile.Size = new Size(476, 23);
            txtOpenedFile.TabIndex = 1;
            txtOpenedFile.DoubleClick += btnSelectFile_ClickAsync;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblProcessing);
            groupBox1.Controls.Add(btnSelectFile);
            groupBox1.Controls.Add(txtOpenedFile);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(488, 83);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "File to calculate hash";
            // 
            // lblProcessing
            // 
            lblProcessing.AutoSize = true;
            lblProcessing.ForeColor = Color.Blue;
            lblProcessing.Location = new Point(6, 55);
            lblProcessing.Name = "lblProcessing";
            lblProcessing.Size = new Size(158, 15);
            lblProcessing.TabIndex = 2;
            lblProcessing.Text = "Working on hash calculation";
            lblProcessing.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtHashResult);
            groupBox2.Location = new Point(12, 106);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(240, 56);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Calculated hash";
            // 
            // txtHashResult
            // 
            txtHashResult.Location = new Point(6, 22);
            txtHashResult.Name = "txtHashResult";
            txtHashResult.ReadOnly = true;
            txtHashResult.Size = new Size(228, 23);
            txtHashResult.TabIndex = 1;
            txtHashResult.TextChanged += txtHashResult_TextChanged;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(txtHashToCompare);
            groupBox3.Location = new Point(260, 106);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(240, 56);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hash to compare";
            // 
            // txtHashToCompare
            // 
            txtHashToCompare.Location = new Point(6, 22);
            txtHashToCompare.Name = "txtHashToCompare";
            txtHashToCompare.Size = new Size(228, 23);
            txtHashToCompare.TabIndex = 0;
            txtHashToCompare.TextChanged += txtHashToCompare_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 175);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 6;
            label1.Text = "Hash comparison result:";
            // 
            // lblCompResult
            // 
            lblCompResult.AutoSize = true;
            lblCompResult.Location = new Point(159, 175);
            lblCompResult.Name = "lblCompResult";
            lblCompResult.Size = new Size(0, 15);
            lblCompResult.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 201);
            Controls.Add(lblCompResult);
            Controls.Add(label1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "QuickXorHash calculator";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button btnSelectFile;
        private TextBox txtOpenedFile;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label lblCompResult;
        private TextBox txtHashToCompare;
        private TextBox txtHashResult;
        private Label lblProcessing;
    }
}