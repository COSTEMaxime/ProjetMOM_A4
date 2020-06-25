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

        User user;
        ApplicationInfo app;

        IAction action;

        public MainView() {
            InitializeComponent();
            user = new User();
            app = new ApplicationInfo();
        }

        private void systemFilesTreeView_AfterSelect(object sender, TreeViewEventArgs e) {

        }

        private void loginButton_Click(object sender, EventArgs e) {
            action = new UserAction(new LoginMessenger(user, app));
            action.carryOut();
        }

        private void registerButton_Click(object sender, EventArgs e) {
            action = new UserAction(new RegisterMessenger(user, app));
            action.carryOut();
        }

        private void logoutButton_Click(object sender, EventArgs e) {
            // action = new UserAction(new LogoutMessenger(user, app));
            // action.carryOut();
            throw new NotImplementedException();
        }

        private void decryptionButton_Click(object sender, EventArgs e) {
            action = new UserAction(new FileDecodeMessenger(user, app));
            action.carryOut();
        }
    }
}
