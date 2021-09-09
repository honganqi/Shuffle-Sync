namespace Shuffle_Sync
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.driveletter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filetype = new System.Windows.Forms.ComboBox();
            this.deletefiles = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.targetPath = new System.Windows.Forms.TextBox();
            this.pathDrive = new System.Windows.Forms.Label();
            this.syncButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.sourcePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.browseButtonTarget = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.targetDriveInfoText = new System.Windows.Forms.Label();
            this.targetDriveInfoLabel = new System.Windows.Forms.Label();
            this.sourcePathInfoText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sourceProgressBar = new System.Windows.Forms.ProgressBar();
            this.targetProgressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.labelSeparator = new System.Windows.Forms.Label();
            this.syncMode = new System.Windows.Forms.ComboBox();
            this.syncModeLabel = new System.Windows.Forms.Label();
            this.syncConditionLabel = new System.Windows.Forms.Label();
            this.syncCondition = new System.Windows.Forms.TextBox();
            this.fileType_helper = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Drive Letter";
            // 
            // driveletter
            // 
            this.driveletter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveletter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveletter.FormattingEnabled = true;
            this.driveletter.Location = new System.Drawing.Point(141, 137);
            this.driveletter.Name = "driveletter";
            this.driveletter.Size = new System.Drawing.Size(142, 25);
            this.driveletter.TabIndex = 3;
            this.driveletter.SelectedIndexChanged += new System.EventHandler(this.driveletter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Type(s)";
            // 
            // filetype
            // 
            this.filetype.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filetype.FormattingEnabled = true;
            this.filetype.Location = new System.Drawing.Point(371, 137);
            this.filetype.Name = "filetype";
            this.filetype.Size = new System.Drawing.Size(75, 25);
            this.filetype.TabIndex = 4;
            this.filetype.SelectedIndexChanged += new System.EventHandler(this.filetype_SelectedIndexChanged);
            this.filetype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filetype_KeyPress);
            this.filetype.Leave += new System.EventHandler(this.filetype_SelectedIndexChanged);
            // 
            // deletefiles
            // 
            this.deletefiles.AutoSize = true;
            this.deletefiles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletefiles.Location = new System.Drawing.Point(141, 241);
            this.deletefiles.Name = "deletefiles";
            this.deletefiles.Size = new System.Drawing.Size(108, 21);
            this.deletefiles.TabIndex = 9;
            this.deletefiles.Text = "Delete all files";
            this.deletefiles.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Path";
            // 
            // targetPath
            // 
            this.targetPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPath.Location = new System.Drawing.Point(141, 174);
            this.targetPath.Name = "targetPath";
            this.targetPath.Size = new System.Drawing.Size(224, 25);
            this.targetPath.TabIndex = 5;
            this.targetPath.Text = "music";
            // 
            // pathDrive
            // 
            this.pathDrive.AutoSize = true;
            this.pathDrive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathDrive.Location = new System.Drawing.Point(63, 177);
            this.pathDrive.Name = "pathDrive";
            this.pathDrive.Size = new System.Drawing.Size(63, 17);
            this.pathDrive.TabIndex = 20;
            this.pathDrive.Text = "(SelDrive)";
            // 
            // syncButton
            // 
            this.syncButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.syncButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncButton.Location = new System.Drawing.Point(140, 276);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(143, 38);
            this.syncButton.TabIndex = 10;
            this.syncButton.Text = "Shuffle Sync!";
            this.syncButton.UseVisualStyleBackColor = true;
            this.syncButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Path";
            // 
            // sourcePath
            // 
            this.sourcePath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourcePath.Location = new System.Drawing.Point(141, 51);
            this.sourcePath.Name = "sourcePath";
            this.sourcePath.Size = new System.Drawing.Size(224, 25);
            this.sourcePath.TabIndex = 1;
            this.sourcePath.Leave += new System.EventHandler(this.sourcePath_Leave);
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.browseButton.Location = new System.Drawing.Point(371, 50);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 27);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // browseButtonTarget
            // 
            this.browseButtonTarget.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.browseButtonTarget.Location = new System.Drawing.Point(371, 173);
            this.browseButtonTarget.Name = "browseButtonTarget";
            this.browseButtonTarget.Size = new System.Drawing.Size(75, 27);
            this.browseButtonTarget.TabIndex = 6;
            this.browseButtonTarget.Text = "Browse";
            this.browseButtonTarget.UseVisualStyleBackColor = true;
            this.browseButtonTarget.Click += new System.EventHandler(this.browseButtonTarget_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(35, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Drive Information";
            // 
            // targetDriveInfoText
            // 
            this.targetDriveInfoText.AutoSize = true;
            this.targetDriveInfoText.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.targetDriveInfoText.Location = new System.Drawing.Point(63, 367);
            this.targetDriveInfoText.Name = "targetDriveInfoText";
            this.targetDriveInfoText.Size = new System.Drawing.Size(106, 17);
            this.targetDriveInfoText.TabIndex = 13;
            this.targetDriveInfoText.Text = "n/a (invalid path)";
            // 
            // targetDriveInfoLabel
            // 
            this.targetDriveInfoLabel.AutoSize = true;
            this.targetDriveInfoLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.targetDriveInfoLabel.Location = new System.Drawing.Point(163, 346);
            this.targetDriveInfoLabel.Name = "targetDriveInfoLabel";
            this.targetDriveInfoLabel.Size = new System.Drawing.Size(14, 21);
            this.targetDriveInfoLabel.TabIndex = 14;
            this.targetDriveInfoLabel.Text = " ";
            // 
            // sourcePathInfoText
            // 
            this.sourcePathInfoText.AutoSize = true;
            this.sourcePathInfoText.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sourcePathInfoText.Location = new System.Drawing.Point(138, 83);
            this.sourcePathInfoText.Name = "sourcePathInfoText";
            this.sourcePathInfoText.Size = new System.Drawing.Size(0, 17);
            this.sourcePathInfoText.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Source";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Target";
            // 
            // sourceProgressBar
            // 
            this.sourceProgressBar.Location = new System.Drawing.Point(141, 83);
            this.sourceProgressBar.Name = "sourceProgressBar";
            this.sourceProgressBar.Size = new System.Drawing.Size(224, 23);
            this.sourceProgressBar.TabIndex = 18;
            this.sourceProgressBar.Visible = false;
            // 
            // targetProgressBar
            // 
            this.targetProgressBar.Location = new System.Drawing.Point(141, 321);
            this.targetProgressBar.Name = "targetProgressBar";
            this.targetProgressBar.Size = new System.Drawing.Size(224, 23);
            this.targetProgressBar.TabIndex = 19;
            this.targetProgressBar.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(289, 276);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(77, 38);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // labelSeparator
            // 
            this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSeparator.Location = new System.Drawing.Point(39, 331);
            this.labelSeparator.Name = "labelSeparator";
            this.labelSeparator.Size = new System.Drawing.Size(407, 2);
            this.labelSeparator.TabIndex = 21;
            // 
            // syncMode
            // 
            this.syncMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syncMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncMode.FormattingEnabled = true;
            this.syncMode.Items.AddRange(new object[] {
            "until full",
            "leave free space",
            "number of files",
            "up to file size"});
            this.syncMode.Location = new System.Drawing.Point(141, 210);
            this.syncMode.Name = "syncMode";
            this.syncMode.Size = new System.Drawing.Size(142, 25);
            this.syncMode.TabIndex = 7;
            this.syncMode.SelectedIndexChanged += new System.EventHandler(this.syncMode_SelectedIndexChanged);
            // 
            // syncModeLabel
            // 
            this.syncModeLabel.AutoSize = true;
            this.syncModeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncModeLabel.Location = new System.Drawing.Point(36, 213);
            this.syncModeLabel.Name = "syncModeLabel";
            this.syncModeLabel.Size = new System.Drawing.Size(73, 17);
            this.syncModeLabel.TabIndex = 20;
            this.syncModeLabel.Text = "Sync Mode";
            // 
            // syncConditionLabel
            // 
            this.syncConditionLabel.AutoSize = true;
            this.syncConditionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncConditionLabel.Location = new System.Drawing.Point(371, 213);
            this.syncConditionLabel.Name = "syncConditionLabel";
            this.syncConditionLabel.Size = new System.Drawing.Size(27, 17);
            this.syncConditionLabel.TabIndex = 20;
            this.syncConditionLabel.Text = "MB";
            this.syncConditionLabel.Visible = false;
            // 
            // syncCondition
            // 
            this.syncCondition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncCondition.Location = new System.Drawing.Point(289, 210);
            this.syncCondition.Name = "syncCondition";
            this.syncCondition.Size = new System.Drawing.Size(76, 25);
            this.syncCondition.TabIndex = 8;
            this.syncCondition.Visible = false;
            this.syncCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.syncCondition_KeyPress);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(495, 469);
            this.Controls.Add(this.syncConditionLabel);
            this.Controls.Add(this.syncCondition);
            this.Controls.Add(this.syncMode);
            this.Controls.Add(this.syncModeLabel);
            this.Controls.Add(this.labelSeparator);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.targetProgressBar);
            this.Controls.Add(this.sourceProgressBar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sourcePathInfoText);
            this.Controls.Add(this.targetDriveInfoLabel);
            this.Controls.Add(this.targetDriveInfoText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.browseButtonTarget);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.sourcePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.syncButton);
            this.Controls.Add(this.pathDrive);
            this.Controls.Add(this.targetPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deletefiles);
            this.Controls.Add(this.filetype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.driveletter);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Shuffle Sync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox driveletter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox filetype;
        private System.Windows.Forms.CheckBox deletefiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox targetPath;
        private System.Windows.Forms.Label pathDrive;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sourcePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button browseButtonTarget;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label targetDriveInfoText;
        private System.Windows.Forms.Label targetDriveInfoLabel;
        private System.Windows.Forms.Label sourcePathInfoText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar sourceProgressBar;
        private System.Windows.Forms.ProgressBar targetProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label labelSeparator;
        private System.Windows.Forms.ComboBox syncMode;
        private System.Windows.Forms.Label syncModeLabel;
        private System.Windows.Forms.Label syncConditionLabel;
        private System.Windows.Forms.TextBox syncCondition;
        private System.Windows.Forms.ToolTip fileType_helper;
    }
}

