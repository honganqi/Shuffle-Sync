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

using PortableDeviceApiLib;
using PortableDeviceTypesLib;

namespace Shuffle_Sync
{
    public partial class MainWindow : Form
    {
        bool fromSourceTextBox = true;
        DriveInfo[] drives = DriveInfo.GetDrives();
        public MainWindow()
        {
            InitializeComponent();
            InitializeDriveLetters();
            CommonFileTypes();

            // initialize form from settings
            sourcePath.Text = Properties.Settings.Default["sourcePath"].ToString();
            filetype.Text = Properties.Settings.Default["filetype"].ToString();
            targetPath.Text = Properties.Settings.Default["targetPath"].ToString();
            syncMode.SelectedIndex = (int)Properties.Settings.Default["syncMode"];
            syncCondition.Text = Properties.Settings.Default["syncCondition"].ToString();

            fileType_helper.SetToolTip(filetype, "Separate file types with a comma (\",\")");

            var deletefilesInit = Convert.ToBoolean(Properties.Settings.Default["deletefiles"]);
            if (deletefilesInit == true)
            {
                deletefiles.Checked = true;
            }
            else
            {
                deletefiles.Checked = false;
            }

            DriveInfo[] drives = DriveInfo.GetDrives();
            if (driveletter.SelectedIndex < 0)
            {
                driveletter.SelectedIndex = 0;
            }
            pathDrive.Text = '(' + drives[driveletter.SelectedIndex].ToString() + ')';
            getDriveInfo(drives[driveletter.SelectedIndex].ToString());
        }



        // main sync button
        private void button1_Click(object sender, EventArgs e)
        {
            bool goSync = false;
            bool deleteFilesConfirm = false;
            String fullTargetPath = drives[driveletter.SelectedIndex].ToString() + targetPath.Text;

            // check if source path is valid
            if (CheckSourcePath(sourcePath.Text) == false)
            {
                MessageBox.Show("Source path is invalid or does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {

                // check if path in target path is valid
                if (CheckTargetPath(fullTargetPath) == true)
                {
                    // check drive type
                    if (drives[driveletter.SelectedIndex].DriveType.ToString() != "Removable")
                    {
                        DialogResult typeDialog = MessageBox.Show("This drive is detected as a fixed drive. Are you sure you want to sync to this drive?", "Drive is not removable", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (typeDialog == DialogResult.Yes) goSync = true;
                    }
                    else
                    {
                        goSync = true;
                    }

                    // check drive size
                    if (CheckDriveSize() > 0)
                    {
                        long targetDriveSize = CheckDriveSize();
                        DialogResult sizeDialog = MessageBox.Show("This drive has a capacity of " + FormatBytes(targetDriveSize) + " which is unusual for a removable drive. Are you sure you want to sync to this drive?", "Unusual Size", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (sizeDialog == DialogResult.Yes) goSync = true;
                    }
                    else
                    {
                        goSync = true;
                    }

                    // check if "delete" is selected (skip if target path does not exist)
                    if (deletefiles.Checked == true)
                    {
                        DialogResult deleteDialog = MessageBox.Show("Are you sure you want to delete all files in this directory before syncing?", "Delete all files?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (deleteDialog == DialogResult.Yes)
                        {
                            deleteFilesConfirm = true;
                            goSync = true;
                        } else
                        {
                            goSync = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Target path is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (goSync == true)
            {
                if (deleteFilesConfirm == true)
                {
                    DirectoryInfo targetDirectory = new DirectoryInfo(fullTargetPath);
                    deleteDirectoryContents(targetDirectory);
                }

                startSync(fullTargetPath);
                getDriveInfo(Path.GetPathRoot(fullTargetPath));
            }
        }







        //   FUNCTIONS    //
        private void startSync(string fullTargetPath)
        {
            syncButton.Enabled = false;
            labelSeparator.Visible = false;
            targetProgressBar.Visible = true;
            cancelButton.Visible = true;

            string[] randomizedFiles = DirSearch(sourcePath.Text, filetype.Text);
            DriveInfo[] drives = DriveInfo.GetDrives();
            DriveInfo selecteddrive = drives[driveletter.SelectedIndex];
            long devicefreespace = selecteddrive.AvailableFreeSpace;
            int filecount = randomizedFiles.Length;
            int syncvalue;
            syncvalue = int.Parse(syncCondition.Text);

            switch (syncMode.SelectedIndex)
            {
                case 0: // 0: until full
                    syncvalue = 0;
                    break;
                case 1: // 1: leave free space
                    devicefreespace = devicefreespace - ((long)syncvalue * 1024 * 1024);
                    break;
                case 2: // 2: number of files
                    filecount = int.Parse(syncCondition.Text);
                    break;
                case 3: // 3: up to file size
                    devicefreespace = ((long)syncvalue * 1024 * 1024);
                    break;
            }

            // background worker
            // fullTargetPath, filecount, randomizedFiles, devicefreespace
            object[] parameters = new object[] { fullTargetPath, filecount, randomizedFiles, devicefreespace, syncMode.SelectedIndex, syncvalue };
            backgroundWorker1.RunWorkerAsync(parameters);
        }

        private long CheckDriveSize()
        {
            long driveSize = 64000000000;
            DriveInfo[] drives = DriveInfo.GetDrives();
            if (drives[driveletter.SelectedIndex].TotalSize > driveSize)
            {
                return drives[driveletter.SelectedIndex].TotalSize;
            } else
            {
                return 0;
            }
        }

        // check source path media and display info/progress bar
        private void sourcePathInfo(String directory)
        {
            sourceProgressBar.Visible = true;
            String[] fileList = DirSearch(this.sourcePath.Text, filetype.Text);
            int filecount = fileList.Length;
            sourceProgressBar.Minimum = 0;
            sourceProgressBar.Maximum = filecount;
            Int64[] sizesize = new Int64[filecount];
            for (int i = 0; i < filecount; i++)
            {
                FileInfo fileinfo = new FileInfo(fileList[i]);
                sizesize[i] = (int)fileinfo.Length;
                sourceProgressBar.Value = i;
            }
            sourceProgressBar.Visible = false;
            sourcePathInfoText.Text = "Source folder size: " + FormatBytes(sizesize.Sum());
        }

        // check path - source
        private bool CheckSourcePath(string sourcePath)
        {
            if (sourcePath != "")
            {
                DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(sourcePath));
                if (Path.IsPathRooted(sourcePath) && (dir.Exists))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        // check path - target
        private bool CheckTargetPath(string targetPath)
        {
            if (targetPath != "")
            {
                DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(targetPath));
                dir.Create();
                return true;
            } else
            {
                return false;
            }

        }

        // get list of files
        string[] DirSearch(string sDir, string filetype)
        {
            // create array of source files
            string[] files = new string[] { };
            string[] tempfiles = new string[] { };
            string[] filetypes;

            if (filetype.Contains(","))
            {
                filetypes = filetype.Split(',');
            } else
            {
                filetypes = new string[1];
                filetypes[0] = filetype;
            }

            foreach (String filetypesingle in filetypes)
            {
                try
                {
                    tempfiles = Directory.GetFiles(sDir, "*." + filetypesingle, SearchOption.AllDirectories);
                    int initialFileCount = files.Length;
                    Array.Resize<string>(ref files, initialFileCount + tempfiles.Length);
                    Array.Copy(tempfiles, 0, files, initialFileCount, tempfiles.Length);
                }
                catch
                {
                    // do nothing when system folder (eg. Recycle Bin) is hit
                }
            }


            int fileCount = files.Length - 1;
            Random rnd = new Random();
            for (int i = 0; i < fileCount; i++)
            {
                string tmp = files[i];
                int tempIndex = rnd.Next(i, fileCount);
                files[i] = files[tempIndex];
                files[tempIndex] = tmp;
            }



            return files;
        }

        // copy file
        bool CopyFile(string sourcePath, string targetDir)
        {
            string sourceFile = System.IO.Path.GetFileName(sourcePath);
            string desintationPath = System.IO.Path.Combine(targetDir, sourceFile);

            try
            {
                System.IO.File.Copy(sourcePath, desintationPath, true);
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        // empty directory
        public static void deleteDirectoryContents(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles())
            {
                file.Attributes = FileAttributes.Normal;
                file.Delete();
            }
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        // get drive information
        private void getDriveInfo(String targetDriveLetter)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            DriveInfo selecteddrive = drives[driveletter.SelectedIndex];
            targetDriveInfoLabel.Text = "- " + targetDriveLetter.Replace("\\", "");
            targetDriveInfoText.Text = "Drive label: " + selecteddrive.VolumeLabel + "\n";
            targetDriveInfoText.Text += "Drive type: " + selecteddrive.DriveType.ToString().ToUpper() + " drive\n";
            targetDriveInfoText.Text += "Capacity: " + FormatBytes(selecteddrive.TotalSize) + "\n";
            targetDriveInfoText.Text += "Free space: " + FormatBytes(selecteddrive.AvailableFreeSpace);
        }

        static String FormatBytes(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0 " + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

        private void checkMode(int selectedMode)
        {
            // 0: until full
            // 1: leave free space
            // 2: number of files
            // 3: up to file size

            switch (syncMode.SelectedIndex)
            {
                case 0: // 0: until full
                    syncCondition.Visible = false;
                    syncConditionLabel.Visible = false;
                    break;
                case 1: // 1: leave free space
                    syncCondition.Visible = true;
                    syncConditionLabel.Visible = true;
                    syncConditionLabel.Text = "MB";
                    break;
                case 2: // 2: number of files
                    syncCondition.Visible = true;
                    syncConditionLabel.Visible = true;
                    syncConditionLabel.Text = "files";
                    break;
                case 3: // 3: up to file size
                    syncCondition.Visible = true;
                    syncConditionLabel.Visible = true;
                    syncConditionLabel.Text = "MB";
                    break;
                default:
                    break;
            }

        }

        private void InitializeDriveLetters()
        {
            string[] logicalDrives = Environment.GetLogicalDrives();
            string[] driveletterCollectionNew = new string[logicalDrives.Length];
            DriveInfo[] drivelist = DriveInfo.GetDrives();

            driveletter.DisplayMember = "Text";
            driveletter.ValueMember = "Value";

            //driveletter.DataSource = drivelist;
            for (int key = 0; key < drivelist.Length; key++)
            {
                driveletter.Items.Add(new { Text = drivelist[key].VolumeLabel + " (" + drivelist[key].ToString().Replace("\\", "") + ") " + FormatBytes(drivelist[key].AvailableFreeSpace) + " free", Value = key });
                if ((Properties.Settings.Default["driveletter"].ToString() != "") && (Directory.Exists(drivelist[key].ToString())))
                {
                    if (drivelist[key].ToString() == Properties.Settings.Default["driveletter"].ToString())
                    {
                        driveletter.SelectedIndex = key;
                    }
                }
            }
        }

        private void CommonFileTypes()
        {
            List<string> commonFileTypes = new List<string>();
            commonFileTypes.Add("mp3");
            commonFileTypes.Add("wma");
            commonFileTypes.Add("ogg");
            commonFileTypes.Add("aac");
            commonFileTypes.Add("flac");
            commonFileTypes.Add("m4a");
            commonFileTypes.Add("wav");
            filetype.DataSource = commonFileTypes;
        }








        //     EVENTS     //
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void driveletter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            DriveInfo selecteddrive = drives[driveletter.SelectedIndex];
            pathDrive.Text = '(' + drives[driveletter.SelectedIndex].ToString() + ')';
            getDriveInfo(drives[driveletter.SelectedIndex].ToString());
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if ((sourcePath.Text != "") && (Directory.Exists(sourcePath.Text)))
            {
                folderBrowserDialog1.SelectedPath = sourcePath.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                fromSourceTextBox = true;
                this.sourcePath.Text = folderBrowserDialog1.SelectedPath;
                if (CheckSourcePath(this.sourcePath.Text))
                {
                    sourcePathInfo(this.sourcePath.Text);
                }
            }
        }

        private void browseButtonTarget_Click(object sender, EventArgs e)
        {
            String fullTargetPath = drives[driveletter.SelectedIndex].ToString() + targetPath.Text;
            if ((fullTargetPath != "") && (Directory.Exists(fullTargetPath)))
            {
                folderBrowserDialog2.SelectedPath = fullTargetPath;
            }
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                String targetPathDrive = Path.GetPathRoot(folderBrowserDialog2.SelectedPath);
                DriveInfo[] drives = DriveInfo.GetDrives();
                // need to get key of selected drive from DriveInfo drivelist based on drive letter
                for (int key = 0; key < drives.Length; key++)
                {
                    if (drives[key].ToString() == targetPathDrive)
                    {
                        driveletter.SelectedIndex = key;
                        targetPath.Text = folderBrowserDialog2.SelectedPath.Replace(targetPathDrive, "");
                        getDriveInfo(targetPathDrive);
                        break;
                    }
                }
            }
        }

        private void sourcePath_Leave(object sender, EventArgs e)
        {
            if (CheckSourcePath(sourcePath.Text))
            {
                sourcePathInfo(sourcePath.Text);
                fromSourceTextBox = true;
            } else
            if (sourcePath.Text != "")
            {
                MessageBox.Show("Source path is invalid or does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void syncMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkMode(syncMode.SelectedIndex);
        }

        private void syncCondition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void filetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != Convert.ToChar(",")))
            {
                e.Handled = true;
            }
        }

        private void filetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourcePathInfo(sourcePath.Text);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            object[] parameters = e.Argument as object[];
            int filesCopied = 0;

            // fullTargetPath, filecount, randomizedFiles, devicefreespace
            string fullTargetPath = (string)parameters[0];
            int filecount = (int)parameters[1];
            string[] randomizedFiles = (string[])parameters[2];
            long devicefreespace = (long)parameters[3];
            int syncmode = (int)parameters[4];
            int syncvalue = (int)parameters[5];
            long copiedsize;
            long transferredsize;
            int progressBarStatus;
            Int64[] sizesize = new Int64[filecount];

            // if sync mode is NOT "leave free space"
            for (int i = 0; i < filecount; i++)
            {
                if (worker.CancellationPending == true)
                {
                    break;
                }
                else
                {
                    if (CopyFile(randomizedFiles[i], fullTargetPath))
                    {
                        break;
                    }
                    else
                    {
                        FileInfo fileinfoko = new FileInfo(randomizedFiles[i]);
                        sizesize[i] = (int)fileinfoko.Length;
                        copiedsize = sizesize.Sum();

                        transferredsize = copiedsize * 100;
                        progressBarStatus = (int)(transferredsize / devicefreespace);
                        if (progressBarStatus > 100)
                        {
                            progressBarStatus = 100;
                            break;
                        }
                        filesCopied++;
                        backgroundWorker1.ReportProgress(progressBarStatus);
                    }
                }
            }



            object[] results = new object[] { filesCopied, sizesize.Sum() };
            e.Result = results;

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            targetProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelSeparator.Visible = true;
            targetProgressBar.Visible = false;
            syncButton.Enabled = true;
            cancelButton.Visible = false;
            DriveInfo[] drives = DriveInfo.GetDrives();
            getDriveInfo(drives[driveletter.SelectedIndex].ToString());
            object[] results = e.Result as object[];
            MessageBox.Show(results[0].ToString() + " files copied!\n(" + FormatBytes((long)results[1]) + ")", "Shuffled!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default["sourcePath"] = sourcePath.Text;
            DriveInfo[] drivelist = DriveInfo.GetDrives();
            Properties.Settings.Default["driveletter"] = drivelist[driveletter.SelectedIndex].ToString();
            Properties.Settings.Default["filetype"] = filetype.Text;
            Properties.Settings.Default["targetPath"] = targetPath.Text;
            Properties.Settings.Default["deletefiles"] = deletefiles.Checked;
            Properties.Settings.Default["syncMode"] = syncMode.SelectedIndex;
            Properties.Settings.Default["syncCondition"] = syncCondition.Text;

            if (Convert.ToBoolean(Properties.Settings.Default["needsUpgrade"]) == true)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default["needsUpgrade"] = false;
            }
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
    }
}
