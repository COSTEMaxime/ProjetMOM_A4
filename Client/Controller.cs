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

        public async void login() {
            view.appendConsole("Logging in ...\n");
            IAction action = new UserAction(new LoginMessenger(userInfo, appInfo));
            updateViewConsole(await Task.Run(() => action.carryOut()));
        }

        public async void logout() {
            throw new NotImplementedException();
        }

        public async void register() {
            view.appendConsole("Registering ...\n");
            IAction action = new UserAction(new RegisterMessenger(userInfo, appInfo));
            updateViewConsole(await Task.Run(() => action.carryOut()));
        }

        public async void decodeFiles(string[] files) {
            view.appendConsole("Decoding file(s) ...\n");
            string[] contents = dao.getFilesContent(files);
            IAction action = new UserAction(new FileDecodeMessenger(userInfo, appInfo, contents));
            updateViewConsole(await Task.Run(() => action.carryOut()));
        }
    }
}
