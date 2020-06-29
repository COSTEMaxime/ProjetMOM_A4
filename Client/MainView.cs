using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client {
    public partial class MainView : Form {

        User userInfo;
        ApplicationInfo appInfo;
        Controller ctrl;

        public MainView(User userInfo, ApplicationInfo appInfo, Controller ctrl) {
            InitializeComponent();
            this.userInfo = userInfo;
            this.appInfo = appInfo;
            this.ctrl = ctrl;
        }

        public void appendConsole(string message) {
            consoleTextBox.AppendText(message);
            consoleTextBox.ScrollToCaret();
        }

        private void MainView_Load(object sender, EventArgs e) {
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives) {
                DriveInfo di = new DriveInfo(drive);

                TreeNode node = new TreeNode(drive.Substring(0, 2));
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                systemFilesTreeView.Nodes.Add(node);
            }
        }

        private void systemFilesTreeView_AfterSelect(object sender, TreeViewEventArgs e) {

        }

        private void systemFilesTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e) {

            if (e.Node.Nodes.Count > 0) {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null) {
                    e.Node.Nodes.Clear();

                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
                    foreach (var file in rootDir.GetFiles()) {
                        TreeNode n = new TreeNode(file.Name, 13, 13);
                        e.Node.Nodes.Add(n);
                    }

                    foreach (string dir in dirs) {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try {
                            node.Tag = dir;

                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);

                            foreach (var file in di.GetFiles()) {
                                TreeNode n = new TreeNode(file.Name, 13, 13);
                                node.Nodes.Add(n);
                            }

                        } catch (UnauthorizedAccessException) {
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } finally {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void loginButton_Click(object sender, EventArgs e) {
            ctrl.login(usernameTextBox.Text, passwordTextBox.Text);
        }

        private void registerButton_Click(object sender, EventArgs e) {
             ctrl.register(usernameTextBox.Text, passwordTextBox.Text, emailTextBox.Text);
        }

        private void logoutButton_Click(object sender, EventArgs e) {
            ctrl.logout();
        }

        private void decryptionButton_Click(object sender, EventArgs e) {
            List<string> files = new List<string>();
            files.Add(systemFilesTreeView.SelectedNode.FullPath);

            ctrl.decodeFiles(files.ToArray());
        }
    }
}
