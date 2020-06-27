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
        }

        private void systemFilesTreeView_AfterSelect(object sender, TreeViewEventArgs e) {

        }
        private void systemFilesTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e) {

            if (e.Node.Nodes.Count > 0) {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null) {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs) {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException) {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void loginButton_Click(object sender, EventArgs e) {
            ctrl.login();
        }

        private void registerButton_Click(object sender, EventArgs e) {
 
            // Update model
            userInfo.Username = usernameTextBox.Text;
            userInfo.Password = passwordTextBox.Text;

            ctrl.register();
        }

        private void logoutButton_Click(object sender, EventArgs e) {
            ctrl.logout();
        }

        private void decryptionButton_Click(object sender, EventArgs e) {
            ctrl.decodeFile();
        }

        private void MainView_Load(object sender, EventArgs e) {

            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives) {
                DriveInfo di = new DriveInfo(drive);

                TreeNode node = new TreeNode(drive.Substring(0, 1));
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                systemFilesTreeView.Nodes.Add(node);
            }
        }
    }
}
