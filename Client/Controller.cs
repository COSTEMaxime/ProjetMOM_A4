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
            Application.Run(view);
        }

        public List<string> loadSubDirectories(string directory) {
            return dao.getSubDirectoriesAndFiles(directory);
        }

        private void updateViewConsole(MiddlewareService.Message response) {
            if(response.operationStatus != true) {
                view.appendConsole("[ERROR] ");
            }
            view.appendConsole(response.info + "\n");
        }

        public async void login(string username, string password) {

            if(userInfo.IsLoggedIn == false) {
                // Update Model
                userInfo.Username = username;
                userInfo.Password = password;

                view.appendConsole("Logging in ...\n");

                // Send message to middleware
                IAction action = new UserAction(new LoginMessenger(userInfo, appInfo));
                MiddlewareService.Message response = await Task.Run(() => action.carryOut());

                if(response.operationStatus == true) {
                    // Update model
                    userInfo.Token = (string)response.data[0];
                    userInfo.IsLoggedIn = true;

                    view.appendConsole("Successfully logged in as " + userInfo.Username + "\n");
                } else {
                    view.appendConsole("ERROR : " + response.info + "\n");
                }
            } else {
                view.appendConsole("User is already logged in, please log out first !\n");
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
                view.appendConsole("Cannot log user out : Please log in first.\n");
            }
        }

        public async void register(string username, string password, string email) {
            view.appendConsole("Registering ...\n");

            // Update model
            userInfo.Username = username;
            userInfo.Password = password;
            userInfo.Email = email;

            // Send message to middleware
            IAction action = new UserAction(new RegisterMessenger(userInfo, appInfo));
            Client.MiddlewareService.Message response = await Task.Run(() => action.carryOut());
            
            if(response.operationStatus == true) {
                view.appendConsole("Successfully created user !\n");
            } else {
                view.appendConsole("ERROR : " + response.info + "\n");
            }
        }

        public async void decodeFiles(string[] files) {
            view.appendConsole("Decoding file(s) ...\n");

            // Retreiving file contents
            string[] contents = dao.getFilesContent(files);
            Dictionary<string, string> data = new Dictionary<string, string>();
            
            for(int i = 0; i < files.Length; i++)
                data.Add(files[i], contents[i]);

            // Sending message to server
            IAction action = new UserAction(new FileDecodeMessenger(userInfo, appInfo, data));
            MiddlewareService.Message response = await Task.Run(() => action.carryOut());

            if(response.operationStatus == true) {
                view.appendConsole("Ok.\n");
            } else {
                view.appendConsole("ERROR : " + response.info + "\n");
            }
        }
    }
}
