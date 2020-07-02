using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client {
    public class Controller {

        User userInfo;
        ApplicationInfo appInfo;
        MainView view;
        DAO dao;

        public Controller() {
            this.userInfo = new User();
            this.appInfo = new ApplicationInfo();
            this.dao = new DAO();

            appInfo.Token = "client";

            InitView();
        }

        private void InitView() {
            view = new MainView(userInfo, appInfo, this);
            view.loadDrives(dao.getDrives());
            Application.Run(view);
        }

        public string[] loadSubDirectories(string directoryName) {
            return dao.getSubDirectories(directoryName);
        }

        public string[] loadDirectoryFiles(string directoryName) {
            return dao.getDirectoryFiles(directoryName);
        }

        public async void login(string username, string password) {

            if(userInfo.IsLoggedIn == false) {

                if(username != "" && password != "") {
                    view.appendConsole("Logging in ...\n");

                    // Update Model
                    userInfo.Username = username;
                    userInfo.Password = password;

                    // Send message to middleware
                    IAction action = new UserAction(new LoginMessenger(userInfo, appInfo));
                    MiddlewareService.Message response = await Task.Run(() => action.carryOut());

                    if (response.operationStatus == true) {
                        // Update model
                        userInfo.Token = (string)response.data[0];
                        userInfo.IsLoggedIn = true;

                        view.appendConsole("Successfully logged in as " + userInfo.Username + "\n");
                    }
                    else {
                        view.appendConsole("ERROR : " + response.info + "\n");
                    }
                } else {
                    view.appendConsole("ERROR : Invalid username or password.\n");
                }
            } else {
                view.appendConsole("ERROR : User is already logged in, please log out first !\n");
            }
        }

        public async void logout() {

            if(userInfo.IsLoggedIn == true) {
                view.appendConsole("Logging out ...\n");

                // Send message to server
                IAction action = new UserAction(new LogoutMessenger(userInfo, appInfo));
                MiddlewareService.Message response = await Task.Run(() => action.carryOut());

                if (response.operationStatus == true) {
                    // Update Model
                    userInfo.Username = "";
                    userInfo.Password = "";
                    userInfo.IsLoggedIn = false;

                    view.appendConsole("Logged out successfully !\n");
                } else {
                    view.appendConsole("ERROR : " + response.info + "\n");
                }
            } else {
                view.appendConsole("ERROR : Cannot log user out : Please log in first.\n");
            }
        }

        public async void register(string username, string password, string email) {
            
            if(username != "" && password != "" && email.Contains("@")) {
                view.appendConsole("Registering ...\n");

                // Update model
                userInfo.Username = username;
                userInfo.Password = password;
                userInfo.Email = email;

                // Send message to middleware
                IAction action = new UserAction(new RegisterMessenger(userInfo, appInfo));
                Client.MiddlewareService.Message response = await Task.Run(() => action.carryOut());

                if (response.operationStatus == true) {
                    view.appendConsole("Successfully created user !\n");
                } else {
                    view.appendConsole("ERROR : " + response.info + "\n");
                }
            } else {
                view.appendConsole("ERROR : Invalid username, password or email.\n");
            }
        }

        public async void decodeFiles(string[] files) {
            if(files.Length > 0) {
                // Retreiving file contents
                byte[][] contents = dao.getFilesContents(files);
                Dictionary<string, byte[]> data = new Dictionary<string, byte[]>();

                for (int i = 0; i < files.Length; i++)
                    if(contents[i].Length > 0)
                        data.Add(files[i], contents[i]);

                if(data.Count() > 0) {
                    view.appendConsole("Decoding file(s) ...\n");

                    // Sending message to server
                    IAction action = new UserAction(new FileDecodeMessenger(userInfo, appInfo, data));
                    MiddlewareService.Message response = await Task.Run(() => action.carryOut());

                    if (response.operationStatus == true) {
                        view.appendConsole("Ok.\n");
                    }
                    else {
                        view.appendConsole("ERROR : " + response.info + "\n");
                    }
                } else {
                    view.appendConsole("ERROR : Directory dosen't contain any files.\n");
                }
            } else {
                view.appendConsole("ERROR : No file selected.\n");
            }
        }
    }
}
