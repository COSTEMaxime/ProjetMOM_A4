using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
