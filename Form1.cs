using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Explorer
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const string message = "New name here (without: /\\:*?«<>|)";
        private char[] wrongCharactersForNameFile = { '/', '\\', ':', '*', '?', '«', '<', '>', '|' };

        public Form()
        {
            InitializeComponent();
            NewNameField.Text = message;
        }

        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFile();
        }

        private void treeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OpenFile();
            else if (e.KeyCode == Keys.Delete)
                DeleteFile();
            else if (e.KeyCode == Keys.F2)
                RenameFile();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    PathField.Text = fbd.SelectedPath;
                    BuildTree(fbd.SelectedPath);
                }
            }
        }

        private void NewNameField_MouseClick(object sender, MouseEventArgs e)
        {
            NewNameField.Text = "";
        }

        private void BuildTree(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (directoryInfo.Exists)
            {
                treeView.Nodes.Clear();
                BuildTree(directoryInfo, treeView.Nodes);
                //Вuild_tree_oly_o_evet,_forexampleifyouserwotclick_oH_it,_it_wottвuild_tree
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);
            curNode.Tag = directoryInfo.FullName;

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                TreeNode node = curNode.Nodes.Add(file.FullName, file.Name);
                node.Tag = file.FullName;
            }

            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                BuildTree(subdir, curNode.Nodes);
        }

        private void OpenFile()
        {
            if (treeView.SelectedNode != null)
            {
                string path = treeView.SelectedNode.Tag as string;

                if (!string.IsNullOrEmpty(path))
                    System.Diagnostics.Process.Start(path);
            }
        }

        private void RenameFile()
        {
            if (treeView.SelectedNode != null && !string.IsNullOrEmpty(NewNameField.Text.Trim()))
            {
                foreach (char item in wrongCharactersForNameFile)
                {
                    if (NewNameField.Text.Contains(item))
                    {
                        NewNameField.Text = message;
                        return;
                    }
                }

                string oldPath = treeView.SelectedNode.Tag as string;

                if (!string.IsNullOrEmpty(oldPath))
                {
                    FileAttributes fileAttributes = File.GetAttributes(oldPath);

                    if (fileAttributes.HasFlag(FileAttributes.Directory))
                    {
                        if (Directory.Exists(oldPath))
                        {
                            string parentDirectory = Directory.GetParent(oldPath).FullName;
                            string newPath = parentDirectory + "\\" + NewNameField.Text.Trim();

                            if (Directory.Exists(newPath))
                            {
                                NewNameField.Text = "Directory is exist";
                                return;
                            }
                            else
                            {
                                if (treeView.SelectedNode.Parent == null)
                                    PathField.Text = newPath;

                                treeView.SelectedNode.Text = NewNameField.Text.Trim();
                                Directory.Move(oldPath, newPath);
                                BuildTree(PathField.Text);
                            }
                        }
                    }
                    else
                    {
                        if (File.Exists(oldPath))
                        {
                            string fileDirectory = Path.GetDirectoryName(oldPath);
                            string ext = Path.GetExtension(oldPath);
                            string newPath = fileDirectory + "\\" + NewNameField.Text.Trim() + ext;

                            if (File.Exists(newPath))
                            {
                                NewNameField.Text = "File is exist";
                                return;
                            }
                            else
                            {
                                treeView.SelectedNode.Text = NewNameField.Text.Trim() + ext;
                                File.Move(oldPath, newPath);
                                BuildTree(PathField.Text);
                            }
                        }
                    }
                }

                NewNameField.Text = message;
            }
        }

        private void DeleteFile()
        {
            if (treeView.SelectedNode != null)
            {
                string path = treeView.SelectedNode.Tag as string;

                if (!string.IsNullOrEmpty(path))
                {
                    FileAttributes fileAttributes = File.GetAttributes(path);

                    if (fileAttributes.HasFlag(FileAttributes.Directory))
                    {
                        if (Directory.Exists(path))
                        {
                            if (treeView.SelectedNode.Parent == null)
                                treeView.Nodes.Remove(treeView.SelectedNode);
                            else
                                treeView.SelectedNode.Parent.Nodes.Remove(treeView.SelectedNode);

                            Directory.Delete(path, true);
                        }
                    }
                    else
                    {
                        if (File.Exists(path))
                        {
                            if (treeView.SelectedNode.Parent == null)
                                treeView.Nodes.Remove(treeView.SelectedNode);
                            else
                                treeView.SelectedNode.Parent.Nodes.Remove(treeView.SelectedNode);

                            File.Delete(path);
                        }
                    }
                }
            }
        }
    }
}
