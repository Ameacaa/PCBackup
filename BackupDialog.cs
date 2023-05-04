using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace C__Backup
{
	public partial class BackupDialog : Form
	{
		private List<string> ns;
		private List<string[]> ft;
		private string nameFileTxt;
		private string backupOtherDir;

		public BackupDialog(List<string> ns, List<string[]> ft, string nameFileTxt, string backupOtherDir)
		{
			this.ns = ns;
			this.ft = ft;
			this.nameFileTxt = nameFileTxt;
			this.backupOtherDir = backupOtherDir;
			InitializeComponent();
		}

		public void Set(string from = "", string to = "", string info = "", int actual = -1, int backup = -1)
		{
			if (from != "") txtFromDir.Text = "From Directory: " + from;
			if (to != "") txtToDir.Text = "To Directory: " + to;
			if (info != "") txtInfo.Text = "Info:\nNot Implemented";
			if (actual != -1) prgsActual.Value = actual;
			if (backup != -1) prgsBackup.Value = backup;
			Refresh();
		}
		private void BackupDialog_Load(object sender, EventArgs e)
		{
			// Doing NameFolder to txt file
			for (int i = 0; i < ns.Count; i++)
			{
				Set(to: backupOtherDir);
				Set(from: ns[i], actual: 0);
				List<string> names = Directory.GetFileSystemEntries(ns[i]).ToList();
				Set(actual: 50);
                File.Create(nameFileTxt).Close();
                File.AppendAllLines(nameFileTxt, names);
				Set(actual: 100);
			}
			Set(backup: 3);

			// Copy Folders
			for (int i = 0; i < ft.Count; i++)
			{
				Set(from: ft[i][0], to: ft[i][0], actual: 0);
				
				// TODO: Copy directories
				// TODO: Make info folder string

				Set(backup: 3 + ((i+1) * 97 / ft.Count));
			}

			Close();
		}
	}
}
