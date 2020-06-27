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

        IAction action;

        public Controller(User userInfo, ApplicationInfo appInfo) {
            this.userInfo = userInfo;
            this.appInfo = appInfo;

            appInfo.Token = "client";

            InitView();
        }

        private void updateViewConsole(MiddlewareService.Message response) {
            if(response.operationStatus != true) {
                view.appendConsole("[ERROR] ");
            }
            view.appendConsole(response.info + "\n");
        }

        private void InitView() {
            view = new MainView(userInfo, appInfo, this);
            Application.Run(view);
        }

        public async Task login() {
            view.appendConsole("Logging in ...\n");
            action = new UserAction(new LoginMessenger(userInfo, appInfo));
            updateViewConsole(await Task.Run(() => action.carryOut()));
        }

        public async Task logout() {
            // action = new UserAction(new LogoutMessenger(userInfo, appInfo));
            // action.carryOut();
            throw new NotImplementedException();
        }

        public async Task register() {
            view.appendConsole("Registering ...\n");
            action = new UserAction(new RegisterMessenger(userInfo, appInfo));
            updateViewConsole(await Task.Run(() => action.carryOut()));
        }

        public async Task decodeFile() {
            view.appendConsole("Decoding file ...\n");
            action = new UserAction(new FileDecodeMessenger(userInfo, appInfo));
            updateViewConsole(await Task.Run(() => action.carryOut()));
        }
    }
}
