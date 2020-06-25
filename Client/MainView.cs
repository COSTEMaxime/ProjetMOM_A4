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

        public MainView() {
            InitializeComponent();
            user = new User();
        }

        private void systemFilesTreeView_AfterSelect(object sender, TreeViewEventArgs e) {

        }

        private void loginButton_Click(object sender, EventArgs e) {
            if(usernameTextBox.Text != "" && passwordTextBox.Text != "") {

                // Update Model
                user.username = usernameTextBox.Text;
                user.password = passwordTextBox.Text;

                // Generate Message
                MiddlewareService.Message msg = new MiddlewareService.Message();
                msg.operationName = "login";
                msg.info = "LET ME IIIIN !!!";
                msg.data = new Object[1];
                msg.data.Append(user);

                // Send to server
                MiddlewareService.ServiceEntryPointClient client = new MiddlewareService.ServiceEntryPointClient();
                client.AccessService(msg);

                consoleTextBox.AppendText("Sent message do server.\n");
                
            } else {
                consoleTextBox.AppendText("Enter a correct username or password.\n");
            }
        }
    }
}
