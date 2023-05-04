using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__Backup
{
	public partial class appForm : Form
	{
		public appForm() { InitializeComponent(); }

		//TODO: Auto find user path
		// Default Directories
		private static readonly string userDir = "C:\\Users\\k7a-1\\"; // Directory From (Source)
		private static readonly string backupDir = "E:\\TEMPBackup\\"; // Directory To (Destination)
		private static readonly string backupOtherDir = "E:\\TEMPBackup\\_Others\\"; // Path for nameFile list
		private static readonly string nameFileTxt = backupOtherDir + DateTime.Now.ToString("hhmmss-ddMMyy") + "-NameFile.txt"; // The .txt for name file list
		// Directory list
		private readonly string[,] copyFolder = {
				{ userDir + @"AppData\Local\",      backupDir + @"AppData\Local\" },
				{ userDir + @"AppData\Roaming\",    backupDir + @"AppData\Roaming\" },
				{ userDir + @"AppData\LocalLow\",   backupDir + @"AppData\LocalLow\" },
				{ userDir + @"Desktop\",            backupDir + @"Desktop\" },
				{ userDir + @"Documents\",          backupDir + @"Documents\" },
				{ userDir + @"Downloads\",          backupDir + @"Downloads\" },
				{ userDir + @"Music\",              backupDir + @"Music\" },
				{ userDir + @"Pictures\",           backupDir + @"Pictures\" },
				{ userDir + @"Saved Games\",        backupDir + @"Saved Games\" },
				{ userDir + @"Videos\",             backupDir + @"Videos\" },
				{ @"D:\Universidade\",              backupDir + @"DriveD\Universidade\" },
				{ @"D:\Soundboard\",                backupDir + @"DriveD\Soundboard\" },
				{ @"D:\Projects\",                  backupDir + @"DriveD\Projects\" },
				{ @"D:\Games\",                     backupDir + @"DriveD\Games\" },
			}; // Folders will copy to path 1 to path 2
		private readonly string[] nameFile = {
				"C:\\Program Files\\",
				"C:\\Program Files (x86)\\",
				"C:\\Program Files\\Ameaca\\"
			}; // Will get all name of folder in path and write in txt file
        
		private bool CheckRawDirectories()
		{
			string[] folders = { userDir, backupDir, backupOtherDir };
			string[] files = { nameFileTxt };

            for (int i = 0; i < folders.GetLength(0); i++)
            {
                if (Directory.Exists(folders[i])) { continue; } // userDir will be always good
                else
				{
                    try { Directory.CreateDirectory(folders[i]); }
                    catch { return false; }
                }
            }
            for (int i = 0; i < files.GetLength(0); i++)
            {
                if (File.Exists(files[i])) { continue; }
                else
                {
                    try { File.Create(files[i]).Close(); }
                    catch { return false; }
                }
            }
            return true;
        }

        private bool CheckDirectories()
        {
            bool allgood = true;
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if ((bool)dataGrid.Rows[i].Cells[0].Value == false) { continue; } // If backup is false, pass
                // From
                if (!Directory.Exists(dataGrid.Rows[i].Cells[1].Value.ToString()))
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    allgood = false;
                }
                else { dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen; }
                // To
                if (!Directory.Exists(dataGrid.Rows[i].Cells[2].Value.ToString()))
                {
                    // Try Create one
                    try
                    {
                        Directory.CreateDirectory(dataGrid.Rows[i].Cells[2].Value.ToString());
                        dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                    }
                    catch
                    {
                        dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        allgood = false;
                    }
                }
                else { dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen; }
            }
            return allgood;
        }

		private void ResetGrid()
		{
            // Removed existing rows in DataGridView
            dataGrid.Rows.Clear();

            int lencf = copyFolder.GetLength(0);

            // Adding in DataGridView
            for (int i = 0; i < lencf; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = true;
                dataGrid.Rows[i].Cells[1].Value = copyFolder[i, 0].ToString();
                dataGrid.Rows[i].Cells[2].Value = copyFolder[i, 1].ToString();
            }

            for (int i = lencf; i < lencf + nameFile.Length; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrchid;
                dataGrid.Rows[i].Cells[0].Value = true;
                dataGrid.Rows[i].Cells[1].Value = nameFile[i - lencf].ToString();
                dataGrid.Rows[i].Cells[2].Value = backupOtherDir;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fromDialog = new FolderBrowserDialog
			{
				ShowNewFolderButton = true,
				Description = "Select the source directory to add in list to backup",
				RootFolder = Environment.SpecialFolder.MyComputer
			};
			fromDialog.ShowDialog();
			string from = fromDialog.SelectedPath;

			if ( from == "" ) { return; }

			FolderBrowserDialog toDialog = new FolderBrowserDialog
			{
				ShowNewFolderButton = true,
				Description = "Select the destination directory to add in list to backup",
				RootFolder = Environment.SpecialFolder.MyComputer
			};
			toDialog.ShowDialog();
			string to = toDialog.SelectedPath;

			if (to == "") { return; }

			object[] param = { true, from, to };
			dataGrid.Rows.Add(param);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ResetGrid();
        }

		private void btnSave_Click(object sender, EventArgs e)
		{

		}

		private void btnImport_Click(object sender, EventArgs e)
		{

		}
		
		private void btnBackup_Click(object sender, EventArgs e)
		{
            if (CheckRawDirectories() == false) { return; } // Check raw directories errors
            if (CheckDirectories() == false) { return; } // Check directories errors


            // Save dataGrid values to lists
            List<string> ns = new List<string>();
            List<string[]> ft = new List<string[]>();
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if ((bool)dataGrid.Rows[i].Cells[0].Value == false) { continue; } // If backup is false, pass

                if (dataGrid.Rows[i].Cells[2].Value.ToString().Equals(backupOtherDir)) // Compare the To
                { ns.Add(dataGrid.Rows[i].Cells[1].Value.ToString()); } // Save only the From
                else
                { ft.Add(new string[2] { dataGrid.Rows[i].Cells[1].Value.ToString(), dataGrid.Rows[i].Cells[2].Value.ToString() }); }
            }


            // Prepare Backup Dialog
            BackupDialog bd = new BackupDialog(ns, ft, nameFileTxt, backupOtherDir);
			bd.ShowDialog();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			HelpDialog a = new HelpDialog();
			a.ShowDialog();
		}

        private void appForm_Load(object sender, EventArgs e)
        {
			ResetGrid();
        }
    }
}
